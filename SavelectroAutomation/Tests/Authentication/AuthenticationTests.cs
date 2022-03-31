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

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\authenticationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Category("Authentication")]
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
            lp.Login("octavianautomation@yahoo.com", "Automation");
            AccountPage ac = new AccountPage(_driver);
            ac.CheckAccountPage("Bine ai venit, Octavian!");
        }

        [Category("Authentication")]
        [Test, TestCaseSource("GetCredentialsDataCsv")]

        public void AuthenticationNegative(string email , string password,string emailError,string passwordError,string passwordLengthError,string mismatchError)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.ClickAccesAccount();

            LoginPage lp = new LoginPage(_driver);
            Assert.IsTrue(lp.CheckLoginPage("Ai deja un cont?"));
            lp.Login(email,password);
            Assert.AreEqual(emailError, lp.EmailError());
            Assert.AreEqual(passwordError, lp.PasswordEmptyError());
            Assert.AreEqual(passwordLengthError, lp.PasswordLengthError());
            Assert.AreEqual(mismatchError, lp.PasswordMismatchError());
            
        }
    }
}
