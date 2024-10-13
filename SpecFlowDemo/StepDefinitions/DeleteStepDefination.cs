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
    public class DeleteStepDefination
    {
        private string _endpoint;
        private RestResponse _response;
        private string _bearerToken = "21db41271537a4de218c2236072efc6e74897f3daf27506ead379fc21598e756"; // Your Bearer token


        [Given(@"I have the DELETE API endpoint ""(.*)""")]
        public void GivenIHaveTheDELETEAPIEndpoint(string endpoint)
        {
            _endpoint = endpoint; // Store the endpoint
        }

        [When(@"I send a DELETE request")]
        public async Task WhenISendADELETERequest()
        {
            var client = new RestClient(_endpoint);
            var request = new RestRequest
            {
                Method = Method.Post // Set the method here
            };

            request.AddHeader("Authorization", "Bearer " + _bearerToken);

            // Log request for debugging
            Console.WriteLine($"Request URL: {_endpoint}");

            try
            {
                _response = await client.DeleteAsync(request);

                // Log response for debugging
                Console.WriteLine($"Response Status Code: {(int)_response.StatusCode}");
                Console.WriteLine($"Response Content: {_response.Content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during request: {ex.Message}");
                throw; // Re-throw to handle in the test framework
            }
        }

        [Then(@"the Delete response status code should be (.*)")]
        public void ThenTheDeleteResponseStatusCodeShouldBeAdjustBasedOnExpectedResponse(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
        }

    }
}
