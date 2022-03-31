using NUnit.Framework;
using SavelectroAutomation.PageModels;
using SavelectroAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.Tests.Contact
{
    class ContactTest:BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\contactData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Category("ContactTest")]

        [Test]

        public void ContactPositive()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.AccesContactForm();
            _driver.Navigate().GoToUrl(url + contactUrlPath);
            ContactPage cop= new ContactPage(_driver);
            Assert.IsTrue(cop.CheckLoginPage("Contacteaza-ne"));
            cop.Contact("octavian","aaa@ro.ro","Steel","0741888999","Super bine pus la punct website");
        }

        [Category("ContactTest")]
        [Test, TestCaseSource("GetCredentialsDataCsv")]

        public void ContactNegative(string name, string email, string company, string phone, string message,string nameError,string emailError,string messageError)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.AccesContactForm();
            _driver.Navigate().GoToUrl(url + contactUrlPath);
            ContactPage cop = new ContactPage(_driver);
            cop.Contact(name, email, company, phone, message);
            Assert.IsTrue(cop.CheckLoginPage("Contacteaza-ne"));
            Assert.AreEqual(nameError, cop.NameError());
            Assert.AreEqual(emailError, cop.EmailError());
            Assert.AreEqual(messageError, cop.MessageError());

        }
    }
}
