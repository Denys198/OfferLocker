using OfferLocker.AutomationTest.Helpers;
using OfferLocker.AutomationTest.PageObjects.LoginPage;
using OfferLocker.AutomationTest.PageObjects.UserPage;
using System;
using Xunit;

namespace OfferLocker.AutomationTest.Tests
{
    public class LoginTests : Browser, IDisposable
    {
        public LoginPage loginPage;
        public UserPage userPage;

        public LoginTests() : base()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/authentication");
            loginPage = new LoginPage(Driver);
        }
        [Fact]
        public void LoginWithValidCredentials()
        {
            loginPage.Login("popescuandrei@gmail.com", "string");
            userPage = new UserPage(Driver);
            userPage.WaitForPageToLoad("[id='header-wrapper']");
            Assert.True(userPage.HeaderPage.Displayed);
        }
        [Fact]
        public void LoadRegisterForm()
        {
            loginPage.LoadRegisterForm();
            Assert.True(loginPage.TxtFullName.Displayed);
        }
        public void Dispose()
        {
            CloseBrowser();
        }
    }
}
