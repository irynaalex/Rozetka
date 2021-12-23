using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace PageObject    
{    
    public class BasePage
    {
        private const int TimeWait = 3000;
        protected readonly IWebDriver _driver;
        public BasePage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public static bool Elexists(By by, IWebDriver _driver)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static void Waitforelement(IWebDriver _driver, By by)
        {
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(1000);
                if (Elexists(by, _driver))
                {
                    break;
                }
            }
        }

        public void WaitToBeClickable(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TimeWait));
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        public  IWebElement WaitAndFindElement(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TimeWait));
            return webDriverWait.Until(ExpectedConditions.ElementExists(by));
        }
    }

    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

    }
    public static class MyAssert
    {
        public static bool MyIsTrue(string first, string second)
        {
            string numericString = "";
            foreach (char c in second)
            {
                if ((c >= '0' && c <= '9') || c == ' ' || c == '-')
                {
                    numericString = String.Concat(numericString, c);
                }
                else
                    break;
            }
            if (Convert.ToInt32(first) < Convert.ToInt32(numericString))
            {
                return true;
            }
            else
                return false;
        }
    }
}
