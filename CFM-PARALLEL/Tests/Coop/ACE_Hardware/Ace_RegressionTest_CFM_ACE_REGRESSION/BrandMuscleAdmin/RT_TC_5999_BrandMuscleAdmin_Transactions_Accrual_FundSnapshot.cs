﻿using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using CFMAutomation.PageObject.UI.Ace.Transactions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]
    public class RT_TC_5999_Transactions:Base
    {
        [Test, NonParallelizable]
        public void RT_TC_BrandMuscleAdmin_Transactions_VerifyingAccrualEntryInFundSnapShot() {
            IWebDriver Driver = null;
            try
            {
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Transaction_Accrual transaction_Accrual = new Transaction_Accrual();
                transaction_Accrual.Transaction_AllocateAccruals("Flat", Parameters.Ace_AccrualPositive_Amount);

                //Checking the Accrual Entry Under Detailed Report
                transaction_Accrual.VerifyingAccrualEntryUnderDetailedReport("Flat");
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