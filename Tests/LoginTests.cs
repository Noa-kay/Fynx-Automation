using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FynxAutomationProject.Pages;
using OpenQA.Selenium;

namespace FynxAutomationProject.Tests
{
    [TestClass]
    public class LoginTests : BaseTest
    {
        [TestMethod]
        public void VerifyLoginWithValidUser()
        {
            WelcomePage welcome = new WelcomePage(driver);
            welcome.ClickSignIn(); 

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("LielTest", "1234");

            Thread.Sleep(2000);

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                wait.Until(d => d.Url.ToLower().Contains("profile"));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timed out! Current URL is: " + driver.Url);
            }

            Assert.IsTrue(driver.Url.ToLower().Contains("profile"),
                $"Registration failed. The browser stayed at: {driver.Url}");

            Assert.IsTrue(driver.Url.Contains("profile"), "Sign in failed");
        }


    }
}
