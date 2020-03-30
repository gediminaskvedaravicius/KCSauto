using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class RadiobuttonTests
    {
        [Test]
        public void NothingChecked ()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("buttoncheck")).Click();
            Assert.AreEqual("Radio button is Not checked", driver.FindElement(By.Id("buttoncheck")).Text);
        }

        [Test]
        public void MaleIsChecked ()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.CssSelector("input[value='Male']")).Click();
            driver.FindElement(By.Id("buttoncheck")).Click();
            Assert.AreEqual("Radio button 'Male' is checked", driver.FindElement(By.Id("buttoncheck")).Text);
        }

        [Test]
        public void FemaleIsChecked()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.CssSelector("input[value='Female']")).Click();
            driver.FindElement(By.Id("buttoncheck")).Click();
            Assert.AreEqual("Radio button 'Female' is checked", driver.FindElement(By.Id("buttoncheck")).Text);
        }

        [Test]

        public void GroupRadioButtonChecked ()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement GetValuesButton = driver.FindElement(By.CssSelector(".btn:nth-child(5)"));
            IWebElement MaleRadioButton = driver.FindElement(By.Name("gender"));
            IWebElement FemaleRadioButton = driver.FindElement(By.CssSelector(".panel-body > div:nth-child(2) > .radio-inline:nth-child(3) > input"));
            IWebElement AgeZeroToFiveRadioButton = driver.FindElement(By.Name("ageGroup"));
            IWebElement AgeFiveToFifteenRadioButton = driver.FindElement(By.CssSelector("div:nth-child(3) > .radio-inline:nth-child(3) > input"));
            IWebElement AgeFifteenToFiftyRadioButton = driver.FindElement(By.CssSelector(".radio-inline:nth-child(4) > input"));

            GetValuesButton.Click();
            Assert.AreEqual("Sex :\r\nAge group:", driver.FindElement(By.CssSelector(".groupradiobutton")).Text);

            MaleRadioButton.Click();
            AgeZeroToFiveRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Male\r\nAge group: 0 - 5", driver.FindElement(By.CssSelector(".groupradiobutton")).Text);

            MaleRadioButton.Click();
            AgeFiveToFifteenRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Male\r\nAge group: 5 - 15", driver.FindElement(By.CssSelector(".groupradiobutton")).Text);
            
            MaleRadioButton.Click();
            AgeFifteenToFiftyRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Male\r\nAge group: 15 - 50", driver.FindElement(By.CssSelector(".groupradiobutton")).Text);

            FemaleRadioButton.Click();
            AgeZeroToFiveRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Female\r\nAge group: 0 - 5", driver.FindElement(By.CssSelector(".groupradiobutton")).Text);

            FemaleRadioButton.Click();
            AgeFiveToFifteenRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Female\r\nAge group: 5 - 15", driver.FindElement(By.CssSelector(".groupradiobutton")).Text);

            FemaleRadioButton.Click();
            AgeFifteenToFiftyRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Female\r\nAge group: 15 - 50", driver.FindElement(By.CssSelector(".groupradiobutton")).Text);

        }

    }
}
