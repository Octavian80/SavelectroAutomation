using NUnit.Framework;
using SavelectroAutomation.PageModels;
using SavelectroAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.Tests.Account
{
    class AccountTests:BaseTest
    {
        string url = FrameworkConstants.GetUrl();


        [Test]
        public void ChangePasswordSucces()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.ClickAccesAccount();
            LoginPage lp = new LoginPage(_driver);
            Assert.IsTrue(lp.CheckLoginPage("Ai deja un cont?"));
            lp.Login("octavianautomation@yahoo.com", "Automation");
            AccountPage ap = new AccountPage(_driver);
            Assert.IsTrue(lp.CheckLoginPage("Bine ai venit, Octavian!"));
            ap.ChangePassword("aaaaaaaaaaaa", "aaaaaaaaaaaaaa1", "aaaaaaaaaaaa");
        }
    }
}
