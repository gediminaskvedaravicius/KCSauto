using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class InputFormDemoTests : BaseTest
    {
        IWebElement firstname => driver.FindElement(By.Name("first_name"));
        IWebElement lastname => driver.FindElement(By.Name("last_name"));
        IWebElement email => driver.FindElement(By.Name("email"));
        IWebElement phone => driver.FindElement(By.Name("phone"));
        IWebElement address => driver.FindElement(By.Name("address"));
        IWebElement city => driver.FindElement(By.Name("city"));
        IWebElement state => driver.FindElement(By.Name("state"));
        IWebElement zip => driver.FindElement(By.Name("zip"));
        IWebElement website => driver.FindElement(By.Name("website"));
        IWebElement hosting => driver.FindElement(By.Name("hosting"));
        IWebElement comment => driver.FindElement(By.Name("comment"));
        IWebElement sendButton => driver.FindElement(By.CssSelector(".btn"));

        [SetUp]
        public void BeforeTest ()
        {
            driver.Url = "https://www.seleniumeasy.com/test/input-form-demo.html";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [Test]
        public void FillForm ()
        {
            firstname.SendKeys("Gediminas");
            lastname.SendKeys("Kvedaravicius");
            email.SendKeys("xx@xx.lt");
            phone.SendKeys("123456789");
            address.SendKeys("KCS");
            city.SendKeys("Kaunas");
            new SelectElement(state).SelectByIndex(1);
            zip.SendKeys("06643");
            website.SendKeys("www.website.com");
            hosting.Click();
            comment.SendKeys("komentaras");
            sendButton.Click();
            Thread.Sleep(1000);
            
            Assert.AreEqual("", firstname.Text);
            Assert.AreEqual("", lastname.Text);
            Assert.AreEqual("", email.Text);
            Assert.AreEqual("", phone.Text);
            Assert.AreEqual("", address.Text);
            Assert.AreEqual("", city.Text);
            Assert.AreEqual("", zip.Text);
            Assert.AreEqual("", website.Text);
            Assert.AreEqual("", comment.Text);
           
       }
    }

}
