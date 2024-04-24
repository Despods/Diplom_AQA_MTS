﻿using Diplom_AQA_MTS.Models;
using Diplom_AQA_MTS.Pages;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom_AQA_MTS.Steps
{
    public class NavigationSteps(IWebDriver driver) : BaseSteps(driver)
    {
        public LoginPage NavigateToLoginPage()
        {
            return new LoginPage(_driver);
        }

        public DashBoardPage NavigateToDashboardPage()
        {
            return new DashBoardPage(_driver);
        }

        public DashBoardPage SuccessfulLogin(User user)
        {
            return Login<DashBoardPage>(user);
        }

        public T Login<T>(User user) where T : BasePage
        {
            LoginPage = new LoginPage(_driver);

            LoginPage.InputEmail.SendKeys(user.Username);
            LoginPage.InputPassword.SendKeys(user.Password);
            LoginPage.ButtonLogin.Click();

            return (T)Activator.CreateInstance(typeof(T), _driver, false);
        }
    }
}