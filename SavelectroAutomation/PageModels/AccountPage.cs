using OpenQA.Selenium;
using SavelectroAutomation.PageModels.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels
{
    class AccountPage : BasePage
    {
        const string welcomeLabelSelector = "title-primary";//class
        const string accountViewButtonSelector = "#page_content > p:nth-child(4) > a";//css
        const string accountUpdateButtonSelector = "#page_content > p:nth-child(7) > a";//css
        const string changePasswordButtonSelector = "#page_content > p:nth-child(9) > a";//css
        const string logoutButtonSelector = "#page_content > p:nth-child(11) > a";//css
        const string passwordInputSelector = "old_password";//id
        const string newpasswordInputSelector = "new_password";//id
        const string confirmNewPassordInputSelector = "confirm_password";//id
        const string submitSelector = "#page_change_password_form > button";//css



        public AccountPage(IWebDriver driver) : base(driver)
        {
        }

        public Boolean CheckAccountPage(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.ClassName(welcomeLabelSelector)).Text.ToLower());
        }

        public void ChangePassword(string password,string newPassword, string confirmNewPassword)
        {
            var changePasswordButton = driver.FindElement(By.CssSelector(changePasswordButtonSelector));
            changePasswordButton.Click();
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var newpasswordInput = driver.FindElement(By.Id(newpasswordInputSelector));
            newpasswordInput.Clear();
            newpasswordInput.SendKeys(newPassword);
            var confirmNewPassordInput = driver.FindElement(By.Id(confirmNewPassordInputSelector));
            confirmNewPassordInput.Clear();
            confirmNewPassordInput.SendKeys(confirmNewPassword);
            var submitButton = driver.FindElement(By.CssSelector(submitSelector));
            /*submitButton.Submit();*/
        }
    }
}
