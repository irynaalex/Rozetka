using OpenQA.Selenium;

namespace PageObject
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver _driver) : base(_driver) { }

        private readonly By _fieldSearch = By.Name("search");
        private readonly By _searchLineFirm = By.Name("searchline");
        private readonly By _searchLineFirmClick = By.CssSelector("div:nth-child(3)  rz-filter-section-autocomplete > ul:nth-child(2) > li > a");
       
        public void searchText(string text) => WaitAndFindElement(_fieldSearch).SendKeys(text+Keys.Enter);
    
        public void searchLineFirm(string text) => WaitAndFindElement(_searchLineFirm).SendKeys(text);
        public void searchLineTextClick() => WaitAndFindElement(_searchLineFirmClick).Click();
        public void waitSearchLineTextClick() => Waitforelement(_driver,_searchLineFirmClick);

    }
}
