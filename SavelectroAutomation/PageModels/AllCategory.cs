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
        public AllCategory(IWebDriver driver) : base(driver)
        {

        }

        public Boolean SelectAllCategories(string categorie)
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
    }
}
