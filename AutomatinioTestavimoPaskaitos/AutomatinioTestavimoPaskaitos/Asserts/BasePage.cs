using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Asserts
{
    public class BasePage
    {
        protected IWebDriver driver;
        public BasePage (IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
