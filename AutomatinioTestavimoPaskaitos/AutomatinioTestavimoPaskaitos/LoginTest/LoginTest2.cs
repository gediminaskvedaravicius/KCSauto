using AutomatinioTestavimoPaskaitos.LoginTest.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.LoginTest
{
    [AllureNUnit]
    public class LoginTest2 : BaseTest
    {
        
        [Test]
        public void TestLogin()
        {
            loginPage.EnterUsername2("opensourcecms");
            loginPage.EnterPassword2("opensourcecms");
            loginPage.ClickLoginButton2();
            homePage.AssertLogoutButtonIsVisible();
            MakeScreenshotOnTestFailure2();
        }

        [TearDown]
        public void Logout()
        {
            homePage.ClickLogout();
            loginPage.AssertLoginButtonIsVisible();
        }
    }
}