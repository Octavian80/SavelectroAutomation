using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SavelectroAutomation.PageModels.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavelectroAutomation.PageModels
{
    class RegistrationPage : BasePage
    {
        const string registrationLabelSelector = "#user_account_fields > h1";//css
        const string emailInputSelector = "profile_email";//id
        const string passwordInputSelector = "profile_password";//id
        const string individualButtonSelector = "#user_account_fields > div.d-flex.mt-3.mb-3.row-billing-type > div.form-input.mr-4.row-billing-type-individual > div > label";//css 
        const string companyButtonSelector = "#user_account_fields > div.d-flex.mt-3.mb-3.row-billing-type > div.form-input.mr-4.row-billing-type-company > div > label";//css 
        const string personNameSelector = "profile_billing_person_name";//id
        const string companyNameSelector = "profile_billing_org_name";//id
        const string billingNumberSelector = "profile_billing_org_number";//id
        const string vatNumberSelector = "profile_billing_org_vat";//id
        const string billingNameSelector = "profile_billing_name";//id
        const string bankNameSelector = "profile_billing_bank_name";//id
        const string ibanSelector = "profile_billing_bank_iban";//id
        const string personCountrySelector = "profile_billing_country";//id
        const string personStateSelector = "profile_billing_state";//id
        const string personCitySelector = "profile_billing_city";//id
        const string cityListSelector = "body > div:nth-child(20)";//css
        const string personAdressSelector = "profile_billing_address";//id
        const string personZipCodeSelector = "profile_billing_zip";//id
        const string personPhoneSelector = "profile_billing_phone";//id
        const string sameShippingAdressSelector = "#shipping_address_container > div.form-group.row-shipping-as-billing-on > div > div > label";//css
        const string otherShippingAdressSelector = "#shipping_address_container > div.form-group.row-shipping-as-billing-off > div > div > label";//css
        const string otherNameShippingSelector = "profile_shipping_name";//id
        const string otherCountryShippingSelector = "profile_shipping_country";//id
        const string otherStateShippingSelector = "profile_shipping_state";//id
        const string otherCityShippingSelector = "profile_shipping_city";//id
        const string otherAdressShippingSelector = "profile_shipping_address";//id
        const string otherZipCodeShipppingSelector = "profile_shipping_zip";//id
        const string otherPhoneShippingSelector = "profile_shipping_phone";//id
        const string newsletterSelector = "#user_account_fields > div.row-newsletter-terms-submit > div.form-group.row-join-newsletter > div > div > label";//css
        const string termsConditionsSelector = "#user_account_fields > div.row-newsletter-terms-submit > div.form-group.row-confirm-terms > div > div > label";//css
        const string submitButtonSelector = "#user_account_fields > div.row-newsletter-terms-submit > button";//css
        const string emailErrorSelector = "parsley-id-5";//id
        const string passwordEmptyErrorSelector = "parsley-id-7";//id
        const string passwordLenghtErrorSelector = "message_profile_password";//id
        const string nameErrorSelector = "parsley-id-14";//id
        const string cityErrorSelector = "parsley-id-22";//id
        const string adressErrorSelector = "parsley-id-24";//id
        const string phoneErrorSelector = "parsley-id-28";//id
        const string companyNameErrorSelector = "//ul[starts-with(@id, 'parsley-id-')]";// XPath dynamic Id
        const string companyPersonErrorSelector = "//ul[starts-with(@id, 'parsley-id-')]";// XPath dynamic Id



        public Boolean CheckRegistrationLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(registrationLabelSelector)).Text.ToLower());
        }



        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void PersonRegistration( string email, string password,string name,string country,string adress,string phone)
        {
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var individualButton = driver.FindElement(By.CssSelector(individualButtonSelector));
            individualButton.Click();
            var personNameInput = driver.FindElement(By.Id(personNameSelector));
            personNameInput.Clear();
            personNameInput.SendKeys(name);
            var countrySelect = driver.FindElement(By.Id(personCountrySelector));
            countrySelect.Click();
            countrySelect.SendKeys(country);
            countrySelect.Click();
           /* var citySelect = driver.FindElement(By.Id(personCitySelector));            
            citySelect.Clear();
            citySelect.SendKeys(city);
            citySelect.Click();*/
            var personAdressInput = driver.FindElement(By.Id(personAdressSelector));
            personAdressInput.Clear();
            personAdressInput.SendKeys(adress);
            var personPhoneInput = driver.FindElement(By.Id(personPhoneSelector));
            personPhoneInput.Clear();
            personPhoneInput.SendKeys(phone);
            var personShippingAdress = driver.FindElement(By.CssSelector(sameShippingAdressSelector));
            personShippingAdress.Click();
            var newsletter = driver.FindElement(By.CssSelector(newsletterSelector));
            newsletter.Click();
            var termsAndConditions = driver.FindElement(By.CssSelector(termsConditionsSelector));
            termsAndConditions.Click();
            var submitRegistration = driver.FindElement(By.CssSelector(submitButtonSelector));
            submitRegistration.Submit();


        }

        public void CompanyRegistration(string email, string password, string companyName,string tradeRegister,string vat,string person,string bank,string iban, string country, string adress, string phone)
        {
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var companyButton = driver.FindElement(By.CssSelector(companyButtonSelector));
            companyButton.Click();
            var companyNameInput = driver.FindElement(By.Id(companyNameSelector));
            companyNameInput.Clear();
            companyNameInput.SendKeys(companyName);
            var billingNumberInput = driver.FindElement(By.Id(billingNumberSelector));
            billingNumberInput.Clear();
            billingNumberInput.SendKeys(tradeRegister);
            var vatIput = driver.FindElement(By.Id(vatNumberSelector));
            vatIput.Clear();
            vatIput.SendKeys(vat);
            var companyPersonInput = driver.FindElement(By.Id(billingNameSelector));
            companyPersonInput.Clear();
            companyPersonInput.SendKeys(person);
            var bankNameInput = driver.FindElement(By.Id(bankNameSelector));
            bankNameInput.Clear();
            bankNameInput.SendKeys(bank);
            var ibanInput = driver.FindElement(By.Id(ibanSelector));
            ibanInput.Clear();
            ibanInput.SendKeys(iban);
            var countrySelect = driver.FindElement(By.Id(personCountrySelector));
            countrySelect.Click();
            countrySelect.SendKeys(country);
            countrySelect.Click();
            /*var personState= driver.FindElement(By.Id(personStateSelector));
            personState.Click();
            personState.SendKeys(state);
            personState.Click();
            var citySelect = driver.FindElement(By.Id(personCitySelector));                                
            citySelect.SendKeys(Keys.ArrowDown+ city + Keys.Enter);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].value='enter the value here';", citySelect); */          
            var personAdressInput = driver.FindElement(By.Id(personAdressSelector));
            personAdressInput.Clear();
            personAdressInput.SendKeys(adress);
            var personPhoneInput = driver.FindElement(By.Id(personPhoneSelector));
            personPhoneInput.Clear();
            personPhoneInput.SendKeys(phone);
            var personShippingAdress = driver.FindElement(By.CssSelector(sameShippingAdressSelector));
            personShippingAdress.Click();
            var newsletter = driver.FindElement(By.CssSelector(newsletterSelector));
            newsletter.Click();
            var termsAndConditions = driver.FindElement(By.CssSelector(termsConditionsSelector));
            termsAndConditions.Click();
            var submitRegistration = driver.FindElement(By.CssSelector(submitButtonSelector));
            submitRegistration.Submit();


        }

        public void CompanySimplifiedRegistration(string email, string password, string companyName,string person,string country, string adress, string phone)
        {
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var companyButton = driver.FindElement(By.CssSelector(companyButtonSelector));
            companyButton.Click();
            var companyNameInput = driver.FindElement(By.Id(companyNameSelector));
            companyNameInput.Clear();
            companyNameInput.SendKeys(companyName);
            /*var billingNumberInput = driver.FindElement(By.Id(billingNumberSelector));
            billingNumberInput.Clear();
            billingNumberInput.SendKeys(tradeRegister);
            var vatIput = driver.FindElement(By.Id(vatNumberSelector));
            vatIput.Clear();
            vatIput.SendKeys(vat);*/
            var companyPersonInput = driver.FindElement(By.Id(billingNameSelector));
            companyPersonInput.Clear();
            companyPersonInput.SendKeys(person);
            /*var bankNameInput = driver.FindElement(By.Id(bankNameSelector));
            bankNameInput.Clear();
            bankNameInput.SendKeys(bank);
            var ibanInput = driver.FindElement(By.Id(ibanSelector));
            ibanInput.Clear();
            ibanInput.SendKeys(iban);*/
            var countrySelect = driver.FindElement(By.Id(personCountrySelector));
            countrySelect.Click();
            countrySelect.SendKeys(country);
            countrySelect.Click();
            /*var personState= driver.FindElement(By.Id(personStateSelector));
            personState.Click();
            personState.SendKeys(state);
            personState.Click();
            var citySelect = driver.FindElement(By.Id(personCitySelector));                                
            citySelect.SendKeys(Keys.ArrowDown+ city + Keys.Enter);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].value='enter the value here';", citySelect); */
            var personAdressInput = driver.FindElement(By.Id(personAdressSelector));
            personAdressInput.Clear();
            personAdressInput.SendKeys(adress);
            var personPhoneInput = driver.FindElement(By.Id(personPhoneSelector));
            personPhoneInput.Clear();
            personPhoneInput.SendKeys(phone);
            var personShippingAdress = driver.FindElement(By.CssSelector(sameShippingAdressSelector));
            personShippingAdress.Click();
            var newsletter = driver.FindElement(By.CssSelector(newsletterSelector));
            newsletter.Click();
            var termsAndConditions = driver.FindElement(By.CssSelector(termsConditionsSelector));
            termsAndConditions.Click();
            var submitRegistration = driver.FindElement(By.CssSelector(submitButtonSelector));
            submitRegistration.Submit();


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

            var exists = Utils.FindElementSafe(driver, By.Id(passwordEmptyErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.Id(passwordEmptyErrorSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

        public string PasswordLengthError()
        {

            var exists = Utils.FindElementSafe(driver, By.Id(passwordLenghtErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.Id(passwordLenghtErrorSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

        public string NameError()
        {

            var exists = Utils.FindElementSafe(driver, By.Id(nameErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.Id(nameErrorSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

        public string CityError()
        {

            var exists = Utils.FindElementSafe(driver, By.Id(cityErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.Id(cityErrorSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

        public string AdressError()
        {

            var exists = Utils.FindElementSafe(driver, By.Id(adressErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.Id(adressErrorSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

        public string PhoneError()
        {

            var exists = Utils.FindElementSafe(driver, By.Id(phoneErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.Id(phoneErrorSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

        public string CompanyNameError()
        {

            var exists = Utils.FindElementSafe(driver, By.XPath(companyNameErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.XPath(companyNameErrorSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

        public string CompanyPersonError()
        {

            var exists = Utils.FindElementSafe(driver, By.XPath(companyPersonErrorSelector));

            if (exists == null) return "";

            var passError = driver.FindElement(By.XPath(companyPersonErrorSelector));
            if (passError.Displayed)
            {
                return passError.Text;
            }

            return "";
        }

    }
}
