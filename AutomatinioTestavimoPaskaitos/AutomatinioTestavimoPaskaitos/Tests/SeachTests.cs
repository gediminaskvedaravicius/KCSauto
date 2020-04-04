using AutomatinioTestavimoPaskaitos.Pages;
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
        private SearchPage searchPage;

        [SetUp]
        public void BeforeTest ()
        {
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-dual-list-box-demo.html";
            
            searchPage = new SearchPage(driver);

        }
        [Test]
        public void TestSearch()
        {
            searchPage
                .EnterTextInSearchField("Vestibulum")
                .AssertSearchElementCount(1)
                .AssertSearchElementList("Vestibulum at eros");

        }

        [Test]
        public void TestSearchEmptyResult()
        {
            searchPage
                .EnterTextInSearchField("nesamone")
                .AssertSearchElementCount(0);

        }
    }
}