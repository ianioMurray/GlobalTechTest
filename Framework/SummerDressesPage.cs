using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTechTest.Framework
{
    public class SummerDressesPage : IndivdualProductPage
    {
        private string summerDressElementIdentifier = "[Class='replace-2x img-responsive'][Title='Printed Summer Dress']";
        private string addToCartButton = "add_to_cart";


        public SummerDressesPage(IWebDriver driver) : base(driver) { }

        public void SelectPrintedSummerDress()
        {
            IWebElement fadedShortSleeveTShirtImage = Driver.FindElement(By.CssSelector(summerDressElementIdentifier));
            fadedShortSleeveTShirtImage.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(addToCartButton)));
        }
    }
}
