using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.CampaignManager
{
    class Tactics
    {
        public By TacticTile { get { return (By.XPath("//a[text()='Tactics']")); } }
        public By CreateTacticBtn { get { return (By.XPath("//span[text()='Create New Tactic']")); } }
        public By TacticName { get { return (By.XPath("//input[@formcontrolname='tacticName']")); } }
        public By TacticDescription {  get { return (By.XPath("//textarea[@formcontrolname='tacticDescription']")); } }
        public By TacticTypeDropdown { get { return (By.XPath("//span[text()='Tactic Type']")); } }
        public By TacticMarketingTypeDropdown { get { return (By.XPath("//span[text()='Marketing Type']")); } }
        public By TacticToggle { get { return (By.XPath("//tbody/tr[1]/td[5]/mat-slide-toggle/label/div/div/div[@class='mat-slide-toggle-thumb']")); } }
        public By SaveBtn { get { return (By.XPath("//span[text()='Save Changes']")); } }
        public By Dropdownlist { get { return (By.XPath("//div[@role='listbox']")); } }
        public By TacticEdit { get { return (By.XPath("//tbody/tr[1]/td[5]/button/span[@class='mat-button-wrapper']")); } }
        public By Existvalidation { get { return (By.XPath("//span[contains(text(),'is required.')]")); } }
        public void TacticExecution()
        {
            try
            {
                Tactics tactics = new Tactics();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(TacticTile);
                Pages.BasicInteractions().Click(TacticTile);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().Click(CreateTacticBtn);
                Pages.BasicInteractions().WaitTime(1);
                tactics.pressTabButton();
                tactics.pressTabButton();
                tactics.pressTabButton();
                tactics.pressTabButton();
                tactics.pressTabButton();
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().IsElementVisible(Existvalidation);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(TacticName, ConfigurationManager.AppSettings["TacticName"]);
                Pages.BasicInteractions().Type(TacticDescription, ConfigurationManager.AppSettings["TacticDescription"]);
                Pages.BasicInteractions().Click(TacticTypeDropdown);
                Pages.BasicInteractions().WaitTime(2);
                tactics.Dropdownselection(Dropdownlist, ConfigurationManager.AppSettings["TacticTypeSelection"]);
                Pages.BasicInteractions().Click(TacticMarketingTypeDropdown);
                Pages.BasicInteractions().WaitTime(1);
                tactics.Dropdownselection(Dropdownlist, ConfigurationManager.AppSettings["TacticMarketingTypeSelection"]);
                Pages.BasicInteractions().Click(SaveBtn);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().WaitVisible(CreateTacticBtn);
                Pages.BasicInteractions().Click(TacticToggle);
                Pages.BasicInteractions().WaitTime(2);
                //Tactics tactic = new Tactics();
                // tactic.KeyAction("Di");
                //Pages.BasicInteractions().Type(Dropdownvalues, Keys.Enter);
                //IWebDriver Driver = null;
                //Pages.BasicInteractions().Type(TacticTypeDropdown, " AutoTacticType12 ");
                //Pages.BasicInteractions().SelectTextAndType(Dropdownvalues, "AutoTacticType1");
                //Pages.BasicInteractions().SelectByOptionName(Driver, "AutoTacticType");
                //IList<IWebElement> OptionList = TacticTypeDropdown
                /*Tactic Edit*/
                Pages.BasicInteractions().Click(TacticEdit);
                Pages.BasicInteractions().Type(TacticDescription, ConfigurationManager.AppSettings["TacticDescription"]);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(SaveBtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void SelectdropdownValues(IWebDriver webdriver, string text)
        {
            IList<IWebElement> all = webdriver.FindElements(By.XPath("//div[@role='listbox']"));

            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement ele in all)
            {
                allText[i++] = ele.Text;
                Console.WriteLine("Selecting all the values");
            }
            //return null;
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
        public void KeyAction()
        {
            Actions actions = new Actions(Base.Driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
            Console.WriteLine("Entered");
            Pages.BasicInteractions().WaitTime(2);
            //Driver.FindElement(by).SendKeys(text + Keys.Enter);
            //IWebElement element = (IWebElement)driver.FindElements(By.XPath("//div[@role='listbox']"));
            //Actions keyPress = new Actions(Driver);
            //keyPress.SendKeys(Keys.Escape);
            //  Pages.BasicInteractions().Type("Di", Keys.Enter);
        }
       /* public IList<string> GetAllOptionsCM(By by,string exptext)
        {
            IList<IWebElement> moptions = new SelectElement(Base.Driver.FindElement(by)).Options;
            List<string> v = new List<string>();
            for (int i = 0; i <= moptions.Count - 1; i++)
            {
                string alloptions = Pages.BasicInteractions().GetText();
                if (alloptions.Contains(exptext))
                {
                    Pages.BasicInteractions().Click(moptions);
                }
            }
            return v;
        }*/
    }
}
