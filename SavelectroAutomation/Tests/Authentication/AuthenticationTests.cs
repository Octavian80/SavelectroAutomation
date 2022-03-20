using NUnit.Framework;
using SavelectroAutomation.PageModels;
using SavelectroAutomation.Tests;
using SavelectroAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.Tests.Authentication
{
    class AuthenticationTests:BaseTest
    {

        string url = FrameworkConstants.GetUrl();
        [Test]

        public void AuthenticationPositive()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.ClickAccesAccount();

            LoginPage lp = new LoginPage(_driver);
            Assert.IsTrue(lp.CheckLoginPage("Ai deja un cont?"));
            lp.Login("cornel@com.ro", "astra");
        }
    }
}
