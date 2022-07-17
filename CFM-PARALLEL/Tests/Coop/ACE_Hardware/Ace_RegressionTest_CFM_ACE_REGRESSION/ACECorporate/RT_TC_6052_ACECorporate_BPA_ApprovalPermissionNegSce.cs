using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.ACECorporate
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]

    public class RT_TC_6052_ACECorporate_BPA:Base
    {
        public string bpaID = string.Empty;

        [Test,Parallelizable]
        public void RT_TC_LME_ApprovalPermissionNegSce()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Preapproval_FullFlow preapproval_FullFlow = new Preapproval_FullFlow(Driver);
                bpaID = preapproval_FullFlow.ACE_Preapproval_Fullflow();
                PreApproval_ApprovalPermission preApproval_ApprovalPermission = new PreApproval_ApprovalPermission();
                preApproval_ApprovalPermission.Ace_PreApproval_ApprovalPermission(bpaID);
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