using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CFM_PARALLEL.PageObject.UI.Functions.Bobcat
{
    class BC_Transactions
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Transactions obj_transaction;
        private BC_Claim bc;

        //Constructor
        public BC_Transactions(IWebDriver Driver)
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_transaction = new OBJ_Transactions();
            bc = new BC_Claim();
        }
        //Get Available Funds for Program
        public string GetAvailableFunds(string ProgramName)
        {
            try
            {
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(10);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().Click(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));
                }
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(10);
                string AvailableFund = Pages.BasicInteractions().GetText(obj_transaction.AvailableFunds);

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                return AvailableFund;
            }
            catch (Exception ex)
            {
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
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_transaction.ProgramList(Parameters.Bobcat_ProgramName())))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(Parameters.Bobcat_ProgramName()));

                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().Click(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(Parameters.Bobcat_ProgramName()));
                }
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(10);
                string AvailableFund = Pages.BasicInteractions().GetText(obj_transaction.AvailableFunds);

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                Funds.Add("AvailableFunds", Convert.ToDouble(AvailableFund));

                //Clicking on View Detailed Report
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkViewDetailedReport);
                Pages.BasicInteractions().Click(obj_dashboard.LnkViewDetailedReport);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnMoreDetails);
                Pages.BasicInteractions().Click(obj_dashboard.BtnMoreDetails);

                //Get All the funds and add to Dictionary
                string TotalCredited = Pages.BasicInteractions().GetText(obj_dashboard.TotalCredited);

                if (TotalCredited.Contains("(") | TotalCredited.Contains(")"))
                {
                    TotalCredited = "-" + TotalCredited.Replace("(", "").Replace(")", "");
                }
                Funds.Add("TotalCredited", Convert.ToDouble(TotalCredited));


                //Open Claims
                string OpenClaims = Pages.BasicInteractions().GetText(obj_dashboard.OpenCliams);

                if (OpenClaims.Contains("(") | OpenClaims.Contains(")"))
                {
                    OpenClaims = "-" + OpenClaims.Replace("(", "").Replace(")", "");
                }
                Funds.Add("OpenClaims", Convert.ToDouble(OpenClaims));

                //Approved Claims
                string ApprovedClaims = Pages.BasicInteractions().GetText(obj_dashboard.ApprovedClaims);

                if (ApprovedClaims.Contains("(") | ApprovedClaims.Contains(")"))
                {
                    ApprovedClaims = "-" + ApprovedClaims.Replace("(", "").Replace(")", "");
                }
                Funds.Add("ApprovedClaims", Convert.ToDouble(ApprovedClaims));

                //Paid Claims
                string PaidCliams = Pages.BasicInteractions().GetText(obj_dashboard.PaidClaims);

                if (PaidCliams.Contains("(") | PaidCliams.Contains(")"))
                {
                    PaidCliams = "-" + PaidCliams.Replace("(", "").Replace(")", "");
                }
                Funds.Add("PaidCliams", Convert.ToDouble(PaidCliams));

                return Funds;
            }
            catch (Exception ex)
            {
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

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_transaction.LeftNavTransaction);
                Pages.BasicInteractions().Click(obj_transaction.LeftNavTransaction);
                Pages.BasicInteractions().WaitVisible(obj_transaction.TranAccrual);
                Pages.BasicInteractions().Click(obj_transaction.TranAccrual);

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_transaction.ProgramNameDropdown);
                Pages.BasicInteractions().Click(obj_transaction.ProgramNameDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.ProgramNameText);
                Pages.BasicInteractions().Clear(obj_transaction.ProgramNameText);
               // if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                //{
                    Pages.BasicInteractions().Type(obj_transaction.ProgramNameText, ProgramName);
                    Pages.BasicInteractions().WaitVisible(obj_transaction.ProgramNameTextOption(ProgramName));
                    Pages.BasicInteractions().Click(obj_transaction.ProgramNameTextOption(ProgramName));
                //}
                
                //Pages.BasicInteractions().GetAllOptions()
                
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoading);
                Pages.BasicInteractions().WaitUntilElementClickable(obj_transaction.LMEDropdown,60);
                Pages.BasicInteractions().Click(obj_transaction.LMEDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.LMEText);
                Pages.BasicInteractions().Clear(obj_transaction.LMEText);
                Pages.BasicInteractions().Type(obj_transaction.LMEText, Parameters.Bobcat_Test_LME());
                Pages.BasicInteractions().WaitVisible(obj_transaction.LMETextOption);
                Pages.BasicInteractions().Click(obj_transaction.LMETextOption);
                Pages.BasicInteractions().WaitTime(10);

                Pages.BasicInteractions().WaitVisible(obj_transaction.PeriodDropdown);
                Pages.BasicInteractions().Click(obj_transaction.PeriodDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.PeriodText);
                Pages.BasicInteractions().Clear(obj_transaction.PeriodText);
                Pages.BasicInteractions().WaitVisible(obj_transaction.PeriodTextOption);
                Pages.BasicInteractions().Click(obj_transaction.PeriodTextOption);
                Pages.BasicInteractions().WaitTime(10);

                Pages.BasicInteractions().WaitVisible(obj_transaction.AccrualAmount);
                Pages.BasicInteractions().Type(obj_transaction.AccrualAmount, amount);

                Pages.BasicInteractions().WaitVisible(obj_transaction.AccrualComments);
                Pages.BasicInteractions().Type(obj_transaction.AccrualComments, "Accrual");

                Pages.BasicInteractions().WaitVisible(obj_transaction.ButtonPreview);
                Pages.BasicInteractions().Click(obj_transaction.ButtonPreview);


                Pages.BasicInteractions().WaitVisible(obj_transaction.SubmitButton);
                Pages.BasicInteractions().Click(obj_transaction.SubmitButton);
                Console.WriteLine("$" + amount + " ACCRUED for Program: " + ProgramName + " & Store: " + Parameters.Bobcat_Test_LME());
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_transaction.BackToTansactions);
                Pages.BasicInteractions().Click(obj_transaction.BackToTansactions);

                Pages.BasicInteractions().WaitTime(5);
    
                Pages.BasicInteractions().WaitVisible(obj_transaction.Dashboard);
                Pages.BasicInteractions().Click(obj_transaction.Dashboard);
                Pages.BasicInteractions().WaitTime(10);
                String AvailableFundAfterAccrual = GetAvailableFunds(ProgramName);

                Assert.True(Convert.ToDouble(AvailableFundAfterAccrual.Replace("$", "")) == (Convert.ToDouble(AvailableFundBeforeAccrual.Replace("$", "")) + Convert.ToDouble(amount.Replace("$", ""))));
                Console.WriteLine("Accrual Amount Added to Available Funds Correctly");
            }
            catch (Exception ex)
            { 
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

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.LeftNavTransaction);
                Pages.BasicInteractions().Click(obj_transaction.LeftNavTransaction);
                Pages.BasicInteractions().WaitVisible(obj_transaction.TranAdjustment);
                Pages.BasicInteractions().Click(obj_transaction.TranAdjustment);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.ProgramNameDropdown);
                Pages.BasicInteractions().Click(obj_transaction.ProgramNameDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.ProgramNameText);
                Pages.BasicInteractions().Clear(obj_transaction.ProgramNameText);
                //if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                //{
                    Pages.BasicInteractions().Type(obj_transaction.ProgramNameText, ProgramName);
                    Pages.BasicInteractions().WaitVisible(obj_transaction.ProgramNameTextOption(ProgramName));
                    Pages.BasicInteractions().Click(obj_transaction.ProgramNameTextOption(ProgramName));
                //}
                //else if (accrualType.ToUpper().Equals("Rolling".ToUpper()))
                //{
                //    Pages.BasicInteractions().Type(obj_transaction.ProgramNameText, Parameters.Bobcat_ProgramName_Rolling);
                //    Pages.BasicInteractions().WaitVisible(obj_transaction.ProgramNameTextOption(Parameters.Bobcat_ProgramName_Rolling));
                //    Pages.BasicInteractions().Click(obj_transaction.ProgramNameTextOption(Parameters.Bobcat_ProgramName_Rolling));
                //}
                
                Pages.BasicInteractions().WaitTime(10);

                Pages.BasicInteractions().WaitUntilElementClickable(obj_transaction.LMEDropdown,60);
                Pages.BasicInteractions().Click(obj_transaction.LMEDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.LMEText);
                Pages.BasicInteractions().Clear(obj_transaction.LMEText);
                Pages.BasicInteractions().Type(obj_transaction.LMEText, (Parameters.Bobcat_Test_LME()));
                Pages.BasicInteractions().WaitVisible(obj_transaction.LMETextOption);
                Pages.BasicInteractions().Click(obj_transaction.LMETextOption);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_transaction.PeriodDropdown);
                Pages.BasicInteractions().Click(obj_transaction.PeriodDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.PeriodText);
                Pages.BasicInteractions().Clear(obj_transaction.PeriodText);
                Pages.BasicInteractions().WaitVisible(obj_transaction.PeriodTextOption);
                Pages.BasicInteractions().Click(obj_transaction.PeriodTextOption);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_transaction.AdjustAmount);
                Pages.BasicInteractions().Type(obj_transaction.AdjustAmount, amount);

                Pages.BasicInteractions().WaitVisible(obj_transaction.AccrualComments);
                Pages.BasicInteractions().Type(obj_transaction.AccrualComments, "Adjustment");

                Pages.BasicInteractions().WaitVisible(obj_transaction.ButtonPreview);
                Pages.BasicInteractions().Click(obj_transaction.ButtonPreview);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_transaction.SubmitButton);
                Pages.BasicInteractions().Click(obj_transaction.SubmitButton);
                Console.WriteLine(amount + " ADJUSTMENT for Program: " + ProgramName + " & Store: " + Parameters.Bobcat_Test_LME());

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.BackToTansactions);
                Pages.BasicInteractions().Click(obj_transaction.BackToTansactions);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.Dashboard);
                Pages.BasicInteractions().Click(obj_transaction.Dashboard);

                String AvailableFundAftertransfer = GetAvailableFunds(ProgramName);

                Assert.True(Convert.ToDouble(AvailableFundAftertransfer.Replace("$", "")) == (Convert.ToDouble(AvailableFundBeforeTransfer.Replace("$", "")) + Convert.ToDouble(amount.Replace("$", ""))));
                Console.WriteLine("Adjustment Amount Added to Available Funds Correctly");
            }
            catch (Exception ex)
            {
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

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_transaction.LeftNavTransaction);
                Pages.BasicInteractions().Click(obj_transaction.LeftNavTransaction);
                Pages.BasicInteractions().WaitVisible(obj_transaction.TranTransfer);
                Pages.BasicInteractions().Click(obj_transaction.TranTransfer);

                Pages.BasicInteractions().WaitTime(10);

                //Transfering Fund from Source to Some Destination program
                Pages.BasicInteractions().WaitVisible(obj_transaction.SourceProgramNameDropdown);
                Pages.BasicInteractions().Click(obj_transaction.SourceProgramNameDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.SourceProgramNameText);
                Pages.BasicInteractions().Clear(obj_transaction.SourceProgramNameText);
                Pages.BasicInteractions().Type(obj_transaction.SourceProgramNameText, ProgramName);
                Pages.BasicInteractions().WaitVisible(obj_transaction.SourceProgramNameTextOption(ProgramName));
                Pages.BasicInteractions().Click(obj_transaction.SourceProgramNameTextOption(ProgramName));
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.sourceLMEDropdownDisbaled,60);
                Pages.BasicInteractions().Click(obj_transaction.SourceLMEDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.SourceLMEText);
                Pages.BasicInteractions().Clear(obj_transaction.SourceLMEText);
                Pages.BasicInteractions().Type(obj_transaction.SourceLMEText, Parameters.Bobcat_Test_LME());
                Pages.BasicInteractions().WaitVisible(obj_transaction.SourceLMETextOption);
                Pages.BasicInteractions().Click(obj_transaction.SourceLMETextOption);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_transaction.DestinationProgramNameDropdown);
                Pages.BasicInteractions().Click(obj_transaction.DestinationProgramNameDropdown);

                Pages.BasicInteractions().WaitVisible(obj_transaction.DestinationProgramNameText);
                Pages.BasicInteractions().Clear(obj_transaction.DestinationProgramNameText);
                Pages.BasicInteractions().Type(obj_transaction.DestinationProgramNameText, Keys.ArrowDown);
                Pages.BasicInteractions().Type(obj_transaction.DestinationProgramNameText, Keys.Enter);

                //Pages.BasicInteractions().Type(DestinationProgramNameText,Parameters.Ace_ProgramName());
                //Pages.BasicInteractions().WaitVisible(DestinationLMETextOption);
                //Pages.BasicInteractions().Click(DestinationLMETextOption);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.DestinationLMEDropdownDisabled,60);
                Pages.BasicInteractions().Click(obj_transaction.DestinationLMEDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.DestinationLMEText);
                Pages.BasicInteractions().Clear(obj_transaction.DestinationLMEText);
                Pages.BasicInteractions().Type(obj_transaction.DestinationLMEText, Keys.ArrowDown);
                Pages.BasicInteractions().Type(obj_transaction.DestinationLMEText, Keys.Enter);
                //Pages.BasicInteractions().Type(DestinationLMEText,Parameters.Ace_Test_LME_00080);
                //Pages.BasicInteractions().WaitVisible(DestinationLMETextOption);
                //Pages.BasicInteractions().Click(DestinationLMETextOption);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_transaction.PeriodDropdown);
                Pages.BasicInteractions().Click(obj_transaction.PeriodDropdown);
                Pages.BasicInteractions().WaitVisible(obj_transaction.PeriodText);
                Pages.BasicInteractions().Clear(obj_transaction.PeriodText);
                Pages.BasicInteractions().WaitVisible(obj_transaction.PeriodTextOption);
                Pages.BasicInteractions().Click(obj_transaction.PeriodTextOption);
                Pages.BasicInteractions().WaitTime(10);

                Pages.BasicInteractions().WaitVisible(obj_transaction.TransferAmount);
                Pages.BasicInteractions().Type(obj_transaction.TransferAmount, (amount));

                Pages.BasicInteractions().WaitVisible(obj_transaction.AccrualComments);
                Pages.BasicInteractions().Type(obj_transaction.AccrualComments, ("Transfer"));

                Pages.BasicInteractions().WaitVisible(obj_transaction.ButtonPreview);
                Pages.BasicInteractions().Click(obj_transaction.ButtonPreview);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_transaction.SubmitButton);
                Pages.BasicInteractions().Click(obj_transaction.SubmitButton);
                //Pages.BasicInteractions().WaitTime(10);
                Console.WriteLine(amount + " TRANSFERED for Program: " + ProgramName + " from Store: " + Parameters.Bobcat_Test_LME()
                    + " to Store: " + Parameters.Bobcat_Test_LME());
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_transaction.BackToTansactions);
                Pages.BasicInteractions().Click(obj_transaction.BackToTansactions);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.Dashboard);
                Pages.BasicInteractions().Click(obj_transaction.Dashboard);

                String AvailableFundAftertransfer = GetAvailableFunds(ProgramName);

                Assert.True(Convert.ToDouble(AvailableFundAftertransfer.Replace("$", "")) == (Convert.ToDouble(AvailableFundBeforeTransfer.Replace("$", "")) - Convert.ToDouble(amount.Replace("$", ""))));
                Console.WriteLine("Transfer Amount Removed From Available Funds Correctly");
            }
            catch (Exception ex)
            {
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
                Pages.BasicInteractions().WaitVisible(obj_transaction.Dashboard);
                Pages.BasicInteractions().Click(obj_transaction.Dashboard);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoading);

                string AvailableFindsAfterClaimCreation = GetAvailableFunds(Parameters.Pandora_ProgramName());
                Assert.True(Convert.ToDouble(AvailableFindsAfterClaimCreation.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation.Replace("$", "")) - Convert.ToDouble(Parameters.ClaimRequestedAmount_Pandora.Replace("$", ""))));
                Console.WriteLine("Calim Amount Deducted from Available Funds Correctly");
            }
            catch (Exception ex)
            {
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
                    //Pages.BasicInteractions().Type(ProgramNameText, Parameters.Ace_ProgramName());
                }
                else
                {
                    ProgramName = Parameters.Bobcat_ProgramName_Rolling;
                    //Pages.BasicInteractions().Type(ProgramNameText, Parameters.Ace_ProgramName_Rolling);
                }

                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().Click(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));
                }
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.ViewDetailedReport);
                Pages.BasicInteractions().ClickJavaScript(obj_transaction.ViewDetailedReport);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoading);

                Pages.BasicInteractions().WaitVisible(obj_transaction.ApprovedTab);
                if (Pages.BasicInteractions().IsElementEnabled(obj_transaction.LMEdropdownDetailedReport))
                {
                    Pages.BasicInteractions().Click(obj_transaction.LMEdropdownDetailedReport);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().TypeClear(obj_transaction.LMESearchTxtDetailedReport, Parameters.Bobcat_Test_LME());
                    Pages.BasicInteractions().Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Down);
                    Pages.BasicInteractions().Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Enter);
                }
                Pages.BasicInteractions().WaitVisible(obj_transaction.SubmittedStartdate);
                Pages.BasicInteractions().Click(obj_transaction.SubmittedStartdate);
                Pages.BasicInteractions().WaitTime(2);
                DateSelection dsTran = new DateSelection();
                Pages.BasicInteractions().ClickJavaScript(obj_transaction.currentdate);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.SubmittedEndDate);
                Pages.BasicInteractions().Click(obj_transaction.SubmittedEndDate);
                Pages.BasicInteractions().WaitTime(2);
                DateSelection dsExp = new DateSelection();
                Pages.BasicInteractions().ClickJavaScript(obj_transaction.currentdate);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().Click(obj_transaction.ApplyFilter);
                Pages.BasicInteractions().WaitTime(10);
                Regex regex = new Regex("[^0-9.]");
                //Checking the First row Amount
                Assert.AreEqual(Convert.ToDouble(regex.Replace(Pages.BasicInteractions().GetText(obj_transaction.FirstrowAmount), "")), Convert.ToDouble(regex.Replace(Parameters.Bobcat_AccrualPositive_Amount, "")));
                Console.WriteLine("Accrual Amount Entry showing under Fund Snapshot");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
        }

        //verifying Accrual Entry under Detailed Report
        public void VerifyingTransferEntryUnderDetailedReport(string accrualType = "Flat")
        {
            try
            {
                string ProgramName = null;
                if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName();
                    //Pages.BasicInteractions().Type(ProgramNameText, Parameters.Ace_ProgramName());
                }
                else
                {
                    ProgramName = Parameters.Bobcat_ProgramName_Rolling;
                    //Pages.BasicInteractions().Type(ProgramNameText, Parameters.Ace_ProgramName_Rolling);
                }

                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().Click(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));
                }
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.ViewDetailedReport);
                Pages.BasicInteractions().ClickJavaScript(obj_transaction.ViewDetailedReport);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);

                Pages.BasicInteractions().WaitVisible(obj_transaction.TransferredTab);
                Pages.BasicInteractions().Click(obj_transaction.TransferredTab);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingCircleFundsnapshot);
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementEnabled(obj_transaction.LMEdropdownDetailedReport))
                {
                    Pages.BasicInteractions().Click(obj_transaction.LMEdropdownDetailedReport);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().TypeClear(obj_transaction.LMESearchTxtDetailedReport, Parameters.Bobcat_Test_LME());
                    Pages.BasicInteractions().Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Down);
                    Pages.BasicInteractions().Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Enter);
                }
                Pages.BasicInteractions().WaitVisible(obj_transaction.SubmittedStartdate);
                Pages.BasicInteractions().Click(obj_transaction.SubmittedStartdate);
                Pages.BasicInteractions().WaitTime(2);
                DateSelection dsTran = new DateSelection();
                Pages.BasicInteractions().ClickJavaScript(obj_transaction.currentdate);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.SubmittedEndDate);
                Pages.BasicInteractions().Click(obj_transaction.SubmittedEndDate);
                Pages.BasicInteractions().WaitTime(2);
                DateSelection dsExp = new DateSelection();
                Pages.BasicInteractions().ClickJavaScript(obj_transaction.currentdate);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().Click(obj_transaction.ApplyFilter);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(10);
                Regex regex = new Regex("[^0-9.]");
                Assert.True(Pages.BasicInteractions().GetText(obj_transaction.FirstrowAmount).Contains("("));
                Console.WriteLine("Application showing The Specified amount is deducted from the Source LME");
                Assert.AreEqual(Convert.ToDouble(regex.Replace(Pages.BasicInteractions().GetText(obj_transaction.FirstrowAmount), "")), Convert.ToDouble(regex.Replace(Parameters.Bobcat_TransferPositive_Amount, "")));
                //Checking the First row Amount
                Console.WriteLine("Transfter Amount Entry showing under Fund Snapshot");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
        }


        //verifying Accrual Entry under Detailed Report
        public void VerifyingAdjustmentEntryUnderDetailedReport(string accrualType = "Flat")
        {
            try
            {
                string ProgramName = null;
                if (accrualType.ToUpper().Equals("Flat".ToUpper()))
                {
                    ProgramName = Parameters.Bobcat_ProgramName();
                    //Pages.BasicInteractions().Type(ProgramNameText, Parameters.Ace_ProgramName());
                }
                else
                {
                    ProgramName = Parameters.Bobcat_ProgramName_Rolling;
                    //Pages.BasicInteractions().Type(ProgramNameText, Parameters.Ace_ProgramName_Rolling);
                }

                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().Click(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));
                }
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.ViewDetailedReport);
                Pages.BasicInteractions().ClickJavaScript(obj_transaction.ViewDetailedReport);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoading);

                Pages.BasicInteractions().WaitVisible(obj_transaction.AdjustedTab);
                Pages.BasicInteractions().Click(obj_transaction.AdjustedTab);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                if (!Pages.BasicInteractions().GetElement(obj_transaction.LMEdropdownDetailedReport).GetAttribute("class").Contains("disable"))
                {
                    Pages.BasicInteractions().Click(obj_transaction.LMEdropdownDetailedReport);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().TypeClear(obj_transaction.LMESearchTxtDetailedReport, Parameters.Bobcat_Test_LME());
                    Pages.BasicInteractions().Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Down);
                    Pages.BasicInteractions().Type(obj_transaction.LMESearchTxtDetailedReport, Keys.Enter);
                }
                Pages.BasicInteractions().WaitVisible(obj_transaction.SubmittedStartdate);
                Pages.BasicInteractions().Click(obj_transaction.SubmittedStartdate);
                Pages.BasicInteractions().WaitTime(2);
                DateSelection dsTran = new DateSelection();
                Pages.BasicInteractions().ClickJavaScript(obj_transaction.currentdate);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_transaction.SubmittedEndDate);
                Pages.BasicInteractions().Click(obj_transaction.SubmittedEndDate);
                Pages.BasicInteractions().WaitTime(2);
                DateSelection dsExp = new DateSelection();
                Pages.BasicInteractions().ClickJavaScript(obj_transaction.currentdate);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().Click(obj_transaction.ApplyFilter);
                Pages.BasicInteractions().WaitTime(10);
                Regex regex = new Regex("[^0-9.]");
                //Assert.True(Pages.BasicInteractions().GetText(FirstrowAdjustedAmount).Contains("("));
                //Console.WriteLine("Application showing The Specified amount is deducted from the Source LME");
                Assert.AreEqual(Convert.ToDouble(regex.Replace(Pages.BasicInteractions().GetText(obj_transaction.FirstrowAmount), "")), Convert.ToDouble(regex.Replace(Parameters.Bobcat_AccrualPositive_Amount, "")));
                //Checking the First row Amount
                Console.WriteLine("Adjustment Amount Entry showing under Fund Snapshot");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
        }
    }
}
