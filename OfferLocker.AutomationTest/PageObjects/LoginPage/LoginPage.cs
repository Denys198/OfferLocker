using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.AutomationTest.PageObjects.LoginPage
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = "[type='email']")]
        public IWebElement TxtEmail { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[type='password']")]
        public IWebElement TxtPassword { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[type='button'")]
        public IWebElement ButtonSubmit { get; set; }

        [FindsBy(How = How.Id, Using = "links")]
        public IWebElement HeaderPage { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[type=checkbox]")]
        public IWebElement CheckboxRegister { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[type='text']")]
        public IWebElement TxtFullName { get; set; }
        public void Login(string email, string passwd)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(passwd);
            ButtonSubmit.Click();
        }
        public void LoadRegisterForm()
        {
            CheckboxRegister.Click();
        }
    }
}
