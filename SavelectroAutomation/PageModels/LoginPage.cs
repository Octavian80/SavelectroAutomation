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
        const string emailErrorSelector = "parsley-id-5"; // css 
        const string passwordSelector = "profile_password"; // id
        const string passwordErrorSelector = "parsley-id-7"; //id
        const string passwordLengthErrorSelector = "message_profile_password";//id
        const string forgotPasswordSelector = "#page_login_form > div:nth-child(5) > a"; //css
        const string loginButtonSelector = "#page_login_form > div:nth-child(4) > button";//css
        const string rememberMeSelector = "remember_login";//id
        const string createAccountSelector = "btn btn-secondary";//css
        const string loginLabelSelector = "title-primary";//class
        const string passwordMismatchSelector = "message_password_mismatch";//id

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

       

        public string EmailError()
        {
            var exists = Utils.FindElementSafe(driver, By.Id(emailErrorSelector));

            if (exists == null) return "";

            var emailError = driver.FindElement(By.Id(emailErrorSelector)); 
            if (emailError.Displayed)
                return emailError.Text;
            return "";
        }

        public string PasswordEmptyError()
        {

            var exists = Utils.FindElementSafe(driver, By.Id(passwordErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.Id(passwordErrorSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

        public string PasswordLengthError()
        {
            var exists = Utils.FindElementSafe(driver, By.Id(passwordLengthErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.Id(passwordLengthErrorSelector));
            if (passError.Displayed)
            {               
                return passError.Text;               
            }

            return "";
           
        }

        public string PasswordMismatchError()
        {
            var exists = Utils.FindElementSafe(driver, By.Id(passwordMismatchSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.Id(passwordMismatchSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

    }
}
