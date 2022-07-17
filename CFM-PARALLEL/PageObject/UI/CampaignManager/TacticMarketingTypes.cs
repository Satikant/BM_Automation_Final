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
    class TacticMarketingTypes
    {
        public By TacticMarketingTypesTile { get { return (By.XPath("//a[text()='Tactic Marketing Types']")); } }
        public By CreateTacticMarketingTypeBtn { get { return (By.XPath("//span[text()='Create New Tactic Marketing Type']")); } }
        public By TacticMarketingTypeName { get { return (By.XPath("//input[@formcontrolname='tacticMarketingTypeName']")); } }
        public By TacticMarketingLabel { get { return (By.XPath("//label[text()='Tactic Marketing Type Name']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By TacticMarketingTypeEdit { get { return (By.XPath("//tbody/tr[1]/td[2]/button/span[@class='mat-button-wrapper']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public void TacticMarketingTypesExecution()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(TacticMarketingTypesTile);
                Pages.BasicInteractions().Click(TacticMarketingTypesTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(CreateTacticMarketingTypeBtn);
                Pages.BasicInteractions().WaitTime(2);
                pressTabButton();
                pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(TacticMarketingTypeName, ConfigurationManager.AppSettings["TacticMarketingTypeName"]);
                Pages.BasicInteractions().Click(TacticMarketingLabel);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(3);
                //Edit
                Pages.BasicInteractions().Click(TacticMarketingTypeEdit);
                Pages.BasicInteractions().Type(TacticMarketingTypeName, ConfigurationManager.AppSettings["TacticMarketingTypeName"]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(TacticMarketingLabel);
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
