using AutomatinioTestavimoPaskaitos.LoginTest.Pages;
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

        [TearDown]
        public void QuitDriver()
        {
            Driver.Quit();
        }
    }
}
