using OpenQA.Selenium;
using Diplom_AQA_MTS.Elements;
using GraduateWork.Elements;
using Diplom_AQA_MTS.Models;
using NUnit.Allure.Attributes;
using Diplom_AQA_MTS.Pages.ProjectPages;

namespace Diplom_AQA_MTS.Pages
{
    public class EditProjectPage : BasePage
    {
        private static string END_POINT = "";

        //описание элементов на странице
        private static readonly By TitleLabelBy = By.XPath("//h4[contains(text(),'Project')]");
        private static readonly By NameInputBy = By.CssSelector("[data-testid='textbox-name']");
        private static readonly By ProjectKeyInputBy = By.CssSelector("[data-testid='textbox-key']");
        private static readonly By DescriptionInputBy = By.CssSelector("[data-testid='textbox-description']");
        private static readonly By DeleteButtonBy = By.CssSelector("[data-testid='section-project_edit'] button[data-testid='button-more_single:delete']");

        // инициализация класса
        public EditProjectPage(IWebDriver driver) : base(driver)
        {
        }

        public EditProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            throw new NotImplementedException();
        }

        [AllureStep("Click Delete Button")]
        public AllProjectsPage DeleteButtonClick()
        {
            DeleteButton.Click();
            return new AllProjectsPage(_driver);
        }

        // Методы
        public UIElement TitleLabel => new(_driver, TitleLabelBy);
        public UIElement NameInput => new(_driver, NameInputBy);
        public UIElement ProjectKeyInput => new(_driver, ProjectKeyInputBy);
        public UIElement DescriptionInput => new(_driver, DescriptionInputBy);
        public Button DeleteButton => new(_driver, DeleteButtonBy);
    }
}
