using OpenQA.Selenium;
using SavelectroAutomation.PageModels.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels
{
    class CheckoutPage : BasePage
    {
        const string checkoutLabelSelector = "//*[@id='page_content']/div[3]/div[1]/h1";//xpath

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        public Boolean CheckCheckoutPage(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.XPath(checkoutLabelSelector)).Text.ToLower());
        }
    }
}
