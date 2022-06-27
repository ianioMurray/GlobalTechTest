using OpenQA.Selenium;

namespace GlobalTechTest.Framework
{
    public abstract class Page
    {
        protected readonly IWebDriver Driver;

        public Page(IWebDriver driver)
        {
            this.Driver = driver;
        }
    }
}
