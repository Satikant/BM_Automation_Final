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
    class SubPlatform
    {
        public By SubPlatformTile { get { return (By.XPath("//a[text()='Sub-Platforms']")); } }
        public By CreateSubPlatformBtn { get { return (By.XPath("//span[text()='Create New Sub Platform']")); } }
        public By SubPlatformName { get { return (By.XPath("//input[@formcontrolname='subPlatformName']")); } }
        public By SubPlatformDescription { get { return (By.XPath("//textarea[@formcontrolname='subPlatformDescription']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By ToggleBtn { get { return (By.XPath("//tbody/tr[1]/td[3]/mat-slide-toggle/label/div/div/div[@class='mat-slide-toggle-thumb']")); } }
        public By SubplatformEdit { get { return (By.XPath("//tbody/tr[1]/td[3]/button/span[@class='mat-button-wrapper']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public void SubPlatFormExecution()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(SubPlatformTile);
                Pages.BasicInteractions().Click(SubPlatformTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(CreateSubPlatformBtn);
                Pages.BasicInteractions().WaitTime(1);
                pressTabButton();
                pressTabButton();
                pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(SubPlatformName, ConfigurationManager.AppSettings["SubPlatformName"]);
                Pages.BasicInteractions().Type(SubPlatformDescription, ConfigurationManager.AppSettings["SubPlatformDescription"]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(4);
                Pages.BasicInteractions().WaitVisible(CreateSubPlatformBtn);
                Pages.BasicInteractions().Click(ToggleBtn);
                Pages.BasicInteractions().WaitTime(3);
               /*Subplatform Edit*/
                Pages.BasicInteractions().Click(SubplatformEdit);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Type(SubPlatformDescription, ConfigurationManager.AppSettings["SubPlatformDescription"]);
                Pages.BasicInteractions().WaitTime(2);
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