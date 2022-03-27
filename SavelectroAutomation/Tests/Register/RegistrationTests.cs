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

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\personRegistrationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

      

        [Test]

        public void PersonRegisterPositiveTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            Assert.IsTrue(rp.CheckRegistrationLabel("Inregistrare"));
            rp.PersonRegistration("aaaa@go.ro", "spartcus", "Georgel", "Romania", "Lacramioarei", "5555555555");

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
            rp.CompanyRegistration("steelmetal@steel.ro", "sssoososoo", "Steel", "J30/14/14", "111111111", "Onica Dorel", "Alpha", "11111111", "Romania","Lacramioarei", "5555555555") ;

        }

        /* [TestCase("aa@ro","123456GGG","AAA", "Romania","Stea","0744444444", "Valoarea introdusa trebuie sa fie o adresa de email valida.","","","","","")]
         [TestCase("","123456GGG","AAA", "Romania","Stea","0744444444", "Aceasta valoare este obligatorie.","", "","","","")]
         [TestCase("aa@ro.ro","123456GGG","AAA", "Romania","Stea","0744","","", "","","", "Valoarea introdusa nu este valida.")]
         [TestCase("aa@ro.ro","123","AAA","Romania","Stea", "0744444444","","", "Parola trebuie sa contina litere si cifre si trebuie sa aiba minim 6 caractere.", "", "","")]
         [TestCase("aa@ro.ro", "123456GGG","","Romania","Stea", "0744444444","","","", "Aceasta valoare este obligatorie.", "","")]
         [TestCase("aa@ro.ro","123456GGG", "AAA", "Romania","", "0744444444","","","","", "Aceasta valoare este obligatorie.", "")]
         [TestCase("","", "", "Romania","","", "Aceasta valoare este obligatorie.", "Aceasta valoare este obligatorie.", "", "Aceasta valoare este obligatorie.", "Aceasta valoare este obligatorie.", "Aceasta valoare este obligatorie.")]*/

        [Test, TestCaseSource("GetCredentialsDataCsv")]
        public void PersonRegisterNegative(string email, string password, string name, string country,string adress, string phone,string emailError,string passEmptyError,string passLengthError,string nameError,string adressError,string telephoneError)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            Assert.IsTrue(rp.CheckRegistrationLabel("Inregistrare"));
            rp.PersonRegistration(email, password,name,country,adress,phone);
            Assert.AreEqual(emailError, rp.EmailError());
            Assert.AreEqual(passEmptyError, rp.PasswordEmptyError());
            Assert.AreEqual(passLengthError, rp.PasswordLengthError());
            Assert.AreEqual(nameError, rp.NameError());           
            Assert.AreEqual(adressError, rp.AdressError());
            Assert.AreEqual(telephoneError, rp.PhoneError());
        }

        [TestCase("aaaa@aa.ro","aaaaaa","","pppppp","Romania","aaaaa","074444444","","Aceasta valoare este obligatorie.","")]
        
        public void CompanyNameRegisterNegative(string email, string password, string companyName,string person,string country, string adress, string phone,string emailError, string companyNameError,string personError)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            Assert.IsTrue(rp.CheckRegistrationLabel("Inregistrare"));
            rp.CompanySimplifiedRegistration(email, password, companyName, person,country, adress, phone);
            Assert.AreEqual(emailError, rp.EmailError());           
            Assert.AreEqual(companyNameError, rp.CompanyNameError());                 

        }

        [TestCase("aaaa@aa.ro", "aaaaaa","Iron","", "Romania", "aaaaa", "074444444", "","","Aceasta valoare este obligatorie.")]

        public void CompanyPersonRegisterNegative(string email, string password, string companyName, string person, string country, string adress, string phone, string emailError, string companyNameError, string personError)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            Assert.IsTrue(rp.CheckRegistrationLabel("Inregistrare"));
            rp.CompanySimplifiedRegistration(email, password, companyName, person, country, adress, phone);
            Assert.AreEqual(emailError, rp.EmailError());
            Assert.AreEqual(personError, rp.CompanyPersonError());

        }


    }
}
