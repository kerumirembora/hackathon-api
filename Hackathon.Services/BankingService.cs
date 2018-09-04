using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Services.DataTransferObjects;
using Hackathon.Services.Interfaces;
using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class BankingService : IBankingService
    {
        private readonly IUserRepository _userRepository;

        private string _clientId = "Sandman";
        private string _secret = "NYqAmBKxzJwQmXuxMX3Fc09qh54e7yUmBeIBJjjku-AFwej4Btahljaqhl44UVdp";
        private string _discoveryEndpoint = "https://api-sbx.sbanken.no/identityserver/";
        private string _apiBaseAddress = "https://api-sbx.sbanken.no";
        private string _bankBasePath = "/bank";

        private HttpClient _httpClient;

        public BankingService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> TransferToSavingsAccount(int userId, int transferAmount)
        {
            var user = await _userRepository.Get(userId);
            _httpClient = GetHttpClient(user.SbankenCustomerId).GetAwaiter().GetResult();
            var isTransferValid = await ValidateTransfer(user.OriginDepositAccountId, user.DestinationSavingsAccountId, transferAmount);
            if (!isTransferValid)
                return false;

            var isTransferExecuted = await ExecuteTransfer(user.OriginDepositAccountId, user.DestinationSavingsAccountId, transferAmount);

            return isTransferExecuted;
        }

        private async Task<bool> ExecuteTransfer(string originAccountId, string destinationAccountId, int transferAmount)
        {
            string jsonString = JsonConvert.SerializeObject(new Transfer
            {
                Amount = transferAmount,
                FromAccountId = originAccountId,
                ToAccountId = destinationAccountId,
                Message = "Good boy"
            });
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var transferResponse = await _httpClient.PostAsync($"{_bankBasePath}/api/v1/Transfers", stringContent);

            transferResponse.EnsureSuccessStatusCode();

            return true;
        }

        private async Task<bool> ValidateTransfer(string originAccountId, string destinationAccountId, int transferAmount)
        {
            var accountResponse = await _httpClient.GetAsync($"{_bankBasePath}/api/v1/Accounts");
            var accountResult = await accountResponse.Content.ReadAsStringAsync();
            var accountsList = JsonConvert.DeserializeObject<AccountsList>(accountResult);
            // check if both the saving and deposit accounts exist
            // TO DO: improve this DUMB query
            var bothAccountsExist = accountsList.Items.Any(a => a.AccountId.Equals(originAccountId)) &&
                                    accountsList.Items.Any(a => a.AccountId.Equals(destinationAccountId));
            if (!bothAccountsExist)
                return false;

            // check if the deposit account has enough available balance
            var originAccountResponse = await _httpClient.GetAsync($"{_bankBasePath}/api/v1/Accounts/{originAccountId}");
            var originAccountResult = await originAccountResponse.Content.ReadAsStringAsync();
            var originAccount = JsonConvert.DeserializeObject<AccountItem>(originAccountResult);

            if (originAccount.Item.Available <= transferAmount)
                return false;

            return true;
        }

        private async Task<HttpClient> GetHttpClient(long customerId)
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
                    { "customerId", customerId.ToString() }
                }
            };

            // Finally: Set the access token on the connecting client. 
            // It will be used with all requests against the API endpoints.
            httpClient.SetBearerToken(tokenResponse.AccessToken);

            return httpClient;
        }
    }
}
