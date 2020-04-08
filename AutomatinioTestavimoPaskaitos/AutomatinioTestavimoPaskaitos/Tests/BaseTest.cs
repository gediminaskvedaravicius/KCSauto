using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void BeforeEveryTest()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void AfterEveryTest()
        {
            driver.Quit();
        }
    }

    //BaseTest SetUp
        //InputFieldTests SetUp
        //vyks testai esantys InputFieldTests klasėje
        //InputFieldTests TearDown
    //BaseTest TearDown
}
