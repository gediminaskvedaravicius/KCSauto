using AutomatinioTestavimoPaskaitos.Values;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Pages
{
    public class DropDownPage : BasePage
    {
        private IWebElement singleDropdown => driver.FindElement(By.Id("select-demo"));
        private SelectElement singleDropdownSelectElement => new SelectElement(singleDropdown);
        private IWebElement displaySelectedDayElement => driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement multiChoiceElement => driver.FindElement(By.Id("multi-select"));
        private SelectElement multiselectElement => new SelectElement(multiChoiceElement);
        private IWebElement firstSelectedButton => driver.FindElement(By.Id("printMe"));
        private IWebElement showAllSelectedElement => driver.FindElement(By.CssSelector(".getall-selected"));
        private IList<IWebElement> stateOptionElementList => multiselectElement.Options;
        private IWebElement getAllSelectedButton => driver.FindElement(By.Id("printAll"));

        public DropDownPage(IWebDriver driver) : base(driver) { }

        public DropDownPage SelectDay(WeekDay weekDay)
        {
            singleDropdownSelectElement.SelectByValue(weekDay.day);
            return this;
        }

        //var numeris = 1; 
        //Console.WriteLine("As {0}", numeris);

        public DropDownPage AssertSelectedDay(WeekDay weekDay)
        {
            Assert.AreEqual($"Day selected :- {WeekDay.FRIDAY.day}", displaySelectedDayElement.Text);
            return this;
        }

        public DropDownPage SelectState (State state)
        {
            multiselectElement.SelectByValue(state.state);
            return this;
        }
        public DropDownPage SelectSecondState (State state)
        {
            var builder = new Actions(driver);
            builder.KeyDown(Keys.Control);
            builder.Click(stateOptionElementList[state.index]);
            builder.KeyUp(Keys.Control);
            builder.Build().Perform();
            return this;
        }
        public DropDownPage ClickPrintSingle ()
        {
            firstSelectedButton.Click();
            return this;
        }
        public DropDownPage ClickPrintAll()
        {
            getAllSelectedButton.Click();
            return this;
        }
        public DropDownPage AssertFirstSelected(State state)
        {
            Assert.AreEqual($"First selected option is : {state.state}", showAllSelectedElement.Text);
            return this;
        }
        
        public DropDownPage AssertAllSelectedState (List<State> stateList)
        {
            string stateList2 = "";
            foreach (var state in stateList)
            {
                stateList2 += $"{state.state},";
            }
            stateList2 = stateList2.Substring(0, stateList2.Length - 1);

            Assert.AreEqual($"Options selected are : {stateList2}", showAllSelectedElement.Text);
            return this;
        }





    }
}
