using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FynxAutomationProject.Tests
{

    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string url = "http://localhost:4200";


        [TestInitialize]
        public void Setup()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--remote-allow-origins=*");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(url);
            driver.Manage().Cookies.DeleteAllCookies(); 
        }

        [TestCleanup]
        public void Teardown()
        {

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }

        }

    }
}
