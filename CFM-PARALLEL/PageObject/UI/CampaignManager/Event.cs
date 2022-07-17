using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Configuration;

namespace CFM_PARALLEL.PageObject.UI.CampaignManager
{
    public class Event
    {
        public By EventTile { get { return (By.XPath("//a[text()='Events']")); } }
        public By CreateEvenBtn { get { return (By.XPath("//span[text()='Create New Event']")); } }
        public By EventCode { get { return (By.XPath("//input[@formcontrolname='eventCode']")); } }
        public By Label { get { return (By.XPath("//input[@formcontrolname='label']")); } }
        public By Category { get { return (By.XPath("//input[@formcontrolname='category']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public By EventEdit { get { return (By.XPath("//tbody/tr[1]/td[5]/button/span[@class='mat-button-wrapper']")); } }
        public By EventLabel { get { return (By.XPath(" //label[text()='Event Code']")); } }
        public void EventExecution()
        {
            try
            {
                Event events = new Event();
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().GetCurrentUrl();
                Pages.BasicInteractions().Click(EventTile);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(CreateEvenBtn);
                Pages.BasicInteractions().WaitTime(1);
                pressTabButton();
                pressTabButton();
                pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(EventCode, ConfigurationManager.AppSettings["EventCode"]);
                Pages.BasicInteractions().Type(Label, ConfigurationManager.AppSettings["Label"]);
                Pages.BasicInteractions().Type(Category, ConfigurationManager.AppSettings["Category"]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(SaveBtn);
                /*Event Edit*/
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(EventEdit);
                Pages.BasicInteractions().Type(EventCode, ConfigurationManager.AppSettings["EventCode"]);
                Pages.BasicInteractions().Type(Label, ConfigurationManager.AppSettings["Label"]);
                Pages.BasicInteractions().Type(Category, ConfigurationManager.AppSettings["Category"]);
                Pages.BasicInteractions().Click(EventLabel);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(SaveBtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        public void pressTabButton()
        {
            Actions keyPress = new Actions(Base.Driver);
            keyPress.SendKeys(Keys.Tab).Build().Perform();
        }
    }
}

