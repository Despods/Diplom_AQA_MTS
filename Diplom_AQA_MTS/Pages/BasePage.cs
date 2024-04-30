using Allure.Helpers;
using Diplom_AQA_MTS.Helpers.Configuration;
using OpenQA.Selenium;

namespace Diplom_AQA_MTS.Pages
{
    public abstract class BasePage //абстрактный класс, чтобы наследники реализовывали все методы данного класса
    {
        protected IWebDriver _driver { get; private set; }
        protected WaitsHelper _waitsHelper { get; private set; }

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            _driver = driver;
            _waitsHelper = new WaitsHelper(_driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

            if (openPageByUrl)
                OpenPageByUrl();
        }

        public BasePage(IWebDriver driver) : this(driver, false)
        {
        }

        public abstract bool IsPageOpenend();
        protected abstract string GetEndpoint();

        private void OpenPageByUrl()
        {
            _driver.Navigate().GoToUrl(Configurator.AppSettings.URL + GetEndpoint());
        }
    }
}
