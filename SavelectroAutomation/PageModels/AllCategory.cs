using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SavelectroAutomation.PageModels.POM;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels
{
    class AllCategory : BasePage
    {
        const string allCategorySelector = "mega_10_category";//id
        const string categorySelector = "[id ^=mega_10_category__cat_]";//id
        const string itemsSelector = "prod-title";//class
        const string cartButtonSelector = "[id ^=btn_cart_main_]";//id
        const string submitSelector = "#fancybox-container-1 > div.fancybox-inner > div.fancybox-stage > div > div > div > div.fancy-footer > a.btn.btn-primary.float-right.d-none.d-lg-inline-block";//css
        const string cartLabel = "#fancy-title";//class


        public AllCategory(IWebDriver driver) : base(driver)
        {

        }

        public Boolean VerifyAllCategories(string categorie) // method to find all categories in main category and test if one category is in this menu
        {
            var allCategory = driver.FindElement(By.Id(allCategorySelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(allCategory).Build().Perform();
            var categorys = driver.FindElements(By.CssSelector(categorySelector));
  
            List<string> validations = new List<string>();
            foreach (IWebElement element in categorys)
            {
                validations.Add(element.Text);
            }
            return validations.Contains(categorie);

        }

        public void SelectOneProduct(int itemIndex, int subcategoryIndex) // method to add to chart one product
        {
            var allCategory = driver.FindElement(By.Id(allCategorySelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(allCategory).Build().Perform();
            var categorys = driver.FindElements(By.CssSelector(categorySelector));
            Console.WriteLine(categorys.Count);
            var item = categorys[itemIndex];
            Console.WriteLine(item.Text);
            item.Click();
            var items = driver.FindElements(By.ClassName(itemsSelector));
            Console.WriteLine(items.Count);
            foreach (IWebElement element in items)
            {
                Console.WriteLine(element.Text);
            }
            var subcategoryItem = items[subcategoryIndex];
            subcategoryItem.Click();
            var buttonCart = driver.FindElement(By.CssSelector(cartButtonSelector));
            buttonCart.Click();
            /*driver.SwitchTo().ParentFrame();*/
            var submitButton = Utils.WaitForElementClickable(driver, 10, By.CssSelector(submitSelector));
            Console.WriteLine(submitButton.Text);
            submitButton.Click();
            /*driver.SwitchTo().ParentFrame();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var confirmButton = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(submitSelector)));           
            Console.WriteLine(confirmButton.Text);
            confirmButton.Click();*/
        }
    }
}
