using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GlobalTechTest.Framework
{
    public class IndivdualProductPage : Page
    {
        private string sizeDropdownElementIdentifier = "group_1";
        private string blueColourElementIdentifier = ".color_pick[name='Blue']";
        private string orangeColourElementIdentifier = ".color_pick[name='Orange']";
        private string beigecolourElementIdentifier = ".color_pick[name='Beige']";
        private string addToCartElementIdentifier = "add_to_cart";
        private string popupContinueShoppingButtonElementIdentifeir = "[class*='button'][Title='Continue shopping']";
        private string popupProceedToCheckoutElementIdentifier = "[class*='button'][Title='Proceed to checkout']";

        public IndivdualProductPage(IWebDriver driver) : base(driver) { }

        // Select Size
        public void SelectSize(Size size)
        {
            switch (size)
            {
                case Size.Small:
                    {
                        ChooseSmallSize();
                        break;
                    }
                case Size.Medium:
                    {
                        ChooseMediumSize();
                        break;
                    }
            }
        }

        private void ChooseMediumSize()
        {
            SelectElement sizeDropDown = new SelectElement(Driver.FindElement(By.Id(sizeDropdownElementIdentifier)));
            sizeDropDown.SelectByText("M");
        }

        private void ChooseSmallSize()
        {
            SelectElement sizeDropDown = new SelectElement(Driver.FindElement(By.Id(sizeDropdownElementIdentifier)));
            sizeDropDown.SelectByText("S");
        }


        // Select Colour
        public void SelectColour(Colour colour)
        {
            switch (colour)
            {
                case Colour.Blue:
                    {
                        ChooseBlueColour();
                        break;
                    }
                case Colour.Orange:
                    {
                        ChooseOrangeColour();
                        break;
                    }
                case Colour.Beige:
                    {
                        ChooseBeigeColour();
                        break;
                    }
            }
        }

        private void ChooseBlueColour()
        {
            IWebElement colourSelector = Driver.FindElement(By.CssSelector(blueColourElementIdentifier));
            colourSelector.Click();
        }

        private void ChooseOrangeColour()
        {
            IWebElement colourSelector = Driver.FindElement(By.CssSelector(orangeColourElementIdentifier));
            colourSelector.Click();
        }

        private void ChooseBeigeColour()
        {
            IWebElement colourSelector = Driver.FindElement(By.CssSelector(beigecolourElementIdentifier));
            colourSelector.Click();
        }

        // Add item to cart
        public void AddItemToCart()
        {
            IWebElement submitButton = Driver.FindElement(By.Id(addToCartElementIdentifier));
            submitButton.Click();
        }

        // Select option from Popup displayed after adding product to the cart
        public void ContinueShopping()
        {
            WebDriverWait wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait1.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(popupContinueShoppingButtonElementIdentifeir)));

            IWebElement continueShoppingButton = Driver.FindElement(By.CssSelector(popupContinueShoppingButtonElementIdentifeir));
            continueShoppingButton.Click();
        }

        public void ProceedToCheckout()
        {
            WebDriverWait wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait1.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(popupProceedToCheckoutElementIdentifier)));

            IWebElement continueShoppingButton = Driver.FindElement(By.CssSelector(popupProceedToCheckoutElementIdentifier));
            continueShoppingButton.Click();
        }
    }
}
