using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationFramework.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomationFramework.Common.Helpers
{
    class SeleniumHelper : HelperBase
    {
        #region Element Methods
        public static string getText(IWebElement element)
        {
            try
            {
                return element.Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
        public static bool TextContains(IWebElement element,string expectedText)
        {
            return element.Text.Contains(expectedText);
        }
        public static bool UrlContains(string value)
        {
            return SeleniumDriver.Instance.Url.Contains(value);
        }
        public static string GetUrl()
        {
            return SeleniumDriver.Instance.Url;
        }
        public static void PressEnter(IWebElement element)
        {
            try
            {
                if (element == null) return;
                element.SendKeys(Keys.Enter);
            }
            catch (NullReferenceException)
            {

            }
        }
        public static string GetAttributeValue(IWebElement element, string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        public static void Click(IWebElement element)
        {
            if (element != null)
            {
                element.Click();
            }
        }

        public static void ContextClick(IWebElement iwe)
        {
            new Actions(SeleniumDriver.Instance).ContextClick(iwe).Perform();
        }

        public static bool IsDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static bool IsEnabled(IWebElement element)
        {
            try
            {
                return element.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsSelected(IWebElement element)
        {
            try
            {
                return element.Selected;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsChecked(IWebElement element)
        {
            try
            {
                var result = Convert.ToBoolean(element.GetAttribute("checked"));
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static int HeightOfTheIWebElement(IWebElement element)
        {
            return element.Size.Height;
        }

        public static int WidthOfTheIWebElement(IWebElement element)
        {
            return element.Size.Width;
        }

        public static void Wait()
        {
            Thread.Sleep(1500);
        }

        public static void Wait(IWebElement iwe)
        {
            var wait = new WebDriverWait(SeleniumDriver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => Equals(d.SwitchTo().ActiveElement(), iwe));
        }

        public static void Wait(decimal seconds)
        {
            var time = Convert.ToInt32(seconds * 1000);
            Thread.Sleep(time);
        }

        public static void SendKeys(IWebElement element, string input)
        {
            try
            {
                if (element == null || input == null) return;
                element.Clear();
                element.SendKeys(input);
            }
            catch (NullReferenceException)
            {

            }
        }

        public static void ClearText(IWebElement element)
        {
            element.Clear();
        }
        public static IWebElement FindElement(Func<string, By> func, string selector)
        {
            var element = SeleniumDriver.Instance.FindElement(func(selector));
            return element;
        }

        public static IList<IWebElement> FindElements(Func<string, By> func, string selector)
        {
            IList<IWebElement> element = SeleniumDriver.Instance.FindElements(func(selector));
            return element;
        }

        public static string GetCssValue(IWebElement element, string cssValue)
        {
            var value = element.GetCssValue(cssValue);
            return value;
        }

        #endregion

        #region Browser Window Methods
        public static void BackBrowserButton()
        {
            SeleniumDriver.Instance.Navigate().Back();
        }
        public static void ForwardBrowserButton()
        {
            SeleniumDriver.Instance.Navigate().Forward();
        }
        public static void AcceptInformationMessage()
        {
            var alert = SeleniumDriver.Instance.SwitchTo().Alert();
            alert.Accept();
        }
        public static void DismissInformationMessage()
        {
            var alert = SeleniumDriver.Instance.SwitchTo().Alert();
            alert.Dismiss();
        }
        public static int NumberOfBrowserWindows()
        {
            return SeleniumDriver.Instance.WindowHandles.Count;
        }
        public static void SwitchFrameByName(string title)
        {
            SeleniumDriver.Instance.SwitchTo().Frame(title);
        }

        public static void SwitchFrameByIndex(int index)
        {
            SeleniumDriver.Instance.SwitchTo().Frame(index);
        }

        public static void SwitchFrameBySelector(By by)
        {
            SwitchFrameToDefault();

            SeleniumDriver.Instance.SwitchTo().Frame(SeleniumDriver.Instance.FindElement(by));
        }

        public static void SwitchFrameToDefault()
        {
            SeleniumDriver.Instance.SwitchTo().DefaultContent();
        }
        public static void ChangeBrowserInstanceToNewWindow(int frameIndex)
        {
            var handles = SeleniumDriver.Instance.WindowHandles;
            SeleniumDriver.Instance.SwitchTo().Window(handles[frameIndex]);
        }

        #endregion

        #region Other Methods

        public static void ScrollToElement(IWebElement element)
        {
            var scrollY = Convert.ToString(element.Location.Y - element.Size.Height);

            var builder = new Actions(SeleniumDriver.Instance);
            builder.MoveToElement(element).Build().Perform();
            ((IJavaScriptExecutor)SeleniumDriver.Instance).ExecuteScript("window.scrollBy(0,-9000);");
            ((IJavaScriptExecutor)SeleniumDriver.Instance).ExecuteScript("window.scrollBy(0," + scrollY + ");");
        }
        public static void PressKey(string key)
        {
            var builder = new Actions(SeleniumDriver.Instance);

            switch (key.ToLower())
            {
                case "return":
                    builder.SendKeys(Keys.Return);
                    break;
                case "tab":
                    builder.SendKeys(Keys.Tab);
                    break;
                case "arrowdown":
                    builder.SendKeys(Keys.ArrowDown);
                    break;
                case "arrowup":
                    builder.SendKeys(Keys.ArrowUp);
                    break;
                case "arrowleft":
                    builder.SendKeys(Keys.ArrowLeft);
                    break;
                case "arrowright":
                    builder.SendKeys(Keys.ArrowRight);
                    break;
                case "home":
                    builder.SendKeys(Keys.Home);
                    break;
                case "end":
                    builder.SendKeys(Keys.End);
                    break;
                case "pageup":
                    builder.SendKeys(Keys.PageUp);
                    break;
                case "pagedown":
                    builder.SendKeys(Keys.PageDown);
                    break;
            }
            builder.Build().Perform();
        }
        public static void DeleteAllcookies()
        {
            SeleniumDriver.Instance.Manage().Cookies.DeleteAllCookies();
        }

        public static bool PageSourceContains(string value)
        {
            return SeleniumDriver.Instance.PageSource.Contains(value);
        }

        public static void RefreshPage()
        {
            SeleniumDriver.Instance.Navigate().Refresh();
        }

        public static void ClearBrowserCache()
        {
            var builder = new Actions(SeleniumDriver.Instance);
            builder.KeyDown(Keys.Control).SendKeys(Keys.F5).KeyUp(Keys.Control).Perform();
        }

        public static IWebDriver GetDriver()
        {
            return SeleniumDriver.Instance;
        }

        public static string[] SplitString(string split)
        {
            return split.Split();
        }

        #endregion
    }
}
