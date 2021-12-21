using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using Task4RozetkaUA.Models;


namespace Tests
{
    [Parallelizable]
    public class BaseTest
    {
        public static IEnumerable<Filter> GetTestDataFromXml()
        {
            Filters filters = FilterReader.ReadFiltersFromXML();
            for (int i = 0; i < filters.FiltersList.Count; i++)
            {
                yield return filters.FiltersList[i];
            }
        }
              
        private static readonly ThreadLocal<IWebDriver> DriverThreadlocal = new();
        public static IWebDriver _driver
        {
            get
            {
                if (!DriverThreadlocal.IsValueCreated)
                {
                    throw new ArgumentException("Driver is not initialized!");
                }
                return DriverThreadlocal.Value;
            }
        }

        [SetUp]
        public void Setup()
        {
             DriverThreadlocal.Value = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://rozetka.com.ua");
            _driver.Manage().Window.Maximize();
        }
                
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}