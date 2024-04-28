using Diplom_AQA_MTS.Pages;
using Diplom_AQA_MTS.Steps;

namespace Diplom_AQA_MTS.Tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void CorrectLoginTest()
        {
            Assert.That(NavigationSteps.SuccessfulLogin(Admin).WelcomeMessage.Displayed);
        }

        [Test]
        public void UnCorrectLoginTest()
        {
            string ErrorText = "Either your email address or your password is wrong. Please try again or recover your password.";
            var LoginPage = new LoginPage(Driver);
            LoginPage.IncorrectLogin("Incorect@mail.ru", "Login");
            Assert.That(LoginPage.ErrorLabel.Text.Trim(), Is.EqualTo(ErrorText));
        }
    }
}