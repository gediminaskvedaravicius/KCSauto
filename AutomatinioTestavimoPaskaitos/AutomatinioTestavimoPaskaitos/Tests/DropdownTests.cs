using NUnit.Framework;
using OpenQA.Selenium;
using AutomatinioTestavimoPaskaitos.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AutomatinioTestavimoPaskaitos.Values;

namespace AutomatinioTestavimoPaskaitos.Tests
{
    
    public class DropdownTests : BaseTest
    {
        private DropDownPage dropDownPage;

        [SetUp]
        public void BeforeTest ()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";

            dropDownPage = new DropDownPage(driver);
        }

        [Test]
        public void SingleDropdown ()
        {
            //singleDropdownSelectElement.SelectByValue("Wednesday");
            //Assert.AreEqual("Day selected :- Wednesday", displaySelectedDayElement.Text);

            dropDownPage.SelectDay(WeekDay.FRIDAY)
                .AssertSelectedDay(WeekDay.FRIDAY);

        }

        [Test]
        public void MultiChoice ()
        {
            dropDownPage
                .SelectState(State.CALIFORNIA)
                .SelectSecondState(State.FLORIDA)
                .ClickPrintSingle()
                .AssertFirstSelected(State.CALIFORNIA)
                .ClickPrintAll()
                .AssertAllSelectedState(new List<State> { State.CALIFORNIA, State.FLORIDA });
        }
    }
}

