using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FynxAutomationProject.Pages
{
    public class WelcomePage : BasePage
    {

        private By signUpBtn = By.XPath("//button[contains(text() , 'Sign Up')]");
        private By signInBtn = By.XPath("//button[contains(text() , 'Sign In')]");

        public WelcomePage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickSignUp()
        {
            driver.FindElement(signUpBtn).Click();
        }

        public void ClickSignIn()
        {
            driver.FindElement(signInBtn).Click();
        }

    }
}
