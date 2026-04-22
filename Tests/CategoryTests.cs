using FynxAutomationProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FynxAutomationProject.Tests
{
    [TestClass]
    public class CategoryTests : BaseTest
    {
        [TestMethod]
        public void VerifyCategoryCreationWithWait()
        {
            WelcomePage welcome = new WelcomePage(driver);
            welcome.ClickSignIn();

            LoginPage login = new LoginPage(driver);
            login.Login("LielTest", "1234");

            driver.Navigate().GoToUrl(url + "/categories");

            CategoriesPage catPage = new CategoriesPage(driver);
            catPage.OpenCreateModal();

            string uniqueName = "Auto_" + DateTime.Now.Ticks;
            catPage.CreateNewCategory(uniqueName, "Description created by Selenium");

            Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                bool isClosed = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("modal")));
                Assert.IsTrue(isClosed, "The modal did not close. Check for validation errors in the UI.");
            }
            catch (WebDriverTimeoutException)
            {
                string errorText = driver.FindElement(By.ClassName("error-message")).Text; 
                Assert.Fail($"Test failed because the modal stayed open. Error on screen: {errorText}");
            }
        }
    }
}