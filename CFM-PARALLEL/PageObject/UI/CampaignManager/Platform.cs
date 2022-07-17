using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.CampaignManager
{
    class Platform
    {
        public By PlatFormTile { get { return (By.XPath("//a[text()='Platforms']")); } }
        public By CreatePlatFormBtn { get { return (By.XPath("//span[text()='Create New Platform']")); } }
        public By PlatformName { get { return (By.XPath("//input[@formcontrolname='platformName']")); } }
        public By PlatformDescription { get { return (By.XPath("//textarea[@formcontrolname='platformDescription']")); } }
        public By NetSuiteID { get { return (By.XPath("//input[@formcontrolname='netSuiteVendorID']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By PlatformEdit { get { return (By.XPath("//tbody/tr[1]/td[4]/button/span[@class='mat-button-wrapper']")); } }
        public By ToggleBtn { get { return (By.XPath("//tbody/tr[1]/td[4]/mat-slide-toggle/label/div/div/div[@class='mat-slide-toggle-thumb']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public void PlatFormExecution()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(PlatFormTile);
                Pages.BasicInteractions().Click(PlatFormTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(CreatePlatFormBtn);
                Pages.BasicInteractions().WaitTime(1);
                pressTabButton();
                pressTabButton();
                pressTabButton();
                pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(PlatformName, ConfigurationManager.AppSettings["PlatformName"]);
                Pages.BasicInteractions().Type(PlatformDescription, ConfigurationManager.AppSettings["PlatformDescription"]);
                Pages.BasicInteractions().Type(NetSuiteID, ConfigurationManager.AppSettings["NetSuiteID"]);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(4);
                Pages.BasicInteractions().WaitVisible(CreatePlatFormBtn);
                Pages.BasicInteractions().Click(ToggleBtn);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(PlatformEdit);
                Pages.BasicInteractions().Type(PlatformDescription, ConfigurationManager.AppSettings["PlatformDescription"]);
                Pages.BasicInteractions().Type(NetSuiteID, ConfigurationManager.AppSettings["NetSuiteID"]);
                Pages.BasicInteractions().WaitTime(1);
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