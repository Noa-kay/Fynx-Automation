using Microsoft.VisualStudio.TestTools.UnitTesting;
using FynxAutomationProject.Pages;
using System.Threading;
using System.IO;

namespace FynxAutomationProject.Tests
{
    [TestClass]
    public class ProfileTests : BaseTest
    {
        [TestMethod]
        public void VerifyProfileImageUploadAlert()
        {

            WelcomePage welcome = new WelcomePage(driver);
            welcome.ClickSignIn();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("LielTest", "1234");

            driver.Navigate().GoToUrl(url + "/profile");
            Thread.Sleep(2000); 

            ProfilePage profilePage = new ProfilePage(driver);

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "profile.jpg");

            profilePage.UploadProfileImage(imagePath);

            Thread.Sleep(3000); 
            string firstAlert = profilePage.GetAlertTextAndAccept();

            Thread.Sleep(1000); 
            try
            {
                profilePage.GetAlertTextAndAccept(); 
            }
            catch
            {
            }

            Assert.AreEqual("Profile picture updated successfully!", firstAlert);
            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
        }
    }
}