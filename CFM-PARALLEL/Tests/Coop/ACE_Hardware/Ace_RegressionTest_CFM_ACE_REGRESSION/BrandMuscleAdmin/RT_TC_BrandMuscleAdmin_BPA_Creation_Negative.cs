using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.BrandingPreapproval;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    //[Category("CFM_ACE_REGRESSION")]
    public class RT_TC_BrandMuscleAdmin_BPA:Base
    {
        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_BPA_Creation_Negative()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("CORPORATE1");
                PreApproval_Negative preApproval_Negative = new PreApproval_Negative(Driver);
                preApproval_Negative.Ace_PreApproval_Negative();
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