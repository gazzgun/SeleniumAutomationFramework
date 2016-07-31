using SeleniumAutomationFramework.Common.Selenium.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFramework.PageObjects.Pages
{
   public  class HomePage : BasePage
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
            get { return "Majestic Wine - Buy Wine & Champagne Online"; }
        }

        #endregion

        #region Elements

        #endregion

        #region Methods

        #endregion
    }
}
