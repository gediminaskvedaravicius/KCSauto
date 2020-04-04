using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Pages
{
    public class InputFieldPage : BasePage
    {
        private IWebElement inputTextField => driver.FindElement(By.Id("user-message"));
        private IWebElement showMessageButton => driver.FindElement(By.CssSelector("#get-input button"));
        
        private IWebElement inputNumberOne => driver.FindElement(By.Id("sum1"));
        private IWebElement inputNumberTwo => driver.FindElement(By.Id("sum2"));
        private IWebElement getTotalButton => driver.FindElement(By.CssSelector("#gettotal button"));
        

        public InputFieldPage (IWebDriver driver) : base(driver) { }

        // First block methods
        public InputFieldPage EnterMessage (string text)
        {
            inputTextField.SendKeys(text);
            return this;
        }

        public InputFieldPage ClearMessage()
        {
            inputTextField.Clear();
            return this;
        }
        public InputFieldPage ClickShowMessage()
        {
            showMessageButton.Click();
            return this;
        }
        

        // Second block methods
        public InputFieldPage EnterFirstNumber (string number)
        {
            inputNumberOne.SendKeys(number);
            return this;
        }
        public InputFieldPage EnterSecondNumber(string number)
        {
            inputNumberTwo.SendKeys(number);
            return this;
        }
        public InputFieldPage EnterFirstAndSecondNumber(string number1, string number2)
        {
            inputNumberOne.SendKeys(number1);
            inputNumberTwo.SendKeys(number2);
            return this;
        }
        public InputFieldPage ClickCalculateSum()
        {
            getTotalButton.Click();
            return this;
        }


    }
}
