using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using System.IO;
using CFM_PARALLEL.Enum;
using System;
using OpenQA.Selenium;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    //[Category("CFM_ACE_REGRESSION")]
    public class RT_TC_6005_BrandMuscleAdmin_Claim:Base
    {
        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]

        public void RT_TC_BrandMuscleAdmin_ClaimDateValidation()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("CORPORATE1");
                Claim_Validations claim_Validation = new Claim_Validations(Driver);
                claim_Validation.ClaimDateValidation();
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