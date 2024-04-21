using GraduateWork.Elements;
using OpenQA.Selenium;

namespace Diplom_AQA_MTS.Elements
{
    public class DropDown//обернем элемент DropDown для удобства работы с ним
    {
        private UIElement _uiElement;
        private List<UIElement> _list;
        private By _By = By.CssSelector("[data - testid = 'dropdown-menu']");

        public DropDown(IWebDriver driver, By by)
        {
            _uiElement = new UIElement(driver, by);
            _uiElement.Click();

            _list = _uiElement.FindUIElements(_By);
        }

        public bool Enabled => _uiElement.Enabled;

        public bool Displayed => _uiElement.Displayed;

        public List<string> GetOptions()//получим все значения элементов в DropDown
        {
            var tmp = new List<string>();

            foreach (UIElement element in _list)
            {
                tmp.Add(element.Text);
            }
            return tmp;
        }

        public void SelectByIndex(int index)//Выбор элемента по индексу
        {
            if( index < _list.Count )
            {
                _list[index].Click();
            }
            else
            {
                throw new AssertionException("Не можем определить элемент с индексом" + index);
            }
        }

        public void SelectByText(string text)//Выбор элемента по текстровому значению
        {
           foreach (UIElement element in _list)
            {
                if (element.Text == text)
                {
                    element.Click();
                }
                else
                {
                    throw new AssertionException("Не можем определить элемент с текстом" + text);
                }
            }
        }
    }
}
