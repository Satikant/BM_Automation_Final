using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Program_Management;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions.Pandora
{
    public class PN_ProgramManagement
    {
        private IWebDriver Driver;
        private Base bs;
        private BrowserURLLaunch bl;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private BasicInteractions bi;
        private OBJ_Program obj_program;
        private Database db;
        //Constructor
        public PN_ProgramManagement(IWebDriver Driver)
        {
            this.Driver = Driver;
            bs = new Base();
            bl = new BrowserURLLaunch(Driver);
            obj_dashboard = new OBJ_Dashboard();
            bi = new BasicInteractions(Driver);
            obj_claims = new OBJ_Claims();
            obj_program = new OBJ_Program();
            db = new Database(Driver);
        }

        public static string db_programName, db_prgDesc, db_strDate, db_endDate, db_currency,
           db_fundistributionhierarchy, db_claimflow, db_overdraft, db_requireBPA, db_ecomEligible,
           db_accrualType, db_accrualPeriod, db_claimDate, db_expDate,
           db_reimbursementType, db_reimbursementRate, db_capping, db_cappingpercent, db_activityOptions,
           db_accrualAmt;
        public static string ProgramName = CommonFunctions.UniqueName("AutomationTest").Replace("AM","").Replace("PM","");


        public static void Program_DatabaseDataRead()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_FullFlow));
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
                SqlConnection connection_claim_db = new SqlConnection(connection_db);
                string claim_query = "select * from cfmaddnewprogramdata where AccrualType='" + db_accrualType + "' order by indexaddnew desc";
                connection_claim_db.Open();
                SqlCommand claim_cmd = new SqlCommand(claim_query, connection_claim_db);
                using (SqlDataReader read = claim_cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        db_programName = read["PrgName"].ToString();
                        db_prgDesc = read["PrgDesc"].ToString();
                        db_strDate = read["StartDate"].ToString();
                        db_endDate = read["EndDate"].ToString();
                        db_currency = read["Currency"].ToString();
                        db_fundistributionhierarchy = read["FundDistributionHierarchy"].ToString();
                        db_claimflow = read["ClaimFlow"].ToString();
                        db_overdraft = read["Overdraft"].ToString();
                        db_requireBPA = read["RequireBPA"].ToString();
                        db_ecomEligible = read["EcomEligible"].ToString();
                        db_accrualType = read["AccrualType"].ToString();
                        db_accrualPeriod = read["AccrualPeriod"].ToString();
                        db_claimDate = read["ClaimDate"].ToString();
                        db_expDate = read["ExpiryDate"].ToString();
                        db_reimbursementType = read["ReimbursementType"].ToString();
                        db_reimbursementRate = read["ReimbursementRate"].ToString();
                        db_capping = read["CappingOption"].ToString();
                        db_cappingpercent = read["CappingPercent"].ToString();
                        db_activityOptions = read["ActivityOptions"].ToString();
                        db_accrualAmt = read["AccrualAmount"].ToString();
                        Console.WriteLine(db_programName + " | " + db_prgDesc + " | " + db_strDate + " | " + db_endDate + " | " + db_currency + " | " +
            db_fundistributionhierarchy + " | " + db_claimflow + " | " + db_overdraft + " | " + db_requireBPA + " | " + db_ecomEligible + " | " +
            db_accrualType + " | " + db_accrualPeriod + " | " + db_claimDate + " | " + db_expDate + " | " +
            db_reimbursementType + " | " + db_reimbursementRate + " | " + db_capping + " | " + db_cappingpercent + " | " + db_activityOptions + " | " +
            db_accrualAmt);
                    }
                }
                connection_claim_db.Close();
            }
            catch (Exception ex)
            {
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Database connection error is: " + ex);
                Assert.Fail("Database connection error is: " + ex);
            }
        }

        //Navigating to New Program Creation form
        public void NavigatingToProgramCreation()
        {
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.leftNavProgram);
                bi.Click(obj_program.leftNavProgram);
                bi.WaitTillNotVisible(obj_program.imgLoading);
                bi.WaitTime(5);
                //Clicking on New Program
                bi.WaitVisible(obj_program.btnNewprogram);
                bi.Click(obj_program.btnNewprogram);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
            }
        }   
        
        //Fill ProgramDetails Secton
        public void FillProgramDetailsSection(string db_PrgName, String db_PrgDesc, String db_Currency)
        {
            try
            {
                //Waiting upto programname field is visible
                bi.WaitVisible(obj_program.ProgramName);
                bi.Type(obj_program.ProgramName, db_PrgName);
                //Prg_Name = db_PrgName;
                bi.WaitVisible(obj_program.ProgramDesc);
                bi.Type(obj_program.ProgramDesc, db_PrgDesc);
                bi.WaitVisible(obj_program.ProgramCurrencyDropdown);

                if (db_Currency == "USD")
                {
                    db_Currency = "$";
                }
                bi.Click(obj_program.ProgramCurrencyDropdown);
                bi.WaitVisible(obj_program.ProgramCurrencyText);
                bi.TypeClear(obj_program.ProgramCurrencyText, db_Currency);
                bi.Type(obj_program.ProgramCurrencyText, Keys.Enter);
                

                bi.WaitVisible(obj_program.StartDate);
                bi.Click(obj_program.StartDate);
                bi.WaitTime(5);
                DateSelection dssrt = new DateSelection(Driver);
                bi.Click(obj_program.StartDateSelection(dssrt.Ace_DateSelection_prgStartDate()));

                bi.WaitVisible(obj_program.EndDate);
                bi.Click(obj_program.EndDate);
                bi.WaitTime(5);
                DateSelection dsend = new DateSelection(Driver);
                bi.Click(obj_program.EndDateSelection(dsend.Ace_DateSelection_prgEndDate()));

                bi.WaitTime(5);
                bi.ClickJavaScript(obj_program.NextButton);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
            }
        }
        //Fill ProgramFlow section
        public void FillProgramFlowSection()
        {
            try
            {
                bi.WaitVisible(obj_program.ClaimFlow);
                bi.ClickJavaScript(obj_program.ClaimFlow);
                bi.WaitTime(2);
                bi.WaitVisible(obj_program.FundMatchingHierarchy);
                bi.ClickJavaScript(obj_program.FundMatchingHierarchy);
                //bi.WaitVisible(obj_program.ClaimFlow);
                //bi.ClickJavaScript(obj_program.ClaimFlow);
                //if (db_overdraft.Equals("Y"))
                //{
                //    bi.WaitVisible(obj_program.OverdraftYes);
                //    bi.ClickJavaScript(obj_program.OverdraftYes);
                //}
                //else
                //{
                //    bi.WaitVisible(obj_program.OverdraftNo);
                //    bi.ClickJavaScript(obj_program.OverdraftNo);
                //}

                //if (db_requireBPA.Equals("Y"))
                //{
                //    bi.WaitVisible(obj_program.BrandingApprovalsYes);
                //    bi.ClickJavaScript(obj_program.BrandingApprovalsYes);
                //}
                //else
                //{
                //    bi.WaitVisible(obj_program.BrandingApprovalsNo);
                //    bi.ClickJavaScript(obj_program.BrandingApprovalsNo);
                //}

                //if (db_ecomEligible.Equals("Y"))
                //{
                //    bi.WaitVisible(obj_program.EComYes);
                //    bi.ClickJavaScript(obj_program.EComYes);
                //}
                //else
                //{
                //    bi.WaitVisible(obj_program.EComNo);
                //    bi.ClickJavaScript(obj_program.EComNo);
                //}

                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                bi.WaitTime(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
            }
        }

        //Fill program Accrual Details
        public void FillProgramAccrualDetailsSection(string db_accrualType, string db_accrualPeriod)
        {
            try
            {

                bi.WaitVisible(obj_program.NextButton);
                if (db_accrualType.ToUpper().Equals("Flat".ToUpper()))
                {
                    bi.WaitVisible(obj_program.Accrual_Flat);
                    bi.ClickJavaScript(obj_program.Accrual_Flat);
                    if (db_accrualPeriod.ToUpper().Equals("Annual".ToUpper()))
                    {
                        bi.WaitVisible(obj_program.Accrual_Flat_Annual);
                        bi.ClickJavaScript(obj_program.Accrual_Flat_Annual);
                    }
                    else if (db_accrualPeriod.ToUpper().Equals("Monthly".ToUpper()))
                    {
                        bi.WaitVisible(obj_program.Accrual_Flat_Monthly);
                        bi.ClickJavaScript(obj_program.Accrual_Flat_Monthly);
                    }
                }
                else if (db_accrualType.ToUpper().Equals("Rolling".ToUpper()))
                {
                    bi.WaitVisible(obj_program.Accrual_Rolling);
                    bi.ClickJavaScript(obj_program.Accrual_Rolling);
                    if (db_accrualPeriod.ToUpper().Equals("3 months".ToUpper()))
                    {
                        bi.WaitVisible(obj_program.Accrual_Rolling_3);
                        bi.ClickJavaScript(obj_program.Accrual_Rolling_3);
                    }
                    else if (db_accrualPeriod.ToUpper().Equals("6 months".ToUpper()))
                    {
                        bi.WaitVisible(obj_program.Accrual_Rolling_6);
                        bi.ClickJavaScript(obj_program.Accrual_Rolling_6);
                    }
                    else if (db_accrualPeriod.ToUpper().Equals("9 months".ToUpper()))
                    {
                        bi.WaitVisible(obj_program.Accrual_Rolling_9);
                        bi.ClickJavaScript(obj_program.Accrual_Rolling_9);
                    }
                    else if (db_accrualPeriod.ToUpper().Equals("12 months".ToUpper()))
                    {
                        bi.WaitVisible(obj_program.Accrual_Rolling_12);
                        bi.ClickJavaScript(obj_program.Accrual_Rolling_12);
                    }
                }
                bi.WaitVisible(obj_program.TransactionDate);
                bi.Click(obj_program.TransactionDate);
                bi.WaitTime(5);
                DateSelection dsTran = new DateSelection(Driver);
                bi.Click(obj_program.LastTranDateSelection(dsTran.Ace_DateSelection_prgTranDate(),Driver));

                bi.WaitTime(5);
                bi.WaitVisible(obj_program.ExpirationDate);
                bi.Click(obj_program.ExpirationDate);
                bi.WaitTime(2);
                DateSelection dsExp = new DateSelection(Driver);
                bi.Click(obj_program.ExpirationDateSelection(dsExp.Ace_DateSelection_prgExpirationDate(),Driver));
                bi.WaitTime(3);
                bi.ClickJavaScript(obj_program.NextButton);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("ACE_Program_AccrualDetails " + ex);
                Assert.Fail("ACE_Program_AccrualDetails " + ex);
            }
        }

        //Filling Reimbursement Section
        public void FillReimbursementSection(string db_reimbursementType, string db_reimbursementRate, string db_capping, string db_cappingpercent, string db_activityOptions)
        {
            try
            {
                bi.WaitVisible(obj_program.NextButton);
                if (db_reimbursementType.Equals("Fixed"))
                {
                    bi.WaitVisible(obj_program.Reimbursement_Fixed);
                    bi.ClickJavaScript(obj_program.Reimbursement_Fixed);
                    bi.WaitVisible(obj_program.ReimburseFixedPercent);
                    bi.Clear(obj_program.ReimburseFixedPercent);
                    bi.Type(obj_program.ReimburseFixedPercent, db_reimbursementRate);
                }
                else if (db_reimbursementType.Equals("Variable"))
                {
                    bi.WaitVisible(obj_program.Reimbursement_Variable);
                    bi.ClickJavaScript(obj_program.Reimbursement_Variable);
                }

                if (db_capping.Equals("Y"))
                {
                    bi.WaitVisible(obj_program.CappingYes);
                    bi.ClickJavaScript(obj_program.CappingYes);
                }
                else if (db_capping.Equals("N"))
                {
                    bi.WaitVisible(obj_program.CappingNo);
                    bi.ClickJavaScript(obj_program.CappingNo);
                }

                obj_program.ActivityOption("Direct Mail",Driver);
                bi.ClickJavaScript(obj_program.NextButton);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
                Console.WriteLine("ACE_Program_Reimbursement " + ex);
                Assert.Fail("ACE_Program_Reimbursement " + ex);
            }
        }

        //Program Preview Section
        public void ProgramPreview()
        {
            try
            {
                bi.WaitTime(3);
                bi.WaitVisible(obj_program.SubmitButton);
                bi.Click(obj_program.SubmitButton);
                bi.WaitTime(60);

                bi.WaitVisible(obj_program.LeftNavDashboard);
                bi.Click(obj_program.LeftNavDashboard);
                Console.WriteLine("Program " + ProgramName + " created successfully");

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("ACE_Program_preview" + ex);
                Assert.Fail("ACE_Program_preview " + ex);
            }
        }

        
        //ProgramCreation And Verifyon MangoDB
        public void ProgramCreationAndVerifyingonMangoDB(string AccrualType="Flat")
        {
            db_accrualType = AccrualType;
            Program_DatabaseDataRead();

            //navigating to ProgramCreation page
            NavigatingToProgramCreation();
            bi.WaitTime(5);
            //Filling Program Details Section
            FillProgramDetailsSection(ProgramName, db_prgDesc, db_currency);
            //Filling ProgramFlow Section
            FillProgramFlowSection();
            //Filling Accrual Details Section
            FillProgramAccrualDetailsSection(db_accrualType,db_accrualPeriod);

            //Filling ReimbursementDetails
            FillReimbursementSection(db_reimbursementType, db_reimbursementRate, db_capping, db_cappingpercent, db_activityOptions);

            //Fill Preview And Submit
            ProgramPreview();

            //Verifying on MangoDB
            db.VerifyProgramCreationOnMangoDB(ProgramName);
        }


        //ProgramCreation ValidatingAll the fields
        public void ProgramCreationValidatingAlltheFields()
        {
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.leftNavProgram);
                bi.Click(obj_program.leftNavProgram);
                bi.WaitTillNotVisible(obj_program.imgLoading);
                bi.WaitTime(5);
                //Clicking on New Program
                bi.WaitVisible(obj_program.btnNewprogram);
                bi.Click(obj_program.btnNewprogram);

                bi.WaitVisible(obj_program.NextButton);
                Console.WriteLine("TESTING NEGATIVE SCENARIO FOR PROGRAM CREATION");
                //Start creating one program and first click on the Next button
                bi.ClickJavaScript(obj_program.NextButton);
                if (bi.IsElementPresent(obj_program.ErrorPrgName))
                {
                    bi.Type(obj_program.ProgramName, "ProgramForNegativeScenario");
                    Console.WriteLine("PRG NEGATIVE: Program name entered");
                    bi.Type(obj_program.ProgramDesc, "ProgramForNegativeScenario description");
                    Console.WriteLine("PRG NEGATIVE: Program description entered");
                }
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.NextButton);

                bi.ClickJavaScript(obj_program.NextButton);
                if (bi.IsElementPresent(obj_program.ErrorPrgCurrency))
                {
                    bi.WaitVisible(obj_program.ProgramCurrencyDropdown);
                    bi.Click(obj_program.ProgramCurrencyDropdown);
                    bi.WaitVisible(obj_program.ProgramCurrencyText);
                    bi.TypeClear(obj_program.ProgramCurrencyText, "$");
                    bi.Type(obj_program.ProgramCurrencyText, Keys.Enter);

                    //bi.WaitVisible(program_ProgramDetails.ProgramCurrencyTextOption);
                    //bi.Click(program_ProgramDetails.ProgramCurrencyTextOption);
                    Console.WriteLine("PRG NEGATIVE: Currency selected");
                }
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                if (bi.IsElementPresent(obj_program.ErrorPrgStartDate))
                {
                    DateSelection dsStart = new DateSelection(Driver);

                    bi.WaitVisible(obj_program.StartDate);
                    bi.Click(obj_program.StartDate);
                    bi.WaitTime(2);
                    bi.Click(obj_program.StartDateSelection(dsStart.Ace_DateSelection_prgStartDate()));
                    Console.WriteLine("PRG NEGATIVE: Program Start Date selected");
                }
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                if (bi.IsElementPresent(obj_program.ErrorPrgEnddate))
                {
                    DateSelection dsEnd = new DateSelection(Driver);

                    bi.WaitVisible(obj_program.EndDate);
                    bi.Click(obj_program.EndDate);
                    bi.WaitTime(5);
                    bi.Click(obj_program.EndDateSelection(dsEnd.Ace_DateSelection_prgEndDate()));
                    Console.WriteLine("PRG NEGATIVE: Program End Date selected");
                }
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);

                //Programs Flow stepper
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                if (bi.IsElementPresent(obj_program.ErrorClaimFlow))
                {
                    bi.WaitVisible(obj_program.ClaimFlow);
                    bi.Click(obj_program.ClaimFlow);
                    Console.WriteLine("PRG NEGATIVE: Claim Flow selected");
                }
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                if (bi.IsElementPresent(obj_program.ErrorFundDistriHierarchy))
                {
                    bi.WaitVisible(obj_program.FundOrganizationHierarchy);
                    bi.Click(obj_program.FundOrganizationHierarchy);
                    Console.WriteLine("PRG NEGATIVE: Fund Distribution Hierarchy selected");
                }
                //bi.WaitVisible(program_ProgramsFlow.NextButton);
                //program_ProgramsFlow.NextButton.Click();
                //if (ErrorClaimFlow.IsElementPresent())
                //{
                //    bi.WaitVisible(program_ProgramsFlow.ClaimFlow);
                //    program_ProgramsFlow.ClaimFlow.Click();
                //    Console.WriteLine("PRG NEGATIVE: Claim Flow selected");
                //}
                //bi.WaitVisible(program_ProgramsFlow.NextButton);
                //program_ProgramsFlow.NextButton.Click();
                //if (bi.IsElementPresent(obj_program.ErrorAllowOverdraft))
                //{

                //    bi.WaitVisible(obj_program.OverdraftYes);
                //    bi.Click(obj_program.OverdraftYes);
                //    Console.WriteLine("PRG NEGATIVE: Claims overdraft option selected");
                //}
                //bi.WaitVisible(obj_program.BrandingApprovalsYes);
                //bi.Click(obj_program.BrandingApprovalsYes);
                //Console.WriteLine("PRG NEGATIVE: BPA option selected");

                //bi.WaitVisible(obj_program.EComYes);
                //bi.Click(obj_program.EComYes);
                //Console.WriteLine("PRG NEGATIVE: E-COM option selected");

                //}
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);

                //**Accrual Details stepper
                bi.WaitTime(5);

                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(obj_program.ErrorChooseAccrualType))
                {
                    bi.WaitVisible(obj_program.Accrual_Flat);
                    bi.Click(obj_program.Accrual_Flat);
                    Console.WriteLine("PRG NEGATIVE: Accrual Type option selected");
                }
                bi.WaitTime(5);

                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(obj_program.ErrorChooseAccrualPeriod))
                {
                    bi.WaitVisible(obj_program.Accrual_Flat_Annual);
                    bi.Click(obj_program.Accrual_Flat_Annual);
                    Console.WriteLine("PRG NEGATIVE: Accrual Period option selected");
                }
                bi.WaitTime(5);

                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(obj_program.ErrorLastTranDate))
                {
                    DateSelection dsTran = new DateSelection(Driver);

                    bi.WaitVisible(obj_program.TransactionDate);
                    bi.Click(obj_program.TransactionDate);
                    bi.WaitTime(5);
                    bi.Click(obj_program.LastTranDateSelection(dsTran.Ace_DateSelection_prgTranDate(),Driver));
                    Console.WriteLine("PRG NEGATIVE: Program Last Transaction Date selected");
                }
                bi.WaitTime(5);

                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                if (bi.IsElementPresent(obj_program.ErrorExpirationDate))
                {
                    DateSelection dsExp = new DateSelection(Driver);

                    bi.WaitVisible(obj_program.ExpirationDate);
                    bi.Click(obj_program.ExpirationDate);
                    bi.WaitTime(5);
                    bi.Click(obj_program.ExpirationDateSelection(dsExp.Ace_DateSelection_prgExpirationDate(),Driver));
                    Console.WriteLine("PRG NEGATIVE: Program Expiration Date selected");
                }
                bi.WaitTime(5);

                bi.ClickJavaScript(obj_program.NextButton);

                //**Reimbursement stepper
                bi.WaitTime(5);
                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                if (bi.IsElementPresent(obj_program.ErrorChooseReimbursementType))
                {
                    bi.WaitVisible(obj_program.Reimbursement_Fixed);
                    bi.Click(obj_program.Reimbursement_Fixed);
                    Console.WriteLine("PRG NEGATIVE: Reimbursement Type selected");
                }
                bi.WaitTime(5);

                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                bi.WaitTime(5);

                if (bi.IsElementPresent(obj_program.ErrorFixedReimbursementRate))
                {
                    bi.WaitVisible(obj_program.ReimburseFixedPercent);
                    bi.Clear(obj_program.ReimburseFixedPercent);
                    bi.Type(obj_program.ReimburseFixedPercent, "90");
                    Console.WriteLine("PRG NEGATIVE: Reimbursement Percentage entered");
                }
                bi.WaitTime(5);

                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                bi.WaitTime(5);

                if (bi.IsElementPresent(obj_program.ErrorCapping))
                {
                    bi.WaitVisible(obj_program.CappingNo);
                    bi.Click(obj_program.CappingNo);
                    Console.WriteLine("PRG NEGATIVE: Capping option selected");
                }
                bi.WaitTime(5);

                bi.WaitVisible(obj_program.NextButton);
                bi.ClickJavaScript(obj_program.NextButton);
                bi.WaitTime(5);

                if (bi.IsElementPresent(obj_program.ErrorActivitySelect))
                {
                    obj_program.ActivityOption("Direct Mail",Driver);
                    Console.WriteLine("PRG NEGATIVE: Activity option selected");
                }
                bi.WaitTime(5);

                if (bi.IsElementPresent(obj_program.NextButton))
                { bi.ClickJavaScript(obj_program.NextButton); }

                //**Preview stepper
                bi.WaitTime(5);
                if (bi.IsElementPresent(obj_program.SubmitButton))
                {
                    Console.WriteLine("PRG NEGATIVE: Button to submit Program is present");
                    Console.WriteLine("PRG NEGATIVE: All the error messages are displayed");
                }

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
                Console.WriteLine("Program_NegativeScenario_ErrorMsgs " + ex);
                Assert.Fail("Program_NegativeScenario_ErrorMsgs " + ex);
            }
        }



        //Verifying Program display for LME Users
        public void validateProgramDisplayingforLMEUsersOnDashBoard(String ProgramName)
        {
            bool flag = false;
            try
            {
                bi.WaitTillNotVisible(obj_program.imgLoading);
                bi.WaitTillNotVisible(obj_program.LoadingEllipseImage);
                bi.WaitTime(5);
                if (bi.IsElementDisplayed(obj_program.ProgramList(ProgramName)))
                {
                    bi.Click(obj_program.ProgramList(ProgramName));
                    Console.WriteLine("Program displayed among first four");
                    flag = true;
                }
                else
                {
                    bi.WaitVisible(obj_program.OtherProgramsLink);
                    bi.Click(obj_program.OtherProgramsLink);
                    bi.WaitTime(2);
                    bi.Click(obj_program.ProgramList(ProgramName));
                    Console.WriteLine("Program displayed under dropdown");
                    flag = true;
                }

                Assert.IsTrue(flag);
                Console.WriteLine("Program is displaying for LME users on fundsnapshot");

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
                Console.WriteLine("Program_NegativeScenario_FundSnapshot " + ex);
                Assert.Fail("Program_NegativeScenario_FundSnapshot " + ex);
            }
        }


        //Checking program creation Nonavailability for LME users
        public void VerifyProgramCreationPermissionNonAvailabilityForLMEUser()
        {
           
            try
            {
                bi.WaitVisible(obj_program.leftNavProgram);
                bi.Click(obj_program.leftNavProgram);
                bi.WaitTillNotVisible(obj_program.imgLoading);
                bi.WaitTime(5);
                Assert.IsFalse(bi.IsElementPresent(obj_program.btnNewprogram));
                //{
                    Console.WriteLine("Program Creation is not available for LME Users");
                //}
                //else
                //{
                //    Console.WriteLine("Program is not present on left navigation pane");
                //    Console.WriteLine("User cannot Create a Program");
                //}

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Program_NegativeScenario_LeftNavValidation " + ex);
                Assert.Fail("Program_NegativeScenario_LeftNavValidation " + ex);
            }
        }

    }
}
