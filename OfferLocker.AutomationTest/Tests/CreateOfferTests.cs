using OfferLocker.AutomationTest.Helpers;
using OfferLocker.AutomationTest.PageObjects;
using OfferLocker.AutomationTest.PageObjects.Offers;
using System;
using Xunit;

namespace OfferLocker.AutomationTest.Tests
{
    public class CreateOfferTests : Browser, IDisposable
    {
        public CreateOfferPage createOfferPage;
        public OfferPage offers;

        public CreateOfferTests() : base()
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
