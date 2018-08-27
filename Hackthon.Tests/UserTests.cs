using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Hackthon.Tests
{
    [TestClass]
    public class UserTests
    {
        static HttpClient client = new HttpClient();

        [TestMethod]
        public void SuccessfullLogin()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:3951/api/users"),
                Method = HttpMethod.Post
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsync("http://localhost:3951/api/users", new StringContent("Manel")).Result;
            response.EnsureSuccessStatusCode();

            //// return URI of the created resource.
            //return response.Headers.Location;

            //using (var response = client.PostAsync(request).Result)
            //{
            //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            //}
        }
    }
}
