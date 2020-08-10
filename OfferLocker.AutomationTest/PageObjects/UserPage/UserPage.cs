using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.AutomationTest.PageObjects.UserPage
{
    public class UserPage : BasePage
    {
        public UserPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How=How.Id, Using = "links")]
        public IWebElement ElementInPage { get; set; }
    }
}
