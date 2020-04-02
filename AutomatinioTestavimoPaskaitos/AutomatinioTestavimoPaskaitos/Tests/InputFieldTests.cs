using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class InputFieldTests : BaseTest
    {
        private IWebElement inputTextField => driver.FindElement(By.Id("user-message"));
        private IWebElement showMessageButton => driver.FindElement(By.CssSelector("#get-input button"));
        private IWebElement displayedText => driver.FindElement(By.Id("display"));
        private IWebElement inputNumberOne => driver.FindElement(By.Id("sum1"));
        private IWebElement inputNumberTwo => driver.FindElement(By.Id("sum2"));
        private IWebElement getTotalButton => driver.FindElement(By.CssSelector("#gettotal button"));
        private IWebElement displayedValue =>  driver.FindElement(By.Id("displayvalue"));

        [SetUp]
        public void BeforeTest ()
        {   
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
        }


        [Test]
        public void ShowMessage()
        {
            var irasomasTekstas = "tekstas";
            
            inputTextField.SendKeys(irasomasTekstas);
            showMessageButton.Click();

            Assert.AreEqual(irasomasTekstas, displayedText.Text);
        }

        [Test]
        public void CountSum ()
        {
            inputNumberOne.SendKeys("5");
            inputNumberTwo.SendKeys("2");
            getTotalButton.Click();

            Assert.AreEqual("7", displayedValue.Text);
        }
    }
}
