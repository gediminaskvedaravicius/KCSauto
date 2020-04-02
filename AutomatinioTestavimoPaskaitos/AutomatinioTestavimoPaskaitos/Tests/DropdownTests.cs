using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    
    public class DropdownTests : BaseTest
    {
        private IWebElement singleDropdown => driver.FindElement(By.Id("select-demo"));
        private IWebElement multiChoiceElement => driver.FindElement(By.Id("multi-select"));
        private IWebElement ohio => new SelectElement(multiChoiceElement).Options[4];
        private IWebElement firstSelectedButton => driver.FindElement(By.Id("printMe"));
        private IWebElement getAllSelectedButton => driver.FindElement(By.Id("printAll"));

        [SetUp]
        public void BeforeTest ()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        }

        [Test]
        public void SingleDropdown ()
        {
            //Select elementa galima pagal jo teksta
            //new SelectElement(singleDropdown).SelectByText("Wednesday");
            //Select elementa galima pagal jo value atributo verte
            //new SelectElement(singleDropdown).SelectByValue("Wednesday");
            //Select elementa galima pagal jo indeksa
            new SelectElement(singleDropdown).SelectByIndex(4);

            Assert.AreEqual("Day selected :- Wednesday", driver.FindElement(By.ClassName("selected-value")).Text);
            Assert.AreEqual("Day selected :- Wednesday", driver.FindElement(By.CssSelector(".selected-value")).Text);

            Assert.IsTrue(driver.FindElement(By.CssSelector(".selected-value")).Text.Contains("Wednesday"));        
        }

        [Test]
        public void MultiChoice ()
        {
            new SelectElement(multiChoiceElement).SelectByIndex(1);

            var builder = new Actions(driver);
            builder.KeyDown(Keys.Control);
            builder.Click(ohio);
            builder.KeyUp(Keys.Control);
            builder.Build().Perform();

            firstSelectedButton.Click();
            Assert.AreEqual("First selected option is : Florida", driver.FindElement(By.CssSelector(".getall-selected")).Text);

            getAllSelectedButton.Click();
            Assert.AreEqual("Options selected are : Florida,Ohio", driver.FindElement(By.CssSelector(".getall-selected")).Text);
        }
    }
}
