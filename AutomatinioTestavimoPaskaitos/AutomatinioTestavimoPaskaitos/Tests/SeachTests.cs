using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class SearchTests : BaseTest
    {
        private IWebElement searchElement => driver.FindElement(By.Name("SearchDualList"));
        private IList<IWebElement> searchResultElementList => driver.FindElements(By.CssSelector(".list-left li:not([style *='display: none;'])"));

        [SetUp]
        public void BeforeTest ()
        {
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-dual-list-box-demo.html";
        }
        [Test]
        public void TestSearch()
        {
            searchElement.SendKeys("Vestibulum");
            
            Assert.AreEqual(1, searchResultElementList.Count);
            Assert.AreEqual("Vestibulum at eros", searchResultElementList[0].Text);
        }

        [Test]
        public void TestSearchEmptyResult()
        {
            searchElement.SendKeys("nesamone");
            Assert.AreEqual(0, searchResultElementList.Count);
        }
    }
}