using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OfferLocker.AutomationTest.PageObjects
{
    public class BasePage
    {
        public IWebDriver driver;
        public BasePage() { }
        
        public void WaitForPageToLoad(string selector)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(selector)));
        }
    }
}
