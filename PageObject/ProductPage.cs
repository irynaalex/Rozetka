using OpenQA.Selenium;

namespace PageObject
{
    public class ProductPage: BasePage
    {
        public ProductPage(IWebDriver _driver) : base(_driver) { }

        private readonly By _buttonChoiceByPrice = By.CssSelector("select[_ngcontent-rz-client-c42='']");
        private readonly By _buttonChoiceByPriceExpensive = By.CssSelector("select[_ngcontent-rz-client-c42=''] option[value='2: expensive']");
        private readonly By _buttonIconAddProductBay = By.XPath("//*[@class ='toOrder ng-star-inserted']");
        private readonly By _buttonProductsInCart = By.XPath("//button[@class ='header__button ng-star-inserted header__button--active']");


        public void buttonChoiceByPric() => WaitAndFindElement(_buttonChoiceByPrice).Click();
        public void buttonChoiceByPriceExpensive() => WaitAndFindElement(_buttonChoiceByPriceExpensive).Click();
        public void buttonIconAddProductBay() => WaitAndFindElement(_buttonIconAddProductBay).Click();
        public void waitButtonIconAddProductBay() => Waitforelement(_driver, _buttonIconAddProductBay);
        public void buttonProductsInCart() => WaitAndFindElement(_buttonProductsInCart).Click();

    }
}
