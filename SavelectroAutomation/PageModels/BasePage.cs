﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels.POM
{
   public class BasePage
    {
       public  IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
