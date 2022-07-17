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
    class ProgramType
    {
        public By ProgTypesTile { get { return (By.XPath("//a[text()='Program Types']")); } }
        public By NewProgTypeBtn { get { return (By.XPath("//span[text()='Create New Program Type']")); } }
        public By ProgramTypeName { get { return (By.XPath("//input[@formcontrolname='programTypeName']")); } }
        public By TenantDropdown { get { return (By.XPath("//span[text()='Tenant']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By ProgTypeEdit { get { return (By.XPath("//tbody/tr[1]/td[3]/button/span[@class='mat-button-wrapper']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public By Dropdownlist { get { return (By.XPath("//div[@role='listbox']")); } }
        public By ProgramLabel { get { return (By.XPath(" //span[text()='Modify']")); } }
        public void ProgTypeExecution()
        {
            try
            {
                ProgramType programtype = new ProgramType();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(ProgTypesTile);
                Pages.BasicInteractions().Click(ProgTypesTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(NewProgTypeBtn);
                Pages.BasicInteractions().WaitTime(1);
                programtype.pressTabButton();
                programtype.pressTabButton();
                programtype.pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(ProgramTypeName, ConfigurationManager.AppSettings["ProgramTypeName"]);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(TenantDropdown);
                programtype.Dropdownselection(Dropdownlist, ConfigurationManager.AppSettings["TenantProgramType"]);
                Pages.BasicInteractions().Click(SaveBtn);
                /*ProgramType Edit*/
                Pages.BasicInteractions().Click(ProgTypeEdit);
                Pages.BasicInteractions().Type(ProgramTypeName, ConfigurationManager.AppSettings["ProgramTypeName"]);
                Pages.BasicInteractions().Click(ProgramLabel);
                Pages.BasicInteractions().WaitTime(1);
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
