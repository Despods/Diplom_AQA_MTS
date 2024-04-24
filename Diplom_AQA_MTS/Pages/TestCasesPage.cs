using Diplom_AQA_MTS.Elements;
using GraduateWork.Elements;
using OpenQA.Selenium;

namespace Diplom_AQA_MTS.Pages
{
    public class TestCasesPage : BasePage
    {
        private static string END_POINT = "testcases";

        //описание элементов на странице
        private static readonly By ButtonQuickCreateBy = By.XPath("//button/div[text()='Quick create')]");
        private static readonly By InputNameQuickCaseBy = By.XPath("[data-testid='textbox-quickadd']");
        private static readonly By ButtonCommitQuickCaseBy = By.XPath("[data-testid='button-component-commit']");
        private static readonly By ErrorLabelBy = By.Id("portal-root");


        // инициализация класса
        public TestCasesPage(IWebDriver driver) : base(driver)
        {
        }

        public override bool IsPageOpenend()
        {
            try
            {
                return ButtonQuickCreate.Displayed;
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

        // Методы
        public Button ButtonQuickCreate => new(_driver, ButtonQuickCreateBy);
        public UIElement InputNameQuickCase => new(_driver, InputNameQuickCaseBy);
        public Button ButtonCommitQuickCase => new(_driver, ButtonCommitQuickCaseBy);
        public UIElement ErrorLabel => new(_driver, ErrorLabelBy);

        // Методы получения свойств
        public string GetErrorLabelText() => ErrorLabel.Text.Trim().ToLower();
    }
}
