using System;
using SeleniumAutomationFramework.Drivers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFramework.Common.Selenium.Base
{
    public abstract class BasePage
    {
        protected abstract string PageName { get; }
        protected abstract string RelativeUrl { get; }
        protected abstract string Title { get; }

        protected string Url
        {
            get
            {
                return "/" + RelativeUrl;
            }
        }
        public virtual void Goto()
        {
            try
            {
                SeleniumDriver.Goto(Url);
            }
            catch (UriFormatException)
            {
            }
        }
        public bool isAt()
        {
            return SeleniumDriver.Instance.Title.Contains(Title);
        }
    }
}

