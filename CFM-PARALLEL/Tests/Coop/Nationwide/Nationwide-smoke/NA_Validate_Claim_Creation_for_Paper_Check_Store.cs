using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.UI.Functions.Nationwide;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CFM_PARALLEL.Tests.Coop.Nationwide.Nationwide_smoke
{
    public class NA_Validate_Claim_Creation_for_Paper_Check_Store : Base
    {
        //Claim Creation
        [Test, Parallelizable]
        [Category("CFM_NATIONWIDE_SMOKE")]
        public void NA_Validate_Claim_Creation_for_PaperCheck_Store()
        {
            IWebDriver Driver = null;
            try
            {
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_NATIONWIDE("LME2");
                bl.Click_CFMLink();
                //NW_FundRequest nW_FR = new NW_FundRequest(Driver);
                NW_Payments nW_FR = new NW_Payments();
                Thread.Sleep(10000);

                nW_FR.Create_PaperCheckProfile1();

                CommonUtilities.Logout(Driver);
                Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }

        }

    }
}
