using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.StepDefinitions
{
    [Binding]
    public class GetStepDefination
    {
        private string _endpoint;
        private RestResponse _response;
        private string _bearerToken = "21db41271537a4de218c2236072efc6e74897f3daf27506ead379fc21598e756"; // Your Bearer token

        [Given(@"I have the API endpoint ""(.*)""")]
        public void GivenIHaveTheAPIEndpoint(string endpoint)
        {
            _endpoint = endpoint; // Store the endpoint
        }

        [When(@"I send a GET request")]
        public async Task WhenISendAGetRequest()
        {
            var client = new RestClient(_endpoint);
            var request = new RestRequest();

            // Add the Bearer token to the request header
            request.AddHeader("Authorization", "Bearer " + _bearerToken);

            _response = await client.ExecuteAsync(request);

            // Log the response content
            Console.WriteLine($"Response Status Code: {(int)_response.StatusCode}");
            Console.WriteLine($"Response Content: {_response.Content}");
        }

        [Then(@"the Get response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
        }

        [Then(@"the Get response should contain the user name")]
        public void ThenTheResponseShouldContainTheUserName()
        {
            Assert.IsTrue(_response.Content.Contains("name"), "Response does not contain the user name.");
        }
    }
}