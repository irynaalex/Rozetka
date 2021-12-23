using OpenQA.Selenium;

namespace PageObject
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver _driver) : base(_driver) { }

        private readonly By _fieldSearch = By.Name("search");
        private readonly By _searchLineFirm = By.Name("searchline");
        private readonly By _searchLineFirmClick = By.XPath("//div[3]//li//a[@class='checkbox-filter__link']");
       
        public void searchText(string text) => WaitAndFindElement(_fieldSearch).SendKeys(text+Keys.Enter);
    
        public void searchLineFirm(string text) => WaitAndFindElement(_searchLineFirm).SendKeys(text);
        public void searchLineTextClick() => _driver.FindElement(_searchLineFirmClick,2000).Click();
        public void waitSearchLineTextClick() => Waitforelement(_driver,_searchLineFirmClick);

    }
}
