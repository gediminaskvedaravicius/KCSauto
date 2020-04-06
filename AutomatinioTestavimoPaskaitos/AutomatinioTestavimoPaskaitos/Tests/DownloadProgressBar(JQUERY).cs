using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class DownloadProgressBar_JQUERY_ : BaseTest
    {
        private IWebElement downloadButton => driver.FindElement(By.Id("downloadButton"));
        private IWebElement closeButton => driver.FindElement(By.CssSelector(".ui-dialog-buttonset > button"));
        private IWebElement finishedTextElement => driver.FindElement(By.CssSelector(".progress-label"));

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/jquery-download-progress-bar-demo.html";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
        }

        [Test]
        public void TestDownload()
        {
            downloadButton.Click();
            Thread.Sleep(30000);
            Assert.AreEqual("Complete!", finishedTextElement.Text);
        }
        [Test]
        public void TestDownload2()
        {
            downloadButton.Click();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementIsVisible(By.CssSelector(".ui-dialog-buttonset > button")));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
            Assert.IsTrue(closeButton.Displayed);
            
        }

        [Test]
        public void TestDownload3()
        {
            downloadButton.Click();

            string finishedText = "Complete!";


            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.TextToBePresentInElement(finishedTextElement, finishedText));

            Assert.AreEqual("Complete!", finishedTextElement.Text);
        }
        [Test]
        public void TestDownload4()
        {
            downloadButton.Click();

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementIsVisible(By.CssSelector(".ui-dialog-buttonset > button")));
            }
            catch(WebDriverTimeoutException e)
            {

            }
            finally
            {
               driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            }

            Assert.AreEqual("Complete!", finishedTextElement.Text);
        }


    }
}
