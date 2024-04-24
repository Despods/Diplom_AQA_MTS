using Diplom_AQA_MTS.Pages;
using OpenQA.Selenium;

namespace Diplom_AQA_MTS.Steps
{
    public class BaseSteps
    {
        protected IWebDriver _driver;

        public BaseSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        protected LoginPage? LoginPage { get; set; }
        protected DashBoardPage? DashBoardPage { get; set; }
        protected TestCasesPage? TestCasePage { get; set; }
    }
}
