using OpenQA.Selenium;

namespace GlobalTechTest.Framework
{
    public class EveningDressesPage : FluentEveningDressesPage<EveningDressesPage>
    {
        public EveningDressesPage(IWebDriver driver) : base(driver) { }
    }
}
