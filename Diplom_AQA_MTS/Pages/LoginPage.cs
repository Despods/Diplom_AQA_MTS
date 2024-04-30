using OpenQA.Selenium;
using Diplom_AQA_MTS.Elements;
using GraduateWork.Elements;
using Allure.Net.Commons;
using Diplom_AQA_MTS.Models;
using NUnit.Allure.Attributes;

namespace Diplom_AQA_MTS.Pages
{
    public  class LoginPage : BasePage
    {
        private static string END_POINT = "";

        //описание элементов на странице
        private static readonly By InputEmailBy = By.Id(":r0:");
        private static readonly By InputPasswordBy = By.Id(":r2:");
        private static readonly By ButtonLoginBy = By.ClassName("button-label");
        private static readonly By ErrorLabelBy = By.XPath("//*[@data-testid='text-login-error:login-error-invalid']/p[1]");

        // инициализация класса
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public override bool IsPageOpenend()
        {
            try
            {
                return ButtonLogin.Displayed && InputEmail.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        [AllureStep("Неккоректный логин")]
        public LoginPage IncorrectLogin(string username, string password)
        {
            AllureApi.AddTestParameter("Login", username);
            AllureApi.AddTestParameter("Password", password, ParameterMode.Masked);
            InputEmail.SendKeys(username);
            InputPassword.SendKeys(password);
            ButtonLogin.Click();
            return this;
        }

        // Методы
        public UIElement InputEmail => new(_driver, InputEmailBy);
        public UIElement InputPassword => new(_driver, InputPasswordBy);
        public Button ButtonLogin => new(_driver, ButtonLoginBy);
        public UIElement ErrorLabel => new(_driver, ErrorLabelBy);
    }
}