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

        public void SelectAllCategories()
        {
            var allCategory = driver.FindElement(By.Id(allCategorySelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(allCategory).Build().Perform();
            var category = driver.FindElements(By.CssSelector(categorySelector));
            Console.WriteLine(category.Count);

        }
    }
}
