using AutomatinioTestavimoPaskaitos.LoginTest.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.LoginTest
{
    public class LoginTest2 : BaseTest
    {
        
        [Test]
        public void TestLogin()
        {
            loginPage.Login(User.DefaultUser);
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