using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Pages
{
    public class SearchPage : BasePage
    {

        private IWebElement searchElement => driver.FindElement(By.Name("SearchDualList"));
        private IList<IWebElement> searchResultElementList => driver.FindElements(By.CssSelector(".list-left li:not([style *='display: none;'])"));

        public SearchPage(IWebDriver driver) : base(driver) { }

        public SearchPage EnterTextInSearchField(string text)
        {
            searchElement.SendKeys(text);
            return this;
        }
        public SearchPage AssertSearchElementCount(int elementCount)
        {
            Assert.AreEqual(elementCount, searchResultElementList.Count);
            return this;
        }

        public SearchPage AssertSearchElementList(string text)
        {
            Assert.AreEqual(text, searchResultElementList[0].Text);
            return this;
        }


    }
}
