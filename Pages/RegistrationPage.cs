using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FynxAutomationProject.Pages
{
    public class RegistrationPage : BasePage
    {

        private By usernameField = By.Name("username");
        private By emailField = By.CssSelector("input[type='email']");
        private By titleLabel = By.ClassName("app-title");
        private By submitButton = By.XPath("//button[@type='submit']");
        private By passwordField = By.Name("password");
        private By confirmPasswordField = By.Name("confirmPassword");

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetPageTitle()
        {
            return driver.FindElement(titleLabel).Text;
        }

        public void FillForm(string user , string email , string pass , string confirmPass)
        {
            driver.FindElement(usernameField).SendKeys(user);
            driver.FindElement(emailField).SendKeys(email);
            driver.FindElement(passwordField).SendKeys(pass);
            driver.FindElement(confirmPasswordField).SendKeys(confirmPass);

        }

        public void ClickSubmit()
        {
            driver.FindElement(submitButton).Click();
        }


    }
}
