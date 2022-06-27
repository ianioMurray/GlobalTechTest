using GlobalTechTest.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace GlobalTechTest.Tests
{
    public class UserJourneyTests
    {
        [Fact]
        [Trait("Category", "EndToEndTests" )]
        
        public void VerifyItemsInCart()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo();

                ClothingCategoriesMenu categoryMenu = new ClothingCategoriesMenu(driver);

                // Add to the cart a Faded Short Sleeve T Shirt, size medium, colour blue
                categoryMenu.SelectTShirtsFromTheWomenMenu();

                TShirtsPage tShirtsPage = new TShirtsPage(driver);
                tShirtsPage.SelectShortSleeveFadedTShirt();
                tShirtsPage.SelectSize(Size.Medium);
                tShirtsPage.SelectColour(Colour.Blue);
                tShirtsPage.AddItemToCart();
                tShirtsPage.ContinueShopping();

                // Add to the cart an Evening Dress, size small, colour beige
                categoryMenu.SelectEveningDressesFromTheWomenMenu();

                EveningDressesPage eveningDressesPage = new EveningDressesPage(driver);
                eveningDressesPage.SelectPrintedDress();
                eveningDressesPage.SelectSize(Size.Small);
                eveningDressesPage.SelectColour(Colour.Beige);
                eveningDressesPage.AddItemToCart();
                eveningDressesPage.ContinueShopping();

                // Add to the cart a Printed Summer Dress, size medium, colour orange
                categoryMenu.SelectSummerDressesFromTheWomenMenu();

                SummerDressesPage summerDressesPage = new SummerDressesPage(driver);
                summerDressesPage.SelectPrintedSummerDress();
                summerDressesPage.SelectSize(Size.Medium);
                summerDressesPage.SelectColour(Colour.Orange);
                summerDressesPage.AddItemToCart();
                summerDressesPage.ProceedToCheckout();

                // Checkout
                CheckOutPage checkOutPage = new CheckOutPage(driver);
                checkOutPage.EnsurePageLoaded();

                // Remove the Evening Dress from the cart
                checkOutPage.RemoveItem("Printed Dress");

                // Add a second Faded Short Sleeve T Shirt of the same size and colour
                categoryMenu.SelectTShirtsFromTheWomenMenu();

                tShirtsPage.SelectShortSleeveFadedTShirt();
                tShirtsPage.SelectSize(Size.Medium);
                tShirtsPage.SelectColour(Colour.Blue);
                tShirtsPage.AddItemToCart();
                summerDressesPage.ProceedToCheckout();

                checkOutPage.EnsurePageLoaded();

                // Assert the total for each line in the cart
                List<string> totalPricePerLineInShoppingCart = checkOutPage.GetProductsPriceTotal();
                Assert.Equal("$28.98", totalPricePerLineInShoppingCart[0]);
                Assert.Equal("$33.02", totalPricePerLineInShoppingCart[1]);

                // Assert the cart total is $65.53
                Assert.Equal("$65.53", checkOutPage.getShoppingCartTotal());
                
                // Assert.Equal("$64.00", checkOutPage.getShoppingCartTotal());
            }
        }
    }
}
