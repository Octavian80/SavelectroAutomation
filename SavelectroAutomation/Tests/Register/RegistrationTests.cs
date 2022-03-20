using NUnit.Framework;
using SavelectroAutomation.PageModels;
using SavelectroAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.Tests.Register
{
    class RegistrationTests:BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        [Test]

        public void PersonRegisterTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            Assert.IsTrue(rp.CheckRegistrationLabel("Inregistrare"));
            rp.PersonRegistration("aaaa@go.ro", "spartcus", "Georgel", "Romania", "Constanta", "Lacramioarei", "5555555555");

        }
        [Test]
        public void CompanyRegisterTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            Assert.IsTrue(rp.CheckRegistrationLabel("Inregistrare"));
            rp.CompanyRegistration("steelmetal@steel.ro","sssoososoo","Steel","J30/14/14","111111111","Onica Dorel","Alpha","11111111", "Romania", "Constanta", "Lacramioarei", "5555555555");

        }
    }
}
