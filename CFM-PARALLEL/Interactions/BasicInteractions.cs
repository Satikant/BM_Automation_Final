using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CFM_PARALLEL.Interactions_New
{
    public class BasicInteractions : Base
    {
        private IWebDriver Driver { get; set; }
        private int ite = 1;

        public BasicInteractions(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        public void Gotourl(string url)
        {
            try
            {
                Driver.Navigate().GoToUrl(url);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in GoToURL Method in BasicInteractions. URL = "+url);
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }

        public string Geturl()
        {
            return Driver.Url;
        }


        public void Type(By by, string value)
        {
            try
            {
                Driver.FindElement(by).SendKeys(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in Type Method in BasicInteractions. Xpath = " + by.ToString() + "Value Sent = "+value);
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }

        public void Type(By by, string value, int waittimeinsecs)
        {
            try
            {
                WaitTime(waittimeinsecs);
                Driver.FindElement(by).SendKeys(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in Type Method in BasicInteractions. Xpath = " + by.ToString() + "Value Sent = " + value +"waitTimeInSeconds = "+waittimeinsecs);
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }

        public void Clear(By by, int waittimeinsecs)
        {
            try
            {
                Driver.FindElement(by).Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in Clear Method in BasicInteractions. Xpath = " + by.ToString() +  "waitTimeInSeconds = " + waittimeinsecs);
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }

        public void TypeClear(By by, string value)
        {
            try
            {
                var element = Driver.FindElement(by);
                element.Clear();
                element.SendKeys(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in TypeClear Method in BasicInteractions. Xpath = " + by.ToString() + "value = " + value);
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }
        public void Clear(By by)
        {
            try
            {
                var element = Driver.FindElement(by);
                element.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in Clear Method in BasicInteractions. Xpath = " + by.ToString());
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }

        public void TypeClear(By by, string value, int waittimeinsecs)
        {
            try
            {
                var element = Driver.FindElement(by);
                element.Clear();
                element.SendKeys(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in TypeClear Method in BasicInteractions. Xpath = " + by.ToString() + "value = " + value);
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }

        public void SelectTextAndType(By by, string value)
        {
            Driver.FindElement(by).SendKeys(Keys.Control + "a");
            Driver.FindElement(by).SendKeys(value);
        }

        public void CopyData(By by)
        {
            Driver.FindElement(by).SendKeys(Keys.Control + "a");
            Driver.FindElement(by).SendKeys(Keys.Control + "c");
        }

        public void PasteData(By by)
        {
            Driver.FindElement(by).SendKeys(Keys.Control + "v");
        }     


        #region Get functionality
        public string GetText(By by)
        {
            String text;

            try
            {
                text= Driver.FindElement(by).Text;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in GetText Method in BasicInteractions. Xpath = " + by.ToString());
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
            return text;
        }
        public string GetText(By by, int waittimeinsecs)
        {
            WaitTime(waittimeinsecs);
            return Driver.FindElement(by).Text;
        }
        public void Windowhandle()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            //Driver.Close();
            //Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }

        public int WindowhandleCounts()
        {
            int count = Driver.WindowHandles.Count();
            return count;
        }

        public string GetTextJavaScript(By by)
        {

            return ((IJavaScriptExecutor)Driver).ExecuteScript("return $(arguments[0]).text();", Driver.FindElement(by)).ToString();
        }
        public string GetTextJavaScript(By by, int waittimeinsecs)
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript("return $(arguments[0]).text();", Driver.FindElement(by)).ToString();
        }
        public string GetAttribute(By by, string value)
        {
            String attribute;

            try
            {
              attribute =   Driver.FindElement(by).GetAttribute(value);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in GetAttribute Method in BasicInteractions. Xpath = " + by.ToString() + "Attribute Name = "+value);
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
            return attribute;
        }
       
        //Get visible text
        public string GetText(IWebElement element)
        {
            return element.Text;
        }

       
        public void WindowHandle()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            WaitTime(15);
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }
        public string GetCurrentUrl()
        {
            return Driver.Url;
        }
        

        #endregion

        #region Exists functionality
        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsElementPresent(By by, int waittimeinsecs)
        {
            try
            {
                WaitTime(waittimeinsecs);
                Driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Element functionality
        public IWebElement GetElement(By by)
        {
            IWebElement element;

            try
            {
                element = Driver.FindElement(by);

           }
            catch (Exception ex)
            {
                Console.WriteLine("Click failed in getElement method with exception " + ex.ToString() + "For the Xpath = " + by.ToString());
                Console.WriteLine();
                throw;
            }

            return element;

  }

        public IWebElement GetElement(By by, int waittimeinsecs)
        {
            IWebElement element;
            try
            {
                element= Driver.FindElement(by);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Click failed in getElement method with exception " + ex.ToString() + "For the Xpath = " + by.ToString() + "with WaitTimeInSec = " + waittimeinsecs);
                Console.WriteLine();
                throw;
            }
            return element;
        }

        public IList<IWebElement> GetElements(By by)
        {
            IList<IWebElement> elements;
            try
            {
                elements= Driver.FindElements(by);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Click failed in getElement method with exception " + ex.ToString() + "For the Xpath = " + by.ToString());
                Console.WriteLine();
                throw;
            }
            return elements;
        }

       
        public bool IsElementDisplayed(By by)
        {
            bool Found = false;
            try
            {
                Found = Driver.FindElement(by).Displayed;
            }
            catch
            {
                Found = false;  
            }

            return Found;
        }


        // Element is enabled or not
        public bool IsElementEnabled(By by)
        {
            bool enabled = true;
            try
            {
                 enabled = Driver.FindElement(by).Enabled;

            }
            catch
            {
                enabled = false;
            }
            return enabled;
        }
        //Element is selected or not
        public bool IsElementSelected(By by)
        {

            try
            {
                bool selected = Driver.FindElement(by).Selected;
                return selected;
            }
            catch
            {
                throw new Exception("ELEMENTNOTSELECTED");
            }

        }

     
       
        //Check input box is empty or not
        public bool IsInputBoxEmpty(By by)
        {
            string textvalue = Driver.FindElement(by).GetAttribute("value");
            if (textvalue.Length == 0)
            { return true; }
            else return false;
        }
        //Check list is em[ty or not
        public bool IsListEmpty(By by)
        {
            IWebElement element = Driver.FindElement(by);
            SelectElement listBox = new SelectElement(element);
            IList<IWebElement> listOptions = listBox.Options;
            if (listOptions.Count > 0)
            { return false; }
            return true;
        }

        public List<string> Options(By by)
        {
            IList<IWebElement> moptions = new SelectElement(Driver.FindElement(by)).Options;
            List<string> v = new List<string>();
            for (int i = 0; i <= moptions.Count - 1; i++)
            {
                v.Add(moptions[i].Text.ToString().Trim());
            }
            return v;
        }


        #endregion

        #region click functionality
        public void Click(By by)
        {
            try
            {
                Driver.FindElement(by).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Click failed with exception " +ex.ToString() +"For the Xpath = "+by.ToString());
                Console.WriteLine();
                Assert.Fail();
            }
        }

        public void Click(By by , Boolean waitVisibleRequired)
        {
            try
            {
                if (waitVisibleRequired)
                    WaitVisible(by);
                Driver.FindElement(by).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Element in Click Method with XPath = : "+by.ToString() + "WaitVisibleRequired = "+waitVisibleRequired.ToString());
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }
        public void Click(By by, int timeinsecs)
        {
            WaitTime(timeinsecs);
            Driver.FindElement(by).Click();
        }
        public void HoverBy(By Hoverby)
        {
            IWebElement elementToHover = Driver.FindElement(Hoverby);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
        }
        public void HoverByClickBy(By Hoverby, By ClickBy)
        {
            IWebElement elementToHover = Driver.FindElement(Hoverby);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            Click(ClickBy);
        }
        public void HoverByDoubleClickBy(By Hoverby)
        {
            IWebElement elementToHover = Driver.FindElement(Hoverby);
            Actions hover = new Actions(Driver);
            //hover.MoveToElement(elementToHover);
            hover.DoubleClick(elementToHover);
            hover.Build();
            hover.Perform();

        }
        public void HoverByClickBy(By Hoverby, By ClickBy, int timeinsecs)
        {
            IWebElement elementToHover = Driver.FindElement(Hoverby);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            Click(ClickBy);
        }
        public void HoverClickBy(By by)
        {
            IWebElement elementToHover = Driver.FindElement(by);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            Click(by);
        }
        public void HoverClickBy(By by, int timeinsecs)
        {
            IWebElement elementToHover = Driver.FindElement(by);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            Click(by);
        }
        public void ClickJavaScript(By by)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", GetElement(by));
        }
        public void ClickJavaScript(By by, int timeinsecs)
        {
            WaitExists(by, timeinsecs);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", GetElement(by));
        }   

        internal void ClickAndWait(By by, int timeToWait)
        {
            Driver.FindElement(by).Click();
            WaitTime(timeToWait);
        }

        internal void ClickAndWait(IWebElement element, int timeToWait)
        {
            element.Click();
            WaitTime(timeToWait);
        }

        //Click and wait for page to load
        public void ClickAndWaitForPageToLoad(By elementLocator, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                var element = Driver.FindElement(elementLocator);
                element.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
            }
            catch (Exception e)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }

        //Click and wait for page to load
        public void ClickAndWaitForPageToLoad(IWebElement element, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                element.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
            }
            catch (Exception e)
            {
                Console.WriteLine("Element with locator: '" + element + "' was not found in current context page.");
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine(); 
                throw;
            }
        }
    
        public void HoverByJavaScript(By Hoverby)
        {
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                    "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                    "arguments[0].dispatchEvent(evObj);";
            IJavaScriptExecutor executor = Driver as IJavaScriptExecutor;
            executor.ExecuteScript(javaScript, GetElement(Hoverby));
        }    
     
        #endregion

        #region select functionality
        public void SelectByText(By by, string text)
        {
            new SelectElement(Driver.FindElement(by)).SelectByText(text);

        }
        public void SelectByText(By by, string text, int waititmeinsecs)
        {
            new SelectElement(Driver.FindElement(by)).SelectByText(text);
        }
        public void SelectByValue(By by, string value)
        {
            new SelectElement(Driver.FindElement(by)).SelectByValue(value);
        }
        public void SelectByValue(By by, string value, int waititmeinsecs)
        {
            new SelectElement(Driver.FindElement(by)).SelectByValue(value);
        }
        public void SelectByIndex(By by, int index)
        {
            new SelectElement(Driver.FindElement(by)).SelectByIndex(index);
        }
        public void SelectByIndex(By by, int index, int waititmeinsecs)
        {
            new SelectElement(Driver.FindElement(by)).SelectByIndex(index);
        }
        #endregion

        #region wait functionality
        public void WaitExists(By by, int timeOut = 60)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementExists(by));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in WaitExists Method in BasicInteractions. Xpath = " + by.ToString());
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }      
        }

        public void WaitVisible(By by, int timeOut = 300)
        {
            try
            { 
               new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in WaitVisible Method in BasicInteractions. Xpath = " + by.ToString());
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }          
        }

        public bool IsWaitVisible(By by, int timeOut = 60)
        {
            Boolean found = true;
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            }
            catch
            {
                // do not need to catch exception
                found= false;
            }
            return found;
        }

        //does not work when the element is still attached to DOM....
        //public void WaitWhileNotVisible(By by)
        //{
        //    var stillExists = true;
        //    while (stillExists)
        //    {
        //        try
        //        {
        //            WaitVisible(by, 1);
        //        }
        //        catch
        //        {
        //            stillExists = false;
        //        }

        //    }
        //}

        public void WaitTime(int seconds)
        {
            try { seconds = seconds * 1000; } catch { seconds = 1000; }
            Thread.Sleep(seconds);
        }

        public void WaitForPageToLoad()
        {
            try
            {
                IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(800.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in WaitForPageToLoad Method in BasicInteractions.");
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
            }
        }

        public void WaitForPageToLoad(int timeinsec)
        {
            try
            {
                IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeinsec + 500.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in WaitForPageToLoad Method in BasicInteractions. Waitime = "+timeinsec );
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }

        public IWebElement WaitUntilElementClickable(By by, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception e)
            {
                Console.WriteLine("Element : '" + by + "' was not found in current context page.");
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }
        
        //Wait till the element is visible
        internal void WaitTillNotVisible(By by, int timeInSecond = 120)
        {
            try
            {
                if (IsElementPresent(by))
                {
                    new WebDriverWait(Driver, TimeSpan.FromSeconds(timeInSecond)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
                    //new WebDriverWait(Driver, TimeSpan.FromSeconds(timeInSecond)).Until(ExpectedConditions.StalenessOf(Driver.FindElement(by)));//does not work when the element is still attached to DOM, even NOT displayed.
                    WaitTime(1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Element with Xpath = " +by.ToString()+ " is still present after " + timeInSecond + " Seconds");
                Console.WriteLine();
                Console.WriteLine("Exception is : "+ e.ToString());
                Console.WriteLine();
                throw;
            }
        }
      
        //will wait until elemnet is clickable
        public IWebElement WaitUntilElementClickable(IWebElement element, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
               // return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
            }
            catch (Exception e)
            {
                Console.WriteLine("Element : '" + element + "' was not found in current context page.");
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
        }       

        //will search for the element until a timeout is reached
        public IWebElement WaitUntilElementVisible(By elementLocator, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }

        //will wait for the timeout for element to be unattched from DOM
        public bool WaitUntilStalenessOfElement(IWebElement element, int timeinsec)
        {
            Boolean found = true;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeinsec));
                found = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
            }
            catch(Exception e)
            {
                Console.WriteLine("Element is still not attached to current DOM");
                Console.WriteLine();
                Console.WriteLine("Exception is : " + e.ToString());
                Console.WriteLine();
                throw;
            }
            return found;
        }

        //will wait until URL contains the provided URL part
        public bool WaitUntilURLContains(string URL_Part, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(URL_Part));
            }
            catch (Exception ex)
            {
                Console.WriteLine("URL does not contains " + URL_Part + " after waiting time is over. ERROR: " + ex.Message);
                Console.WriteLine();
                Console.WriteLine("Exception is : " + ex.ToString());
                Console.WriteLine();
                throw;
            }
        }

        #endregion


        #region checks functionality
        public void Check(By by)
        {
            if (!Driver.FindElement(by).Selected)
            {
                Driver.FindElement(by).Click();
            }

        }
        public void Check(By by, int timeinsecs)
        {
            WaitTime(timeinsecs);
            if (!Driver.FindElement(by).Selected)
            {
                Driver.FindElement(by).Click();
            }
        }
        public void CheckJavaScript(By by)
        {
            if (!Driver.FindElement(by).Selected)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", by);
            }

        }
        public void CheckJavaScript(By by, int timeinsecs)
        {
            if (!Driver.FindElement(by).Selected)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", by);
            }
        }
        public void Uncheck(By by)
        {
            if (Driver.FindElement(by).Selected)
            {
                Driver.FindElement(by).Click();
            }

        }
        public void Uncheck(By by, int timeinsecs)
        {
            if (Driver.FindElement(by).Selected)
            {
                Driver.FindElement(by).Click();
            }
        }
        public void UncheckJavaScript(By by)
        {
            if (Driver.FindElement(by).Selected)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", by);
            }

        }
        public void UncheckJavaScript(By by, int timeinsecs)
        {
            if (Driver.FindElement(by).Selected)
            {

                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", by);
            }
        }

        public bool IsElementVisible(By by)
        {
            Boolean found = true;
            try
            {
                bool displayed = Driver.FindElement(by).Displayed;

            }
            catch
            {
                found= false;
                // throw new System.Exception("ELEMENTNOTDISPLAYED");
            }

            return found;
        }

        //public void CheckAndReCheck(By by, By ElementToCheck)
        //{
        //    if (! Driver.FindElement(by).Selected)
        //    {
        //        //BrowserURLLaunch b1 = new BrowserURLLaunch();
        //      Driver.FindElement(by).Click();
        //    }
        //    if (!ElementToCheck.IsElementPresent() || !by.getElement().Selected)
        //    {
        //        BrowserURLLaunch b1 = new BrowserURLLaunch();
        //        b1. Driver.FindElement(by).Click();
        //    }

        //}
        //public void CheckAndReCheck(By by, By ElementToCheck, int timeinsecs)
        //{
        //    by.WaitExists(timeinsecs);
        //    if (!by.getElement().Selected)
        //    {
        //        BrowserURLLaunch b1 = new BrowserURLLaunch();
        //        b1. Driver.FindElement(by).Click();
        //    }

        //    bi.WaitTime(1);
        //    if (!ElementToCheck.IsElementPresent() || !by.getElement().Selected)
        //    {
        //        BrowserURLLaunch b1 = new BrowserURLLaunch();
        //        b1. Driver.FindElement(by).Click();
        //    }
        //}


        
        #endregion

        //public void SwitchToIFrame(this By by)
        //{
        //    Driver.SwitchTo().Frame(by.getElement());
        //}

        //public void SwitchToIFrame(this By by, int timeinsecs)
        //{
        //    by.WaitExists(timeinsecs);
        //    Base.Driver.SwitchTo().Frame(by.getElement());
        //}
        //public IWebDriver IFrameDriver(this By by)
        //{
        //    IWebDriver driver = Driver;
        //    driver.SwitchTo().Frame(by.getElement());
        //    return driver;
        //}
        //public IWebDriver IFrameDriver(this By by, int timeinsecs)
        //{
        //    by.WaitExists(timeinsecs);
        //    IWebDriver driver = Driver;
        //    driver.SwitchTo().Frame(by.getElement());
        //    return driver;
        //}
       


        #region ALERTS
        //Accept Alert
        public bool AcceptAlert()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                alert.Accept();
                //Console.Out.WriteLine("Alert Was Present");
                return true;
            }
            catch
            {
                Console.Out.WriteLine("No Alert Found");
                return false;
            }
        }

        //Dismiss Alert
        public bool DismissAlert()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                alert.Dismiss();
                //Console.Out.WriteLine("Alert Was Present");
                return true;
            }
            catch
            {
                Console.Out.WriteLine("No Alert Found");
                return false;
            }
        }

        //Retieves the text present in the Alert pop up
        public string GetAlertText()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                var text = alert.Text.ToString();
                //Console.Out.WriteLine("Alert Was Present");
                return text;
            }
            catch
            {
                Console.Out.WriteLine("No Alert Found");
                return null;
            }
        }
  
       

        #endregion

        #region Maths
        public decimal ConvertToDecimalFromDollarString(string value)
        {
            return Convert.ToDecimal(value.Substring(1, value.Length - 1));
        }

        public decimal RoundToTwoDecimal(decimal value)
        {
            return Math.Round(value, 2);
        }

        public string ConvertToDollarValueWithDollarSign(decimal value)
        {
            return "$" + Convert.ToString(RoundToTwoDecimal(value));
        }
        #endregion

        #region SELECT

        //Select By Text from Dropdown
        //public void SelectByText(By by, string text)
        //{
        //    new SelectElement(Driver.FindElement(by)).SelectByText(text);
        //}
        ////Select By Text from Drop down
        //public void SelectByText(By by, string text, int timeinsec)
        //{
        //    WaitExists(by, timeinsec);
        //    new SelectElement(Driver.FindElement(by)).SelectByText(text);
        //}
        //Select By Value from Drop down
        //public void SelectByValue(By by, string value)
        //{
        //    new SelectElement(Driver.FindElement(by)).SelectByValue(value);
        //}
        ////Select By Value from Drop down
        //public void SelectByValue(By by, string value, int timeinsec)
        //{
        //    WaitExists(by, timeinsec);
        //    new SelectElement(Driver.FindElement(by)).SelectByValue(value);
        //}
        ////Select by Index from drop down
        //public void SelectByIndex(By by, int index)
        //{
        //    new SelectElement(Driver.FindElement(by)).SelectByIndex(index);
        //}
        //public void SelectByIndex(By by, int index, int timeinsec)
        //{
        //    WaitExists(by, timeinsec);
        //    new SelectElement(Driver.FindElement(by)).SelectByIndex(index);
        //}
        //Get selected options
        public string GetSelectedOption(By by)
        {
            string text = new SelectElement(Driver.FindElement(by)).SelectedOption.GetAttribute("text").ToString();
            return text;
        }
        //Returns all available options of dropdown list or ListBox as string separated by COMMA
        public string GetAvailableOptions(By by)
        {
            IWebElement element = Driver.FindElement(by);
            SelectElement select = new SelectElement(element);
            IList<IWebElement> allOptions = select.Options;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < allOptions.Count; i++)
            {
                if (allOptions.Count == 1)
                {
                    sb = sb.Append(allOptions[i].Text.Trim());
                    break;
                }
                else if (i == allOptions.Count - 1)
                {
                    sb = sb.Append(allOptions[i].Text.Trim());
                }
                else
                {
                    sb = sb.Append(allOptions[i].Text.Trim() + ",");
                }
            }
            string options = sb.ToString();
            return options;
        }
        //Verify Selected Option
        public bool VerifySelectedOption(By by, string text)
        {
            IList<IWebElement> moptions = new SelectElement(Driver.FindElement(by)).Options;
            foreach (IWebElement opt in moptions)
            {
                if (text.Contains(opt.Text))
                {
                    break;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //get all options available from drop down
        public IList<string> GetAllOptions(By by)
        {
            IList<IWebElement> moptions = new SelectElement(Driver.FindElement(by)).Options;
            List<string> v = new List<string>();
            for (int i = 0; i <= moptions.Count - 1; i++)
            {
                v.Add(moptions[i].Text.ToString().Trim());
            }
            return v;
        }

        #endregion

        #region TAKE SCREEN SHOT
        public void TakeScreenshots(string FunctionalityName)
        {
            try
            {
                String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy"); // Get Today's Date to create the folder
                //String FolderPath = "C:\\Users\\Priti Kumari\\Pictures\\Screenshots\\" + Todaysdate; // local path
                String FolderPath = "D:\\Screenshots\\" + Todaysdate; //server path
                if (!Directory.Exists(FolderPath)) {
                    DirectoryInfo di = Directory.CreateDirectory(FolderPath);
                }
                string timestamp = DateTime.Now.ToString("HH:mm:ss").Replace(":","_"); // Get timestamp to create the file
                String fileName = FunctionalityName +"_"+ timestamp;
                string Dir = FolderPath +"\\"+ fileName;
                Screenshot screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(Dir + ".png", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Failed to take to take screen shot due to " + e);
            }
        }
        #endregion

        #region IOEvents

        internal void Scrolldown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }
        //Do MouseHover on any element
        internal void MouseHoverOnElement(By by)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(Driver.FindElement(by));
            //Wait.WaitTime(1);
            action.Build().Perform();
            WaitTime(2);
        }
        internal void MouseHoverOnElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element);
            //Wait.WaitTime(1);
            action.Build().Perform();
            WaitTime(1);
        }
        //Do mouse hover and click on that element
        internal void MouseHoverAndClick(By by)
        {
            MouseHoverOnElement(by);
            //Wait.WaitTime(2);
            Click(by);
        }

        //Double click on any element
        internal void DoubleClick(By by)
        {
            IWebElement element = Driver.FindElement(by);
            Actions action = new Actions(Driver);
            action.MoveToElement(element);
            action.DoubleClick();
            action.Build().Perform();
            WaitTime(4);
        }

        //Right click on any element
        internal void RightClick(By by)
        {
            IWebElement element = Driver.FindElement(by);
            Actions action = new Actions(Driver);
            action.MoveToElement(element);
            action.ContextClick();
            action.Build().Perform();
        }

        // Scroll the page untill the element is in the view
        internal void ScrollToViewElement(By by)
        {
            IWebElement element = Driver.FindElement(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        // Scroll the page untill the element is in the view
        internal void ScrollToViewElement(IWebElement element)
        {
            //IWebElement element = Driver.FindElement(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        //Scroll to the bottom of the page
        internal void ScrollToBottomOfPage(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.clientHeight);");
        }

        //Scroll to the Top of the page
        internal void ScrollToTopOfPage(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 0)");
            //Below line instead of the upper line can be used when the page is already scrolled to bottom
            //js.ExecuteScript("window.scrollTo(0, -(document.body.scrollHeight));");
        }

        //Scroll up for some distance
        internal void ScrollUpForSomeDistance(int distance)
        {
            //IWebElement element = Driver.FindElement(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0,-" + distance + ")");
        }

        //Scroll down for some distance
        internal void ScrollDownForSomeDistance(int distance)
        {
            //IWebElement element = Driver.FindElement(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0," + distance + ")");
        }

        //Press ESCAPE button without reference to WenElement
        internal void PressESCButton()
        {

            Actions keyPress = new Actions(Driver);
            keyPress.SendKeys(Keys.Escape);
            keyPress.Build().Perform();
            //Need to add reference for System.Windows.Forms to work below line
            //System.Windows.Forms.SendKeys.SendWait("{ESC}");

        }

        //Press Control Button
        internal void PressControlButton(IWebDriver driver)
        {
            Actions keyPress = new Actions(driver);
            keyPress.KeyDown(Keys.LeftControl);
            //keyPress.SendKeys(Keys.LeftControl);
            keyPress.Build().Perform();

        }

        //Release Control Button
        internal void ReleaseControlButton(IWebDriver driver)
        {
            Actions keyPress = new Actions(driver);
            keyPress.KeyUp(Keys.LeftControl);
            //keyPress.SendKeys(Keys.LeftControl);
            keyPress.Build().Perform();
        }

        //Press Alt Button
        internal void PressAltButton(IWebDriver driver)
        {
            Actions keyPress = new Actions(driver);
            keyPress.KeyDown(Keys.LeftAlt);
            //keyPress.SendKeys(Keys.LeftControl);
            keyPress.Build().Perform();

        }

        //Release Alt Button
        internal void ReleaseAltButton(IWebDriver driver)
        {
            Actions keyPress = new Actions(driver);
            keyPress.KeyUp(Keys.LeftAlt);
            //keyPress.SendKeys(Keys.LeftControl);
            keyPress.Build().Perform();
        }

        //Press Shift Button
        internal void PressShiftButton(IWebDriver driver)
        {
            Actions keyPress = new Actions(driver);
            keyPress.KeyDown(Keys.LeftShift);
            //keyPress.SendKeys(Keys.LeftControl);
            keyPress.Build().Perform();

        }

        //Release Shift Button
        internal void ReleaseShiftButton(IWebDriver driver)
        {
            Actions keyPress = new Actions(driver);
            keyPress.KeyUp(Keys.LeftShift);
            //keyPress.SendKeys(Keys.LeftControl);
            keyPress.Build().Perform();
        }

        #endregion

        #region NAVIGATION


        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }
        public void ScrollBy(int scroll)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript(" window.scrollBy(0, scroll);");

        }
        public string GetCurrentURL()
        {
            return Driver.Url;
        }
        #endregion

        #region RANDOM STRING GENERATOR

        //It will generate random string with given length
        public string StringGenerator(int requiredlength)
        {
            Random random = new Random();
            var chars = "ABCDEF";
            var result = new string(
                Enumerable.Repeat(chars, requiredlength)
                          .Select(s => s[random.Next(s.Length)])
                  .ToArray());

            return result;
        }

        #endregion

        #region SCROLL

        ////Scroll upto element to be visible
        //public void ScrollToViewElement(By by)
        //{
        //    IWebElement element = Driver.FindElement(by);
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        //    js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //}

        ////Scroll upto element to be visible
        //public void ScrollToViewElement(By by)
        //{
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        //    js.ExecuteScript("arguments[0].scrolSlIntoView(true);", by);
        //}

        //Scroll to bottom of page
        public void ScrollToBottomOfPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, document.body.clientHeight);");
        }
        //Scroll to top of page
        public void ScrollToTopOgPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, 0)");
        }

        #endregion

        #region VERIFY PAGE

        // It will verify the page with expected page name
        public void VerifyCurrentPage(string expectedpagename)
        {
            try
            {
                string act_currenturl = Driver.Url;
                if (act_currenturl.Contains(expectedpagename))
                {
                    Console.WriteLine("Current page verified successfully.");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Failed to verify current page due to " + e);
            }
        }

        //Verify Title
        public void VerifyTitle(string title, int timeinsec)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeinsec));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(title));
        }

        public void VerifyTitle(string title)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(title));
        }
        #endregion

        #region Enter KEY
        //Press Enter key 

        public void Enter(By by)
        {
            Driver.FindElement(by).SendKeys(Keys.Enter);
        }
        #endregion

        #region Cretate Unique Name
        //create unique name
        public string UniqueName(string name)
        {
            string timestamp = DateTime.Now.ToString();
            timestamp = timestamp.Replace("/", "").Replace(" ", "").Replace(":", "");
            return name + timestamp;
        }
        #endregion

        #region SWITCHES
        internal void SwitchToIFrame(By by)
        {
            Driver.SwitchTo().Frame(GetElement(by));
        }

        internal void SwitchToIFrame(By by, int timeinsecs)
        {
            WaitExists(by, timeinsecs);
            Driver.SwitchTo().Frame(GetElement(by));
        }
        internal IWebDriver IFrameDriver(By by)
        {
            IWebDriver driver = Driver;
            driver.SwitchTo().Frame(GetElement(by));
            return driver;
        }
        internal IWebDriver IFrameDriver(By by, int timeinsecs)
        {
            WaitExists(by, timeinsecs);
            IWebDriver driver = Driver;
            driver.SwitchTo().Frame(GetElement(by));
            return driver;
        }
        internal void Imultiframe(By by, string text)
        {
            IList<IWebElement> mf = GetElements(by);
            foreach (IWebElement frames in mf)
            {
                var actualframe = frames.GetAttribute("value");
                var actualframetitle = frames.GetAttribute("title");
                if (actualframe.Equals(text))
                {

                    Driver.SwitchTo().Frame(frames);
                }
                else if (actualframetitle.Equals(text))
                {

                    Driver.SwitchTo().Frame(frames);
                }
            }

        }
        internal void Defaultframe()
        {
            Driver.SwitchTo().DefaultContent();
        }
      
        internal void Winhandling(By by, int i)
        {
            IList<string> lst = Driver.WindowHandles.ToList();
            IEnumerator<string> it = lst.GetEnumerator();
            while (!it.MoveNext())
            {
                var id = it.MoveNext().ToString().Trim();
                if (ite == i)
                {
                    break;
                }
                ite++;
                Driver.SwitchTo().Window(id);

            }

        }
        internal void Winclose()
        {
            Driver.Close();
            //Driver.SwitchTo()
        }
    
        internal void Opennewtab()
        {
            IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
            js.ExecuteScript("window.open()");
            WaitTime(1);
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            WaitTime(1);
        }

        public void SwitchDriverToDefault()
        {
            Driver.SwitchTo().Window(CurrentWindow);
        }
        public void SwitchToNewBrowserTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        #endregion

    }
}
