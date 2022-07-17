
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
using _Excel = Microsoft.Office.Interop.Excel;
namespace CFM_PARALLEL.PageObject.UI.CampaignManager
{
    class JiraTenantMapping
    {
        public By JIRATenantMAPTile { get { return (By.XPath("//a[text()='JIRA Tenant Mappings']")); } }
        public By NewJIRATenantMAPBtn { get { return (By.XPath("//span[text()='Create New Jira Tenant Mapping']")); } }
        public By TenantSelection { get { return (By.XPath("//span[text()='Tenant']")); } }
        public By ClientimapactedName { get { return (By.XPath("//input[@formcontrolname='jiraClientImpactedName']")); } }
        public By ClientimapactedID { get { return (By.XPath("//input[@formcontrolname='jiraClientImpactedID']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By JiraTenantEdit { get { return (By.XPath("//tbody/tr[1]/td[4]/button/span[@class='mat-button-wrapper']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public By Dropdownlist { get { return (By.XPath("//div[@role='listbox']")); } }
        public void JiraTenantMappingExecution()
        {
            try
            {
                JiraTenantMapping tenantMapping = new JiraTenantMapping();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(JIRATenantMAPTile);
                Pages.BasicInteractions().Click(JIRATenantMAPTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(NewJIRATenantMAPBtn);
                Pages.BasicInteractions().WaitTime(1);
                tenantMapping.pressTabButton();
                tenantMapping.pressTabButton();
                tenantMapping.pressTabButton();
                tenantMapping.pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(TenantSelection);
                tenantMapping.Dropdownselection(Dropdownlist, ConfigurationManager.AppSettings["JIRAClientTenantselection"]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Type(ClientimapactedName, ConfigurationManager.AppSettings["JIRAClientImpactedName"]);
                Pages.BasicInteractions().Type(ClientimapactedID,ConfigurationManager.AppSettings["JIRAClientImpactedID"]);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(3);
                /*Jiratenant Edit*/
                Pages.BasicInteractions().Click(JiraTenantEdit);
                Pages.BasicInteractions().WaitTime(2);
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
       /** public void PassData(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            Pages.BasicInteractions().Type(ClientimapactedName, userData.Name);
            Pages.BasicInteractions().Type(ClientimapactedID, userData.IDs);
        }**/
        public void pressTabButton()
        {
            Actions keyPress = new Actions(Base.Driver);
            keyPress.SendKeys(Keys.Tab).Build().Perform();
        }
    }
}