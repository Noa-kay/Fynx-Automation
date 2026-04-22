using FynxAutomationProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

namespace FynxAutomationProject.Tests
{
    [TestClass]
    public class RegistrationTests : BaseTest
    {

        public static IEnumerable<object[]> RegistrationData =>
                      ExcelHelper.GetRegistrationData(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "TestData.xlsx"));

        [TestMethod]
        [DynamicData(nameof(RegistrationData))]
        public void RegistrationDataDrivenTest(string user, string email, string pass)
        {
            Random random = new Random();
            string uniqueUser = user + random.Next(100, 999);
            string uniqueEmail = email.Replace("@", $"{random.Next(100, 999)}@");

            Console.WriteLine($"Registering with unique username: {uniqueUser}");

            WelcomePage welcome = new WelcomePage(driver);
            welcome.ClickSignUp();

            RegistrationPage regPage = new RegistrationPage(driver);

            regPage.FillForm(uniqueUser, uniqueEmail, pass, pass);

            Thread.Sleep(2000);

            regPage.ClickSubmit();

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
        }
    }
}