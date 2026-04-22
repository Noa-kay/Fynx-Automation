using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI; 
using SeleniumExtras.WaitHelpers;
using System;

namespace FynxAutomationProject.Pages
{
    public class CategoriesPage : BasePage
    {

        private By titleField = By.Name("title"); 
        private By descriptionField = By.Name("desc"); 
        private By createBtn = By.XPath("//button[contains(@class, 'create-btn') or contains(., 'Create')]");
        private By modalContainer = By.ClassName("modal"); 

        public CategoriesPage(IWebDriver driver) : base(driver)
        {
           
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void OpenCreateModal()
        {
            driver.FindElement(createBtn).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(modalContainer));
        }

        public void CreateNewCategory(string name, string description)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement nameInput = wait.Until(ExpectedConditions.ElementIsVisible(titleField));
            IWebElement descInput = driver.FindElement(descriptionField);

            nameInput.Clear();
            nameInput.SendKeys(name);

            descInput.Clear();
            descInput.SendKeys(description);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
             arguments[0].dispatchEvent(new Event('input', { bubbles: true }));
             arguments[1].dispatchEvent(new Event('input', { bubbles: true }));
            ", nameInput, descInput);


            IWebElement submitBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[type='submit']")));

            js.ExecuteScript("arguments[0].click();", submitBtn);
        }
    }
}