using AutomatinioTestavimoPaskaitos.LoginTest.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.LoginTest
{
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private HomePage homePage;

        [SetUp]
        public void InitPages()
        {
            loginPage = new LoginPage(Driver);
            homePage = new HomePage(Driver);
        }
        [Test]
        public void TestLogin()
        {
            loginPage.EnterUsername("opensourcecms");
            loginPage.EnterPassword("opensourcecms");
            loginPage.ClickLoginButton();

            homePage.AssertLogoutButtonIsVisible();
        }

        [TearDown]
        public void Logout()
        {
            homePage.ClickLogout();
            loginPage.AssertLoginButtonIsVisible();
        }
    }
}
