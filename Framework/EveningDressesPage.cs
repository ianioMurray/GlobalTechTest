using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GlobalTechTest.Framework
{
    public class EveningDressesPage : IndivdualProductPage
    {
        private string eveningDressElementIdentifier = "[Class='replace-2x img-responsive'][Title='Printed Dress']";
        private string addToCartButton = "add_to_cart";

        public EveningDressesPage(IWebDriver driver) : base(driver) { }

        public void SelectPrintedDress()
        {
            IWebElement fadedShortSleeveTShirtImage = Driver.FindElement(By.CssSelector(eveningDressElementIdentifier));
            fadedShortSleeveTShirtImage.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(addToCartButton)));
        }
    }
}
