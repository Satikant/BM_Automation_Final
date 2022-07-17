
using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Functions.Pandora;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;

using System;
using System.Threading;
//using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;


namespace CFM_PARALLEL.Tests.Pandora
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]

    public class Smoke_Pandora_QA : Base
    {
        public String BUSINESSUNIT = "Pandora";


        //Dashboard validating
        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_User_Dashboard()
        {
            try
            {
                      
            Console.WriteLine("Login in -------");
            BrowserURLLaunch b = new BrowserURLLaunch(Driver);
            b.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
            Console.WriteLine("Login with CORPORATE");
            Common_Dashboard_Landing d = new Common_Dashboard_Landing(Driver);
            d.Dashboard_Common(BUSINESSUNIT);
                Driver_CleanUp();
                Driver_SetUp();
            BrowserURLLaunch bc = new BrowserURLLaunch(Driver);
            bc.BrowserURLCLIENT("LME1", BUSINESSUNIT);
            Console.WriteLine("Login with LME");
            Common_Dashboard_Landing dc = new Common_Dashboard_Landing(Driver);
            dc.Dashboard_Common(BUSINESSUNIT);
                        
            }
            catch (Exception ex)
            {
              
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
           
        }


        //Claim Creation
        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_ClaimCreation()
        {
           
            try
            {
               
               
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
           
        }


        //Validating the Available Fund Reduction after Calim Creation
        [Test, NonParallelizable]
        [Category("CFM_PANDORA_SMOKE")]

        public void ST_TC_PN_ClaimCreation_CheckingFunds()
        {
            try
            {
               
                CommonFunctions cf = new CommonFunctions();

                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                PN_Dashboard pd = new PN_Dashboard();
                OBJ_Dashboard obj_dashboard = new OBJ_Dashboard();
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Claim pc = new PN_Claim();
                BasicInteractions bi = new BasicInteractions(Driver);
                //Get Available Funds Before Creating Claim
                string AvailableFundsBeforeClaimCreation = pt.GetAvailableFunds(Parameters.Pandora_ProgramName());

               
                bi.WaitVisible(obj_dashboard.BtnSubmit);
                bi.Click(obj_dashboard.BtnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.BtnSubmitClaim);
                bi.Click(obj_dashboard.BtnSubmitClaim);
                bi.WaitTillNotVisible(obj_dashboard.ImgLoading);

                //Select store and Program

                pc.SelectStoreAndProgram_Claim();

                //Entering Details
                double ReqAmountConverted = pc.EnterDetails_Claim(Parameters.ClaimTotalActivityCost_Pandora_Below5000);

                //Adding Attachment
                pc.AddingAttachment_Claim();
                //Verifying the Fund Deducted correctly

                //SubmitClaim
                string ClaimID = pc.SubmitClaim();
                Thread.Sleep(10000);

                //Navigating Back to DashBoard
                pd.NavigatingToDashBoard();
                string AvailableFindsAfterClaimCreation = pt.GetAvailableFunds(Parameters.Pandora_ProgramName());
                Assert.True(Convert.ToDouble(AvailableFindsAfterClaimCreation.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation.Replace("$", "")) - ReqAmountConverted));

                Console.WriteLine("Calim Requested Amount Deducted from Available Funds Correctly");




            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
          

        }

        //Claim Clone
        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_ClaimClone()
        {
           

            try
            {
               

                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);

                pc.ClaimClone(ClaimID);
               
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
           
        }


        //Claim Hold
        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_ClaimHold()
        {
          

            try
            {
               
                //Login with LME for Creating a Claim
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);

                Driver_CleanUp();
                Driver_SetUp();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pc1.ClaimPerformAction(ClaimID, "Hold");

            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            
        }


        //Claim Approval
        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_ClaimApprove()
        {
            try
            {
               
                //Login with LME for Creating a Claim
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);



                Driver_CleanUp();
                Driver_SetUp();
                CommonFunctions cf1 = new CommonFunctions();

                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pc1.ClaimPerformAction(ClaimID, "Approve");
              

                //Again Login with LME for checking the status of Claim
                Thread.Sleep(10000);
                Driver_CleanUp();
                Driver_SetUp();
                PN_Claim pc2 = new PN_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                //Search Claim By ClaimID And GetStatus
                string ClaimStatus = pc2.SearchClaimAndGetStatus(ClaimID);
                Assert.AreEqual(ClaimStatus, "Approved");
                Console.WriteLine("The satatus of the calim after approval is  " + ClaimStatus);
                

            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
          
        }


        //Claim need Change
        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_ClaimNeedChnage()
        {
            try
            {
               
                //Login with LME for Creating a Claim
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);
                Thread.Sleep(30000);

                //Login with Corporate User
                Driver_CleanUp();
                Driver_SetUp();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pc1.ClaimPerformAction(ClaimID, "Needs Change");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            
        }


        //Claim Approved
        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_ClaimDisApproved()
        {
           

            try
            {
                
                //Login with LME for Creating a Claim
                PN_Claim pc = new PN_Claim();
                
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);


                //Login with Corporate User
                Driver_CleanUp();
                Driver_SetUp();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pc1.ClaimPerformAction(ClaimID, "Deny");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            

        }


        [Test, NonParallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_Transaction_Accrual()
        {           
            try
            {
                
                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Accrual("FLAT", Parameters.Pandora_AccrualPositive_Amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
           
        }


        [Test, NonParallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_Transaction_FundTransfer()
        {

            try
            {              

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_FundTransfer("FLAT", Parameters.Pandora_TransferPositive_Amount);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            
        }


        [Test, NonParallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PN_Transaction_Adjustment()
        {
            try
            {
                
                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Adjustment("FLAT", Parameters.Pandora_AccrualPositive_Amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            
        }

        [Test, NonParallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PNcheck_OpenClaimValidation_Fundsnapshot()
        {

            try
            {                
                BrowserURLLaunch browserLaunchObj = new BrowserURLLaunch(Driver);

                //Login with Corporate for checking an Open_Claim 
                browserLaunchObj.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_Dashboard pN_Dashboardobj = new PN_Dashboard();
                pN_Dashboardobj.SelectProgramName_Fundsnapshot("QAAutomationAug");
                pN_Dashboardobj.ValidateOpenClaimsFilter_Fundsnapshot();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            

        }

        [Test, NonParallelizable]
        [Category("CFM_PANDORA_SMOKE")]
        public void ST_TC_PNcheck_ProcessedClaimValidation_Fundsnapshot()
        {

            try
            {                
                BrowserURLLaunch browserLaunchObj1 = new BrowserURLLaunch(Driver);

                //Login with Corporate for checking an Open_Claim 
                browserLaunchObj1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_Dashboard pN_Dashboardobj1 = new PN_Dashboard();
                pN_Dashboardobj1.SelectProgramName_Fundsnapshot("QAAutomationAug");
                pN_Dashboardobj1.ValidateProcessedClaimsFilter_Fundsnapshot();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
           
        }

       

        }
    }