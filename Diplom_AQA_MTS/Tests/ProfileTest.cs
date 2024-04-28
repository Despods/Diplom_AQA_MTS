using Diplom_AQA_MTS.Pages;
using Diplom_AQA_MTS.Steps;

namespace Diplom_AQA_MTS.Tests
{
    public class ProfileTest : BaseTest
    {
        [Test]
        public void UploadAvatarTest()
        {
            NavigationSteps.SuccessfulLogin(Admin);
            var ProfileSettingsPage = new ProfileSettingsPage(Driver,true);
            ProfileSettingsPage.ProfileUploadAvatar();
            Assert.That(ProfileSettingsPage.AvatarImage.Displayed);
            ProfileSettingsPage.ProfileDeleteAvatar();
        }
    }
}