using Allure.Helpers;
using Diplom_AQA_MTS.Elements;
using GraduateWork.Elements;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;


namespace Diplom_AQA_MTS.Pages.ProjectPages
{
    public class AllProjectsPage : BasePage
    {
        private static string END_POINT = "settings/projects";

        //описание элементов на странице
        private static readonly By TitleLabelBy = By.CssSelector("div h3.sc-fAUVGl");
        private static readonly By ProjectNamesBy = By.CssSelector("[data-testid='cell-name'] span");
        private static readonly By ProjectKeysBy = By.CssSelector("[data-testid='cell-project_key'] span");
        private static readonly By ConfirmButtonBy = By.CssSelector("[data-testid='button-affirm']");

        // инициализация класса
        public AllProjectsPage(IWebDriver driver) : base(driver)
        {
        }

        public AllProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public List<string> ProjectNamesText
        {
            get
            {
                List<string> result = new List<string>();

                foreach (UIElement element in ProjectNames)
                {
                    result.Add(element.Text);
                }

                return result;
            }
        }

        public List<string> ProjectKeysText
        {
            get
            {
                List<string> result = new List<string>();

                foreach (UIElement element in ProjectKeys)
                {
                    result.Add(element.Text);
                }

                return result;
            }
        }

        [AllureStep("Выбираем элемент по Project Name")]
        public DashBoardPage SelectByProjectNameElementLink(UIElement element)
        {
            element.Click();
            return new DashBoardPage(_driver);
        }

        [AllureStep("Выбираем элемент по Project Key")]
        public EditProjectPage SelectRecordByProjectKeyElement(UIElement element)
        {
            element.Click();
            return new EditProjectPage(_driver);
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpenend()
        {
            try
            {
                return TitleLabel.Text.Trim() == "Projects";
            }
            catch (Exception)
            {
                return false;
            }
        }

        [AllureStep("Жмем кнопку подтвердить")]
        public T ConfirmButtonClick<T>()
        {
            ConfirmButton.Click();
            return (T)Activator.CreateInstance(typeof(T), _driver, false);
        }

        // Методы
        public UIElement TitleLabel => new(_driver, TitleLabelBy);
        public List<UIElement> ProjectNames => _waitsHelper.WaitForAllVisibleUiElementsLocatedBy(ProjectNamesBy);
        public List<UIElement> ProjectKeys => _waitsHelper.WaitForAllVisibleUiElementsLocatedBy(ProjectKeysBy);
        public Button ConfirmButton => new(_driver, ConfirmButtonBy);
    }
}
