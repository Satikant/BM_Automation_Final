using OpenQA.Selenium;


namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions
{
    public class OBJ_Transactions
    {
        public By Dashboard { get { return (By.Id("dashboard")); } }
        public By LeftNavTransaction { get { return (By.XPath("//a[@id='allAccruals']")); } }
        
        public By TranAccrual { get { return (By.XPath("//button[@id='accrual-btn']")); } }
        public By BackArrowLink { get { return (By.XPath("//i[contains(@class,'back-arrow')]")); } }

        public By TranAdjustment { get { return (By.XPath("//button[@id='adjustment-btn']")); } }
        public By TranTransfer { get { return (By.XPath("//button[@id='transfer-btn']")); } }
        public By ProgramNameDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'ProgramName')]")); } }
        public By ProgramNameText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])[1]")); } }
        public By ProgramNameTextOption(string ProgramName)
        {
            return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all') and @aria-label='"+ProgramName+"']"));
        }

        public By LMEDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'LMEId')]")); } }
        public By LMEText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])")); } }
        public By LMETextOption { get { return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all')]")); } }

        public By PeriodDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'Period')]")); } }
        public By PeriodText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])")); } }
        public By PeriodTextOption { get { return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all')]")); } }
        public By PeriodTextFirstOption { get { return (By.XPath("(//li[contains(@class,'ui-dropdown-item ui-corner-all')])[1]")); } }

        public By AdjustAmount { get { return (By.Id("txtAmount")); } }

        public By AccrualAmount { get { return (By.Id("txtAmount")); } }
        public By TransferAmountLabel { get { return (By.XPath("//div[contains(text(),'Transfer Amount')]")); } }
        public By TransferAmount { get { return By.XPath("//input[contains(@formcontrolname,'amount') and contains(@id,'txtAmount')]"); } }
        public By ProgramPeriodDropdownOption { get { return (By.XPath("(//mat-option[contains(@class,'mat-option')]//span)[2]")); } }
        public By AccrualComments { get { return (By.XPath("//textarea[contains(@formcontrolname,'Comment')]")); } }
        public By SubmitButton { get { return (By.XPath("//span[contains(text(),'Confirm')]")); } }
        public By BackToTansactions { get { return (By.XPath("//span[contains(text(),'Back to Transactions')]")); } }
        //public By SuccessMessageText { get { return (By.XPath("//div[contains(@class,'transaction-dialog')]//div[contains(@class,'text-container')]")); } }
        public By SuccessMessageText { get { return (By.XPath("//div[contains(@class,'transaction-dialog')]//div[contains(text(),'successfully')]")); } }
        public By LeftNavDashboard { get { return (By.XPath("//a[@id='dashboard']")); } }


        public By ProgramList(string prgname) { return (By.XPath("//ul[contains(@class,'nav nav-tabs')]//li//a[text()='"+prgname+"']")); }
        public By OtherProgramsLink { get { return (By.PartialLinkText("Other Programs")); } }
        public By FundDetailsLink { get { return (By.PartialLinkText("View Detailed Report")); } }
       
        public By AccrualStore { get { return (By.XPath("(//span[contains(@class,'ui-cell-data') and contains(.,'00020')])[1]")); } }
        public By AccruedAmount { get { return (By.XPath("(//span[contains(@class,'ui-cell-data')]//span[contains(@class,'ng-star-inserted')])[1]")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By ButtonPreview { get { return (By.XPath("//button[contains(.,'Preview')]")); } }
        public By AvailableFunds { get { return By.XPath("//div[contains(text(),'Available Funds')]/span"); } }
        public By LoadingImageSnapShot { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }
        public By LoadingImage { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }
        public By LoadingCircleFundsnapshot { get { return By.XPath("//div[contains(@class,'ui-datatable-loading-content')]"); } }

        public By SourceProgramNameDropdown { get { return (By.XPath("(//p-dropdown[contains(@formcontrolname,'ProgramName')])[1]")); } }
        public By SourceProgramNameText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])[1]")); } }
        public By SourceProgramNameTextOption (string ProgramName)
        {
                return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all') and @aria-label='" + ProgramName + "']"));
        }
        public By sourceLMEDropdownDisbaled { get { return By.XPath("(//p-dropdown[contains(@formcontrolname,'sourceLMEId')]/div[contains(@class,'disabled')])[1]"); } }

        public By SourceLMEDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'LMEId')]")); } }
        public By SourceLMEText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])")); } }
        public By SourceLMETextOption { get { return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all')]")); } }

        public By DestinationProgramNameDropdown { get { return (By.XPath("(//p-dropdown[contains(@formcontrolname,'ProgramName')])[2]")); } }
        public By DestinationProgramNameText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])")); } }
        public By DestinationProgramNameTextOption { get { return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all')]")); } }
        public By DestinationLMEDropdownDisabled { get { return By.XPath("(//p-dropdown[contains(@formcontrolname,'destinationLMEId')]/div[contains(@class,'disabled')])[1]"); } }

        public By DestinationLMEDropdown { get { return (By.XPath("(//p-dropdown[contains(@formcontrolname,'LMEId')])[2]")); } }
        public By DestinationLMEText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])")); } }
        public By DestinationLMETextOption { get { return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all')]")); } }

     

       
        public By TransferredStore { get { return (By.XPath("(//span[contains(@class,'ui-cell-data') and contains(.,'00020')])[1]")); } }
        public By TransferredAmount { get { return (By.XPath("(//span[contains(@class,'ui-cell-data')]//span[contains(@class,'ng-star-inserted')])[1]")); } }

       
        public By FundSnapshotSection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Fund Snapshot')]")); } }
        public By FundSnapshotAccrued { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Accrued')]")); } }
        public By FundSnapshotAdjusted { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Adjusted')]")); } }
        public By FundSnapshotTransferred { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Transferred')]")); } }
        public By FundSnapshotOpenClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Open Claims')]")); } }
        public By FundSnapshotApprovedClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Open Claims')]")); } }
        public By FundSnapshotPaidClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Paid Claims')]")); } }
        public By FundSnapshotExpired { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Expired')]")); } }
        public By AccrualTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Accrued')]")); } }
        public By AdjustedTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Adjusted')]")); } }
        public By TransferredTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Transferred')]")); } }
        public By OpenTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Open')]")); } }
        public By ApprovedTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Approved')]")); } }

        public By ApprovedClaimsTab { get { return (By.XPath("//div[contains(@class,'transactionTabs')]//ul//li[contains(@class,'mat-ripple') and contains(.,'Approved Claims')]")); } }

        public By PaidTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Paid')]")); } }
        public By ExpiredTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Expired')]")); } }
       
        public By imgLoadingSnapshot { get { return By.XPath("//img[@src='assets/images/Ellipsis.gif']"); } }

       
        public By ViewDetailedReport { get { return By.XPath("//a[contains(.,'View Detailed Report')]"); } }
        public By AccruedTab { get { return By.XPath("//a[contains(.,'Accrued')]"); } }
      

        public By SubmittedStartdate { get { return (By.XPath("(//p-calendar//.//input)[1]")); } }

        
        public By SubmittedEndDate { get { return (By.XPath("(//p-calendar//.//input)[2]")); } }
        
        public By StartDateSelection(string prgSrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgSrtDate + "')]"));
        }
        public By EndDateSelection(string prgEndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgEndDate + "')])"));
        }
        public By LMEdropdownDetailedReport { get { return By.XPath("//div[@class='DropId nopadding']/p-dropdown"); } }
        public By LMESearchTxtDetailedReport { get { return By.XPath("//div[@class='DropId nopadding']/p-dropdown/div/div[3]/div/input"); } }
        public By currentdate { get { return By.XPath("//a[contains(@class,'ui-state-highlight')]"); } }
        public By ApplyFilter { get { return By.XPath("//button[contains(@class,'search-button') and contains(.,'Apply Filter')]"); } }
        public By FirstrowAmount { get { return By.XPath("//tbody[contains(@class,'ui-table')]/tr[1]/td[@class='amount-column']/span[contains(@class,'ng-star-inserted')]"); } }
        public By FirstrowAmountOpenAndAppprovedClaimTab { get { return By.XPath("//tbody[contains(@class,'ui-table')]/tr[1]/td[@class='amount-column']"); } }
        public By DropdownOption_Transaction(string StoreName)
        {
            return (By.XPath("//span[contains(text(),'" + StoreName + "')]"));
        }
    }
}
