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
        public void loginWithValidCredentials()
        {
            loginPage.Login("popescuandrei@gmail.com", "string");
            userPage = new UserPage(Driver);
            userPage.waitForPageToLoad("[id=\"header-wrapper\"]");
            //userPage.driver.FindElement(By.Id("links"));
            Assert.True(userPage.ElementInPage.Displayed);
        }
        public void Dispose()
        {
            CloseBrowser();
        }
    }
}
