using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions.Bobcat
{
    class BC_Transactions
    {
        private IWebDriver Driver;
        private Base bs;
        private BrowserURLLaunch bl;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private BasicInteractions bi;
        private OBJ_Transactions obj_transaction;
        private BC_Claim bc;

        //Constructor
        public BC_Transactions(IWebDriver Driver)
        {
            this.Driver = Driver;
            bs = new Base();
            bl = new BrowserURLLaunch(Driver);
            obj_dashboard = new OBJ_Dashboard();
            bi = new BasicInteractions(Driver);
            obj_claims = new OBJ_Claims();
            obj_transaction = new OBJ_Transactions();
            bc = new BC_Claim(Driver);
        }


        //Get Available Funds for Program
        public String GetAvailableFunds(string ProgramName)
        {
            // BasicInteractions bi=new BasicInteractions(Driver)

            try
            {
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(10);
                if (bi.IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_transaction.OtherProgramsLink);
                    bi.Click(obj_transaction.OtherProgramsLink);
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));
                }
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(10);
                string AvailableFund = bi.GetText(obj_transaction.AvailableFunds);

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                return AvailableFund;
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        //Get Available, Open, Paid Etc.,

        public IDictionary<string, Double> GetAllTheFunds(String ProgramName)
        {
            IDictionary<string, double> Funds = new Dictionary<string, double>();
            try
            {
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(10);
                if (bi.IsElementDisplayed(obj_transaction.ProgramList(Parameters.Bobcat_ProgramName())))
                {
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(Parameters.Bobcat_ProgramName()));

                }
                else
                {
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_transaction.OtherProgramsLink);
                    bi.Click(obj_transaction.OtherProgramsLink);
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(Parameters.Bobcat_ProgramName()));
                }
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(10);
                string AvailableFund = bi.GetText(obj_transaction.AvailableFunds);

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                Funds.Add("AvailableFunds", Convert.ToDouble(AvailableFund));

                //Clicking on View Detailed Report
                bi.WaitVisible(obj_dashboard.lnkViewDetailedReport);
                bi.Click(obj_dashboard.lnkViewDetailedReport);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(5);
                bi.WaitVisible(obj_dashboard.btnMoreDetails);
                bi.Click(obj_dashboard.btnMoreDetails);

                //Get All the funds and add to Dictionary
                string TotalCredited = bi.GetText(obj_dashboard.TotalCredited);

                if (TotalCredited.Contains("(") | TotalCredited.Contains(")"))
                {
                    TotalCredited = "-" + TotalCredited.Replace("(", "").Replace(")", "");
                }
                Funds.Add("TotalCredited", Convert.ToDouble(TotalCredited));


                //Open Claims
                string OpenClaims = bi.GetText(obj_dashboard.OpenCliams);

                if (OpenClaims.Contains("(") | OpenClaims.Contains(")"))
                {
                    OpenClaims = "-" + OpenClaims.Replace("(", "").Replace(")", "");
                }
                Funds.Add("OpenClaims", Convert.ToDouble(OpenClaims));

                //Approved Claims
                string ApprovedClaims = bi.GetText(obj_dashboard.ApprovedClaims);

                if (ApprovedClaims.Contains("(") | ApprovedClaims.Contains(")"))
                {
                    ApprovedClaims = "-" + ApprovedClaims.Replace("(", "").Replace(")", "");
                }
                Funds.Add("ApprovedClaims", Convert.ToDouble(ApprovedClaims));

                //Paid Claims
                string PaidCliams = bi.GetText(obj_dashboard.PaidClaims);

                if (PaidCliams.Contains("(") | PaidCliams.Contains(")"))
                {
                    PaidCliams = "-" + PaidCliams.Replace("(", "").Replace(")", "");
                }
                Funds.Add("PaidCliams", Convert.ToDouble(PaidCliams));

                return Funds;
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        //Accrual Transaction
        public void Transaction_Accrual(string accrualType, String amount)
        {
            try
            {
                string ProgramName = string.Empty;
                if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName();
                }
                else if (accrualType.ToUpper().Equals("Rolling".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName_Rolling;
                }
                //Get the Availble Funds
                String AvailableFundBeforeAccrual = GetAvailableFunds(ProgramName);

                bi.WaitTime(10);
                bi.WaitVisible(obj_transaction.LeftNavTransaction);
                bi.Click(obj_transaction.LeftNavTransaction);
                bi.WaitVisible(obj_transaction.TranAccrual);
                bi.Click(obj_transaction.TranAccrual);

                bi.WaitTime(10);
                bi.WaitVisible(obj_transaction.ProgramNameDropdown);
                bi.Click(obj_transaction.ProgramNameDropdown);
                bi.WaitVisible(obj_transaction.ProgramNameText);
                bi.Clear(obj_transaction.ProgramNameText);
               // if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                //{
                    bi.Type(obj_transaction.ProgramNameText, ProgramName);
                    bi.WaitVisible(obj_transaction.ProgramNameTextOption(ProgramName));
                    bi.Click(obj_transaction.ProgramNameTextOption(ProgramName));
                //}
                
                //bi.GetAllOptions()
                
                bi.WaitTime(10);
                bi.WaitTillNotVisible(obj_transaction.imgLoading);
                bi.WaitUntilElementClickable(obj_transaction.LMEDropdown,60);
                bi.Click(obj_transaction.LMEDropdown);
                bi.WaitVisible(obj_transaction.LMEText);
                bi.Clear(obj_transaction.LMEText);
                bi.Type(obj_transaction.LMEText, Parameters.Bobcat_Test_LME());
                bi.WaitVisible(obj_transaction.LMETextOption);
                bi.Click(obj_transaction.LMETextOption);
                bi.WaitTime(10);

                bi.WaitVisible(obj_transaction.PeriodDropdown);
                bi.Click(obj_transaction.PeriodDropdown);
                bi.WaitVisible(obj_transaction.PeriodText);
                bi.Clear(obj_transaction.PeriodText);
                bi.WaitVisible(obj_transaction.PeriodTextOption);
                bi.Click(obj_transaction.PeriodTextOption);
                bi.WaitTime(10);

                bi.WaitVisible(obj_transaction.AccrualAmount);
                bi.Type(obj_transaction.AccrualAmount, amount);

                bi.WaitVisible(obj_transaction.AccrualComments);
                bi.Type(obj_transaction.AccrualComments, "Accrual");

                bi.WaitVisible(obj_transaction.ButtonPreview);
                bi.Click(obj_transaction.ButtonPreview);


                bi.WaitVisible(obj_transaction.SubmitButton);
                bi.Click(obj_transaction.SubmitButton);
                Console.WriteLine("$" + amount + " ACCRUED for Program: " + ProgramName + " & Store: " + Parameters.Bobcat_Test_LME());
                bi.WaitTime(10);
                bi.WaitVisible(obj_transaction.BackToTansactions);
                bi.Click(obj_transaction.BackToTansactions);

                bi.WaitTime(5);
    
                bi.WaitVisible(obj_transaction.Dashboard);
                bi.Click(obj_transaction.Dashboard);
                bi.WaitTime(10);
                String AvailableFundAfterAccrual = GetAvailableFunds(ProgramName);

                Assert.True(Convert.ToDouble(AvailableFundAfterAccrual.Replace("$", "")) == (Convert.ToDouble(AvailableFundBeforeAccrual.Replace("$", "")) + Convert.ToDouble(amount.Replace("$", ""))));
                Console.WriteLine("Accrual Amount Added to Available Funds Correctly");
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }



        //Transaction Adjustment
        public void Transaction_Adjustment(string accrualType, String amount)
        {
            try
            {
                string ProgramName = string.Empty;
                if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName();
                }
                else if (accrualType.ToUpper().Equals("Rolling".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName_Rolling;
                }
                String AvailableFundBeforeTransfer = GetAvailableFunds(ProgramName);

                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.LeftNavTransaction);
                bi.Click(obj_transaction.LeftNavTransaction);
                bi.WaitVisible(obj_transaction.TranAdjustment);
                bi.Click(obj_transaction.TranAdjustment);

                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.ProgramNameDropdown);
                bi.Click(obj_transaction.ProgramNameDropdown);
                bi.WaitVisible(obj_transaction.ProgramNameText);
                bi.Clear(obj_transaction.ProgramNameText);
                //if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                //{
                    bi.Type(obj_transaction.ProgramNameText, ProgramName);
                    bi.WaitVisible(obj_transaction.ProgramNameTextOption(ProgramName));
                    bi.Click(obj_transaction.ProgramNameTextOption(ProgramName));
                //}
                //else if (accrualType.ToUpper().Equals("Rolling".ToUpper()))
                //{
                //    bi.Type(obj_transaction.ProgramNameText, Parameters.Bobcat_ProgramName_Rolling);
                //    bi.WaitVisible(obj_transaction.ProgramNameTextOption(Parameters.Bobcat_ProgramName_Rolling));
                //    bi.Click(obj_transaction.ProgramNameTextOption(Parameters.Bobcat_ProgramName_Rolling));
                //}
                
                bi.WaitTime(10);

                bi.WaitUntilElementClickable(obj_transaction.LMEDropdown,60);
                bi.Click(obj_transaction.LMEDropdown);
                bi.WaitVisible(obj_transaction.LMEText);
                bi.Clear(obj_transaction.LMEText);
                bi.Type(obj_transaction.LMEText, (Parameters.Bobcat_Test_LME()));
                bi.WaitVisible(obj_transaction.LMETextOption);
                bi.Click(obj_transaction.LMETextOption);
                bi.WaitTime(5);

                bi.WaitVisible(obj_transaction.PeriodDropdown);
                bi.Click(obj_transaction.PeriodDropdown);
                bi.WaitVisible(obj_transaction.PeriodText);
                bi.Clear(obj_transaction.PeriodText);
                bi.WaitVisible(obj_transaction.PeriodTextOption);
                bi.Click(obj_transaction.PeriodTextOption);
                bi.WaitTime(5);

                bi.WaitVisible(obj_transaction.AdjustAmount);
                bi.Type(obj_transaction.AdjustAmount, amount);

                bi.WaitVisible(obj_transaction.AccrualComments);
                bi.Type(obj_transaction.AccrualComments, "Adjustment");

                bi.WaitVisible(obj_transaction.ButtonPreview);
                bi.Click(obj_transaction.ButtonPreview);
                bi.WaitTime(5);

                bi.WaitVisible(obj_transaction.SubmitButton);
                bi.Click(obj_transaction.SubmitButton);
                Console.WriteLine(amount + " ADJUSTMENT for Program: " + ProgramName + " & Store: " + Parameters.Bobcat_Test_LME());

                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.BackToTansactions);
                bi.Click(obj_transaction.BackToTansactions);

                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.Dashboard);
                bi.Click(obj_transaction.Dashboard);

                String AvailableFundAftertransfer = GetAvailableFunds(ProgramName);

                Assert.True(Convert.ToDouble(AvailableFundAftertransfer.Replace("$", "")) == (Convert.ToDouble(AvailableFundBeforeTransfer.Replace("$", "")) + Convert.ToDouble(amount.Replace("$", ""))));
                Console.WriteLine("Adjustment Amount Added to Available Funds Correctly");
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        //Transaction FundTransfer
        public void Transaction_FundTransfer(string accrualType, String amount)
        {
            try
            {
                string ProgramName = string.Empty;
                if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName();
                }
                else if (accrualType.ToUpper().Equals("Rolling".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName_Rolling;
                }
                //Get the Availble Funds
                String AvailableFundBeforeTransfer = GetAvailableFunds(ProgramName);

                bi.WaitTime(10);
                bi.WaitVisible(obj_transaction.LeftNavTransaction);
                bi.Click(obj_transaction.LeftNavTransaction);
                bi.WaitVisible(obj_transaction.TranTransfer);
                bi.Click(obj_transaction.TranTransfer);

                bi.WaitTime(10);

                //Transfering Fund from Source to Some Destination program
                bi.WaitVisible(obj_transaction.SourceProgramNameDropdown);
                bi.Click(obj_transaction.SourceProgramNameDropdown);
                bi.WaitVisible(obj_transaction.SourceProgramNameText);
                bi.Clear(obj_transaction.SourceProgramNameText);
                bi.Type(obj_transaction.SourceProgramNameText, ProgramName);
                bi.WaitVisible(obj_transaction.SourceProgramNameTextOption(ProgramName));
                bi.Click(obj_transaction.SourceProgramNameTextOption(ProgramName));
                bi.WaitTime(5);

                bi.WaitTillNotVisible(obj_transaction.sourceLMEDropdownDisbaled,60);
                bi.Click(obj_transaction.SourceLMEDropdown);
                bi.WaitVisible(obj_transaction.SourceLMEText);
                bi.Clear(obj_transaction.SourceLMEText);
                bi.Type(obj_transaction.SourceLMEText, Parameters.Bobcat_Test_LME());
                bi.WaitVisible(obj_transaction.SourceLMETextOption);
                bi.Click(obj_transaction.SourceLMETextOption);
                bi.WaitTime(5);

                bi.WaitVisible(obj_transaction.DestinationProgramNameDropdown);
                bi.Click(obj_transaction.DestinationProgramNameDropdown);

                bi.WaitVisible(obj_transaction.DestinationProgramNameText);
                bi.Clear(obj_transaction.DestinationProgramNameText);
                bi.Type(obj_transaction.DestinationProgramNameText, Keys.ArrowDown);
                bi.Type(obj_transaction.DestinationProgramNameText, Keys.Enter);

                //bi.Type(DestinationProgramNameText,Parameters.Ace_ProgramName());
                //bi.WaitVisible(DestinationLMETextOption);
                //bi.Click(DestinationLMETextOption);
                bi.WaitTime(5);

                bi.WaitTillNotVisible(obj_transaction.DestinationLMEDropdownDisabled,60);
                bi.Click(obj_transaction.DestinationLMEDropdown);
                bi.WaitVisible(obj_transaction.DestinationLMEText);
                bi.Clear(obj_transaction.DestinationLMEText);
                bi.Type(obj_transaction.DestinationLMEText, Keys.ArrowDown);
                bi.Type(obj_transaction.DestinationLMEText, Keys.Enter);
                //bi.Type(DestinationLMEText,Parameters.Ace_Test_LME_00080);
                //bi.WaitVisible(DestinationLMETextOption);
                //bi.Click(DestinationLMETextOption);
                bi.WaitTime(5);

                bi.WaitVisible(obj_transaction.PeriodDropdown);
                bi.Click(obj_transaction.PeriodDropdown);
                bi.WaitVisible(obj_transaction.PeriodText);
                bi.Clear(obj_transaction.PeriodText);
                bi.WaitVisible(obj_transaction.PeriodTextOption);
                bi.Click(obj_transaction.PeriodTextOption);
                bi.WaitTime(10);

                bi.WaitVisible(obj_transaction.TransferAmount);
                bi.Type(obj_transaction.TransferAmount, (amount));

                bi.WaitVisible(obj_transaction.AccrualComments);
                bi.Type(obj_transaction.AccrualComments, ("Transfer"));

                bi.WaitVisible(obj_transaction.ButtonPreview);
                bi.Click(obj_transaction.ButtonPreview);
                bi.WaitTime(5);

                bi.WaitVisible(obj_transaction.SubmitButton);
                bi.Click(obj_transaction.SubmitButton);
                //bi.WaitTime(10);
                Console.WriteLine(amount + " TRANSFERED for Program: " + ProgramName + " from Store: " + Parameters.Bobcat_Test_LME()
                    + " to Store: " + Parameters.Bobcat_Test_LME());
                bi.WaitTime(10);
                bi.WaitVisible(obj_transaction.BackToTansactions);
                bi.Click(obj_transaction.BackToTansactions);
                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.Dashboard);
                bi.Click(obj_transaction.Dashboard);

                String AvailableFundAftertransfer = GetAvailableFunds(ProgramName);

                Assert.True(Convert.ToDouble(AvailableFundAftertransfer.Replace("$", "")) == (Convert.ToDouble(AvailableFundBeforeTransfer.Replace("$", "")) - Convert.ToDouble(amount.Replace("$", ""))));
                Console.WriteLine("Transfer Amount Removed From Available Funds Correctly");
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }

        }


        //Validating Fund Reduction After Claim Creation
        public void ValidateFundReductionAfterClaimCreation()
        {
            try
            {
                //Get Available Funds Before Creating Claim
                string AvailableFundsBeforeClaimCreation = GetAvailableFunds(Parameters.Pandora_ProgramName());

                //Creating Claim
                bc.ClaimCreation();

                //Navigating Back to DashBoard
                bi.WaitVisible(obj_transaction.Dashboard);
                bi.Click(obj_transaction.Dashboard);
                bi.WaitTillNotVisible(obj_transaction.imgLoading);

                string AvailableFindsAfterClaimCreation = GetAvailableFunds(Parameters.Pandora_ProgramName());
                Assert.True(Convert.ToDouble(AvailableFindsAfterClaimCreation.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation.Replace("$", "")) - Convert.ToDouble(Parameters.ClaimRequestedAmount_Pandora.Replace("$", ""))));
                Console.WriteLine("Calim Amount Deducted from Available Funds Correctly");
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //verifying Accrual Entry under Detailed Report
        public void VerifyingAccrualEntryUnderDetailedReport(string accrualType = "Flat")
        {
            //BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Transaction_Accrual));
            try
            {
                string ProgramName = null;
                if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName();
                    //bi.Type(ProgramNameText, Parameters.Ace_ProgramName());
                }
                else
                {
                    ProgramName = Parameters.Bobcat_ProgramName_Rolling;
                    //bi.Type(ProgramNameText, Parameters.Ace_ProgramName_Rolling);
                }

                bi.WaitTillNotVisible(obj_transaction.imgLoading);
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(5);
                if (bi.IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_transaction.OtherProgramsLink);
                    bi.Click(obj_transaction.OtherProgramsLink);
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));
                }
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.ViewDetailedReport);
                bi.ClickJavaScript(obj_transaction.ViewDetailedReport);
                bi.WaitTillNotVisible(obj_transaction.imgLoading);

                bi.WaitVisible(obj_transaction.ApprovedTab);
                if (bi.IsElementEnabled(obj_transaction.LMEdropdownDetailedReport))
                {
                    bi.Click(obj_transaction.LMEdropdownDetailedReport);
                    bi.WaitTime(5);
                    bi.TypeClear(obj_transaction.LMESearchTxtDetailedReport, Parameters.Bobcat_Test_LME());
                    bi.Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Down);
                    bi.Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Enter);
                }
                bi.WaitVisible(obj_transaction.SubmittedStartdate);
                bi.Click(obj_transaction.SubmittedStartdate);
                bi.WaitTime(2);
                DateSelection dsTran = new DateSelection(Driver);
                bi.ClickJavaScript(obj_transaction.currentdate);

                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.SubmittedEndDate);
                bi.Click(obj_transaction.SubmittedEndDate);
                bi.WaitTime(2);
                DateSelection dsExp = new DateSelection(Driver);
                bi.ClickJavaScript(obj_transaction.currentdate);
                bi.WaitTime(3);

                bi.Click(obj_transaction.ApplyFilter);
                bi.WaitTime(10);
                Regex regex = new Regex("[^0-9.]");
                //Checking the First row Amount
                Assert.AreEqual(Convert.ToDouble(regex.Replace(bi.GetText(obj_transaction.FirstrowAccruedAmount), "")), Convert.ToDouble(regex.Replace(Parameters.Bobcat_AccrualPositive_Amount, "")));
                Console.WriteLine("Accrual Amount Entry showing under Fund Snapshot");
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);

            }
        }



        //verifying Accrual Entry under Detailed Report
        public void VerifyingTransferEntryUnderDetailedReport(string accrualType = "Flat")
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Transaction_Accrual));
            try
            {
                string ProgramName = null;
                if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName();
                    //bi.Type(ProgramNameText, Parameters.Ace_ProgramName());
                }
                else
                {
                    ProgramName = Parameters.Bobcat_ProgramName_Rolling;
                    //bi.Type(ProgramNameText, Parameters.Ace_ProgramName_Rolling);
                }

                bi.WaitTillNotVisible(obj_transaction.imgLoading);
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(5);
                if (bi.IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_transaction.OtherProgramsLink);
                    bi.Click(obj_transaction.OtherProgramsLink);
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));
                }
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.ViewDetailedReport);
                bi.ClickJavaScript(obj_transaction.ViewDetailedReport);
                bi.WaitTillNotVisible(obj_transaction.imgLoading);
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);

                bi.WaitVisible(obj_transaction.TransferredTab);
                bi.Click(obj_transaction.TransferredTab);
                bi.WaitTillNotVisible(obj_transaction.LoadingCircleFundsnapshot);
                bi.WaitTime(5);
                if (bi.IsElementEnabled(obj_transaction.LMEdropdownDetailedReport))
                {
                    bi.Click(obj_transaction.LMEdropdownDetailedReport);
                    bi.WaitTime(5);
                    bi.TypeClear(obj_transaction.LMESearchTxtDetailedReport, Parameters.Bobcat_Test_LME());
                    bi.Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Down);
                    bi.Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Enter);
                }
                bi.WaitVisible(obj_transaction.SubmittedStartdate);
                bi.Click(obj_transaction.SubmittedStartdate);
                bi.WaitTime(2);
                DateSelection dsTran = new DateSelection(Driver);
                bi.ClickJavaScript(obj_transaction.currentdate);

                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.SubmittedEndDate);
                bi.Click(obj_transaction.SubmittedEndDate);
                bi.WaitTime(2);
                DateSelection dsExp = new DateSelection(Driver);
                bi.ClickJavaScript(obj_transaction.currentdate);
                bi.WaitTime(3);

                bi.Click(obj_transaction.ApplyFilter);
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(10);
                Regex regex = new Regex("[^0-9.]");
                Assert.True(bi.GetText(obj_transaction.FirstrowTransferredAmount).Contains("("));
                Console.WriteLine("Application showing The Specified amount is deducted from the Source LME");
                Assert.AreEqual(Convert.ToDouble(regex.Replace(bi.GetText(obj_transaction.FirstrowTransferredAmount), "")), Convert.ToDouble(regex.Replace(Parameters.Bobcat_TransferPositive_Amount, "")));
                //Checking the First row Amount
                Console.WriteLine("Transfter Amount Entry showing under Fund Snapshot");
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

            }
        }


        //verifying Accrual Entry under Detailed Report
        public void VerifyingAdjustmentEntryUnderDetailedReport(string accrualType = "Flat")
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Transaction_Accrual));
            try
            {
                string ProgramName = null;
                if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName();
                    //bi.Type(ProgramNameText, Parameters.Ace_ProgramName());
                }
                else
                {
                    ProgramName = Parameters.Bobcat_ProgramName_Rolling;
                    //bi.Type(ProgramNameText, Parameters.Ace_ProgramName_Rolling);
                }

                bi.WaitTillNotVisible(obj_transaction.imgLoading);
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(5);
                if (bi.IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_transaction.OtherProgramsLink);
                    bi.Click(obj_transaction.OtherProgramsLink);
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));
                }
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.ViewDetailedReport);
                bi.ClickJavaScript(obj_transaction.ViewDetailedReport);
                bi.WaitTillNotVisible(obj_transaction.imgLoading);

                bi.WaitVisible(obj_transaction.AdjustedTab);
                bi.Click(obj_transaction.AdjustedTab);
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(5);
                if (!bi.getElement(obj_transaction.LMEdropdownDetailedReport).GetAttribute("class").Contains("disable"))
                {
                    bi.Click(obj_transaction.LMEdropdownDetailedReport);
                    bi.WaitTime(5);
                    bi.TypeClear(obj_transaction.LMESearchTxtDetailedReport, Parameters.Bobcat_Test_LME());
                    bi.Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Down);
                    bi.Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Enter);
                }
                bi.WaitVisible(obj_transaction.SubmittedStartdate);
                bi.Click(obj_transaction.SubmittedStartdate);
                bi.WaitTime(2);
                DateSelection dsTran = new DateSelection(Driver);
                bi.ClickJavaScript(obj_transaction.currentdate);

                bi.WaitTime(5);
                bi.WaitVisible(obj_transaction.SubmittedEndDate);
                bi.Click(obj_transaction.SubmittedEndDate);
                bi.WaitTime(2);
                DateSelection dsExp = new DateSelection(Driver);
                bi.ClickJavaScript(obj_transaction.currentdate);
                bi.WaitTime(3);

                bi.Click(obj_transaction.ApplyFilter);
                bi.WaitTime(10);
                Regex regex = new Regex("[^0-9.]");
                //Assert.True(bi.GetText(FirstrowAdjustedAmount).Contains("("));
                //Console.WriteLine("Application showing The Specified amount is deducted from the Source LME");
                Assert.AreEqual(Convert.ToDouble(regex.Replace(bi.GetText(obj_transaction.FirstrowAdjustedAmount), "")), Convert.ToDouble(regex.Replace(Parameters.Bobcat_AccrualPositive_Amount, "")));
                //Checking the First row Amount
                Console.WriteLine("Adjustment Amount Entry showing under Fund Snapshot");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

            }
        }
    }
}
