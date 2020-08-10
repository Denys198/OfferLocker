using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.AutomationTest.Helpers
{
    public abstract class Browser
    {
        protected IWebDriver Driver;

        protected Browser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        protected void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
