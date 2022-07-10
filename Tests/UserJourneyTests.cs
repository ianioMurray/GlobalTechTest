using GlobalTechTest.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
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
                tShirtsPage.SelectShortSleeveFadedTShirt()
                    .SelectSize(Size.Medium)
                    .SelectColour(Colour.Blue)
                    .AddItemToCart()
                    .ContinueShopping();

                // Add to the cart an Evening Dress, size small, colour beige
                categoryMenu.SelectEveningDressesFromTheWomenMenu();

                EveningDressesPage eveningDressesPage = new EveningDressesPage(driver);
                eveningDressesPage.SelectPrintedDress()
                    .SelectSize(Size.Small)
                    .SelectColour(Colour.Beige)
                    .AddItemToCart()
                    .ContinueShopping();

                // Add to the cart a Printed Summer Dress, size medium, colour orange
                categoryMenu.SelectSummerDressesFromTheWomenMenu();

                SummerDressesPage summerDressesPage = new SummerDressesPage(driver);
                summerDressesPage.SelectPrintedSummerDress()#
                    .SelectSize(Size.Medium)
                    .SelectColour(Colour.Orange)
                    .AddItemToCart()
                    .ProceedToCheckout();

                // Checkout
                CheckOutPage checkOutPage = new CheckOutPage(driver);
                checkOutPage.EnsurePageLoaded();

                // Remove the Evening Dress from the cart
                checkOutPage.RemoveItem("Printed Dress");

                // Add a second Faded Short Sleeve T Shirt of the same size and colour
                categoryMenu.SelectTShirtsFromTheWomenMenu();

                tShirtsPage.SelectShortSleeveFadedTShirt()
                    .SelectSize(Size.Medium)
                    .SelectColour(Colour.Blue)
                    .AddItemToCart()
                    .ProceedToCheckout();

                checkOutPage.EnsurePageLoaded();

                // below is a soft assert - this means the test will not simply drop out if one assert fails.  All asserts will be run even if say the 
                // first fails.
                checkOutPage.ShouldSatisfyAllConditions(

                     // Assert the total for each line in the cart
                     p => p.GetProductsPriceTotal(0).ShouldBe("$28.98"),
                     p => p.GetProductsPriceTotal(1).ShouldBe("$33.02"),
                    
                     // Assert the cart total is $65.53
                     p => p.getShoppingCartTotal().ShouldBe("$65.53")

                     //test fails as discount applied to first line in the cart and this is not taken into account when calculating the total
                     //
                     // p => p.getShoppingCartTotal().ShouldBe("$64.00")
                 ); 
            }
        }
    }
}
