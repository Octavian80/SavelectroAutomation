using OpenQA.Selenium;
using SavelectroAutomation.PageModels.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels
{
    class MainPage : BasePage
    {

        const string cookiesAcceptSelector = "#cookie_policy_links > a"; // css selector
        const string accesAccount = "menu_link_1";//id


        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void  AcceptCookies()
        {
            driver.FindElement(By.CssSelector(cookiesAcceptSelector)).Click();
        }

        public void ClickAccesAccount()
        {
            driver.FindElement(By.Id(accesAccount)).Click();
        }
    }
}
