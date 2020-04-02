using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class DatePickerTest :BaseTest
    {
        private IWebElement DateInputElement => driver.FindElement(By.CssSelector("#sandbox-container1 .form-control"));
        private IWebElement TodayButtonInDatePickerContainer => driver.FindElement(By.CssSelector(".datepicker-days tfoot .today"));

        [SetUp]
        public void BeforeTest ()
        {
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-date-picker-demo.html";
        }

        [Test]
        public void PickTodayDateTest()
        {
            DateInputElement.Click();
            TodayButtonInDatePickerContainer.Click();
            
            Assert.AreEqual(DateTime.Today.ToString("dd/MM/yyyy"), DateInputElement.GetAttribute("value"));
        }
    }
}