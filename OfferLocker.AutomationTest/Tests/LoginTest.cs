using OfferLocker.AutomationTest.Helpers;
using OfferLocker.AutomationTest.PageObjects;
using OfferLocker.AutomationTest.PageObjects.LoginPage;
using OfferLocker.AutomationTest.PageObjects.UserPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace OfferLocker.AutomationTest.Tests
{
    public class LoginTest : Browser, IDisposable
    {
        public LoginPage loginPage;
        public UserPage userPage;

        public LoginTest() : base()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/authentication");
            loginPage = new LoginPage(Driver);
        }
        [Fact]
        public void LoginWithValidCredentials()
        {
            loginPage.Login("popescuandrei@gmail.com", "string");
            loginPage.WaitForPageToLoad("[id='header-wrapper']");
            Assert.True(loginPage.HeaderPage.Displayed);
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
