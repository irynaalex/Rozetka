using OpenQA.Selenium;

namespace PageObject
{
   public class HomePage : BasePage
    {
        public HomePage(IWebDriver _driver) : base(_driver)
        {
        }
        private readonly By _menuCategoriesNetboock = By.CssSelector("sidebar-fat-menu li:nth-child(1)");

        public void ClickMenuCategoriesNetboock() => WaitAndFindElement(_menuCategoriesNetboock).Click();

    }
}
