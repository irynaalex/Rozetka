using NUnit.Framework;
using PageObject;
using Task4RozetkaUA.Models;

namespace Tests
{
    [Parallelizable(scope: ParallelScope.All)]
    public class ProductSearchTest: BaseTest
    {
        
        [TestCaseSource (nameof(GetTestDataFromXml))]
        public void Test1(Filter data)
        {
            HomePage homePage = new(_driver);
            homePage.ClickMenuCategoriesNetboock();
            
            SearchPage searchPage = new(_driver);
            searchPage.searchText(data.searchProduct);
            searchPage.searchLineFirm(data.searchFirm);
            searchPage.waitSearchLineTextClick();
            searchPage.searchLineTextClick();
        
            ProductPage productPage = new(_driver);
            productPage.buttonChoiceByPric();
            productPage.buttonChoiceByPriceExpensive();            
            productPage.waitButtonIconAddProductBay();
            productPage.buttonIconAddProductBay();
            productPage.buttonProductsInCart();
            
            ShoppingCartPage shoppingCartPage = new(_driver);
            Assert.IsTrue(MyAssert.MyIsTrue(data.orderSum, shoppingCartPage.textSumProductsInCart()), "don't incorect sum product in cart");
        }        
    }
}