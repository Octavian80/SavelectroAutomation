using OpenQA.Selenium;
using SavelectroAutomation.PageModels.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels
{
    class LoginPage : BasePage
    {
        const string emailSelector = "profile_email"; //id
        const string emailErrorSelector = "#parsley-id-5 > li"; // css 
        const string passwordSelector = "profile_password"; // id
        const string passwordErrorSelector = "#parsley-id-7 > li"; //css
        const string forgotPasswordSelector = "#page_login_form > div:nth-child(5) > a"; //css
        const string loginButtonSelector = "#page_login_form > div:nth-child(4) > button";//css
        const string rememberMeSelector = "remember_login";//id
        const string createAccountSelector = "btn btn-secondary";//class
        const string loginLabelSelector = "title-primary";//class

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public Boolean CheckLoginPage(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.ClassName(loginLabelSelector)).Text.ToLower());
        }

        public void Login(string email, string password)
        {
            var emailInput = driver.FindElement(By.Id(emailSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var loginButton = driver.FindElement(By.CssSelector(loginButtonSelector));
            loginButton.Submit();
        }
    }
}
