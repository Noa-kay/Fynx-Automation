using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FynxAutomationProject.Pages
{
    public class LoginPage : BasePage
    {

        private By usernameField = By.Name("username");
        private By passwordField = By.Name("password");
        private By signInBtn = By.XPath("//button[@type= 'submit']");


        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string user, string pass)
        {
            Console.WriteLine($"Attempting to login with user: {user}");

            driver.FindElement(usernameField).SendKeys(user);
            driver.FindElement(passwordField).SendKeys(pass);

            driver.FindElement(signInBtn).Click();

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url.Contains("profile") || d.Url.Contains("home"));
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Login completed and user session should be active.");
        }
    }
}
