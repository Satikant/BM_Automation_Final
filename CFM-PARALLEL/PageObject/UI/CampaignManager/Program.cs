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
    class Program
    {
        public By ProgramTile { get { return (By.XPath("//a[text()='Programs']")); } }
        public By CreateProgramBtn { get { return (By.XPath("//span[text()='Create New Program']")); } }
        public By ProgramName { get { return (By.XPath("//input[@formcontrolname='programName']")); } }
        public By ProgramDescription { get { return (By.XPath("//textarea[@formcontrolname='programDescription']")); } }
        public By TenantDropdown { get { return (By.XPath("//span[text()='Tenant']")); } }
        public By ProgramTypeDropdown { get { return (By.XPath("//span[text()='ProgramType']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public By Dropdownlist { get { return (By.XPath("//div[@role='listbox']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By ProgramEdit { get { return (By.XPath("//tbody/tr[1]/td[5]/button/span[@class='mat-button-wrapper']")); } }
        public void ProgramExecution()
        {
            try
            {
                Program programs = new Program();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(ProgramTile);
                Pages.BasicInteractions().Click(ProgramTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(CreateProgramBtn);
                Pages.BasicInteractions().WaitTime(1);
                programs.pressTabButton();
                programs.pressTabButton();
                programs.pressTabButton();
                programs.pressTabButton();
                programs.pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(ProgramName, ConfigurationManager.AppSettings["ProgramName"]);
                Pages.BasicInteractions().Type(ProgramDescription, ConfigurationManager.AppSettings["ProgramDescription"]);
                Pages.BasicInteractions().Click(TenantDropdown);
                Pages.BasicInteractions().WaitTime(1);
                programs.Dropdownselection(Dropdownlist, ConfigurationManager.AppSettings["TenantName"]);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(ProgramTypeDropdown);
                Pages.BasicInteractions().WaitTime(1);
                programs.Dropdownselection(Dropdownlist, ConfigurationManager.AppSettings["ProgramType"]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(4);

                /*Program Edit*/
                Pages.BasicInteractions().Click(ProgramEdit);
                Pages.BasicInteractions().Type(ProgramName, ConfigurationManager.AppSettings["ProgramName"]);
                Pages.BasicInteractions().Type(ProgramDescription, ConfigurationManager.AppSettings["ProgramDescription"]);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(SaveBtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
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
