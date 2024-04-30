using OpenQA.Selenium;
using Diplom_AQA_MTS.Elements;
using GraduateWork.Elements;
using System.Reflection;
using NUnit.Allure.Attributes;

namespace Diplom_AQA_MTS.Pages
{
    public class ProfileSettingsPage : BasePage
    {
        private static string END_POINT = "settings/profile";

        //описание элементов на странице
        private static readonly By TitleLabelBy = By.ClassName("sc-ioFbWn");
        private static readonly By UploadAvatarElementBy = By.CssSelector("[type = 'file']");
        private static readonly By MenuButtonАccountBy = By.XPath("//li[@data-testid='item-profile']");
        private static readonly By ButtonSaveBy = By.XPath("//button/div[contains(text(), 'Save')]");
        private static readonly By ButtonDeleteBy = By.XPath("//button/div[contains(text(), 'Remove avatar')]");
        private static readonly By AvatarImageBy = By.XPath("//img");

        // инициализация класса
        public ProfileSettingsPage(IWebDriver driver) : base(driver)
        {
        }

        public ProfileSettingsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public override bool IsPageOpenend()
        {
            try
            {
                return TitleLabel.Displayed;
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

        [AllureStep("Обновляем аватар")]
        public ProfileSettingsPage ProfileUploadAvatar ()
        {

            // Получаем путь к исполняемому файлу (exe)
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Конструируем путь к файлу внутри проекта
            string filePath = Path.Combine(assemblyPath, "Resources", "enot.jpeg"); 
            MenuButtonАccount.Click();
            UploadAvatarElement.SendKeys(filePath);
            ButtonSave.Click();

            return this;
        }

        [AllureStep("Удаляем аватар")]
        public ProfileSettingsPage ProfileDeleteAvatar()
        {
            MenuButtonАccount.Click();
            ButtonDelete.Click();
            ButtonSave.Click();

            return this;
        }

        // Методы
        public UIElement TitleLabel => new(_driver, TitleLabelBy);
        public UIElement UploadAvatarElement => new(_driver, UploadAvatarElementBy);
        public UIElement AvatarImage => new(_driver, AvatarImageBy);
        public UIElement MenuButtonАccount => new(_driver, MenuButtonАccountBy);
        public Button ButtonSave => new(_driver, ButtonSaveBy);
        public Button ButtonDelete => new(_driver, ButtonDeleteBy);
    }
}