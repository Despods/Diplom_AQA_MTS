using Diplom_AQA_MTS.Pages;
using Diplom_AQA_MTS.Steps;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;

namespace Diplom_AQA_MTS.Tests
{
    [AllureSuite("UI Login Tests")]
    public class LoginTest : BaseTest
    {
        [Test]
        [AllureName("Логин с передачей корректных параметров")]
        public void CorrectLoginTest()
        {
            Assert.That(NavigationSteps.SuccessfulLogin(Admin).WelcomeMessage.Displayed);
            AllureApi.Step("Вход выполнен успешно");
        }

        [Test]
        [AllureName("Логин с передачей некорректных параметров")]
        [AllureDescription("Тест использование некорректных данных")]
        public void UnCorrectLoginTest()
        {
            string ErrorText = "Either your email address or your password is wrong. Please try again or recover your password.";
            var LoginPage = new LoginPage(Driver);
            LoginPage.IncorrectLogin("Incorect@mail.ru", "Login");
            Assert.That(LoginPage.ErrorLabel.Text.Trim(), Is.EqualTo(ErrorText));
            AllureApi.Step($"Получена корректная ошибка : ", {ErrorText});
        }
    }
}