using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class ProgressBarDialogTests : BaseTest
    {
        private IWebElement successButton => driver.FindElement(By.CssSelector(".btn-success"));
        private IWebElement successModalElement => driver.FindElement(By.CssSelector(".modal.fade.in"));
        private IWebElement successModalHeaderElement { 
            get {
               try {
               return driver.FindElement(By.CssSelector(".modal.fade.in .modal-header"));
            }
                catch (NoSuchElementException){
                    return null;

               }
            }
         } 

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-progress-bar-dialog-demo.html";
        }
        [Test]
        public void TestProgressBarDialog()
        {
            successButton.Click();
            Assert.IsNotNull(successModalElement);
            Assert.AreEqual("Custom message", successModalHeaderElement.Text);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => successModalElement == null);
            Assert.IsNull(successModalElement);
        }


    }
}
