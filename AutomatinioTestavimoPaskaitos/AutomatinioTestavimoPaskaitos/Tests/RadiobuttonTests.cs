using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class RadiobuttonTests : BaseTest
    {
        private IWebElement getCheckedValueButton => driver.FindElement(By.Id("buttoncheck"));
        private IWebElement radioDisplayedText => driver.FindElement(By.CssSelector(".radiobutton"));
        private IWebElement topMaleRadioButton => driver.FindElement(By.CssSelector("input[value='Male']"));
        private IWebElement topFemaleRadioButton => driver.FindElement(By.CssSelector("input[value='Female']"));
        private IWebElement GetValuesButton => driver.FindElement(By.CssSelector(".btn:nth-child(5)"));
        private IWebElement MaleRadioButton => driver.FindElement(By.Name("gender"));
        private IWebElement FemaleRadioButton => driver.FindElement(By.CssSelector(".panel-body > div:nth-child(2) > .radio-inline:nth-child(3) > input"));
        private IWebElement AgeZeroToFiveRadioButton => driver.FindElement(By.Name("ageGroup"));
        private IWebElement AgeFiveToFifteenRadioButton => driver.FindElement(By.CssSelector("div:nth-child(3) > .radio-inline:nth-child(3) > input"));
        private IWebElement AgeFifteenToFiftyRadioButton => driver.FindElement(By.CssSelector(".radio-inline:nth-child(4) > input"));
        private IWebElement groupRadioDisplayedText => driver.FindElement(By.CssSelector(".groupradiobutton"));

        [SetUp]
        public void BeforeTest ()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
        }
        [Test]
        public void NothingChecked ()
        {
            getCheckedValueButton.Click();
            Assert.AreEqual("Radio button is Not checked", radioDisplayedText.Text);
        }

        [Test]
        public void MaleIsChecked ()
        {
            topMaleRadioButton.Click();
            getCheckedValueButton.Click();
            Assert.AreEqual("Radio button 'Male' is checked", radioDisplayedText.Text);
        }

        [Test]
        public void FemaleIsChecked()
        {
            topFemaleRadioButton.Click();
            getCheckedValueButton.Click();
            Assert.AreEqual("Radio button 'Female' is checked", radioDisplayedText.Text);
        }

        [Test]
        public void GroupRadioButtonChecked ()
        {
            GetValuesButton.Click();
            Assert.AreEqual("Sex :\r\nAge group:", groupRadioDisplayedText.Text);

            MaleRadioButton.Click();
            AgeZeroToFiveRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Male\r\nAge group: 0 - 5", groupRadioDisplayedText.Text);

            MaleRadioButton.Click();
            AgeFiveToFifteenRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Male\r\nAge group: 5 - 15", groupRadioDisplayedText.Text);
            
            MaleRadioButton.Click();
            AgeFifteenToFiftyRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Male\r\nAge group: 15 - 50", groupRadioDisplayedText.Text);

            FemaleRadioButton.Click();
            AgeZeroToFiveRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Female\r\nAge group: 0 - 5", groupRadioDisplayedText.Text);

            FemaleRadioButton.Click();
            AgeFiveToFifteenRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Female\r\nAge group: 5 - 15", groupRadioDisplayedText.Text);

            FemaleRadioButton.Click();
            AgeFifteenToFiftyRadioButton.Click();
            GetValuesButton.Click();
            Assert.AreEqual("Sex : Female\r\nAge group: 15 - 50", groupRadioDisplayedText.Text);

        }

    }
}
