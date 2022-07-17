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
    public class RT_TC_6039_BrandMuscleAdmin_BPA:Base
    {
        public string bpaID = string.Empty;

        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]

        public void RT_TC_BrandMuscleAdmin_BPA_VerifyingonMangoDB()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("CORPORATE1");
                Preapproval_FullFlow preapproval_FullFlow = new Preapproval_FullFlow(Driver);
                //String bpaID = "BPA-2054";
                bpaID = preapproval_FullFlow.ACE_Preapproval_Fullflow();
                preapproval_FullFlow.BrandingPreapproval_VerifyingonMangoDB(bpaID);
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