using Diplom_AQA_MTS.Pages;
using Diplom_AQA_MTS.Steps;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using Diplom_AQA_MTS.Helpers.Configuration;
using System.Diagnostics;

namespace Diplom_AQA_MTS.Tests.GUI
{
    [AllureSuite("UI Login Tests")]
    public class LoginTest : BaseTest
    {
        [Test]
        [AllureName("Логин с передачей корректных параметров")]
        [AllureFeature("Login")]
        public void CorrectLoginTest()
        {
            Debug.Assert(Configurator.AppSettings.Username != null && Configurator.AppSettings.Password != null);
            Assert.That(NavigationSteps.SuccessfulLogin(Admin).WelcomeMessage.Displayed);
            AllureApi.Step("Вход выполнен успешно");
        }

        [Test]
        [AllureName("Логин с передачей некорректных параметров")]
        [AllureFeature("Login")]
        [AllureDescription("Тест использование некорректных данных")]
        public void UnCorrectLoginTest()
        {
            Debug.Assert(Configurator.AppSettings.Username != null);
            string ErrorText = "Either your email address or your password is wrong. Please try again or recover your password.";
            var LoginPage = new LoginPage(Driver);
            LoginPage.IncorrectLogin("Incorect@mail.ru", "Login");
            Assert.That(LoginPage.ErrorLabel.Text.Trim(), Is.EqualTo(ErrorText));
            AllureApi.Step($"Получена корректная ошибка : {ErrorText}");
        }

        [Test]
        //[Ignore("Виталя вставай, мы все сломали")]
        [AllureFeature("Login")]
        [AllureName("Тест воспроизводищий дефект")]
        [AllureDescription("При неккоректном логине ждем, что открыта страница дашборда")]
        //[AllureIssue("BugLogin")]
        public void UnCorrectLoginTestBug()
        {
            var LoginPage = new LoginPage(Driver);
            LoginPage.IncorrectLogin("Incorect@mail.ru", "Login");
            var DashBoardPage = new DashBoardPage(Driver);
            Assert.That(DashBoardPage.IsPageOpenend);
        }
    }
}