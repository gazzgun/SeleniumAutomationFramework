using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumAutomationFramework.Common.Selenium.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFramework.PageObjects.Pages
{
    public class NewSalesOrderPage : BasePage
    {
        #region Properties
        protected override string PageName
        {
            get { return "Create Sales Order Page"; }
        }

        protected override string RelativeUrl
        {
            get { return "/"; }
        }

        protected override string Title
        {
            get { return " ™"; }
        }
        #endregion

        #region Elements
        #region Sales Order General Details
        [FindsBy(How = How.Id, Using = "301Fee")]
        private IWebElement noTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "3020ee")]
        private IWebElement customerNoTextBox { get; set; }
        [FindsBy(How = How.Id,Using ="3022ee")]
        private IWebElement customerNameTextBox { get; set; }
        [FindsBy(How = How.Id,Using = "3026ee")]
        private IWebElement customerCityTextBox { get; set; }
        [FindsBy(How = How.Id,Using = "3029ee")]
        private IWebElement postingDateTextBox { get; set; }
        [FindsBy(How = How.Id,Using = "302Aee")]
        private IWebElement orderDateTextBox { get; set; }
        [FindsBy(How = How.Id,Using = "302Bee")]
        private IWebElement documentDateTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "302Cee")]
        private IWebElement requestDeliveryDateTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "302Fee")]
        private IWebElement externalDocumentNumber { get; set; }
        [FindsBy(How = How.Id, Using = "3030ee")]
        private IWebElement salesPersonCodeTextBox{ get; set; }
        




        #endregion


        #endregion
    }
}
