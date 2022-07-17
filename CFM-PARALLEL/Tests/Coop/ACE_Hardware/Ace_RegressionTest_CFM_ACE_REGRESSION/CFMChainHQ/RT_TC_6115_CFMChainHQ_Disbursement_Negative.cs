﻿using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.Disbursement;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.CFMIndependent
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]

    public class RT_TC_6115_CFMChainHQ_Disbursement:Base
    {

        [Test]
        public void RT_TC_CFMChainHQ_Disbursement_Negative()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Disbursement_Negative disbursement_Negative = new Disbursement_Negative(Driver);
                disbursement_Negative.Disbursement_Negative_LeftNavValidation("CFMChainHQ");
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