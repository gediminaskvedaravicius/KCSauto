using AutomatinioTestavimoPaskaitos.LoginTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
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

        [TearDown]
        public void QuitDriver()
        {
            Driver.Quit();
        }
    }
}
