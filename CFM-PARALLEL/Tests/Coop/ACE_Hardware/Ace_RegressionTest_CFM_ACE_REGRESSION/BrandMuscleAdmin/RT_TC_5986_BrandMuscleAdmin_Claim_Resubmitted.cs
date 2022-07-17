﻿using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    //[Category("CFM_ACE_REGRESSION")]
    public class RT_TC_5986_BrandMuscleAdmin_Claim:Base
    {
        public string claimID = string.Empty;

        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]

        public void RT_TC_BrandMuscleAdmin_Claim_Resubmitted()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("LME1");
                Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
                claimID = claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty);
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction claim_PerformAction = new Claim_PerformAction();
                claim_PerformAction.ACE_Claim_PerformAction(claimID, "Needs Change");
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Base bs3 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURL_ACE("LME1");
                Claim_Resubmitted claim_Resubmitted = new Claim_Resubmitted(Driver);
                string ResubmittedClaimID = claim_Resubmitted.Ace_Claim_Resubmitted(claimID);
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