using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OfferLocker.AutomationTest.PageObjects
{
    public class BasePage
    {
        public IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(10)));
        }
        public void WaitForPageToLoad(string selector)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(selector)));
        }
    }
}
