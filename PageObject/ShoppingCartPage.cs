using OpenQA.Selenium;

namespace PageObject
{
    public class ShoppingCartPage:BasePage
    {
        public ShoppingCartPage(IWebDriver _driver) : base(_driver) { }

        private readonly By _textSumProductsInCart = By.XPath("//div[@class ='cart-receipt__sum-price']//span[contains(@class,'')]");

        public string textSumProductsInCart() => WaitAndFindElement(_textSumProductsInCart).Text;
    }
}
