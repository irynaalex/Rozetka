using NUnit.Framework;
using OpenQA.Selenium;
using PageObject;
using Task4RozetkaUA.Models;

namespace Tests
{
    [TestFixture]
    
    //[Parallelizable(scope: ParallelScope.All)]
    [Parallelizable]
    public class ProductSearchTest: BaseTest
    {
        //[assembly: LevelOfParallelism(3)]
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
            IJavaScriptExecutor js = ((IJavaScriptExecutor)_driver);
            js.ExecuteScript("window.scrollTo(0, -document.body.scrollHeight);");
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
