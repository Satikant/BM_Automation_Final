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
    class JiraTenanntConfig
    {
        public By TenantConfigTile { get { return (By.XPath("//a[text()='JIRA Tenant Configuration']")); } }
        public By CreateconfigBtn { get { return (By.XPath("//span[text()='Create New Jira Tenant Configuration']")); } }
        public By TenantSelection { get { return (By.XPath("//span[text()='Tenant']")); } }
        public By Dropdownvalues { get { return (By.XPath("//div[@role='listbox']")); } }
        public By AgentCompanyName { get { return (By.XPath("//input[@formcontrolname='agentCompanyNameField']")); } }
        public By AgentCompanyID { get { return (By.XPath("//input[@formcontrolname='agentIdField']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public By Dropdownlist { get { return (By.XPath("//div[@role='listbox']")); } }
    
        public void JiraTenanntConfigExecution()
        {
            try
            {
                JiraTenanntConfig TenantConfig = new JiraTenanntConfig();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(TenantConfigTile);
                Pages.BasicInteractions().Click(TenantConfigTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(CreateconfigBtn);
                Pages.BasicInteractions().WaitTime(1);
                TenantConfig.pressTabButton();
                TenantConfig.pressTabButton();
                TenantConfig.pressTabButton();
                TenantConfig.pressTabButton();
                TenantConfig.pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(TenantSelection);
                TenantConfig.Dropdownselection(Dropdownlist, ConfigurationManager.AppSettings["JIRATenantConfigSelection"]);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(AgentCompanyID, ConfigurationManager.AppSettings["JIRATenantAgentID"]);
                Pages.BasicInteractions().Type(AgentCompanyName, ConfigurationManager.AppSettings["JIRATenantCompanyName"]);
                Pages.BasicInteractions().Click(SaveBtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }

        }
        public void KeyAction()
        {
            Actions actions = new Actions(Base.Driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
            Console.WriteLine("Entered");
            Pages.BasicInteractions().WaitTime(2);
        }
        public void Dropdownselection(By element, String text)
        {
            Actions actions = new Actions(Base.Driver);
            Pages.BasicInteractions().Type(element, text);
            Pages.BasicInteractions().WaitTime(4);
            actions.SendKeys(Keys.Enter);
            actions.Build().Perform();
            Console.WriteLine("Entered");
        }
        public void pressTabButton()
        {
            Actions keyPress = new Actions(Base.Driver);
            keyPress.SendKeys(Keys.Tab).Build().Perform();
        }
    }
}
