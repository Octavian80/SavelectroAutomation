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
            Assert.IsTrue(cm.VerifyAllCategories("living then"));
            

        }
        [Test]
        public void ClickOnAItemCategory()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            AllCategory cm = new AllCategory(_driver);
            cm.SelectOneProduct(15,2);
        }
    }
}
