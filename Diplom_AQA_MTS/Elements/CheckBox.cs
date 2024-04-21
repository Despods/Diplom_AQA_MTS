using GraduateWork.Elements;
using OpenQA.Selenium;

namespace Diplom_AQA_MTS.Elements
{
    public class CheckBox
    {
        private UIElement _uiElement;//обернем чекбокс для удобства работы с ним

        /// <summary>
        /// Данный элемент должен использовать атрибут 'use' для локатора
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        public CheckBox(IWebDriver driver, By by)
        {
            _uiElement = new UIElement(driver, by);
        }

        public CheckBox(IWebDriver driver, IWebElement webElement)
        {
            _uiElement = new UIElement(driver, webElement);
        }

        public void Set(bool flag)//если чекбокс уже отмечен, то мы не будем по нему кликать
        {
            if (_uiElement.GetAttribute("href") == "#icon-checkbox-unchecked")
                _uiElement.Click();
        }

        public bool Displayed => _uiElement.Displayed;
    }
}
