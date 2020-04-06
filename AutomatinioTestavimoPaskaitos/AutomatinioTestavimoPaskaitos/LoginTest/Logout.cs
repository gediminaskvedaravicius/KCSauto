using AutomatinioTestavimoPaskaitos.LoginTest.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.LoginTest
{
    public class Logout : BaseTest
    {
        [SetUp]
        public void Login()
        {
            new LoginPage(Driver).Login2(User.DefaultUser);
        }
        [Test]
        public void TestLogout()
        {
            homePage.ClickLogout();
            loginPage.AssertLoginButtonIsVisible();
        }
    }
}
