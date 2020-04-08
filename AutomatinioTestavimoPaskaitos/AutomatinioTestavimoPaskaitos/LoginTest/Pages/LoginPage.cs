
using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.LoginTest.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage (IWebDriver driver) : base(driver) { }
        private IWebElement usernameElement => Driver.FindElement(By.Id("txtUsername1"));
        private IWebElement passwordElement => Driver.FindElement(By.Id("txtPassword"));
        private IWebElement loginButtonElement => Driver.FindElement(By.Id("btnLogin"));

        public void EnterUsername2(string username)
        {
            // inicijuojame kad metodas bus itrauktas i reporta kaip stepas
            AllureLifecycle.Instance.WrapInStep(() =>
          {
              // Vykdomas kodas 
              usernameElement.SendKeys(username);
          },
          // Cia aprasomas stepo pavadinimas ka reporte atvaizduos
            $"Enter user name {username}");
        }
        public void EnterPassword2(string password)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
           {
               passwordElement.SendKeys(password);
           },
                "Enter password :******");
            
        }
        public void ClickLoginButton2()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                loginButtonElement.Click();
            },
            "User clicked login button");
            
        }

        public void EnterUsername (string username)
        {
            usernameElement.SendKeys(username);
        }
        public void EnterPassword (string password)
        {
            passwordElement.SendKeys(password);
            //Jeigu neveikia element.SendKeys galima naudoti actions builderi
            //1 budas: new Actions(Driver).SendKeys(usernameElement, username).Build().Perform().
            //2 budas: pirma Click(), o paskui element.Sendkeys
        }
        public void ClickLoginButton()
        {
            loginButtonElement.Click();
        }
        public void AssertLoginButtonIsVisible()
        {
            Assert.IsTrue(loginButtonElement.Displayed);
        }
        public void Login(User user)
        {
            EnterUsername(user.Username);
            EnterPassword(user.Password);
        }
        public void Login2(User user)
        {
            EnterUsername(user.Username);
            EnterPassword(user.Password);
            ClickLoginButton();
        }

    }
}
