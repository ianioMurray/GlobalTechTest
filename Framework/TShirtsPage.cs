using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GlobalTechTest.Framework
{
    public class TShirtsPage : IndivdualProductPage
    {
        private string fadedShortSleveTShirtElementIdentifier = "[Class='replace-2x img-responsive'][Title='Faded Short Sleeve T-shirts']";
        private string addToCartButton = "add_to_cart";

        public TShirtsPage(IWebDriver driver) : base(driver) { }

        public void SelectShortSleeveFadedTShirt()
        {
            IWebElement fadedShortSleeveTShirtImage = Driver.FindElement(By.CssSelector(fadedShortSleveTShirtElementIdentifier));
            fadedShortSleeveTShirtImage.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(addToCartButton)));
        }
    }
}
