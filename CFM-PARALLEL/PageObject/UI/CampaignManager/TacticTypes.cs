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
    class TacticTypes
    {
        public By TacticTypesTile { get { return (By.XPath("//a[text()='Tactic Types']")); } }
        public By CreateTacticTypeBtn { get { return (By.XPath("//span[text()='Create New Tactic Type']")); } }
        public By TacticTypeName { get { return (By.XPath("//input[@formcontrolname='tacticTypeName']")); } }
        public By TacticTypeLabel { get { return (By.XPath("//label[text()='Tactic Type Name']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By TacticEdit { get { return (By.XPath("//tbody/tr[1]/td[2]/button/span[@class='mat-button-wrapper']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public void TacticTypesExecution()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(TacticTypesTile);
                Pages.BasicInteractions().Click(TacticTypesTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(CreateTacticTypeBtn);
                Pages.BasicInteractions().WaitTime(1);
                pressTabButton();
                pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                //  Pages.BasicInteractions().SelectByText(AutoTacticType12);
                Pages.BasicInteractions().Type(TacticTypeName, ConfigurationManager.AppSettings["TacticTypeName"]);
                Pages.BasicInteractions().Click(TacticTypeLabel);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(4);
                //TacticTypes Edit
                Pages.BasicInteractions().Click(TacticEdit);
                Pages.BasicInteractions().Type(TacticTypeName, ConfigurationManager.AppSettings["TacticTypeName"]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(TacticTypeLabel);
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
