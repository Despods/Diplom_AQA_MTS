using GraduateWork.Elements;
using OpenQA.Selenium;

namespace Diplom_AQA_MTS.Elements
{
    public class Button//обернем элемент кнопку для удобства работы с ней
    {
        private UIElement _uiElement;

        public Button(IWebDriver webDriver, By by)
        {
            _uiElement = new UIElement(webDriver, by);
        }

        public Button(IWebDriver webDriver, IWebElement webElement)
        {
            _uiElement = new UIElement(webDriver, webElement);
        }

        public void Click()
        {
            _uiElement.Click();
        }

        public void Submit()
        {
            _uiElement.Submit();
        }

        public string GetAttribute(string attributeName)
        {
            return _uiElement.GetAttribute(attributeName);
        }

        public string Text => _uiElement.Text;
        public bool Displayed => _uiElement.Displayed;
        public bool Enabled => _uiElement.Enabled;
    }
}
