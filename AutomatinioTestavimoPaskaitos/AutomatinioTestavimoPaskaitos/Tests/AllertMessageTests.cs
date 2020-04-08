using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class AllertMessageTests : BaseTest
    {
        //Normal Allert buttons
        private IWebElement normalSuccessMessageButton => driver.FindElement(By.Id("normal-btn-success"));
        private IWebElement normalWarningMessageButton => driver.FindElement(By.Id("normal-btn-warning"));
        private IWebElement normalErrorMessageButton => driver.FindElement(By.Id("normal-btn-danger"));
        private IWebElement normalInfoMessageButton => driver.FindElement(By.Id("normal-btn-info"));
        //Normal Allert close buttons
        private IWebElement normalSuccessMessageCloseButton => driver.FindElement(By.CssSelector(".alert-normal-success[style *='display: block;'] .close"));
        private IWebElement normalWarningMessageCloseButton => driver.FindElement(By.CssSelector(".alert-normal-warning[style *='display: block;'] .close"));
        private IWebElement normalErrorMessageCloseButton => driver.FindElement(By.CssSelector(".alert-normal-danger[style *='display: block;'] .close"));
        private IWebElement normalInfoMessageCloseButton => driver.FindElement(By.CssSelector(".alert-normal-info[style *='display: block;'] .close"));
        //Normal allert modal
        private IWebElement normalSuccessMessageModal
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector(".alert-normal-success[style *='display: block;']"));
                }
                catch (NoSuchElementException)
                {
                    return null; 
                }

            }
        }
        private IWebElement normalWarningMessageModal
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector(".alert-normal-warning[style *='display: block;']"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            }
        }
        private IWebElement normalErrorMessageModal
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector(".alert-normal-danger[style *='display: block;']"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            }
        }
        private IWebElement normalInfoMessageModal
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector(".alert-normal-info[style *='display: block;']"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            }
        }
        //Autocloseable
        private IWebElement WarningButton => driver.FindElement(By.Id("autoclosable-btn-warning"));
        private IWebElement WarningMessageModal
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector(".alert-autocloseable-warning[style *='display: block;']"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            }
        }



        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html";
        }
        [Test]
        public void NormalAllertMessageTest()
        {
            normalSuccessMessageButton.Click();
            Thread.Sleep(1000);
            Assert.IsNotNull(normalSuccessMessageModal);
            normalSuccessMessageCloseButton.Click();
            Thread.Sleep(1000);
            Assert.IsNull(normalSuccessMessageModal);

            normalWarningMessageButton.Click();
            Thread.Sleep(1000);
            Assert.IsNotNull(normalWarningMessageModal);
            normalWarningMessageCloseButton.Click();
            Thread.Sleep(1000);
            Assert.IsNull(normalWarningMessageModal);

            normalErrorMessageButton.Click();
            Thread.Sleep(1000);
            Assert.IsNotNull(normalErrorMessageModal);
            normalErrorMessageCloseButton.Click();
            Thread.Sleep(1000);
            Assert.IsNull(normalErrorMessageModal);

            normalInfoMessageButton.Click();
            Thread.Sleep(1000);
            Assert.IsNotNull(normalInfoMessageModal);
            normalInfoMessageCloseButton.Click();
            Thread.Sleep(1000);
            Assert.IsNull(normalInfoMessageModal);

        }
        [Test]
        public void AutocloseableTest()
        {
            WarningButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => WarningMessageModal == null);
            Assert.IsNull(WarningMessageModal);
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Close();
        }

    }
}
