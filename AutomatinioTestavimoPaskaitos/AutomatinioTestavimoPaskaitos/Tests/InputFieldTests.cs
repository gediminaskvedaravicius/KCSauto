using AutomatinioTestavimoPaskaitos.Pages;
using NUnit.Framework;
using AutomatinioTestavimoPaskaitos.Asserts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    public class InputFieldTests : BaseTest
    {
        private InputFieldPage inputFieldPage;
        private InputFieldPageAsserts inputFieldPageAsserts;

        [SetUp]
        public void BeforeTest ()
        {   
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            inputFieldPage = new InputFieldPage(driver);

            inputFieldPageAsserts = new InputFieldPageAsserts(driver);
        }


        [Test]
        public void ShowMessage()
        {
            var irasomasTekstas = "tekstas";
            var irasomasTekstas2 = "tekstas2";

            inputFieldPage
                .EnterMessage(irasomasTekstas)
                .ClickShowMessage();
            inputFieldPageAsserts.AssertMessageIs(irasomasTekstas);
            inputFieldPage.ClearMessage();

            inputFieldPage
                .EnterMessage(irasomasTekstas2)
                .ClickShowMessage();
            inputFieldPageAsserts.AssertMessageIs(irasomasTekstas2);
        }

        [Test]
        public void CountSum ()
        {
            var firstNumber = "2";
            var secondNumber = "5";
            var sum = "7";

            //inputNumberOne.SendKeys("5");
            //inputNumberTwo.SendKeys("2");
            //getTotalButton.Click();
            //Assert.AreEqual("7", displayedValue.Text);

            inputFieldPage
                .EnterFirstNumber(firstNumber)
                .EnterSecondNumber(secondNumber)
                .ClickCalculateSum();
            inputFieldPageAsserts.AssertSum(sum);
        }

        [Test]
        public void CountSum2()
        {
            inputFieldPage
                .EnterFirstAndSecondNumber("2", "5")
                .ClickCalculateSum();
            inputFieldPageAsserts.AssertSum("7");
        }
    }
}
