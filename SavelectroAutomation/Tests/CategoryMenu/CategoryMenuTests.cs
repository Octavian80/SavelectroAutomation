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

        [Test]

        public void CheckMainCategory()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            AllCategory cm = new AllCategory(_driver);
            Assert.IsTrue(cm.VerifyAllCategories("living now"));
            

        }
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
            lp.Login("sandu@yahoo.com", "Automatic");
            AllCategory cm = new AllCategory(_driver);
            cm.SelectOneProduct(15,2);
        }
    }
}
