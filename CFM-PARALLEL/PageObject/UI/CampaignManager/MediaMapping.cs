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
    class MediaMappings
    {
        public By MediamappingTile { get { return (By.XPath("//a[text()='Media Mappings']")); } }
        public By CreateMediamappingBtn { get { return (By.XPath("//span[text()='Create New Media Mapping']")); } }
        public By PlatformSelection { get { return (By.XPath("//span[text()='Platform']")); } }
        public By SubPlatformSelection { get { return (By.XPath("//span[text()='Sub Platform']")); } }
        public By TacticSelection { get { return (By.XPath("//span[text()='Tactic']")); } }
        public By SubtacticSelection { get { return (By.XPath("//span[text()='Sub Tactic']")); } }
        public By Dropdownlist { get { return (By.XPath("//div[@role='listbox']")); } }
        public By MediaMappingName { get { return (By.XPath("//input[@formcontrolname='mediaMappingName']")); } }
        public By PilotOutcome { get { return (By.XPath("//textarea[@formcontrolname='pilotOutCome']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By PlatformLabel { get { return (By.XPath("//label[text()='Platform']")); } }
        public By SubplatformLabel { get { return (By.XPath("//label[text()='Sub Platform']")); } }
        public By TacticLabel { get { return (By.XPath("//label[text()='Tactic']")); } }
        public By SubTacticLabel { get { return (By.XPath("//label[text()='Sub Tactic']")); } }
        public By MediamappingText { get { return (By.XPath("//span[text()='Add Media Mapping']")); } }
        
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public By CheckBox { get { return (By.XPath("//tbody/tr[1]/td[7]/mat-checkbox/label/span[1]")); } }
        public void MediaMappingExecution()
        {
            try
            {
                MediaMappings mediamapping = new MediaMappings();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(MediamappingTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(MediamappingTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(CreateMediamappingBtn);
                Pages.BasicInteractions().WaitTime(1);
                mediamapping.pressTabButton();
                mediamapping.pressTabButton();
                mediamapping.pressTabButton();
                mediamapping.pressTabButton();
                mediamapping.pressTabButton();
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(PlatformSelection);
                Pages.BasicInteractions().WaitTime(2);
                mediamapping.Dropdownselection(Dropdownlist, ConfigurationManager.AppSettings["Platformselection"]);

                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(SubPlatformSelection);
                Pages.BasicInteractions().WaitTime(2);
                mediamapping.Dropdownselection(Dropdownlist,ConfigurationManager.AppSettings["SubPlatformselection"]);
                
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(TacticSelection);
                Pages.BasicInteractions().WaitTime(2);
                mediamapping.Dropdownselection(Dropdownlist,ConfigurationManager.AppSettings["Tacticselection"]);

                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(SubtacticSelection);
                Pages.BasicInteractions().WaitTime(3);
                mediamapping.Dropdownselection(Dropdownlist,ConfigurationManager.AppSettings["SubTacticselection"]);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Type(MediaMappingName, ConfigurationManager.AppSettings["MediaMappingName"]);
                Pages.BasicInteractions().Type(PilotOutcome,ConfigurationManager.AppSettings["PilotOutcome"]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(4);
                Pages.BasicInteractions().WaitVisible(CreateMediamappingBtn);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(CheckBox);
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
        public void Dropdownselection(By element,String text)
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

