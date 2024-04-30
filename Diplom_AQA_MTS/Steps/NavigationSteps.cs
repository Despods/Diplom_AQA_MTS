using Allure.Net.Commons;
using Diplom_AQA_MTS.Models;
using Diplom_AQA_MTS.Pages;
using Diplom_AQA_MTS.Pages.ProjectPages;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom_AQA_MTS.Steps
{
    public class NavigationSteps(IWebDriver driver) : BaseSteps(driver)
    {
        [AllureStep("Навигация на Login Page")]
        public LoginPage NavigateToLoginPage()
        {
            return new LoginPage(_driver, true);
        }

        [AllureStep("Навигация на Dashboard Page")]
        public DashBoardPage NavigateToDashboardPage()
        {
            return new DashBoardPage(_driver, true);
        }

        [AllureStep("Навигация на ProfileSettings Page")]
        public ProfileSettingsPage NavigateToProfileSettingsPage()
        {
            return new ProfileSettingsPage(_driver, true);
        }

        [AllureStep("Навигация на Dashboard Page")]
        public DashBoardPage SuccessfulLogin(User user)
        {
            return Login<DashBoardPage>(user);
        }

        [AllureStep("Навигация на AddProject Page")]
        public AddProjectPage NavigateToAddProjectPage()
        {
            return new AddProjectPage(_driver);
        }

        [AllureStep("Навигация на AllProjects Page")]
        public AllProjectsPage NavigateToAllProjectsPage()
        {
            return new AllProjectsPage(_driver, true);
        }

        public T Login<T>(User user) where T : BasePage
        {
            AllureApi.AddTestParameter("Login", user.Username);
            AllureApi.AddTestParameter("Password", user.Password, ParameterMode.Masked);
            LoginPage = new LoginPage(_driver);

            LoginPage.InputEmail.SendKeys(user.Username);
            LoginPage.InputPassword.SendKeys(user.Password);
            LoginPage.ButtonLogin.Click();

            return (T)Activator.CreateInstance(typeof(T), _driver, false);
        }
    }
}