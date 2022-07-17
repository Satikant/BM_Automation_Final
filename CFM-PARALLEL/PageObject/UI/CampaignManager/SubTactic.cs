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
    class SubTactic
    {
        public By SubTacticTile { get { return (By.XPath("//a[text()='Sub-Tactics']")); } }
        public By CreateSubTacticBtn { get { return (By.XPath("//span[text()='Create New Sub Tactic']")); } }
        public By SubTacticName { get { return (By.XPath("//input[@formcontrolname='subTacticName']")); } }
        public By SubTacticDescription { get { return (By.XPath("//textarea[@formcontrolname='subTacticDescription']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By ToggleBtn { get { return (By.XPath("//tbody/tr[1]/td[3]/mat-slide-toggle/label/div/div/div[@class='mat-slide-toggle-thumb']")); } }
        public By SubTacticEdit { get { return (By.XPath("//tbody/tr[1]/td[3]/button/span[@class='mat-button-wrapper']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public void SubTacticExecution()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(SubTacticTile);
                Pages.BasicInteractions().Click(SubTacticTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(CreateSubTacticBtn);
                Pages.BasicInteractions().WaitTime(1);
                pressTabButton();
                pressTabButton();
                pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(SubTacticName, ConfigurationManager.AppSettings["SubTacticName"]);
                Pages.BasicInteractions().Type(SubTacticDescription, ConfigurationManager.AppSettings["SubTacticDescription"]);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(4);
                Pages.BasicInteractions().WaitVisible(CreateSubTacticBtn);
                Pages.BasicInteractions().Click(ToggleBtn);
                Pages.BasicInteractions().WaitTime(2);
                /*Subtactic Edit*/
                Pages.BasicInteractions().Click(SubTacticEdit);
                Pages.BasicInteractions().Type(SubTacticDescription, ConfigurationManager.AppSettings["SubTacticDescription"]);
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
