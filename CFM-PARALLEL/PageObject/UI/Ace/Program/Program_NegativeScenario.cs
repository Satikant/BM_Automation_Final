using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFMAutomation.Common;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Program
{
    public class Program_NegativeScenario
    {
        private IWebDriver Driver { get; set; }
        public Program_NegativeScenario()
        {
           
        }

        public By LeftNavAddProgram { get { return (By.Id("prgEdit")); } }
        public By FundSnapshotSection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Fund Snapshot')]")); } }
        public By ProgramList(string prgname) { return (By.XPath("//ul[contains(@class,'nav nav-tabs')]//li//a[contains(.,'" + prgname + "')]")); }
        public By OtherProgramsLink { get { return (By.PartialLinkText("Other Programs")); } }

        //Error messages for Program creation screens
        public By ErrorPrgName { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Program name is required')]")); } }
        public By ErrorPrgCurrency { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Program Currency is required')]")); } }
        public By ErrorPrgStartDate { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Start Date is required')]")); } }
        public By ErrorPrgEnddate { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'End Date is required')]")); } }
        public By ErrorFundDistriHierarchy { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Fund Distribution Hierarchy is required')]")); } }
        public By ErrorClaimFlow { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Claim Flow is required')]")); } }
        public By ErrorAllowOverdraft { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Please select an option')]")); } }
        public By ErrorChooseAccrualType { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Please select an option')]")); } }
        public By ErrorChooseAccrualPeriod { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Please select an option')]")); } }
        public By ErrorLastTranDate { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Last Transaction Date is required')]")); } }
        public By ErrorExpirationDate { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Expiration Date is required')]")); } }
        public By ErrorExpirationDateValidation { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Expiration Date must be greater than Last Transaction Date')]")); } }
        public By ErrorChooseReimbursementType { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Reimbursement Type is required')]")); } }
        public By ErrorFixedReimbursementRate { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Fixed Reimbursement % is required')]")); } }
        public By ErrorCapping { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Please select an option')]")); } }
        public By ErrorActivitySelect { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p[contains(.,'Please select atleast one Activity')]")); } }
        public By leftNavProgram { get { return By.Id("prgProgramSnapshot"); } }
        //public By LeftNavAddProgram { get { return (By.Id("prgEdit")); } }
        public By btnNewprogram { get { return By.XPath("//button[contains(@class,'primary-button') and contains(.,'New Program')]"); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        /// <summary>
        /// 
        /// </summary>
        public void Program_NegativeScenario_LeftNavValidation()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_NegativeScenario));
            try
            {
                bi.WaitVisible(leftNavProgram);
                bi.Click(leftNavProgram);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(5);
                if (bi.IsElementPresent(btnNewprogram))
                {
                    Console.WriteLine("Program is pesent on left navigation pane");
                }
                else
                {
                    Console.WriteLine("Program is not present on left navigation pane");
                    Console.WriteLine("User cannot Create a Program");
                }

            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Program_NegativeScenario_LeftNavValidation " + ex);
                throw;
            }
        }

        public void Program_NegativeScenario_FundSnapshot()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            OBJ_Transactions ot = new OBJ_Transactions();
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_NegativeScenario));
            try
            {
                bi.WaitTillNotVisible(ot.imgLoadingSnapshot);
                if (bi.IsElementDisplayed(ProgramList(Parameters.Ace_ProgramName())))
                {
                    bi.Click(ProgramList(Parameters.Ace_ProgramName()));
                    Console.WriteLine("Program displayed among first four");
                }
                else
                {
                    bi.WaitVisible(OtherProgramsLink);
                    bi.Click(OtherProgramsLink);
                    bi.WaitTime(2);
                    bi.Click(ProgramList(Parameters.Ace_ProgramName()));
                    Console.WriteLine("Program displayed under dropdown");
                }

            }
            catch (Exception ex)
            {
              
                Console.WriteLine("Program_NegativeScenario_FundSnapshot " + ex);
                throw;
            }
        }

        public void Program_NegativeScenario_ErrorMsgsValidation()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            Program_ProgramDetails program_ProgramDetails = new Program_ProgramDetails(Driver);
            Program_ProgramsFlow program_ProgramsFlow = new Program_ProgramsFlow(Driver);
            Program_AccrualDetails program_AccrualDetails = new Program_AccrualDetails(Driver);
            Program_Reimbursement program_Reimbursement = new Program_Reimbursement(Driver);
            Program_Preview program_Preview = new Program_Preview(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_NegativeScenario));
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(leftNavProgram);
                bi.Click(leftNavProgram);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(5);
                //Clicking on New Program
                bi.WaitVisible(btnNewprogram);
                bi.Click(btnNewprogram);

                bi.WaitVisible(program_ProgramDetails.NextButton);
                Console.WriteLine("TESTING NEGATIVE SCENARIO FOR PROGRAM CREATION");
                //Start creating one program and first click on the Next button
                bi.Click(program_ProgramDetails.NextButton);
                bi.WaitTime(5);
                if(bi.IsElementPresent(ErrorPrgName))
                {
                    bi.Type(program_ProgramDetails.ProgramName,"ProgramForNegativeScenario");
                    Console.WriteLine("PRG NEGATIVE: Program name entered");
                    bi.Type(program_ProgramDetails.ProgramDesc,"ProgramForNegativeScenario description");
                    Console.WriteLine("PRG NEGATIVE: Program description entered");
                }
                bi.WaitTime(3);
                bi.ClickJavaScript(program_ProgramDetails.NextButton);
                bi.WaitTime(5);
                
                if (bi.IsElementPresent(ErrorPrgStartDate))
                {
                    DateSelection dsStart = new DateSelection();

                    bi.WaitVisible(program_ProgramDetails.StartDate);
                    bi.Click(program_ProgramDetails.StartDate);
                    //bi.WaitTime(2);
                    bi.Click(program_ProgramDetails.StartDateSelection(dsStart.Ace_DateSelection_prgStartDate()));
                    Console.WriteLine("PRG NEGATIVE: Program Start Date selected");
                }
                bi.WaitTime(3);
                bi.Click(program_ProgramDetails.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorPrgEnddate))
                {
                    DateSelection dsEnd = new DateSelection();
                    

                    bi.WaitVisible(program_ProgramDetails.EndDate);
                    bi.Click(program_ProgramDetails.EndDate);
                    bi.WaitTime(5);
                    bi.Click(program_ProgramDetails.EndDateSelection(dsEnd.Ace_DateSelection_prgEndDate()));
                    Console.WriteLine("PRG NEGATIVE: Program End Date selected");
                }
                bi.WaitTime(3);
                bi.ClickJavaScript(program_ProgramDetails.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorPrgCurrency))
                {
                    bi.WaitVisible(program_ProgramDetails.ProgramCurrencyDropdown);
                    bi.Click(program_ProgramDetails.ProgramCurrencyDropdown);
                    bi.WaitVisible(program_ProgramDetails.ProgramCurrencyText);
                    bi.TypeClear(program_ProgramDetails.ProgramCurrencyText, "$");
                    bi.Type(program_ProgramDetails.ProgramCurrencyText, Keys.Enter);

                    //bi.WaitVisible(program_ProgramDetails.ProgramCurrencyTextOption);
                    //bi.Click(program_ProgramDetails.ProgramCurrencyTextOption);
                    Console.WriteLine("PRG NEGATIVE: Currency selected");
                }
                bi.Click(program_ProgramDetails.NextButton);
                bi.WaitTime(5);
                //Programs Flow stepper
                bi.WaitTime(5);
                bi.WaitVisible(program_ProgramsFlow.NextButton);
                bi.Click(program_ProgramDetails.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorClaimFlow))
                {
                    bi.WaitVisible(program_ProgramsFlow.ClaimFlow);
                    bi.Click(program_ProgramsFlow.ClaimFlow);
                    Console.WriteLine("PRG NEGATIVE: Claim Flow selected");
                }
                bi.WaitVisible(program_ProgramsFlow.NextButton);
                bi.Click(program_ProgramDetails.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorFundDistriHierarchy))
                {
                    bi.WaitVisible(program_ProgramsFlow.FundOrganizationHierarchy);
                    bi.Click(program_ProgramsFlow.FundOrganizationHierarchy);
                    Console.WriteLine("PRG NEGATIVE: Fund Distribution Hierarchy selected");
                }
                bi.WaitVisible(program_ProgramsFlow.NextButton);
                bi.Click(program_ProgramsFlow.NextButton);
                bi.WaitTime(5);
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
                //if (bi.IsElementPresent(ErrorAllowOverdraft))
                //{

                    bi.WaitVisible(program_ProgramsFlow.OverdraftYes);
                    bi.Click(program_ProgramsFlow.OverdraftYes);
                    Console.WriteLine("PRG NEGATIVE: Claims overdraft option selected");
                //}
                    bi.WaitVisible(program_ProgramsFlow.BrandingApprovalsYes);
                    bi.Click(program_ProgramsFlow.BrandingApprovalsYes);
                    Console.WriteLine("PRG NEGATIVE: BPA option selected");

                    bi.WaitVisible(program_ProgramsFlow.EComYes);
                    bi.Click(program_ProgramsFlow.EComYes);
                    Console.WriteLine("PRG NEGATIVE: E-COM option selected");

                //}
                bi.Click(program_ProgramDetails.NextButton);
                bi.WaitTime(5);

                //**Accrual Details stepper
                Program_AccrualDetails prgAccrualdetails = new Program_AccrualDetails(Driver);
                bi.WaitTime(5);
                bi.WaitVisible(program_AccrualDetails.NextButton);
                bi.Click(program_AccrualDetails.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorChooseAccrualType))
                {
                    bi.WaitVisible(program_AccrualDetails.Accrual_Flat);
                    bi.Click(program_AccrualDetails.Accrual_Flat);
                    Console.WriteLine("PRG NEGATIVE: Accrual Type option selected");
                }
                bi.WaitVisible(program_AccrualDetails.NextButton);
                bi.Click(program_AccrualDetails.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorChooseAccrualPeriod))
                {
                    bi.WaitVisible(program_AccrualDetails.Accrual_Flat_Annual);
                    bi.Click(program_AccrualDetails.Accrual_Flat_Annual);
                    Console.WriteLine("PRG NEGATIVE: Accrual Period option selected");
                }
                bi.WaitVisible(program_AccrualDetails.NextButton);
                bi.Click(program_AccrualDetails.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorLastTranDate))
                {
                    DateSelection dsTran = new DateSelection();

                    bi.WaitVisible(program_AccrualDetails.TransactionDate);
                    bi.Click(program_AccrualDetails.TransactionDate);
                    bi.WaitTime(5);
                    bi.Click(prgAccrualdetails.LastTranDateSelection(dsTran.Ace_DateSelection_prgTranDate()));
                    Console.WriteLine("PRG NEGATIVE: Program Last Transaction Date selected");
                }
                bi.WaitVisible(program_AccrualDetails.NextButton);
                bi.Click(program_AccrualDetails.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorExpirationDate))
                {
                    DateSelection dsExp = new DateSelection();

                    bi.WaitVisible(program_AccrualDetails.ExpirationDate);
                    bi.Click(program_AccrualDetails.ExpirationDate);
                    bi.WaitTime(5);
                    bi.Click(prgAccrualdetails.ExpirationDateSelection(dsExp.Ace_DateSelection_prgExpirationDate()));
                    Console.WriteLine("PRG NEGATIVE: Program Expiration Date selected");
                }
                bi.Click(program_AccrualDetails.NextButton);

                //**Reimbursement stepper
                bi.WaitTime(5);
                bi.WaitVisible(program_Reimbursement.NextButton);
                bi.Click(program_Reimbursement.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorChooseReimbursementType))
                {
                    bi.WaitVisible(program_Reimbursement.Reimbursement_Fixed);
                    bi.Click(program_Reimbursement.Reimbursement_Fixed);
                    Console.WriteLine("PRG NEGATIVE: Reimbursement Type selected");
                }
                bi.WaitVisible(program_Reimbursement.NextButton);
                bi.Click(program_Reimbursement.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorFixedReimbursementRate))
                {
                    bi.WaitVisible(program_Reimbursement.ReimburseFixedPercent);
                    bi.Clear(program_Reimbursement.ReimburseFixedPercent);
                    bi.Type(program_Reimbursement.ReimburseFixedPercent,"75");
                    Console.WriteLine("PRG NEGATIVE: Reimbursement Percentage entered");
                }
                bi.WaitVisible(program_Reimbursement.NextButton);
                bi.Click(program_Reimbursement.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorCapping))
                {
                    bi.WaitVisible(program_Reimbursement.CappingNo);
                    bi.Click(program_Reimbursement.CappingNo);
                    Console.WriteLine("PRG NEGATIVE: Capping option selected");
                }
                bi.WaitVisible(program_Reimbursement.NextButton);
                bi.Click(program_Reimbursement.NextButton);
                bi.WaitTime(5);
                if (bi.IsElementPresent(ErrorActivitySelect))
                {
                    program_Reimbursement.ActivityOption("Direct Mail");
                    Console.WriteLine("PRG NEGATIVE: Activity option selected");
                }
                bi.WaitTime(5);

                if (bi.IsElementPresent(program_Reimbursement.NextButton))
                { bi.ClickJavaScript(program_Reimbursement.NextButton); }

                //**Preview stepper
                bi.WaitTime(5);
                if (bi.IsElementPresent(program_Preview.SubmitButton))
                {
                    Console.WriteLine("PRG NEGATIVE: Button to submit Program is present");
                    Console.WriteLine("PRG NEGATIVE: All the error messages are displayed");
                }

            }
            catch (Exception ex)
            {             
                Console.WriteLine("Program_NegativeScenario_ErrorMsgs " + ex);
                throw;
            }
        }
    }
}
