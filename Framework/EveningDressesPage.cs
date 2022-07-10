using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GlobalTechTest.Framework
{
    public class EveningDressesPage : FluentEveningDressesPage<EveningDressesPage>
    {
        public EveningDressesPage(IWebDriver driver) : base(driver) { }
    }
}
