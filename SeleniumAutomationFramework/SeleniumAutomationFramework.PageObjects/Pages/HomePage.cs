﻿using SeleniumAutomationFramework.Common.Selenium.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumAutomationFramework.Common.Helpers;
using SeleniumAutomationFramework.Drivers;

namespace SeleniumAutomationFramework.PageObjects.Pages
{
    public class HomePage : BasePage
    {
        #region Properties

        protected override string PageName
        {
            get { return "Home Page"; }
        }

        protected override string RelativeUrl
        {
            get { return "/"; }
        }
        //edit title
        protected override string Title
        {
            get { return "Sales Order Processor - Microsoft Dynamics NAV"; }
        }

        #endregion



        #region Elements
        private IWebElement salesOrderOpenLink { get; set; }
        [FindsBy(How = How.Id,Using = "createNewEntityLink")]
        private IWebElement createNewEntry { get; set; }
        [FindsBy(How = How.LinkText,Using = "Customers")]
        private IWebElement customerLink { get; set; }
        #endregion


        #region Methods
        public String GetTitle()
        {
            return Title;
        }
        
        public void ClickCustomer()
        {
            SeleniumHelper.Wait(1);
            if(SeleniumHelper.IsDisplayed(customerLink))
                SeleniumHelper.Click(customerLink);
        }
        public void ClickCreateNewCustomer()
        {
            SeleniumHelper.Click(createNewEntry);
        }
        
        public Boolean ConfirmCustomer(String customerID)
        {
            Boolean result = false;
            if (SeleniumHelper.IsElementPresent(By.LinkText(customerID)))
            {
                result = true; 
            }
            return result;
        }


        public void SelectCustomerById(string customerID)
        {
            SeleniumHelper.Wait(1);
            SeleniumHelper.Click(customerLink);
            IWebElement customerToDelete = SeleniumDriver.Instance.FindElement
               (By.LinkText(customerID));
            SeleniumHelper.Click(customerToDelete);
        }

        #endregion

    }
}
