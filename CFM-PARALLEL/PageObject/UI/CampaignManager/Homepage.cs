using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.CampaignManager
{
    public class Homepage
    {
        IWebDriver Driver;
        public By Username { get { return (By.Id("MainContent_LoginCentiv_UserName")); } }
        public By PWD { get { return (By.Id("MainContent_LoginCentiv_Password")); } }
        public By LoginBtn { get { return (By.XPath("//input[@type='submit']")); } }
        public By BUSelectionDropdown { get { return (By.Name("ctl00$MainContent$ddlBusinessUnit")); } }
        public By CMDropDown { get { return (By.XPath("//span[text()='Campaign Manager']")); } }
        public By CampaignManager { get { return (By.XPath("//a[@class='rmLink rmRootLink clickable CampaignManager']")); } }
        public By ClickOnTile { get { return (By.XPath("//a[text()='Products']")); }}
        
        public void CMPageredirection()
        {
            
            //BasicInteractions BI = new BasicInteractions();
            try
            {
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(CampaignManager);
                Pages.BasicInteractions().Click(CampaignManager);
                Pages.BasicInteractions().WaitTime(4);
                Pages.BasicInteractions().WaitForPageToLoad();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
       
        public void Windowhandles()
        {
            Pages.BasicInteractions().WaitTime(1);
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Pages.BasicInteractions().WaitTime(2);
            //Driver.Close();
            //Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }

    }
}
