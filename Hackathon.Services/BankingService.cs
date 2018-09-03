using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Services.Interfaces;
using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class BankingService : IBankingService
    {
        IEventRepository _eventRepository;
        IGoalSubscriberRepository _goalSubscriberRepository;

        private string _clientId = "Sandman";
        private string _secret = "NYqAmBKxzJwQmXuxMX3Fc09qh54e7yUmBeIBJjjku-AFwej4Btahljaqhl44UVdp";
        private string _customerId = "24087123452";
        private string _discoveryEndpoint = "https://api-sbx.sbanken.no/identityserver/";
        private string _apiBaseAddress = "https://api-sbx.sbanken.no";
        private string _bankBasePath = "/bank";
        private string _customersBasePath = "/customers";
        
        private readonly HttpClient _client;

        public BankingService(IEventRepository eventRepository, IGoalSubscriberRepository goalSubscriberRepository)
        {
            _eventRepository = eventRepository;
            _goalSubscriberRepository = goalSubscriberRepository;
            _client = GetHttpClient().GetAwaiter().GetResult();
        }

        public async Task TransferToSavingsAccount(int userId)
        {
            var accountsList = await GetAccounts(userId);
        }

        public async Task<AccountsList> GetAccounts(int userId)
        {
            // The application retrieves the customer's information.
            var customerResponse = await _client.GetAsync($"{_customersBasePath}/api/v1/Customers");
            var customerResult = await customerResponse.Content.ReadAsStringAsync();

            // The application retrieves the customer's accounts.
            var accountResponse = await _client.GetAsync($"{_bankBasePath}/api/v1/Accounts");
            var accountResult = await accountResponse.Content.ReadAsStringAsync();
            var accountsList = JsonConvert.DeserializeObject<AccountsList>(accountResult);

            var spesificAccountResponse = await _client.GetAsync($"{_bankBasePath}/api/v1/Accounts/{accountsList.Items[0].AccountId}");
            var spesificAccountResult = await spesificAccountResponse.Content.ReadAsStringAsync();

            return accountsList;

        }

        private async Task<HttpClient> GetHttpClient()
        {

            // First: get the OpenId configuration from Sbanken.
            var discoClient = new DiscoveryClient(_discoveryEndpoint);

            var x = discoClient.Policy = new DiscoveryPolicy()
            {
                ValidateIssuerName = false,
            };

            var discoResult = await discoClient.GetAsync();

            if (discoResult.Error != null)
            {
                throw new Exception(discoResult.Error);
            }

            // The application now knows how to talk to the token endpoint.

            // Second: the application authenticates against the token endpoint
            var tokenClient = new TokenClient(discoResult.TokenEndpoint, _clientId, _secret);

            var tokenResponse = tokenClient.RequestClientCredentialsAsync().Result;

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.ErrorDescription);
            }

            // The application now has an access token.

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseAddress),
                DefaultRequestHeaders =
                {
                    { "customerId", _customerId }
                }
            };

            // Finally: Set the access token on the connecting client. 
            // It will be used with all requests against the API endpoints.
            httpClient.SetBearerToken(tokenResponse.AccessToken);

            return httpClient;
        }
    }
}
