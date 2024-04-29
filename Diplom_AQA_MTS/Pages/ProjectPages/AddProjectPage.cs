using OpenQA.Selenium;
using Diplom_AQA_MTS.Elements;
using GraduateWork.Elements;
using Diplom_AQA_MTS.Models;
using NUnit.Allure.Attributes;

namespace Diplom_AQA_MTS.Pages
{
    public class AddProjectPage : BasePage
    {
        private static string END_POINT = "";

        //описание элементов на странице
        private static readonly By TitleLabelBy = By.XPath("//h4[contains(text(),'Create a new project')]");
        private static readonly By NameInputBy = By.CssSelector("[data-testid='textbox-name']");
        private static readonly By ProjectKeyInputBy = By.CssSelector("[data-testid='textbox-key']");
        private static readonly By DescriptionInputBy = By.CssSelector("[data-testid='textbox-description']");
        private static readonly By AddButtonBy = By.CssSelector("[data-testid='button-save-entity']");
        private static readonly By CloseButtonBy = By.CssSelector("[data-testid='button-close-entity'] div");
        private static readonly By ErrorLabelBy = By.XPath("//span[contains(text(),'Valid input is required')]");
        private static readonly By ProjectsMenuBy = By.CssSelector("[data-testid='button-projects']>div");
        private static readonly By ButtunBasePageBy = By.CssSelector("[href='#icon-expand-left-16']");

        // инициализация класса
        public AddProjectPage(IWebDriver driver) : base(driver)
        {
        }

        public AddProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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

        public AddProjectPage CreateProjectMenuSelect()
        {
            ProjectsMenu.SelectByText("Create a new project");
            return this;
        }

        public DashBoardPage AddProjectSuccessfull(Project project)
        {
            NameInput.SendKeys(project.ProjectName);
            ProjectKeyInput.SendKeys(project.ProjectKey);
            DescriptionInput.SendKeys(project.Description);
            AddButton.Click();
            
            Thread.Sleep(1000);
            
            return new DashBoardPage(_driver);
        }

        [AllureStep("Input Project Fields")]
        public AddProjectPage InputProjectFields(Project project)
        {
            NameInput.SendKeys(project.ProjectName);
            ProjectKeyInput.SendKeys(project.ProjectKey);
            DescriptionInput.SendKeys(project.Description);

            return new AddProjectPage(_driver);
        }

        // Методы
        public UIElement TitleLabel => new(_driver, TitleLabelBy);
        public UIElement NameInput => new(_driver, NameInputBy);
        public UIElement ProjectKeyInput => new(_driver, ProjectKeyInputBy);
        public UIElement DescriptionInput => new(_driver, DescriptionInputBy);
        public Button AddButton => new(_driver, AddButtonBy);
        public Button CloseButton => new(_driver, CloseButtonBy);
        public UIElement ErrorLabel => new(_driver, ErrorLabelBy);
        public DropDown ProjectsMenu => new(_driver, ProjectsMenuBy);
        public Button ButtunBasePage => new(_driver, ButtunBasePageBy);
    }
}
