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
    class Product
    {
        public By ProductTile { get { return (By.XPath("//a[text()='Products']")); } }
        public By NewProductBtn { get { return (By.XPath("//span[text()='Create New Product']")); } }
        public By ProductName { get { return (By.XPath("//input[@formcontrolname='productName']")); } }
        public By TenantDropdown { get { return (By.XPath("//span[text()='Tenant']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By ProductEdit { get { return (By.XPath("//tbody/tr[1]/td[3]/button/span[@class='mat-button-wrapper']")); } }
        public By Dropdownlist { get { return (By.XPath("//div[@role='listbox']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public By ProductLabel { get { return (By.XPath(" //span[text()='Modify']")); } }

       
        public void ProductExecution()
        {
            try
            {
                Product products = new Product();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(ProductTile);
                Pages.BasicInteractions().Click(ProductTile);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(NewProductBtn);
                Pages.BasicInteractions().WaitTime(1);
                products.pressTabButton();
                products.pressTabButton();
                products.pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(ProductName, ConfigurationManager.AppSettings["ProductName"]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(TenantDropdown);
                Pages.BasicInteractions().WaitTime(2);
                products.Dropdownselection(Dropdownlist, ConfigurationManager.AppSettings["Dropdownlist"]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(1);
                /*Product Edit*/
                Pages.BasicInteractions().Click(ProductEdit);
                Pages.BasicInteractions().Type(ProductName, ConfigurationManager.AppSettings["ProductName"]);
                Pages.BasicInteractions().Click(ProductLabel);
                Pages.BasicInteractions().WaitTime(1);
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
