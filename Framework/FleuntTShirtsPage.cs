using OpenQA.Selenium;

namespace GlobalTechTest.Framework
{
    public class FleuntTShirtsPage<SELF> : IndivdualProductPage<SELF>
        where SELF : FleuntTShirtsPage<SELF>
    {
        private string fadedShortSleveTShirtElementIdentifier = "[Class='replace-2x img-responsive'][Title='Faded Short Sleeve T-shirts']";

        public FleuntTShirtsPage(IWebDriver driver) : base(driver) { }

        public SELF SelectShortSleeveFadedTShirt()
        {
            IWebElement fadedShortSleeveTShirtImage = Driver.FindElement(By.CssSelector(fadedShortSleveTShirtElementIdentifier));
            fadedShortSleeveTShirtImage.Click();

            WaitForAddToCartButtonToBeVisible();

            return (SELF)this;
        }
    }
}
