using OpenQA.Selenium;
using SavelectroAutomation.PageModels.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels
{
    class CartPage : BasePage
    {
        const string cartMenuButtonSelector = "on-off";//class
        const string emptyCartLabel = "#page_content > div.page-content-center > div > h1";//css 
        const string cartProductsSelector = "prod-title";//class
        const string deleteProductsButtonsSelector = "#page_cart_form > div > table > tbody > tr > td.text-center.d-none.d-lg-table-cell.col-narrow > p:nth-child(2) > a";//class

        public CartPage(IWebDriver driver) : base(driver)
        {
            

        }

        public void EmptyCart()
        {
            var cartMenuButton = driver.FindElement(By.ClassName(cartMenuButtonSelector));
            cartMenuButton.Click();
            var deleteProductsButton = driver.FindElements(By.CssSelector(deleteProductsButtonsSelector));
            foreach (IWebElement deleteButton in deleteProductsButton)
            {
                deleteButton.Click();                
            }
        }

       

         public Boolean CheckEmptyCart(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(emptyCartLabel)).Text.ToLower());
        }

        
    }
}
