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
    class PackageBeneficiary
    {
        public By PackageBeneficiaryTile { get { return (By.XPath("//a[text()='Package Beneficiaries']")); } }
        public By CreatePackageBeneficaryBtn { get { return (By.XPath("//span[text()='Create New Package Beneficiary']")); } }
        public By packageTypeName { get { return (By.XPath("//input[@formcontrolname='packageBeneficiaryType']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By PackagebenficiaryLabel { get { return (By.XPath("//label[text()='Package Beneficiary Type']")); } }

        public void PackageBeneficiaryExecution()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(PackageBeneficiaryTile);
                Pages.BasicInteractions().Click(PackageBeneficiaryTile);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(CreatePackageBeneficaryBtn);
                Pages.BasicInteractions().WaitTime(2);
                pressTabButton();
                pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(packageTypeName, ConfigurationManager.AppSettings["PackageTypeName"]);
                Pages.BasicInteractions().Click(PackagebenficiaryLabel);
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

