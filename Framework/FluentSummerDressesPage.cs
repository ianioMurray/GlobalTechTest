using OpenQA.Selenium;

namespace GlobalTechTest.Framework
{
    public class FluentSummerDressesPage<SELF> : IndivdualProductPage<SELF> where SELF : FluentSummerDressesPage<SELF>
    {
        private string summerDressElementIdentifier = "[Class='replace-2x img-responsive'][Title='Printed Summer Dress']";

        public FluentSummerDressesPage(IWebDriver driver) : base(driver) { }

        public SELF SelectPrintedSummerDress()
        {
            IWebElement fadedShortSleeveTShirtImage = Driver.FindElement(By.CssSelector(summerDressElementIdentifier));
            fadedShortSleeveTShirtImage.Click();

            WaitForAddToCartButtonToBeVisible();

            return (SELF)this;
        }
    }
}
