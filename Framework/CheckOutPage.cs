using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalTechTest.Framework
{
    public class CheckOutPage : Page
    {
        private string shoppingCartTitleElementIdentifier = "cart_title";
        private string shoppingCartTableElementIdentifier = "order-detail-content";
        private string shoppingCartTableBodyElementIdentifier = "tbody";
        private string shoppingCartTableRowElementIdentifier = "tr";
        private string productNameCallElementIdentifier = "product-name";
        private string productDeleteCellElementIdentifier = "cart_quantity_delete";
        private string productRowTotalPriceElementIdentifier = "cart_total";
        private string shoppingCartGrandTotalElementIdentifier = "total_price_container";

        public CheckOutPage(IWebDriver driver) : base(driver) { }

        public void EnsurePageLoaded()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(shoppingCartTitleElementIdentifier)));

            IWebElement shopCartSummaryHeadingElement = Driver.FindElement(By.Id(shoppingCartTitleElementIdentifier));
            string shopCartSummaryHeading = shopCartSummaryHeadingElement.Text;

            bool pageHasLoaded =  (shopCartSummaryHeading.Contains("SHOPPING-CART SUMMARY"));
            if(!pageHasLoaded)
            {
                throw new Exception($"The heading 'Shopping-cart summary' was not found");
            }
        }

        private IReadOnlyCollection<IWebElement> getProductRows()
        {
            IWebElement productsTable = Driver.FindElement(By.Id(shoppingCartTableElementIdentifier));
            IWebElement productTableBody = productsTable.FindElement(By.TagName(shoppingCartTableBodyElementIdentifier));
            return productTableBody.FindElements(By.TagName(shoppingCartTableRowElementIdentifier));
        }

        public void RemoveItem(string productToRemove)
        {
            IReadOnlyCollection<IWebElement> productTableRows = getProductRows();

            int index = -1;

            for(int i = 0; i < productTableRows.Count; i++)
            {
                IWebElement productDescriptionCell = productTableRows.ElementAt(i).FindElement(By.ClassName(productNameCallElementIdentifier));
                if(productDescriptionCell.Text == productToRemove)
                {
                    index = i;
                }
            }

            if (index > -1)
            {
                IWebElement productDescriptionCell = productTableRows.ElementAt(index).FindElement(By.ClassName(productDeleteCellElementIdentifier));
                productDescriptionCell.Click();
            }
            else
            {
                throw new Exception($"Unable to remove {productToRemove} as it could not be found in the table");
            }
        }

        public string GetProductsPriceTotal(int productsIndex)
        {
            List<string> lineTotalPrices = new List<string>();
            IReadOnlyCollection<IWebElement> productTableRows = getProductRows();

            for (int i = 0; i < productTableRows.Count; i++)
            {
                IWebElement productTotalPriceCell = productTableRows.ElementAt(i).FindElement(By.ClassName(productRowTotalPriceElementIdentifier));
                lineTotalPrices.Add(productTotalPriceCell.Text);
            }

            return lineTotalPrices[productsIndex];
        }

        public string getShoppingCartTotal()
        {
            IWebElement grandTotalCell = Driver.FindElement(By.Id(shoppingCartGrandTotalElementIdentifier));
            return grandTotalCell.Text;
        }
    }
}
