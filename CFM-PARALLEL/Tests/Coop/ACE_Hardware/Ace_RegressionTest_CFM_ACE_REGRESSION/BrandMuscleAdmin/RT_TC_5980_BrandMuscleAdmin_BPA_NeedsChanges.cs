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
    public class RT_TC_5980_BrandMuscleAdmin_BPA:Base
    {
        public string bpaID = string.Empty;

        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_BPA_NeedsChanges()
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
CommonUtilities.Logout(Driver);       Driver.Quit();


                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURL_ACE("CORPORATE1");
                PreApproval_PerformAction preApproval_PerformAction = new PreApproval_PerformAction();
                preApproval_PerformAction.ACE_PreApproval_PerformAction(bpaID, "Needs Change");
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
        public void RT_TC_BrandMuscleAdmin_BPA_Resubmitted()
        {
            IWebDriver Driver = null;

            //Base bs = new Base();
            Driver = OpenBrowser();
            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
            bl.BrowserURL_ACE("LME1");
            Preapproval_FullFlow preapproval_FullFlow = new Preapproval_FullFlow(Driver);
            bpaID = preapproval_FullFlow.ACE_Preapproval_Fullflow();
                            CommonUtilities.Logout(Driver);       Driver.Quit();;


            //Base bs2 = new Base();
            Driver=OpenBrowser();
            BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
            bl2.BrowserURL_ACE("CORPORATE1");
            PreApproval_PerformAction preApproval_PerformAction = new PreApproval_PerformAction();
            preApproval_PerformAction.ACE_PreApproval_PerformAction(bpaID, "Needs Change");
                            CommonUtilities.Logout(Driver);       Driver.Quit();;

            //Base bs3 = new Base();
            Driver=OpenBrowser();
            BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
            bl3.BrowserURL_ACE("LME1");
            Preapproval_FullFlow preapproval_FullFlow3 = new Preapproval_FullFlow(Driver);
            preapproval_FullFlow3.BPA_Resubmitted(bpaID);
                            CommonUtilities.Logout(Driver);       Driver.Quit();;
        }

        [Test]
        [Category("CFM_ACE_REGRESSION")]
        public void ST_TC_LME_BPA_Clone()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                bpaID = pf.ACE_Preapproval_Fullflow();
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                //Thread.Sleep(5000);

                //         //Base bcc = new Base();
                //         Driver=OpenBrowser();       
                //         BrowserURLLaunch bll = new BrowserURLLaunch(Driver);
                //bll.BrowserURLACE("LME1");
                Preapproval_Clone pc = new Preapproval_Clone(Driver);
                pc.ACE_Preapproval_Clone(bpaID);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test]
        [Category("CFM_ACE_REGRESSION")]
        public void ST_TC_LME_BPA_Creation_VerifyingOnMangoDB()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                bpaID = pf.ACE_Preapproval_Fullflow();
                pf.BrandingPreapproval_VerifyingonMangoDB(bpaID);

                Preapproval_Clone pc = new Preapproval_Clone(Driver);
                pc.ACE_Preapproval_Clone(bpaID);
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