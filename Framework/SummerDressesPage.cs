using OpenQA.Selenium;

namespace GlobalTechTest.Framework
{
    public class SummerDressesPage : FluentSummerDressesPage<SummerDressesPage>
    {
        public SummerDressesPage(IWebDriver driver) : base(driver) { }
    }
}
