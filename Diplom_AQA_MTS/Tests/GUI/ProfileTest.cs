using Diplom_AQA_MTS.Pages;
using Diplom_AQA_MTS.Steps;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;

namespace Diplom_AQA_MTS.Tests.GUI
{
    [AllureSuite("UI ProfileSettings Tests")]
    public class ProfileTest : BaseTest
    {
        [Test]
        [AllureName("Изменение аватара профиля")]
        public void UploadAvatarTest()
        {
            NavigationSteps.SuccessfulLogin(Admin);
            var DashBoardPage = new DashBoardPage(Driver);
            DashBoardPage.IsPageOpenend();
            var ProfileSettingsPage = new ProfileSettingsPage(Driver, true);
            ProfileSettingsPage.ProfileUploadAvatar();
            Assert.That(ProfileSettingsPage.AvatarImage.Displayed);
            AllureApi.Step("Аватар успешно добавлен");
            ProfileSettingsPage.ProfileDeleteAvatar();
        }
    }
}