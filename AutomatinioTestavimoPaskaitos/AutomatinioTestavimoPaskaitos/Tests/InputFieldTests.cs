using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class InputFieldTests
    {
        [SetUp]
        public void BeforeTest ()
        {

        }


        [Test]
        public void ShowMessage()
        {
            //SetUp arba tai galima vadinti PreCondition
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();

            //Testas prasideda nuo sitos eilutes
            driver.FindElement(By.Id("user-message")).SendKeys("tekstas");
            driver.FindElement(By.CssSelector("#get-input button")).Click();

            Assert.AreEqual("tekstas", driver.FindElement(By.Id("display")).Text);

        }

        [Test]
        public void CountSum ()
        {
            //Precondition
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();

            //Testas
            driver.FindElement(By.Id("sum1")).SendKeys("5");
            driver.FindElement(By.Id("sum2")).SendKeys("2");
            driver.FindElement(By.CssSelector("#gettotal button")).Click();

            Assert.AreEqual("7", driver.FindElement(By.Id("displayvalue")).Text);
        }

    }
}
