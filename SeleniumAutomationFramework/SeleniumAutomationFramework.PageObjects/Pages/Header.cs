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
   public class Header : BasePage
    {
        #region Properties

        protected override string PageName
        {
            get { return "Header"; }
        }

        protected override string RelativeUrl
        {
            get { return "/"; }
        }

        protected override string Title
        {
            get { return ""; }
        }

        #endregion

        #region Elements

        [FindsBy(How = How.LinkText, Using = "Store Finder")]
        private IWebElement StoreFinderLink { get; set; }

        #endregion

        #region Methods

        public void NavigateToStoreFinder()
        {
            StoreFinderLink.Click();
        }

        #endregion
    }
}
