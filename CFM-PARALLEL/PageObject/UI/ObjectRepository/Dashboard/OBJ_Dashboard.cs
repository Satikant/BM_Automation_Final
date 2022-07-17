using OpenQA.Selenium;


namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard
{
    public class OBJ_Dashboard
    {
        private string finalXpath;
        public By BtnSubmit { get { return By.XPath("//button[contains(@class,'dropdown-toggle') and contains(@aria-expanded,true)]"); } }
        public By BtnSubmitClaim { get { return (By.XPath("//a[contains(@class,'submit-menu') and contains(.,'Submit Claim')]")); } }
        public By BtnSubmitFundingRequest { get { return (By.XPath("//a[contains(@class,'submit-menu') and contains(.,'Submit a Funding Request')]")); } }
        public By BtnSubmitBulkClaim { get { return (By.XPath("//a[contains(text(),'Bulk Claim')]")); } }
        public By BtnSubmitPreapprovals { get { return (By.XPath("//a[contains(@class,'submit-menu-item') and contains(.,'Submit Co-op Claim Pre-Approval')]")); } }
        public By SubmitBrandPreapproval { get { return (By.XPath("//a[contains(text(),'Submit Brand Pre-Approval')]")); } }
        public By SubmiFundPreapproval { get { return (By.XPath("//a[contains(text(),'Fund Pre-Approval')]")); } }
        public By ImgLoading { get { return By.Id("loading-image"); } }
        public By LeftNavDashboard { get { return (By.XPath("//a[@id='dashboard']/parent::li")); } }
        public By LeftNavProgram { get { return By.XPath("//a[@id='prgProgramSnapshot']/parent::li"); } }
        public By DashboardHeader { get { return (By.XPath("//h1[contains(.,'Dashboard')]")); } }
        public By DashboardSubmit { get { return (By.XPath("//span[contains(text(),'Submit')]")); } }
        public By DashboardSubmitdropdown { get { return (By.XPath("//ul[@class='dropdown-menu pull-right']")); } }
        public By DbSubmitBPA { get { return (By.XPath("//a[contains(text(),'Submit Brand Pre-Approval')]")); } }
        public By DbSubmitClaim { get { return (By.XPath("//a[contains(text(),'Submit Claim')]")); } }
        public By DbCreateDisbursement { get { return (By.XPath("//a[contains(text(),'Create Disbursement')]")); } }
        public By SubmitBPA { get { return (By.XPath("//button[contains(.,'Submit Brand Pre-Approval')]")); } }
        public By SubmitClaim { get { return (By.XPath("//button[contains(.,'Submit Claim')]")); } }
        public By BrandPreApproval { get { return (By.XPath("//span(.,'BRAND PRE-APPROVALS')")); } }
        public By BPALanding { get { return (By.XPath("//h1[contains(text(),'Submit a Brand Pre-Approval')]")); } }
        public By ClaimLanding { get { return (By.XPath("//h1[contains(.,'Create a Claim')]")); } }
        public By SubmitDisbursement { get { return (By.XPath("//button[contains(.,'Create Disbursement')]")); } }
        public By DisbursementLanding { get { return (By.XPath("//h4[contains(.,'New Disbursement')]")); } }
        public By ActivityOverviewSection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Activity Overview')]")); } }
        public By BPADashboardTotal { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[1]")); } }
        public By BPADashboardOpen { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[2]")); } }
        public By BPADashboardProcessed { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[3]")); } }
        public By ClaimsDashboardTotal { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[4]")); } }
        public By ClaimsDashboardOpen { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[5]")); } }
        public By ClaimsDashboardProcessed { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[6]")); } }
        public By FundSnapshotSection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Fund Snapshot')]")); } }
        public By FundSnapshotAccrued { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Accrued')]")); } }
        public By FundSnapshotAdjusted { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Adjusted')]")); } }
        public By FundSnapshotTransferred { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Transferred')]")); } }
        public By FundSnapshotOpenClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Open Claims')]")); } }
        public By FundSnapshotApprovedClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Open Claims')]")); } }
        public By FundSnapshotPaidClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Paid Claims')]")); } }
        public By FundSnapshotExpired { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Expired')]")); } }
        public By RecentActivitySection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Recent Activity')]")); } }
        public By RecentActivityBPA { get { return (By.XPath("//li[contains(@class,'ng-star-inserted') and contains(.,'Brand Pre-Approvals')]")); } }
        public By RecentActivityClaims { get { return (By.XPath("//li[contains(@class,'ng-star-inserted') and contains(.,'Claims')]")); } }
        public By RecentActivityDisbursement { get { return (By.XPath("//li[contains(@class,'ng-star-inserted') and contains(.,'Disbursements')]")); } }
        public By QuickLinkSection { get { return (By.XPath("(//div[contains(.,'QUICK LINKS')])[7]")); } }
        public By ProgramGuidelinesLink { get { return (By.PartialLinkText("Program Guidelines")); } }
        public By ClaimUserGuideLink { get { return (By.PartialLinkText("Claim User Guide")); } }
        public By Submit { get { return By.XPath("//button[contains(@class,'dropdown-toggle') and contains(@aria-expanded,true)]"); } }
        public By LeftNavClaim { get { return (By.XPath("//a[@id='ManageClaim']/parent::li")); } }
        public By SubmitBrandPreApproval_Button { get { return (By.XPath("//span[contains(text(),'Submit Brand Pre-Approval')]")); } }
        public By SubmitClaim_Button { get { return (By.XPath("//span[contains(text(),'Submit Claim')]")); } }

        public By ViewDetailedReportLink { get { return (By.XPath("//a[contains(text(),'View Detailed Report')]")); } }

        public By Moredetailslinktext { get { return (By.XPath("//button[contains(text(),'More Details')]")); } }

        public By Leftsidesections { get { return (By.XPath("//span[@class='middle-align']")); } }

        public By Pageh1tags { get { return (By.XPath("//div//h1")); } }

        public By Pageheadsectionvalues { get { return (By.XPath("//div[@class='mat-tab-label-content'] | //span[@class='ui-column-title ng-star-inserted']")); } }

        public By Pagelabelvalues { get { return (By.XPath("//div//label")); } }

        public By Pagebuttons { get { return (By.XPath("//div//button[@type='button'] | //div//button")); } }
        public By NavBarButton { get { return (By.XPath("//button[contains(@class,'navbar-toggle')]")); } }
        public By LnkViewDetailedReport { get { return By.XPath("//a[contains(text(),'Detailed Report')]"); } }
        public By BtnMoreDetails { get { return By.XPath("//button[contains(@class,'export-link-left') and contains(.,'Details')]"); } }
        public By TotalCredited { get { return By.XPath("//div[@id='fundDetails']/div/div[2]/div"); } }
        public By OpenCliams { get { return By.XPath("//div[@id='fundDetails']/div/div[3]/div"); } }
        public By ApprovedClaims { get { return By.XPath("//div[@id='fundDetails']/div/div[4]/div"); } }
        public By PaidClaims { get { return By.XPath("//div[@id='fundDetails']/div/div[5]/div"); } }
        public By AvailableFunds { get { return By.XPath("//div[@id='fundDetails']/div/div[6]/div"); } }
        public By FrozenFunds { get { return By.XPath("//a[contains(text(),'Frozen')]/parent::div/following-sibling::div"); } }
        public By LnkTotalClaimsCount_Pandora { get { return By.XPath("//div[contains(text(),'Total')]//following-sibling::div/a"); } }
        public By LnkOpenClaimsCount_Pandora { get { return By.XPath("//div[contains(text(),'Open')]//following-sibling::div/a"); } }
        public By LnkProcessedClaimsCount_Pandora { get { return By.XPath("//div[contains(text(),'Processed')]//following-sibling::div/a"); } }
        public By LnkTotalBPACount { get { return By.XPath("(//div[contains(text(),'Total')]//following-sibling::div/a)[1]"); } }
        public By LnkOpenBPACount { get { return By.XPath("(//div[contains(text(),'Open')]//following-sibling::div/a)[1]"); } }
        public By LnkProcessedBPACount { get { return By.XPath("(//div[contains(text(),'Processed')]//following-sibling::div/a)[1]"); } }

        public By LnkTotalClaimsCount { get { return By.XPath("(//div[contains(text(),'Total')]//following-sibling::div/a)[2]"); } }
        public By LnkOpenClaimsCount { get { return By.XPath("(//div[contains(text(),'Open')]//following-sibling::div/a)[2]"); } }
        public By LnkProcessedClaimsCount { get { return By.XPath("(//div[contains(text(),'Processed')]//following-sibling::div/a)[2]"); } }
        public By OpenClaims_Fundsnapshot { get { return By.XPath("//a[text()='Open Claims ']"); } }
        public By ProcessedClaims_Fundsnapshot { get { return By.XPath("//a[text()='Processed Claims']"); } }

        //Masco Xpath
        public By MS_BM_AdminLink { get { return By.XPath("//span[contains(text(),'BM Admin')]"); } }
        public By MS_SearchEdituser { get { return By.XPath("//a[contains(@class,'SearchEditUser')]"); } }
        public By MS_DashboardElements { get {return By.XPath(GetMS_Xpath());}}
        public By MS_DashboardAvailableFund { get { return By.XPath("//div[contains(text(),'Available Funds')]/following-sibling::div"); } }
        public By MS_ViewDetailsAvailableFund { get { return By.XPath("//label[contains(text(),'Available Funds')]/following-sibling::label"); } }
        public By MS_FirstDataRowLink { get { return By.XPath("//tbody[@class='ui-table-tbody']//tr[1]//td[1]"); } }
        public By MS_TransactionTypeLabel { get { return By.XPath("//Thead[contains(@class,'ui-table-thead')]//tr[1]//th[contains(text(),'Transaction Type')]"); } }
        public By MS_FirstRowTransactionType { get { return By.XPath("//tbody[contains(@class,'ui-table-tbody')]//tr[1]//td[4]"); } }
        public By RequestedAmount_PreviewPage { get { return By.XPath("//span[contains(text(),'Requested Amount')]/parent::div//span[contains(@class,'floatRight')]"); } }
        public By RequestedAmount_FrozenTab { get { return By.XPath("//span[contains(text(),'Requested Amount')]/parent::div//span[contains(@class,'floatRight')]"); } }

        public string GetMS_Xpath() {
            return finalXpath;
        }

        public void SetMS_ActivityOverviewXpath(string param1, string param2)
        {
            string Xpath = "//div[contains(text(),'{0}')]/parent::div//div[contains(text(),'{1}')]";
            finalXpath = string.Format(Xpath, param1, param2);
        }

        public void SetMS_RecentActivityXpath(string param1)
        {
            string Xpath = "//div[contains(text(),'Recent Activity')]/parent::div//ul[contains(@class,'nav-tabs')]//a[contains(text(),'{0}')]";
            finalXpath = string.Format(Xpath, param1);
        }

        public By NewFundDetailStoreDropdown { get { return By.XPath("//label[contains(text(),'All')]"); } }
        public By NewFundDetailStoreTextbox { get { return By.XPath("//input[@placeholder='Please Select']"); } }
        public By NewFundDetailFirstStoreOption { get { return By.XPath("//li[@role='option']"); } }
        public By NewFundDetailFundOverview { get { return By.XPath("//label[contains(text(),'Fund Overview')]"); } }
        public By NewFundDetailSlideButton { get { return By.XPath("//div[contains(@class,'slider round')]"); } }
        public By NewFundDetailApplyFilter { get { return By.XPath("//button[contains(@class,'search-button')]/parent::div[contains(@class,'hidden')]"); } }
        public By TranscationSummarylabel { get { return By.XPath("//label[contains(text(),'Transaction Summary')]"); } }
        public By TranscationSummaryDropdown { get { return By.XPath("//div[contains(@class,'transaction-summary')]//div[contains(@class,'corner-right')]"); } }
        public By DropdownOption { get { return By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all')]"); } }
        public By NewFundDetailProgramDropdown { get { return By.XPath("//div[contains(@class,'program-dropdown')]//span[contains(@class,'ui-clickable pi pi-chevron-down')]"); } }
        public By NewFundDetailProgramTextbox { get { return By.XPath("//input[contains(@class,'ui-dropdown-filter ui-inputtext')]"); } }



        //Geico Xpath

        public By RequiredProgram_Dashboard{ get { return By.XPath("//a[contains(text(),'2020 GFR Co-op Program')]"); } }
        public By TotalSpentAmount { get { return By.XPath("//div[contains(text(),'Total Spent')]/span"); } }
    }
}
