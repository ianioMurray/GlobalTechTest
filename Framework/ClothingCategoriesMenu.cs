using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace GlobalTechTest.Framework
{
    public class ClothingCategoriesMenu : Page
    {
        private string womenMenuOptionElementIdentifier = "[Title='Women']";
        private string tShirtOptionElementIdentifier = "[Title='T-shirts']";
        private string eveningDressOptionElementIdentifier = "[Title='Evening Dresses']";
        private string summerDressOptionElementIdentifier = "[Title='Summer Dresses']";

        public ClothingCategoriesMenu(IWebDriver driver) : base(driver) { }

        private void HoverOverTheWomenOption()
        {
            IWebElement womenTabOption = Driver.FindElement(By.CssSelector(womenMenuOptionElementIdentifier));
            Actions action = new Actions(Driver);
            action.MoveToElement(womenTabOption).Perform();
        }

        private void SelectTShirts()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(tShirtOptionElementIdentifier)));
            
            IWebElement tShirtsOptionInWomensTab = Driver.FindElement(By.CssSelector(tShirtOptionElementIdentifier));
            tShirtsOptionInWomensTab.Click();
        }

        private void SelectEveningDresses()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(eveningDressOptionElementIdentifier)));

            IWebElement eveningDressOptionInWomensTab = Driver.FindElement(By.CssSelector(eveningDressOptionElementIdentifier));
            eveningDressOptionInWomensTab.Click();
        }

        private void SelectSummerDresses()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(summerDressOptionElementIdentifier)));

            IWebElement eveningDressOptionInWomensTab = Driver.FindElement(By.CssSelector(summerDressOptionElementIdentifier));
            eveningDressOptionInWomensTab.Click();
        }

        public void SelectTShirtsFromTheWomenMenu()
        {
            HoverOverTheWomenOption();
            SelectTShirts();
        }

        public void SelectEveningDressesFromTheWomenMenu()
        {
            HoverOverTheWomenOption();
            SelectEveningDresses();
        }

        public void SelectSummerDressesFromTheWomenMenu()
        {
            HoverOverTheWomenOption();
            SelectSummerDresses();
        }
    }
}
