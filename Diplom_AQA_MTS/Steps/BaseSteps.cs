using Diplom_AQA_MTS.Pages;
using Diplom_AQA_MTS.Pages.ProjectPages;
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
        protected AllProjectsPage? AllProjectsPage { get; set; }
        protected AddProjectPage? AddProjectPage { get; set; }
        protected ProfileSettingsPage? ProfileSettingsPage { get; set; }
    }
}
