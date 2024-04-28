using OpenQA.Selenium;
using Diplom_AQA_MTS.Elements;
using GraduateWork.Elements;

namespace Diplom_AQA_MTS.Pages
{
    public class DashBoardPage : BasePage
    {
        private static string END_POINT = "dashboard";

        //описание элементов на странице
        private static readonly By WelcomeMessageBy = By.XPath("//p[contains(text(), 'Have a great day')]");
        private static readonly By ButtonCreateTestCasesBy = By.XPath("//h4[contains(text(), 'Create test cases')]");

        // инициализация класса
        public DashBoardPage(IWebDriver driver) : base(driver)
        {
        }

        public DashBoardPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public override bool IsPageOpenend()
        {
            try
            {
                return WelcomeMessage.Displayed;
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

        public void CreateTestCaseClick()
        {
            ButtonCreateTestCases.Click();
        }

        // Методы
        public UIElement WelcomeMessage => new(_driver, WelcomeMessageBy);
        public Button ButtonCreateTestCases => new(_driver, ButtonCreateTestCasesBy);
    }
}
