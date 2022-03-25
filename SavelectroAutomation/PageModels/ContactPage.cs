using OpenQA.Selenium;
using SavelectroAutomation.PageModels.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels
{
    class ContactPage : BasePage
    {
        const string contactLabelSelector = "title-primary"; // class
        const string contactReasonSelector = "contacts_reasons";//id
        const string contactReasonOptionSelector = "option[value = '3']";//6 option css
        const string nameInputSelector = "contacts_name";//id
        const string companyInputSelector = "contacts_company";//id
        const string emailInputSelector = "contacts_eml";//id
        const string phoneInputSelector = "contacts_phone";//id
        const string reasonInputSelector = "contacts_message";//id 
        const string submitButtonSelector = "#page_contact_form > button";//css
        const string nameErrorSelector = "parsley-id-7";//id
        const string emailEmptyErrorSelector = "parsley-id-11";//id
        const string messageErrorSelector = "parsley-id-15";//id


        public ContactPage(IWebDriver driver) : base(driver)
        {

        }

        public Boolean CheckLoginPage(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.ClassName(contactLabelSelector)).Text.ToLower());
        }

        public void Contact(string name, string email,string company, string phone, string message)
        {
            var contactReason = driver.FindElement(By.Id(contactReasonSelector)).FindElement(By.CssSelector(contactReasonOptionSelector));
            contactReason.Click();
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            nameInput.Clear();
            nameInput.SendKeys(name);
            var companyInput = driver.FindElement(By.Id(companyInputSelector));
            companyInput.Clear();
            companyInput.SendKeys(company);
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            phoneInput.Clear();
            phoneInput.SendKeys(phone);
            var reasonInput = driver.FindElement(By.Id(reasonInputSelector));
            reasonInput.Clear();
            reasonInput.SendKeys(message);
            var submitButton = driver.FindElement(By.CssSelector(submitButtonSelector));
            submitButton.Submit();


        }

        public string NameError()
        {
            var exists = Utils.FindElementSafe(driver, By.Id(nameErrorSelector));

            if (exists == null) return "";

            var emailError = driver.FindElement(By.Id(nameErrorSelector));
            if (emailError.Displayed)
                return emailError.Text;
            return "";
        }

        public string EmailError()
        {
            var exists = Utils.FindElementSafe(driver, By.Id(emailEmptyErrorSelector));

            if (exists == null) return "";

            var emailError = driver.FindElement(By.Id(emailEmptyErrorSelector));
            if (emailError.Displayed)
                return emailError.Text;
            return "";
        }

        public string MessageError()
        {
            var exists = Utils.FindElementSafe(driver, By.Id(messageErrorSelector));

            if (exists == null) return "";

            var emailError = driver.FindElement(By.Id(messageErrorSelector));
            if (emailError.Displayed)
                return emailError.Text;
            return "";
        }
    }
}
