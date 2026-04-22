using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FynxAutomationProject.Pages
{
    public class ProfilePage : BasePage
    {
        private By fileInputLocator = By.CssSelector("input[type='file']");
        private By editBtn = By.ClassName("edit-btn");

        public ProfilePage(IWebDriver driver) : base(driver) { }

        public void UploadProfileImage(string fullPath)
        {
            IWebElement fileInput = driver.FindElement(fileInputLocator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].style.display = 'block'; arguments[0].style.visibility = 'visible';", fileInput);

            fileInput.SendKeys(fullPath);

            js.ExecuteScript("arguments[0].dispatchEvent(new Event('change', { bubbles: true }));", fileInput);
            js.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", fileInput);

            Thread.Sleep(2000);
        }

        public string GetAlertTextAndAccept()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string text = alert.Text;

            Thread.Sleep(1000);

            alert.Accept();

            return text;
        }
    }
}