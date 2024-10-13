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
    public class PostStepDefination
    {
        private string _endpoint;
        private RestResponse _response;
        private string _bearerToken = "21db41271537a4de218c2236072efc6e74897f3daf27506ead379fc21598e756"; // Replace with your actual token
        private string _userData;

        [Given(@"I have the POST API endpoint ""(.*)""")]
        public void GivenIHaveThePostAPIEndpoint(string endpoint)
        {
            _endpoint = endpoint;
        }

        [Given(@"I have the user data")]
        public void GivenIHaveTheUserData(string userData)
        {
            _userData = userData;
        }

        [When(@"I send a POST request")]
        public async Task WhenISendAPOSTRequest()
        {
            var client = new RestClient(_endpoint);
            var request = new RestRequest
            {
                Method = Method.Post // Set the method here
            };


            request.AddHeader("Authorization", "Bearer " + _bearerToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_userData); // Adding user data

            // Log request for debugging
            Console.WriteLine($"Request URL: {_endpoint}");
            Console.WriteLine($"Request Body: {_userData}");

            try
            {
                _response = await client.PostAsync(request);

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

        [Then(@"the Post response status code should be (.*)")]
        public void ThenThePostResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.IsNotNull(_response, "Response is null. The POST request may have failed.");
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
        }

        [Then(@"the Post response should contain the user name")]
        public void ThenThePostResponseShouldContainTheUserName()
        {
            Assert.IsNotNull(_response, "Response is null. The POST request may have failed.");
            Assert.IsTrue(_response.Content.Contains("name"), "Response does not contain the user name.");
        }
     }
}

