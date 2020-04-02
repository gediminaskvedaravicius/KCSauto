using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    

    
    public class CheckboxTests : BaseTest
    {
        private IWebElement singleCheckboxElement => driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement displayedText => driver.FindElement(By.Id("txtAge"));
        private IWebElement checkAllButton => driver.FindElement(By.Id("check1"));
        private IWebElement uncheckAllButton => driver.FindElement(By.CssSelector("input[value='Uncheck All']"));

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        }

        [Test]
        public void TestCheckbox ()
        {
            singleCheckboxElement.Click();

            var tekstas = "Success - Check box is checked";
            
            Assert.IsTrue(singleCheckboxElement.Selected, "Checkbox was not selected");
            Assert.AreEqual(tekstas, displayedText.Text, "Checkbox was not selected");
            
        }

        [Test]
        public void CheckAllTest ()
        {
            checkAllButton.Click();

            var mygtukoTekstas = "Uncheck All";

            Assert.AreEqual(mygtukoTekstas, checkAllButton.GetProperty("value"));
            Assert.IsNotNull(uncheckAllButton,"Mygtuko tekstas turejo pasikeisti");

            var checkboxElementList = driver.FindElements(By.CssSelector(".cb1-element"));

            //var checkboxElementList1 = driver.FindElements(By.CssSelector(".text-left .panel ul~.checkbox input"));
            //var checkboxElementList2 = driver.FindElements(By.CssSelector("ul~.checkbox input"));
            //var checkboxElementList3 = driver.FindElements(By.CssSelector(".text-left .panel"))[1].FindElement(By.CssSelector(".checkbox input"));
            //var checkboxElementList5 = driver.FindElements(By.XPath("//ul//..//input[@class='cb1-element']"));
            //var checkboxElementList6 = driver.FindElements(By.CssSelector(".cb1-element"));
            //var checkboxElementList7 = driver.FindElements(By.CssSelector("input.cb1-element"));

            Assert.AreEqual(4, checkboxElementList.Count, "Turejo buti 4 elementai");

            foreach (var checkboxElement in checkboxElementList)
            {
                Assert.IsTrue(checkboxElement.Selected, "Kazkuris checkboxas arba keli yra nepazymeti");
            }
        }

        [TearDown]
        public void AfterTest ()
        {
            driver.Quit();
        }
    }
}
