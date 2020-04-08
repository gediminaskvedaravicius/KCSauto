using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class RangeSlidersTests : BaseTest
    {
        private IWebElement dangerSlideElement => driver.FindElement(By.CssSelector(".range-danger input"));
        private IWebElement dangerLineOutputElement => driver.FindElement(By.Id("rangeDanger"));

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/drag-drop-range-sliders-demo.html";
        }
        [Test]
        public void TestDangerSlide()
        {
            for (int i=1; i<= 16; i++)
            {
                dangerSlideElement.SendKeys(Keys.ArrowLeft);
            }
            Thread.Sleep(2000);
            Assert.AreEqual("34", dangerLineOutputElement.Text);
        }
        [Test]
        public void TestDefaultValue()
        {
            Assert.AreEqual("50", dangerLineOutputElement.Text);
        }
    }
}
