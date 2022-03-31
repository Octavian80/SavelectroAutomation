using NUnit.Framework;
using SavelectroAutomation.PageModels;
using SavelectroAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.Tests.CartAdd
{
    class CartTests:BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Category("CartTest")]
        [Test]

        public void EmptyngCart()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.ClickAccesAccount();
            LoginPage lp = new LoginPage(_driver);
            Assert.IsTrue(lp.CheckLoginPage("Ai deja un cont?"));
            lp.Login("octavianautomation@yahoo.com","Automation");
            AllCategory cm = new AllCategory(_driver);
            cm.AddToCartOneProduct(12, 2);
            CartPage cap = new CartPage(_driver);
            cap.EmptyCart();
            Assert.IsTrue(cap.CheckEmptyCart("Cosul tau de cumparaturi este gol"));
        }     

    }
}
