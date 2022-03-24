using OpenQA.Selenium;
using SavelectroAutomation.PageModels.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels
{
    class CartPage : BasePage
    {

       // const string cartLabel = "fancy-title";//class
        public CartPage(IWebDriver driver) : base(driver)
        {
            

        }
       /* public Boolean CheckCartPage(string label)
        {
            return String.Equals(label.ToLower(), Utils.WaitForFluentElement(driver, 10, By.ClassName(cartLabel)));
        }*/
    }
}
