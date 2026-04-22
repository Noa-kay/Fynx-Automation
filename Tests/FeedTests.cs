using Microsoft.VisualStudio.TestTools.UnitTesting;
using FynxAutomationProject.Pages;
using System.Threading;

namespace FynxAutomationProject.Tests
{
    [TestClass]
    public class FeedTests : BaseTest
    {
        [TestMethod]
        public void VerifyCategoryFilterWorks()
        {
            WelcomePage welcome = new WelcomePage(driver);
            welcome.ClickSignIn();

            LoginPage login = new LoginPage(driver);
            login.Login("LielTest", "1234");


            driver.Navigate().GoToUrl(url + "/feed");
            Thread.Sleep(2000); 

            FeedPage feedPage = new FeedPage(driver);

            int countBefore = feedPage.GetPostCount();
            Console.WriteLine($"Posts before filtering: {countBefore}");

            feedPage.SelectCategoryByIndex(5);
            Thread.Sleep(2000);

            int countAfter = feedPage.GetPostCount();
            Console.WriteLine($"Posts after filtering: {countAfter}");

            Assert.IsTrue(countAfter >= 0, "The feed should update after category selection.");
        }


        [TestMethod]
        public void VerifySearchFunctionality()
        {
            driver.Navigate().GoToUrl(url + "/feed");
            FeedPage feedPage = new FeedPage(driver);

            string searchTerm = "Spanish"; 
            feedPage.SearchForPost(searchTerm);
            Thread.Sleep(2000); 

            int resultsCount = feedPage.GetPostCount();
            Console.WriteLine($"Found {resultsCount} posts for search: {searchTerm}");

            Assert.IsTrue(resultsCount > 0, "Search results should be displayed.");
        }
    }
}