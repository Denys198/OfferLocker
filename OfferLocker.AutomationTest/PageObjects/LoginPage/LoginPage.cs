using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace OfferLocker.AutomationTest.PageObjects.LoginPage
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(10)));
        }

        [FindsBy(How = How.CssSelector, Using = "[type='email']")]
        public IWebElement TxtEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='password']")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='button'")]
        public IWebElement BtnSubmit { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type=checkbox]")]
        public IWebElement ChkRegister { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='text']")]
        public IWebElement TxtFullName { get; set; }

        public void Login(string email, string passwd)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(passwd);
            BtnSubmit.Click();
        }

        public void LoadRegisterForm()
        {
            ChkRegister.Click();
        }
    }
}
