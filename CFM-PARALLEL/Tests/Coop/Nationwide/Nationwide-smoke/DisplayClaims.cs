using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.PageObject.UI.Functions.Pandora;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace CFM_PARALLEL.Tests.Coop.Nationwide.Nationwide_smoke
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class DisplayClaims
    {
        public class Nationwide_Displayclaims : Base {
            public String BUSINESSUNIT = "Nationwide";
            [Test, Parallelizable]
            [Category("CFM_Nationwide_SMOKE")]
            public void ST_TC_NW_DisplayClaimCreation()
            {
                IWebDriver Driver = null;
                try
                {
                    //Base bs = new Base();
                    Driver = OpenBrowser();
                    //CommonFunctions cf = new CommonFunctions(Driver);
                    PN_Claim pc = new PN_Claim(Driver);
                    BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                    bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                    pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);
                    CommonUtilities.Logout(Driver);
                    CommonUtilities.Logout(Driver); Driver.Quit();
                }
                catch (Exception ex)
                {
                    //CommonUtilities.Logout(Driver);       Driver.Quit();;
                    Console.WriteLine("Error Message: " + ex.Message);
                    throw;
                }
                finally
                {
                    DriverCleanUp(Driver);
                }

            }

        }


    }
}
