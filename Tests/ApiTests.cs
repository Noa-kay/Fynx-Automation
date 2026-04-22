using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FynxAutomationProject.Tests
{
    [TestClass]
    public class ApiTests
    {
        private static readonly HttpClient client = new HttpClient();

        [TestMethod]
        public async Task VerifyWebsiteStatusIsOk()
        {
            Console.WriteLine("Starting API Test: Verify Localhost Status");

            string url = "http://localhost:4200/";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                Console.WriteLine($"Response Status Code: {response.StatusCode}");
                Assert.IsTrue(response.IsSuccessStatusCode, "Localhost is not responding. Is the server running?");
            }
            catch (Exception ex)
            {
                Assert.Fail("Could not connect to localhost: " + ex.Message);
            }
        }

        [TestMethod]
        public async Task VerifyWebsiteContentViaApi()
        {
            Console.WriteLine("Starting API Test: Verify Localhost Content");

            string url = "http://localhost:4200/";
            string responseBody = await client.GetStringAsync(url);

            Assert.IsTrue(responseBody.Contains("Fynx"), "The expected text was not found in the page HTML.");

            Console.WriteLine("API Test passed: Content verified on Localhost.");
        }
    }
}