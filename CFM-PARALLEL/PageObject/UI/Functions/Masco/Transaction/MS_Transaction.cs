using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFMAutomation.Common;
using NUnit.Framework;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Masco
{
    public class MS_Transaction
    {
        private OBJ_Dashboard obj_Dashboard;
        private OBJ_Transactions oBJ_Transactions;

        public MS_Transaction()
        {
            obj_Dashboard = new OBJ_Dashboard();
            oBJ_Transactions = new OBJ_Transactions();
        }

        public void Validate_Transaction()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(oBJ_Transactions.LeftNavTransaction);
                Pages.BasicInteractions().Click(oBJ_Transactions.LeftNavTransaction);
                Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Validate Accrual
                Pages.BasicInteractions().Click(oBJ_Transactions.TranAccrual);
                Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidatePageLabelValues("Program");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Store");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Period");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Amount");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Comments (Optional)");

                Pages.BasicInteractions().Click(oBJ_Transactions.LeftNavTransaction);
                Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);

                //Validate Adjustment
                Pages.BasicInteractions().WaitVisible(oBJ_Transactions.TranAdjustment);
                Pages.BasicInteractions().Click(oBJ_Transactions.TranAdjustment);
                Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidatePageLabelValues("Program");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Store");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Period");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Amount");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Comments (Optional)");

                Pages.BasicInteractions().Click(oBJ_Transactions.LeftNavTransaction);
                Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);

                //Validate Transaction
                Pages.BasicInteractions().WaitVisible(oBJ_Transactions.TranTransfer);
                Pages.BasicInteractions().Click(oBJ_Transactions.TranTransfer);
                Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidatePageLabelValues("Program");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Store");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Comments (Optional)");
                Console.WriteLine("Asserting for TransferAmount label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(oBJ_Transactions.TransferAmountLabel) + "Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(oBJ_Transactions.TransferAmountLabel));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Validate_Transaction method: " + ex.Message);
                throw;
            }
        }

        public void Process_Transaction(string TransactionType)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(oBJ_Transactions.LeftNavTransaction);
                Pages.BasicInteractions().Click(oBJ_Transactions.LeftNavTransaction);
                Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);

                //Validate Accrual
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                if (TransactionType == "Accrual")
                {
                    Pages.BasicInteractions().Click(oBJ_Transactions.TranAccrual);
                    TransactionsWorkFlow("Accrual");
                }
                else if (TransactionType == "Adjustments")
                {
                    Pages.BasicInteractions().Click(oBJ_Transactions.TranAdjustment);
                    TransactionsWorkFlow("Adjustments");
                }
                else if (TransactionType == "Transfers")
                {
                    Pages.BasicInteractions().Click(oBJ_Transactions.TranTransfer);
                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.SourceProgramNameDropdown);
                    Pages.BasicInteractions().Click(oBJ_Transactions.SourceProgramNameDropdown);
                    Pages.BasicInteractions().WaitTime(1);
                    Pages.BasicInteractions().Type(oBJ_Transactions.ProgramNameText, Parameters.MS_ProgramName);
                    Pages.BasicInteractions().WaitTime(1);
                    Pages.BasicInteractions().Click(oBJ_Transactions.ProgramNameTextOption(Parameters.MS_ProgramName));
                    Pages.BasicInteractions().WaitTime(5);

                    Pages.BasicInteractions().Click(oBJ_Transactions.DestinationProgramNameDropdown);
                    Pages.BasicInteractions().WaitTime(1);
                    Pages.BasicInteractions().Type(oBJ_Transactions.ProgramNameText, Parameters.MS_ProgramName);
                    Pages.BasicInteractions().WaitTime(1);
                    Pages.BasicInteractions().Click(oBJ_Transactions.ProgramNameTextOption(Parameters.MS_ProgramName));
                    Pages.BasicInteractions().WaitTime(5);

                    Pages.BasicInteractions().Click(oBJ_Transactions.SourceLMEDropdown);
                    Pages.BasicInteractions().WaitTime(1);
                    Pages.BasicInteractions().Type(oBJ_Transactions.SourceLMEText, Parameters.MS_StoreName);
                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_StoreName));
                    Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_StoreName));

                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(oBJ_Transactions.DestinationLMEDropdown);
                    Pages.BasicInteractions().WaitTime(1);
                    Pages.BasicInteractions().Type(oBJ_Transactions.DestinationLMEText, Parameters.MS_FR_StoreName);
                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_FR_StoreName));
                    Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_FR_StoreName));
                    Pages.BasicInteractions().WaitTime(2);

                    Pages.BasicInteractions().Click(oBJ_Transactions.AccrualAmount);
                    Pages.BasicInteractions().Type(oBJ_Transactions.AccrualAmount, Parameters.MS_RequestedAmount);

                    Pages.BasicInteractions().Click(oBJ_Transactions.PeriodDropdown);
                    Pages.BasicInteractions().WaitTime(1);
                    Pages.BasicInteractions().Click(oBJ_Transactions.PeriodTextFirstOption);

                    Pages.BasicInteractions().Click(oBJ_Transactions.ButtonPreview);
                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.SubmitButton);
                    Pages.BasicInteractions().Click(oBJ_Transactions.SubmitButton);

                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.SuccessMessageText);
                    Console.WriteLine("Asserting for Succesfully Transfer_transaction inside Process_Transaction method");
                    Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(oBJ_Transactions.SuccessMessageText));

                    Pages.BasicInteractions().Click(oBJ_Transactions.BackToTansactions);
                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.LeftNavDashboard);
                    Pages.BasicInteractions().Click(oBJ_Transactions.LeftNavDashboard);
                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.ViewDetailedReport);
                    Pages.BasicInteractions().Click(oBJ_Transactions.ViewDetailedReport);
                    Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                    if (!Pages.BasicInteractions().IsElementDisplayed(obj_Dashboard.NewFundDetailFundOverview))
                    {
                        Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailSlideButton);
                        Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailFundOverview);

                    }
                    Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailProgramDropdown);
                    Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailProgramDropdown);
                    Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailProgramTextbox);
                    Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailProgramTextbox);
                    Pages.BasicInteractions().Type(obj_Dashboard.NewFundDetailProgramTextbox, Parameters.MS_ProgramName);

                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_ProgramName));
                    Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_ProgramName));
                    Pages.BasicInteractions().WaitTime(2);

                    Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailStoreDropdown);
                    Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailStoreDropdown);
                    Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailStoreTextbox);
                    Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailStoreTextbox);
                    Pages.BasicInteractions().Type(obj_Dashboard.NewFundDetailStoreTextbox, Parameters.MS_StoreName);

                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_StoreName));
                    Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_StoreName));
                    Pages.BasicInteractions().WaitTime(2);

                    Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailApplyFilter);
                    Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();


                    Pages.BasicInteractions().Click(obj_Dashboard.TranscationSummaryDropdown);
                    Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction("Transferred"));
                    Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);
                    Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.FirstrowAmount);
                    String amountWithOutDollar = Pages.BasicInteractions().GetText(oBJ_Transactions.FirstrowAmount).Split('$')[1];
                    String amountWithOutBracket = amountWithOutDollar.Replace("(", "").Replace(")", "").Replace(",", "");
                    double actualAmount = Double.Parse(amountWithOutBracket);
                    Console.WriteLine("Asserting for expected and actual transferred amount inside Process_Transaction method");
                    Assert.AreEqual(Double.Parse(Parameters.MS_RequestedNegativeAmount.Replace("-", "")), actualAmount);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Process_Transaction method: " + ex.Message);
                throw;
            }
        }

        private void TransactionsWorkFlow(string TransactionType)
        {
            double actualAmount;

            Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            Pages.BasicInteractions().Click(oBJ_Transactions.ProgramNameDropdown);
            Pages.BasicInteractions().WaitTime(1);
            Pages.BasicInteractions().Click(oBJ_Transactions.ProgramNameTextOption(Parameters.MS_ProgramName));
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            Pages.BasicInteractions().Click(oBJ_Transactions.LMEDropdown);
            Pages.BasicInteractions().WaitTime(1);
            Pages.BasicInteractions().Type(oBJ_Transactions.LMEText, Parameters.MS_FR_StoreName);
            Pages.BasicInteractions().WaitVisible(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_FR_StoreName));
            Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_FR_StoreName));
            Pages.BasicInteractions().WaitTime(2);

            Pages.BasicInteractions().Click(oBJ_Transactions.PeriodDropdown);
            Pages.BasicInteractions().WaitTime(1);
            Pages.BasicInteractions().Click(oBJ_Transactions.PeriodTextFirstOption);
            Pages.BasicInteractions().WaitTime(1);

            Pages.BasicInteractions().Click(oBJ_Transactions.AccrualAmount);
            if (TransactionType == "Accrual")
                Pages.BasicInteractions().Type(oBJ_Transactions.AccrualAmount, Parameters.MS_RequestedAmount);
            else
                Pages.BasicInteractions().Type(oBJ_Transactions.AccrualAmount, Parameters.MS_RequestedNegativeAmount);

            Pages.BasicInteractions().Click(oBJ_Transactions.ButtonPreview);
            Pages.BasicInteractions().WaitVisible(oBJ_Transactions.SubmitButton);
            Pages.BasicInteractions().Click(oBJ_Transactions.SubmitButton);

            Pages.BasicInteractions().WaitVisible(oBJ_Transactions.SuccessMessageText);
            Console.WriteLine("Asserting for successful transaction inside Process_Transaction method");
            Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(oBJ_Transactions.SuccessMessageText));

            Pages.BasicInteractions().Click(oBJ_Transactions.BackToTansactions);
            Pages.BasicInteractions().WaitVisible(oBJ_Transactions.LeftNavDashboard);
            Pages.BasicInteractions().Click(oBJ_Transactions.LeftNavDashboard);
            Pages.BasicInteractions().WaitVisible(oBJ_Transactions.ViewDetailedReport);
            Pages.BasicInteractions().Click(oBJ_Transactions.ViewDetailedReport);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            if (!Pages.BasicInteractions().IsElementDisplayed(obj_Dashboard.NewFundDetailFundOverview))
            {
                Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailSlideButton);
                Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailFundOverview);

            }
            Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailProgramDropdown);
            Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailProgramDropdown);
            Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailProgramTextbox);
            Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailProgramTextbox);
            Pages.BasicInteractions().Type(obj_Dashboard.NewFundDetailProgramTextbox, Parameters.MS_ProgramName);

            Pages.BasicInteractions().WaitVisible(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_ProgramName));
            Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_ProgramName));
            Pages.BasicInteractions().WaitTime(2);

            Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailStoreDropdown);
            Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailStoreDropdown);
            Pages.BasicInteractions().WaitVisible(obj_Dashboard.NewFundDetailStoreTextbox);
            Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailStoreTextbox);
            Pages.BasicInteractions().Type(obj_Dashboard.NewFundDetailStoreTextbox, Parameters.MS_FR_StoreName);

            Pages.BasicInteractions().WaitVisible(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_FR_StoreName));
            Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction(Parameters.MS_FR_StoreName));
            Pages.BasicInteractions().WaitTime(2);

            Pages.BasicInteractions().Click(obj_Dashboard.NewFundDetailApplyFilter);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();


            if (TransactionType == "Accrual")
            {
                Pages.BasicInteractions().Click(obj_Dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction("Accrued"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().WaitVisible(oBJ_Transactions.FirstrowAmount);
                actualAmount = Double.Parse(Pages.BasicInteractions().GetText(oBJ_Transactions.FirstrowAmount).Split('$')[1]);
                Console.WriteLine("Asserting for expected and actual accrued amount inside Process_Transaction method");
                Assert.AreEqual(Double.Parse(Parameters.MS_RequestedAmount), actualAmount);
            }
            else // for adjustment
            {
                {
                    Pages.BasicInteractions().Click(obj_Dashboard.TranscationSummaryDropdown);
                    Pages.BasicInteractions().Click(oBJ_Transactions.DropdownOption_Transaction("Adjusted"));
                    Pages.BasicInteractions().WaitTillNotVisible(obj_Dashboard.ImgLoading);
                    Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.FirstrowAmount);
                    String amountWithOutDollar = Pages.BasicInteractions().GetText(oBJ_Transactions.FirstrowAmount).Split('$')[1];
                    String amountWithOutBracket = amountWithOutDollar.Replace("(", "").Replace(")", "").Replace(",", "");
                    actualAmount = Double.Parse(amountWithOutBracket);
                    Console.WriteLine("Asserting for expected and actual adjusted amount inside Process_Transaction method");
                    Assert.AreEqual(Double.Parse(Parameters.MS_RequestedNegativeAmount.Replace("-", "")), actualAmount);
                }
            }
        }
    }
}
