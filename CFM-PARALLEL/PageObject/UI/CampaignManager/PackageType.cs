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
    class PackageType
    {
        public By PackageTypeTile { get { return (By.XPath("//a[text()='Package Types']")); } }
        public By CreatePackageTypeBtn { get { return (By.XPath("//span[text()='Create New Package Type']")); } }
        public By packageTypeName{ get { return (By.XPath("//input[@formcontrolname='packageTypeName']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By PackageTypeLabel { get { return (By.XPath("//label[text()='Package Type Name']")); } }
        
        public void PackageTypeExecution()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(PackageTypeTile);
                Pages.BasicInteractions().Click(PackageTypeTile);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(CreatePackageTypeBtn);
                //Pages.BasicInteractions().Click(packageTypeName);
                pressTabButton();
                pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                //Pages.BasicInteractions().Click(PackageTypeLabel);
                Pages.BasicInteractions().Type(packageTypeName, ConfigurationManager.AppSettings["PackageTypeName"]);
                Pages.BasicInteractions().Click(PackageTypeLabel);
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
