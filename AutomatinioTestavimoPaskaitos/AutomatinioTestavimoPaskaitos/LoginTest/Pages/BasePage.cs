using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.LoginTest.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage (IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
