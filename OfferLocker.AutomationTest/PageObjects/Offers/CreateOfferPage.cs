using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace OfferLocker.AutomationTest.PageObjects
{
    public class CreateOfferPage : BasePage
    {
        public CreateOfferPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(10)));
        }

        [FindsBy(How = How.CssSelector, Using = "[type='text']")]
        public IWebElement TxtName { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea[@formcontrolname='description']")]
        public IWebElement TxtDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='number']")]
        public IWebElement TxtPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#formGroup > app-submit-button > button")]
        public IWebElement BtnSubmit { get; set; }

        public void FillOfferForm(string offerName, string offerDescription, string price)
        {
            TxtName.SendKeys(offerName);
            TxtDescription.SendKeys(offerDescription);
            TxtPrice.SendKeys(price);

            BtnSubmit.Click();
        }

    }
}
