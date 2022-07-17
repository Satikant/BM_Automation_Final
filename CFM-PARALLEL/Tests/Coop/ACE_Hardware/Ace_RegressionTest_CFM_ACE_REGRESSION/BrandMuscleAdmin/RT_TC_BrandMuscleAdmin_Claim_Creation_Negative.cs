using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.Claim;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RT_TC_BrandMuscleAdmin_Claim :Base
    {
        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_Claim_Creation_Negative()
        {
            IWebDriver Driver = null;
            try
            {
                //Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Claim_Negative claim_Negative = new Claim_Negative(Driver);
                claim_Negative.Ace_Claim_Negative();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_ClaimCountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("LME1");
                Dashboard_Landing pd = new Dashboard_Landing();
                pd.ValidateClaimCountMatchingWithAdditionOfOpenAndProcessedClaims();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_OpenClaimsFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("LME1");
                Dashboard_Landing pd = new Dashboard_Landing();

                pd.ValidateOpenClaimsFilterDashBoard();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_ProcessedClaimsFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("LME1");
                Dashboard_Landing pd = new Dashboard_Landing();

                pd.ValidateProcessedClaimsFilterDashBoard();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }



        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_BPACountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("LME1");
                Dashboard_Landing pd = new Dashboard_Landing();
                pd.ValidateBPACountMatchingWithAdditionOfOpenAndProcessedClaims();
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

        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_OpenBPAFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("LME1");
                Dashboard_Landing pd = new Dashboard_Landing();

                pd.ValidateOpenBPAFilterDashBoard();
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

        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_ProcessedBPAFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("LME1");
                Dashboard_Landing pd = new Dashboard_Landing();

                pd.ValidateProcessedBPAFilterDashBoard();
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