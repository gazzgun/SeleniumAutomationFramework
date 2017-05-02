using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationFramework.Common.Helpers;
using SeleniumAutomationFramework.Common.Selenium.Base;
using SeleniumAutomationFramework.Drivers;
using SeleniumAutomationFramework.PageObjects.Configuration;
using SeleniumAutomationFramework.PageObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumAutomationFramework.PageObjects.Pages
{
    public class CreateCustomerPage : BasePage
    {
        #region Properties

        protected override string PageName
        {
            get { return "Create Customer Page"; }
        }

        protected override string RelativeUrl
        {
            get { return "/"; }
        }
        //edit title
        protected override string Title
        {
            get { return " "; }
        }
        String browser = ApplicationSettings.GetLocalBrowser;
        #endregion
        #region Elements

        [FindsBy(How = How.CssSelector,Using = "[class='icon-Dismiss dialog-close']")]
        IWebElement headerXLink { get; set; }
        [FindsBy(How = How.LinkText,Using = "Delete")]
        IWebElement deleteButton { get; set; }

        #region Section Elements
        [FindsBy(How = How.XPath,Using = "html/body/div[2]/div[4]/form/div[6]/div[1]/div[2]/div/div[4]/div[1]/span[1]")]
        private IWebElement invoicingMenuLink { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div[4]/form/div[6]/div[1]/div[2]/div/div[5]/div[1]/span[1]")]
        private IWebElement paymentsMenuLink { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div[4]/form/div[6]/div[1]/div[2]/div/div[6]/div[1]/span[1]")]
        private IWebElement shippingMenuLink { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div[4]/form/div[6]/div[1]/div[2]/div/div[7]/div[1]/span[1]")]
        private IWebElement foreignTradeMenuLink { get; set; }
        #endregion

        #region General Details Elements
        [FindsBy(How = How.CssSelector, Using = "[title='No.']+div input")]
        private IWebElement noTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Name']+div input")]
        private IWebElement nameTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Address']+div input")]
        private IWebElement addressTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Address 2']+div input")]
        private IWebElement adress2TB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Post Code']+div input")]
        private IWebElement postCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='City']+div input")]
        private IWebElement cityTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Country/Region Code']+div input")]
        private IWebElement countryRegionTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Phone No.']+div input")]
        private IWebElement phoneNoTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Contact']+div input")]
        private IWebElement contactTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Search Name']+div input")]
        private IWebElement searchNameTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Credit Limit (LCY)']+div input")]
        private IWebElement creditLimitTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Salesperson Code']+div input")]
        private IWebElement salespersonCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Responsibility Center']+div input")]
        private IWebElement responsibilityCentreTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Service Zone Code']+div input")]
        private IWebElement serviceZoneTB { get; set; }
        #endregion

        #region Communication Details Elements
        [FindsBy(How = How.CssSelector, Using = "[title='E-Mail']+div input")]
        private IWebElement emailTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Home Page']+div input")]
        private IWebElement homePageURLTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='IC Partner Code']+div input")]
        private IWebElement icPartnerCodeTB { get; set; }
        #endregion
        
        #region Invoicing Details Elements


        #endregion
        
        #region Payments Elements
        [FindsBy(How = How.CssSelector, Using = "[title='Application Method']+div select")]
        private IWebElement applicationMethodTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Partner Type']+div select")]
        private IWebElement partnerTypeTB{ get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Payment Terms Code']+div input")]
        private IWebElement paymentTermsTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Payment Method Code']+div input")]
        private IWebElement paymentMethodCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Reminder Terms Code']+div input")]
        private IWebElement reminderTermsCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Fin. Charge Terms Code']+div input")]
        private IWebElement chargeTermsCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Cash Flow Payment Terms Code']+div input")]
        private IWebElement cashFlowPatmentTermsCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Print Statements']+div input")]
        private IWebElement printStatementCB { get; set; }
        #endregion

        #region Shippoing And Foreign Elements
        [FindsBy(How = How.CssSelector,Using = "[title='Location Code']+div input")]
        private IWebElement locationCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Combine Shipments']+div input")]
        private IWebElement combineShipmentsCB{ get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Shipment Method Code']+div input")]
        private IWebElement shippingMethodCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Shipping Agent Code']+div input")]
        private IWebElement shippingAgentCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Base Calendar Code']+div input")]
        private IWebElement baseCalendarCodeTB { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[title='Currency Code']+div input")]
        private IWebElement currencyCodeTB { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[title='Language Code']+div input")]
        private IWebElement languageCodeTB { get; set; }

     
        #endregion

        #endregion
        #region methods
        public void CreateNewCustomer(Customer customer)
        {
            if (browser.Equals("chrome"))
                ChromeBrowserCustomerSetup();
            EnterGeneralDetails(customer);
            EnterCommunicatiomDetails(customer);
            EnterPaymentDetails(customer);
            EnterShippingAndForeignDetails(customer);
        }

        public void EnterGeneralDetails(Customer newCustomer)
        {
            
            SeleniumHelper.Click(noTB);
            SeleniumHelper.SendKeys(noTB, newCustomer.number.ToString());
            
            SeleniumHelper.Click(nameTB);
            Thread.Sleep(500);
            SeleniumHelper.SendKeys(nameTB, newCustomer.name);
            
            SeleniumHelper.Click(addressTB);
            SeleniumHelper.SendKeys(addressTB, newCustomer.address);
            
            SeleniumHelper.Click(adress2TB);
            SeleniumHelper.SendKeys(adress2TB, newCustomer.address2);
            
            SeleniumHelper.Click(postCodeTB);
            SeleniumHelper.SendKeys(postCodeTB, newCustomer.postcode);
            //SendKeys.SendWait("{ESC}");
            
            SeleniumHelper.Click(cityTB);
            SeleniumHelper.SendKeys(cityTB, newCustomer.city);
            
            SeleniumHelper.Click(countryRegionTB);
            SeleniumHelper.SendKeys(countryRegionTB, newCustomer.country_region);
            
            SeleniumHelper.Click(phoneNoTB);
            SeleniumHelper.SendKeys(phoneNoTB, newCustomer.phoneNumber);
            
            SeleniumHelper.Click(searchNameTB);
            SeleniumHelper.SendKeys(searchNameTB, newCustomer.searchName);
            
            SeleniumHelper.Click(creditLimitTB);
            SeleniumHelper.SendKeys(creditLimitTB, newCustomer.creaditLimit);
            
            SeleniumHelper.Click(salespersonCodeTB);
            SeleniumHelper.SendKeys(salespersonCodeTB, newCustomer.salePersonCode);
            
            SeleniumHelper.Click(responsibilityCentreTB);
            SeleniumHelper.SendKeys(responsibilityCentreTB, newCustomer.responsibilityCenter);
            
            SeleniumHelper.Click(serviceZoneTB);
            SeleniumHelper.SendKeys(serviceZoneTB, newCustomer.serviceZoneCode);
            


        }

        public void EnterCommunicatiomDetails(Customer customer)
        {
            //   SeleniumHelper.SendKeys(communicationPhoneNoTB, customer.communicationDetails.phoneNo.ToString());
            SeleniumHelper.SendKeys(emailTB, customer.email);
            
            SeleniumHelper.SendKeys(homePageURLTB, customer.homePageURL);
            
            // SeleniumHelper.SendKeys(icPartnerCodeTB, customer.communicationDetails.icPartnerCode);
        }

        public void EnterPaymentDetails(Customer customer)
        {

            SeleniumHelper.FromDownListTextSelect(applicationMethodTB,customer.applicationMethod);
            
            SeleniumHelper.FromDownListTextSelect(partnerTypeTB, customer.partnerType);
            
            SeleniumHelper.Click(paymentTermsTB);
            SeleniumHelper.SendKeys(paymentTermsTB, customer.paymentTerms);
            
            SeleniumHelper.Click(paymentMethodCodeTB);
            SeleniumHelper.SendKeys(paymentMethodCodeTB, customer.paymentMethods);
            
            SeleniumHelper.Click(reminderTermsCodeTB);
            SeleniumHelper.SendKeys(reminderTermsCodeTB, customer.reminderTerms);
            
            SeleniumHelper.Click(chargeTermsCodeTB);
            SeleniumHelper.SendKeys(chargeTermsCodeTB, customer.chargeTermCode);
            
            SeleniumHelper.Click(cashFlowPatmentTermsCodeTB);
            SeleniumHelper.SendKeys(cashFlowPatmentTermsCodeTB, customer.cashFlowPayment);
            
            SeleniumHelper.Click(printStatementCB);
            
        }

        public void EnterShippingAndForeignDetails(Customer customer)
        {
            SeleniumHelper.Click(locationCodeTB);
            SeleniumHelper.SendKeys(locationCodeTB,customer.locationCode);
            
            SeleniumHelper.Click(combineShipmentsCB);
            
            SeleniumHelper.Click(shippingMethodCodeTB);
            SeleniumHelper.SendKeys(shippingMethodCodeTB,customer.shippingMethod);
            
            SeleniumHelper.Click(shippingAgentCodeTB);
            SeleniumHelper.SendKeys(shippingAgentCodeTB, customer.shippingAgent);
            
            SeleniumHelper.Click(baseCalendarCodeTB);
            SeleniumHelper.SendKeys(baseCalendarCodeTB,customer.baseCalendarCode);
            
            SeleniumHelper.Click(currencyCodeTB);
            SeleniumHelper.SendKeys(currencyCodeTB,customer.currencyCode);
            
            SeleniumHelper.Click(languageCodeTB);
            SeleniumHelper.SendKeys(languageCodeTB, customer.languageCode);
            
            SeleniumHelper.Click(headerXLink);
            Thread.Sleep(500);
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{ENTER}");
        }

        public void DeleteCustomer()
        {
            deleteButton.Click();
            Thread.Sleep(500);
            SendKeys.SendWait("{ENTER}");
        }

        public void ModifyPhoneNumber(string phoneNumber)
        {
            //SeleniumHelper.Wait(phoneNoTB);
            Thread.Sleep(1000);
            SeleniumHelper.SendKeys(phoneNoTB, phoneNumber);
            SeleniumHelper.Click(headerXLink);
        }
        public void Sleep()
        {
            Thread.Sleep(500);
        }

        public void ChromeBrowserCustomerSetup()
        {
            SeleniumHelper.Click(invoicingMenuLink);
            Sleep();
            SeleniumHelper.Click(paymentsMenuLink);
            Sleep();
            SeleniumHelper.Click(shippingMenuLink);
            Sleep();
            SeleniumHelper.Click(foreignTradeMenuLink);
            Sleep();
        }
    }

  

    #endregion
}

