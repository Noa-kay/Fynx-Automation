using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FynxAutomationProject.Pages
{
    public class FeedPage : BasePage
    {
        public FeedPage(IWebDriver driver) : base(driver) { }

        private By categoryDropdown = By.CssSelector("select[ng-reflect-model='all']");
        private By feedGrid = By.ClassName("feed-grid");
        private By postCards = By.CssSelector(".feed-grid > div");
        private By searchInput = By.CssSelector(".search-box input");

        public void SelectCategoryByIndex(int index)
        {
            IWebElement dropdown = driver.FindElement(categoryDropdown);
            SelectElement select = new SelectElement(dropdown);
            select.SelectByIndex(index); 
            Console.WriteLine($"Selected category at index: {index}");
        }

        public int GetPostCount()
        {
            return driver.FindElements(postCards).Count;
        }

        public void SearchForPost(string text)
        {
            IWebElement element = driver.FindElement(searchInput);
            element.Clear();
            element.SendKeys(text);
            element.SendKeys(Keys.Enter); 
            Console.WriteLine($"Searching for: {text}");
        }
    }
}