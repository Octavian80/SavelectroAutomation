using NUnit.Framework;
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
        }
    }
}
