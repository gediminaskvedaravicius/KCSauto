using Allure.Commons;
using AutomatinioTestavimoPaskaitos.LoginTest.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.LoginTest
{
    [AllureNUnit]
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected LoginPage loginPage;
        protected HomePage homePage;

        [SetUp]
        public void InitDriver()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Url = "https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/login";
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            InitPages();
        }
        
        public void InitPages()
        {
            loginPage = new LoginPage(Driver);
            homePage = new HomePage(Driver);
        }

        protected void MakeScreenshotOnTestFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                DoScreenshot();
            }
        }
        protected void MakeScreenshotOnTestFailure2()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                AllureLifecycle.Instance.WrapInStep (() =>
                {
                    var screenshot = DoScreenshot2();
                    AllureLifecycle.Instance.AddAttachment("Look at me!!", "img/png", screenshot, "png");
                }, 
                "Screen on test failure");

            }
        }

        protected void DoScreenshot()
        {
            Screenshot screenshot = Driver.TakeScreenshot();
            //folder sukurimas
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);

            //string screenshotFile = Path.Combine($"{TestContext.CurrentContext.WorkDirectory}/Screenshots", 
            string screenshotFile = Path.Combine(screenshotPath,
                $"{TestContext.CurrentContext.Test.Name}.png");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
        }

        protected byte[] DoScreenshot2()
        {
            Screenshot screenshot = Driver.TakeScreenshot();
            //folder sukurimas
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);

            //string screenshotFile = Path.Combine($"{TestContext.CurrentContext.WorkDirectory}/Screenshots", 
            string screenshotFile = Path.Combine(screenshotPath,
                $"{TestContext.CurrentContext.Test.Name}.png");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            return screenshot.AsByteArray;
        }
        [TearDown]
        public void QuitDriver()
        {
            Driver.Quit();
        }
    }
}
