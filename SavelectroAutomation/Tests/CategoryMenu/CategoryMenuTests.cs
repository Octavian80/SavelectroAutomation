using NUnit.Framework;
using SavelectroAutomation.PageModels;
using SavelectroAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.Tests.CategoryMenu
{
    class CategoryMenuTests:BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\allCategories.csv"))
            {
                yield return new TestCaseData(values);
            }
        }
        [Category("CategoryTests")]
        [Test, TestCaseSource("GetCredentialsDataCsv")]

        public void CheckMainCategory(string category)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            AllCategory cm = new AllCategory(_driver);
            Assert.IsTrue(cm.VerifyAllCategories(category));
            

        }

        [Category("CategoryTests")]
        [Test]
        public void AddToCart()
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
            AccountPage acp = new AccountPage(_driver);
            acp.CheckAccountPage("Bine ai venit, Octavian!");
            AllCategory cm = new AllCategory(_driver);
            cm.AddToCartOneProduct(11,2);
            CheckoutPage chp = new CheckoutPage(_driver);
            Assert.IsTrue(chp.CheckCheckoutPage("Trimite comanda"));
        }
        [Category("CategoryTests")]
        [Test]

        public void AddToCartMoreProducts()
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
            AccountPage acp = new AccountPage(_driver);
            acp.CheckAccountPage("Bine ai venit, Octavian!");
            AllCategory cm = new AllCategory(_driver);
            cm.AddToCartMoreProducts(10, 1);
            Assert.IsTrue(cm.CheckCartPage("Cos de cumparaturi"));
            cm.CloseCart();
            cm.AddToCartMoreProducts(3, 1);
            Assert.IsTrue(cm.CheckCartPage("Cos de cumparaturi"));

        }
    }
}
