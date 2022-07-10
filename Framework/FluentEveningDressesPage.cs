using OpenQA.Selenium;

namespace GlobalTechTest.Framework
{
    public class FluentEveningDressesPage<SELF> : IndivdualProductPage<SELF>
        where SELF : FluentEveningDressesPage<SELF>
    {
        private string eveningDressElementIdentifier = "[Class='replace-2x img-responsive'][Title='Printed Dress']";

        public FluentEveningDressesPage(IWebDriver driver) : base(driver) { }

        public SELF SelectPrintedDress()
        {
            IWebElement fadedShortSleeveTShirtImage = Driver.FindElement(By.CssSelector(eveningDressElementIdentifier));
            fadedShortSleeveTShirtImage.Click();

            WaitForAddToCartButtonToBeVisible();

            return (SELF)this;
        }
    }
}
