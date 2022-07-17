using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    //[Category("CFM_ACE_REGRESSION")]
    public class RT_TC_7523_BrandMuscleAdmin_BPA:Base
    {
        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]

        public void RT_TC_BrandMuscleAdmin_BPA_Hold()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Preapproval_FullFlow preapproval_FullFlow = new Preapproval_FullFlow(Driver);
                preapproval_FullFlow.ACE_Preapproval_Fullflow();
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURL_ACE("CORPORATE1");
                PreApproval_PerformAction preApproval_PerformAction = new PreApproval_PerformAction();
                preApproval_PerformAction.ACE_PreApproval_PerformAction(preapproval_FullFlow.BPA_ID, "Hold");
CommonUtilities.Logout(Driver);       Driver.Quit();
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