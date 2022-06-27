using OpenQA.Selenium;

namespace GlobalTechTest.Framework
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver driver) : base(driver) { } 

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Driver.Manage().Window.Maximize();
        }
    }
}
