using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace OfferLocker.AutomationTest.PageObjects.UserPage
{
    public class UserPage : BasePage
    {
        public UserPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(10)));
        }

        [FindsBy(How = How.Id, Using = "links")]
        public IWebElement HeaderPage { get; set; }
    }
}
