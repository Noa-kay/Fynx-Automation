using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FynxAutomationProject.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public void ClickHome() => driver.FindElement(By.Id("home-link")).Click();
    }
}