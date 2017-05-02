﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationFramework.Drivers;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace SeleniumAutomationFramework.Common.Helpers
{
    public class SeleniumHelper : HelperBase
    {
        #region Element Methods
        public static string GetText(IWebElement iwe)
        {
            try
            {
                return iwe.Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        public static void FromDownListTextSelect(IWebElement iwe,String option)
        {
            SelectElement selectList = new SelectElement(iwe);
            selectList.SelectByText(option);
        }

        public static void SelectElementFromDropdown(Dictionary<string, string> myDictionary)
        {
            foreach (var fieldItem in myDictionary)
            {
                new SelectElement(FindElement(By.CssSelector(fieldItem.Key))).SelectByText(
                    fieldItem.Value);
            }
        }

        public static void SelectOptionFromList(string cssSelector, string optionText)
        {
            var options = FindElements(By.CssSelector(cssSelector));

            foreach (var option in options)
            {
                if (option.Text == (optionText))
                {
                    option.Click();
                    Thread.Sleep(2000);
                    break;
                }
            }
        }

        public static bool UrlContains(string value)
        {
            return SeleniumDriver.Instance.Url.Contains(value);
        }

        public static string GetUrl()
        {
            return SeleniumDriver.Instance.Url;
        }
        public static void PressEnter(IWebElement iwe)
        {
            try
            {
                if (iwe == null) return;
                iwe.SendKeys(Keys.Enter);
            }
            catch (NullReferenceException)
            {
            }
        }

       

        public static bool GetText(IWebElement iwe, string text)
        {
            return iwe != null && iwe.Text.Contains(text);
        }

        public static void AssertIsTextPresent(IWebElement iwe, string expectedText)
        {
            
            var isPresent = iwe != null && iwe.Text.Contains(expectedText);
            Assert.IsTrue(isPresent, "Expected :: " + expectedText + " | " + "Actual :: " + iwe.Text);
        }

        public static string GetAttributeValue(IWebElement iwe, string attributeName)
        {
            return iwe != null ? iwe.GetAttribute(attributeName) : string.Empty;
        }

        #region IWebElements Doing Methods

        public static bool IsTrue()
        {
            return true;
        }


        public static string TestName { get; set; }

        public static string FeatureName { get; set; }

        public static string[] Tags { get; set; }


        public static void Click(IWebElement iwe)
        {
           
                if (iwe != null)
            {
                try
                {
                    iwe.Click();
                }
                catch (TargetInvocationException e) { }
            }
           
        }

        public static bool IsDisplayed(IWebElement iwe)
        {
            try
            {
                return iwe.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsEnabled(IWebElement iwe)
        {
            try
            {
                return iwe.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsSelected(IWebElement iwe)
        {
            try
            {
                return iwe.Selected;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsChecked(IWebElement iwe)
        {
            try
            {
                var result = Convert.ToBoolean(iwe.GetAttribute("checked"));
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int HeightOfTheIWebElement(IWebElement iwe)
        {
            return iwe.Size.Height;
        }

        public static int WidthOfTheIWebElement(IWebElement iwe)
        {
            return iwe.Size.Width;
        }


     

        public static void Wait(IWebElement iwe)
        {
            var wait = new WebDriverWait(SeleniumDriver.Instance, TimeSpan.FromSeconds(20));
            wait.Until(d => Equals(d.SwitchTo().ActiveElement(), iwe));
        }

        public static void WaitForElementToChangeText(IWebElement iwe, string newText)
        {
            while (!GetText(iwe).Contains(newText))
            {
                Thread.Sleep(1000);
            }
        }

        public static void Wait(decimal seconds)
        {
            var time = Convert.ToInt32(seconds * 1000);
            Thread.Sleep(time);
        }

        public static void SendKeys(IWebElement iwe, string input)
        {
            try
            {
                if (iwe == null || input == null) return;
                iwe.Clear();
                iwe.SendKeys(input);
            }
            catch (NullReferenceException)
            {
            }
        }

      
        public static void ClearText(IWebElement iwe)
        {
            iwe.Clear();
        }

        public static bool IsAttributeValuePresentOnElement(IWebElement iwe, string attribute, string value)
        {
            try
            {
                if (iwe.Displayed)
                {
                    var computedValue = iwe.GetAttribute(attribute);
                    if (computedValue.ToLower().Contains(value.ToLower()))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public static IWebElement FindElement(Func<string, By> func, string selector)
        {
            var iwe = SeleniumDriver.Instance.FindElement(func(selector));
            return iwe;
        }
        

        public static IList<IWebElement> FindElements(Func<string, By> func, string selector)
        {
            IList<IWebElement> iwe = SeleniumDriver.Instance.FindElements(func(selector));
            return iwe;
        }

        public static IWebElement getWebElementByCSS(String css)
        {
            IWebElement element = SeleniumDriver.Instance.FindElement(By.CssSelector(css));
            return element;
        }

        public static string GetCssValue(IWebElement iwe, string cssValue)
        {
            var value = iwe.GetCssValue(cssValue);
            return value;
        }

        public static string ReturnWebElementText(IWebElement iwe)
        {
            return iwe.Text;
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

        public static void AcceptInformationMessage(string message)
        {
            var alert = SeleniumDriver.Instance.SwitchTo().Alert();
            alert.SendKeys(message);
            alert.Accept();
        }

        public static void AcceptInformationMessage()
        {
            var alert = SeleniumDriver.Instance.SwitchTo().Alert();
            alert.Accept();
        }

        public static int NumberOfBrowserWindows()
        {
            return SeleniumDriver.Instance.WindowHandles.Count;
        }

        public static void SwitchFrameByName(string title)
        {
            SeleniumDriver.Instance.SwitchTo().Frame(title);
        }

        public static void SwitchFrameById(int index)
        {
            SeleniumDriver.Instance.SwitchTo().Frame(index);
        }

        public static void SwitchFrameToDefault()
        {
            SeleniumDriver.Instance.SwitchTo().DefaultContent();
        }

        #endregion

        #region Other Types of Methods

        public static void ScrollToElement(IWebElement element)
        {
            var scrollY = Convert.ToString(element.Location.Y - element.Size.Height);

            var builder = new Actions(SeleniumDriver.Instance);
            builder.MoveToElement(element).Build().Perform();
            ((IJavaScriptExecutor)SeleniumDriver.Instance).ExecuteScript("window.scrollBy(0,-9000);");
            ((IJavaScriptExecutor)SeleniumDriver.Instance).ExecuteScript("window.scrollBy(0," + scrollY + ");");
        }

        public static List<string> ListOfSitemapUrLs(string sitemapText)
        {
            var xelement = XElement.Parse(sitemapText);
            var s = xelement.Value;
            var listOfUrLs = s.Split(new[] { "http://" }, StringSplitOptions.RemoveEmptyEntries);
            if (listOfUrLs.Length == 1)
            {
                listOfUrLs = s.Split(new[] { "https://" }, StringSplitOptions.RemoveEmptyEntries);
            }
            var list = new List<string>(listOfUrLs);
            var clensedList = (from el in list where !el.ToLower().Contains(".pdf") select el);
            return clensedList.ToList();
        }

        public static void DismissInformationMessage()
        {
            SeleniumDriver.Instance.SwitchTo().Alert().Dismiss();
        }

        public static void SwitchHandleToDefault()
        {
            try
            {
                var handles = SeleniumDriver.Instance.WindowHandles;
                SeleniumDriver.Instance.SwitchTo().Window(handles[0]);
            }
            catch (Exception)
            {
            }
        }

        public static bool SwitchWindowHandleByTitle(string title)
        {
            var amITrue = false;
            try
            {
                var handles = SeleniumDriver.Instance.WindowHandles;
                SeleniumDriver.Instance.SwitchTo().Window(handles[0]);
                foreach (var handle in handles)
                {
                    amITrue = SeleniumDriver.Instance.SwitchTo().Window(handle).Title.Contains(title);
                }
            }
            catch (Exception)
            {
            }
            return amITrue;
        }

        public static void ChangeBrowserInstanceToNewWindow(int frameIndex)
        {
            var handles = SeleniumDriver.Instance.WindowHandles;
            SeleniumDriver.Instance.SwitchTo().Window(handles[frameIndex]);
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

        public static bool IsElementPresent(By by)
        {
            try
            {
                SeleniumDriver.Instance.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
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
            // Use Ctrl + F5
            // Logger.WriteInformationToLog("Clearing Cache - using Ctrl + F5");
            var builder = new Actions(SeleniumDriver.Instance);
            builder.KeyDown(Keys.Control).SendKeys(Keys.F5).KeyUp(Keys.Control).Perform();
        }

        #endregion

        public static void ContextClick(IWebElement iwe)
        {
            new Actions(SeleniumDriver.Instance).ContextClick(iwe).Perform();
        }

        public static IList<IWebElement> FindElements(By by)
        {
            var iwe = SeleniumDriver.Instance.FindElements(by);
            return iwe;
        }

        public static IWebElement FindElement(By by)
        {
            var iwe = SeleniumDriver.Instance.FindElement(by);
            return iwe;
        }

        public static IWebDriver GetDriver()
        {
            return SeleniumDriver.Instance;
        }

        public static void SwitchFrameBySelector(By by)
        {
            SwitchFrameToDefault();
            //    var iwe = FindElement(by);

            SeleniumDriver.Instance.SwitchTo()
                .Frame(
                    SeleniumDriver.Instance.FindElement(by));
        }



        public static IWebElement FindElement(IWebElement iweSearchingOff, By by)
        {
            return iweSearchingOff.FindElement(by);
        }

        public static string[] SplitString(string split)
        {
            return split.Split();
        }

        public static string[] SplitStringWithChar(string split, char splitChar)
        {
            return split.Split(splitChar);
        }

        #endregion
    }
}
