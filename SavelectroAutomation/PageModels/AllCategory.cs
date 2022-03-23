using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SavelectroAutomation.PageModels.POM;
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
                validations.Add(element.Text.ToLower());
            }
            return validations.Contains(categorie);

        }

        public void SelectOneProduct(int itemIndex, int subcategoryIndex) // method to add to chart
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
            var buttonCart = driver.FindElement(By.CssSelector("[id ^=btn_cart_main_]"));
            buttonCart.Click();

        }
    }
}
