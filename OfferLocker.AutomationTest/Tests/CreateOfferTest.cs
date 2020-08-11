using OfferLocker.AutomationTest.Helpers;
using OfferLocker.AutomationTest.PageObjects;
using OfferLocker.AutomationTest.PageObjects.Offers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OfferLocker.AutomationTest.Tests
{
    public class CreateOfferTest : Browser, IDisposable
    {
        public CreateOfferPage createOfferPage;
        public OfferPage offers;
        public CreateOfferTest() : base()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/offers/create");
            createOfferPage = new CreateOfferPage(Driver);
        }
        [Fact]
        public void CreateOffer()
        {
            createOfferPage.FillOfferForm("Books about manual tests", "Very good books", "120");
            offers = new OfferPage(Driver);
            offers.WaitForPageToLoad("[id='header-wrapper']");
            Assert.True(offers.LinksForUser.Displayed);
        }
        public void Dispose()
        {
            CloseBrowser();
        }
    }
}
