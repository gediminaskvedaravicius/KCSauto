using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class CheckboxTests
    {
        [Test]
        public void TestCheckbox ()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("isAgeSelected")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("isAgeSelected")).Selected, "Checkbox was not selected");
            Assert.AreEqual("Success - Check box is checked", driver.FindElement(By.Id("txtAge")).Text, "Checkbox was not selected");
            
        }

        [Test]
        public void CheckAllTest ()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("check1")).Click();

            Assert.AreEqual("Uncheck All", driver.FindElement(By.Id("check1")).GetProperty("value"));
            Assert.IsNotNull(driver.FindElement(By.CssSelector("input[value='Uncheck All']")),"Mygtuko tekstas turejo pasikeisti");

            var checkboxElementList = driver.FindElements(By.CssSelector(".cb1-element"));

            Assert.AreEqual(4, checkboxElementList.Count, "Turejo buti 4 elementai");

            foreach (var checkboxElement in checkboxElementList)
            {
                Assert.IsTrue(checkboxElement.Selected, "Kazkuris checkboxas arba keli yra nepazymeti");
            }


        }
    }
}
