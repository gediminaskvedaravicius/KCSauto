using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Asserts
{
    public class InputFieldPageAsserts : BasePage
    {
        private IWebElement displayedText => driver.FindElement(By.Id("display"));
        private IWebElement displayedValue => driver.FindElement(By.Id("displayvalue"));

        public InputFieldPageAsserts(IWebDriver driver) : base(driver) { }

        public void AssertMessageIs(string text)
        {
            Assert.AreEqual(text, displayedText.Text);

        }
        public void AssertSum(string expectedSum)
        {
            Assert.AreEqual(expectedSum, displayedValue.Text);

        }

    }
}
