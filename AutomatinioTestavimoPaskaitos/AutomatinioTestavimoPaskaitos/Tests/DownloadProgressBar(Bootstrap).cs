using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class DownloadProgressBar_Bootstrap_ : BaseTest
    {
        private IWebElement downloadButton => driver.FindElement(By.Id("cricle-btn"));
        private IWebElement finishedTextElement => driver.FindElement(By.CssSelector(".percenttext"));

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void TestDownload()
        {
            downloadButton.Click();
            Thread.Sleep(30000);
            Assert.AreEqual("100%", finishedTextElement.Text);
        }
        [Test]
        public void TestDownload2()
        {
            downloadButton.Click();

            var explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            explicitWait.
                Until(ExpectedConditions.TextToBePresentInElement(finishedTextElement, "100%"));

            Assert.AreEqual("100%", finishedTextElement.Text);
        }

        [Test]
        public void TestDownload3()
        {
            downloadButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(d => finishedTextElement.Text == "100%");

            Assert.AreEqual("Complete!", finishedTextElement.Text);

        }
    }
}
