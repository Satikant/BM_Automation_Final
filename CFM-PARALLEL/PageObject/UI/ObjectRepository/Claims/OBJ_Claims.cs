using OpenQA.Selenium;

namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims
{
    public class OBJ_Claims
    {
        public By DdlStoreName { get { return By.XPath("//div[contains(@class,'LME')]"); } }
        public By TxbSearchStoreName { get { return By.XPath("//div[contains(@class,'LME')]/div/div[2]/input"); } }
        public By DdlProgramName { get { return By.XPath("//div[contains(@class,'SelectedProgram')]"); } }
        public By TxbSearchProgramName { get { return By.XPath("//div[contains(@class,'SelectedProgram')]/div/div[2]/input"); } }
        public By BtnNext3 { get { return (By.XPath("//button[contains(@class,'primary-button')]/span[contains(.,'Next')]")); } }
        public By BtnNext1 { get { return By.XPath("//button[contains(text(),'Next') and contains(@name,'data[submit]')]"); } }
        public By BtnNext2 { get { return By.XPath("//button[contains(text(),'Next') and contains(@name,'data[Next]')]"); } }
        public By TxbClaimDescription { get { return By.XPath("//input[contains(@name,'data[ClaimReference]')]"); } }
        public By DdlCampaign { get { return By.XPath("//div[contains(@class,'Campaign')]"); } }
        public By TxbSearchCampaign { get { return By.XPath("//div[contains(@class,'Campaign')]/div/div[2]/input"); } }
        public By DdlTactic { get { return By.XPath("//div[contains(@class,'Activities')]"); } }
        public By DdlMediaType { get { return By.XPath("//div[contains(@class,'MediaType')]"); } }
        public By TxbsearchMediaType { get { return By.XPath("//div[contains(@class,'MediaType')]/div/div[2]/input"); } }
        public By TxbsearchTactic { get { return By.XPath("//div[contains(@class,'Activities')]/div/div[2]/input"); } }
        public By ClaimStartdate
        {
            get
            {
                return (By.XPath("//div[contains(@class,'formio-component-StartDate')]/div"));
            }
        }
        public By ClaimEndDate
        {
            get
            {
                return (By.XPath("//div[contains(@class,'formio-component-EndDate')]/div"));
            }
        }
        public By ClaimTotalActivityCost_Pandora { get { return (By.Name("data[TotalActivityCostUser]")); } }
        public By ClaimRequestedAmount_Pandora { get { return (By.Name("data[RequestedAmountUser]")); } }
        public By ClaimTotalActivityCost { get { return (By.Name("data[TotalActivityCost]")); } }
        public By ClaimRequestedAmount { get { return (By.Name("data[RequestedAmount]")); } }
        public By ClaimAcknowledgement { get { return (By.Name("data[Acknowledgement]")); } }
        public By ClaimVendorName { get { return (By.Name("data[VendorName]")); } }
        public By ClaimRequestedAmount_bobcat { get { return By.XPath("//div[contains(text(),'Requested Amount')]"); } }
        public By ClaimStartDateSelection(string StartDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + StartDate + "')])"));
        }
        public By ClaimEndDateSelection(string EndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + EndDate + "')])[2]"));
        }
        public By PaymentDateSelection()
        {
            return (By.XPath("//td[contains(@class,'today')]//a"));
        }
        public By ClaimInvoice { get { return (By.XPath("//input[contains(@formcontrolname,'InvoiceNo')]")); } }        
        public By ClaimUpload { get { return (By.XPath("//label[contains(text(),'Upload')]")); } }
        public By ClaimComments { get { return (By.Id("txtComments")); } }
        public By InvoiceCalender { get { return By.XPath("//*[@formcontrolname='InvoiceDate']"); } }
        public By BtnInvoiceCalanderToday { get { return By.XPath("//button[contains(.,'Today')]"); } }
        public By BtnSubmit { get { return (By.XPath("//*[contains(@class,'primary-button') and contains(.,'Submit')]")); } }
        public By SubmitClaim_Claims { get { return By.Id("submitClaim"); } }
        public By BtnPrevious { get { return (By.XPath("//button[contains(.,'Previous')]")); } }
        public By ClaimSuccessfulMessage { get { return (By.XPath("//h2[contains(text(),'Successfully')]")); } }
        public By BtnDashBoard { get { return (By.Id("dashboard")); } }
        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }
        public By SearchClaim { get { return (By.Id("searchId")); } }
        public By SimpleSearchTextbox { get { return (By.XPath("//input[@type='text' and contains(@placeholder,'Search')]")); } }
        public By SimpleSearchButton { get { return (By.XPath("//span[text()='Search']")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchClaimIDTextBox { get { return (By.Id("claimId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Review')]")); } }
        public By PendingReviewCheckboxActive { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'Pending')]")); } }
        public By PaidCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Paid')]")); } }
        public By PaidCheckboxActive { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'Paid')]")); } }
        public By DeniedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Denied')]")); } }
        public By DeniedCheckboxActive { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'Denied')]")); } }
        public By ApprovedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Approved')]")); } }
        public By ApprovedCheckboxActive { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'Approved')]")); } }
        public By ResubmittedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Resubmitted')]")); } }
        public By ResubmittedCheckboxActive { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'Resubmitted')]")); } }
        public By PendingPaymentCheckbox { get { return By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Payment')]"); } }
        public By PendingPaymentCheckboxActive { get { return By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'Payment')]"); } }
        public By ClosedCheckbox { get { return By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Closed')]"); } }
        public By ClosedCheckboxActive { get { return By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'Closed')]"); } }
        public By BrandBuilderPaidCheckbox { get { return By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'BrandBuilder Paid')]"); } }
        public By BrandBuilderPaidCheckboxActive { get { return By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'BrandBuilder Paid')]"); } }
        public By ClaimSearchResult(string ClaimId) { return (By.PartialLinkText(ClaimId)); }
        public By ClaimResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'ReviewerAction')]//div//label")); } }
        public By ClaimResponse(string action) { return (By.XPath("//li[contains(@class,'ui-dropdown-item')]/span[contains(.,'" + action + "')]")); }
        public By ClaimApprovedAmount { get { return (By.Id("approvedAmount")); } }
        public By ClaimReviewCodeDropdown { get { return (By.XPath("//p-multiselect[contains(@formcontrolname,'ReviewCode')]")); } }
        public By ClaimReviewCodeText { get { return (By.XPath("//div[contains(@class,'ui-multiselect-filter-container')]//input")); } }
        public By ClaimReviewCodeTextSelect { get { return (By.XPath("(//div[contains(@class,'ui-chkbox-box ui-widget ui-corner-all ui-state-default')])[2]")); } }
        public By ClaimSendResponseButton { get { return (By.Id("sendRespond")); } }
        public By ClaimActionMessage { get { return (By.XPath("//label[contains(@contains(@class,'Approve')]")); } }
        public By ImgLoading { get { return By.Id("loading-image"); } }
        public By TblCalimFirstRowClaimID { get { return By.XPath("//label[contains(text(),'Showing')]//following::a[contains(text(),'CL-')][1]"); } }
        public By TblClaimFirstRowStatus { get { return By.XPath("//label[contains(text(),'Showing')]//following::a[contains(text(),'CL-')][1]//following::span[1]"); } }
        public By LoadingImageClaim { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }
        public By TblEmptyMessage { get { return By.XPath("//td[contains(@class,'emptymessage')]"); } }        
        public By CloneButton { get { return (By.Id("clone")); } }        
        public By Submit { get { return By.XPath("//button[contains(@class,'dropdown-toggle') and contains(@aria-expanded,true)]"); } }
        public By SubmitClaim { get { return (By.XPath("//a[contains(@class,'submit-menu') and contains(.,'Submit Claim')]")); } }       
        public By BPAForClaimYes { get { return (By.XPath("//label[contains(@class,'control-label') and contains(.,'Yes')]")); } }
        public By BPAForClaimNo { get { return (By.XPath("//label[contains(@class,'control-label') and contains(.,'No')]")); } }
        public By ClaimDropdown { get { return (By.XPath("//div[contains(@class,'LME')]/div/div[contains(@class,'form-control')]")); } }
        public By PreApprovalID { get { return By.XPath("//div[contains(@class,'PreApproval')]/div/div[contains(@class,'form-control')]"); } }
        public By ClaimText { get { return (By.XPath("(//input[contains(@class,'choices__input choices__input--cloned') and contains(@type,'text')])[2]")); } }
        public By PreApprovalIDText { get { return By.XPath("(//input[contains(@class,'choices__input choices__input--cloned') and contains(@type,'text')])[4]"); } }
        public By ClaimTextSelected { get { return (By.XPath("//div[contains(text(),'26957 - (HQ) Agway Stores')]")); } }
        public By CoOpProgramRadioSelect(string prgname)
        {
            return (By.XPath("//label[contains(.,'" + prgname + "')]"));
        }
        public By DisbIDText(string DisbID)
        {
            return (By.XPath("//span[contains(text(),'Disbursement')]/following-sibling::span[contains(text(),'"+DisbID+"')]"));
        }
        public By CoopProgram { get { return (By.XPath("//div[contains(@class,'SelectedProgram')]/div/div[contains(@class,'form-control')]")); } }
        public By CoopProgramWithBPA { get { return (By.XPath("//div[contains(@class,'BrandingProgram')]/div/div[contains(@class,'form-control')]")); } }
        public By CoopProgramText { get { return (By.XPath("(//input[contains(@class,'choices__input choices__input--cloned') and contains(@type,'text')])[3]")); } }
        public By CoopProgramTextWithBPA { get { return (By.XPath("(//input[contains(@class,'choices__input choices__input--cloned') and contains(@type,'text')])[5]")); } }
        public By NextButton { get { return (By.XPath("//button[contains(text(),'Next')]")); } }
        public By ErrorTechnical { get { return (By.XPath("//h1[contains(.,'technical error occured')]")); } }
        public By Error500Internal { get { return (By.XPath("//hi[contains(.,'Error 500: Internal Server Error')]")); } }
        public By RbtnDataEquipmentYes { get { return By.XPath("//input[contains(@name,'data[UsedEquipment]') and @value='Yes']"); } }
        public By RbtnDataEquipmentNO { get { return By.XPath("//input[contains(@name,'data[UsedEquipment]') and @value='No']"); } }
        public By ChbAknowledgeForDuplicateInvoice { get { return By.XPath("//app-dupe-check/div/p-checkbox/div/div[2]"); } }
        public By ProgramList(string prgname) { return (By.XPath("//ul[contains(@class,'nav nav-tabs')]//li//a[text()='" + prgname + "']")); }
        public By OtherProgramsLink { get { return (By.PartialLinkText("Other Programs")); } }
        public By FundDetailsLink { get { return (By.PartialLinkText("View Detailed Report")); } }
        public By AccrualTab { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'Accrued')]")); } }
        public By AccrualStore { get { return (By.XPath("(//span[contains(@class,'ui-cell-data') and contains(.,'00020')])[1]")); } }
        public By AccruedAmount { get { return (By.XPath("(//span[contains(@class,'ui-cell-data')]//span[contains(@class,'ng-star-inserted')])[1]")); } }
        public By ButtonPreview { get { return (By.XPath("//button[contains(.,'Preview')]")); } }
        public By AvailableFunds { get { return By.XPath("//div[contains(text(),'Available Funds')]/span"); } }
        public By LoadingImageSnapShot { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }        
        public By NeedsInformationCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Information')]")); } }
        public By NeedsInformationCheckboxActive { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'Information')]")); } }
        public By HoldCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Hold')]")); } }
        public By HoldCheckboxActive { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label ui-label-active') and contains(.,'Hold')]")); } }
        public By EditClaimButton { get { return (By.Id("edit")); } }
        public By ImgLoadingClaim { get { return By.XPath("//img[@src='assets/images/Ellipsis.gif']"); } }
        public By EndDateErrorMsg { get { return (By.XPath("//div[contains(@class,'formio-errors')]//p")); } }
        public By ApprovedAmountErrorMsg { get { return (By.XPath("//span[contains(@class,'alert alert-danger')]")); } }
        public By TblRowsCurrentPage { get { return By.XPath("//tbody[contains(@class,'ui-datatable')]/tr"); } }
        public By PaginationRight { get { return By.XPath("//*[contains(@class,'ui-paginator-icon pi pi-caret-right')]"); } }
        public By ErrorActivityTypeRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Tactic is required')]")); } }
        public By ErrorActivityTypeRequired_bobcat { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Activity Type is required')]")); } }
        public By ErrorStartDateRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Start Date is required')]")); } }
        public By ErrorEndDateRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'End Date is required')]")); } }
        public By ErrorTotalActivityCostReq { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Activity Cost is required')]")); } }
        public By ErrorRequestedAmountReq { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Requested Amount is required')]")); } }
        public By ErrorCampaignReq { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Please select campaign')]")); } }
        public By ErrorAknowledgementReq { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Please acknowledge to proceed')]")); } }
        public By ErrorVendorNameReq { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Please enter vendor name')]")); } }
        public By ErrorClaimFeatureReq { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Claim Feature is required')]")); } }
        public By ErrorAttachDocument { get { return (By.XPath("//div[contains(@class,'ui-growl-item')]")); } }
        public By AttachementRemove { get { return (By.XPath("//i[contains(@class,'fa fa-times-circle cursor-pointer')]")); } }     
        public By ClaimReference { get { return (By.Name("data[ClaimReference]")); } }        
        public By ClaimIDHeader { get { return (By.XPath("//div[contains(@class, 'ng-star-inserted')]/h1")); } }     
        public By SubmitButton { get { return (By.XPath("//span[contains(text(),'Submit')] ")); } }
        public By GrowlMessage { get { return (By.XPath("//div[contains(@class,'ui-growl ui-widget')]")); } }
        public By PreviousButton { get { return (By.XPath("//button[contains(.,'Previous')]")); } }
        public By Dashboard { get { return (By.Id("dashboard")); } }
        public By UploadBulkClaim { get { return (By.XPath("//label[contains(text(),'Click To Upload ')]")); } }
        public By ConfirmBulkUploadButton { get { return (By.XPath("//span[contains(text(),'Confirm Upload')]")); } }
        public By SuccessfulMessage { get { return (By.XPath("//div[contains(text(),'Successfully')]")); } }
        public By ErrorInvoiceRequired { get { return By.XPath("//div[@class='ui-toast-detail' and contains(.,'Invoice # cannot be blank')]"); } }
        public By ErrorAttachmentRequired { get { return By.XPath("//div[@class='ui-toast-detail' and contains(.,'Required at least one support document')]"); } }
        public By ErrorAttachmentRequired_bobcat { get { return By.XPath("//div[@class='ui-toast-detail' and contains(.,'Required atleast one support document')]"); } }
        public By ViewReviewButton { get { return (By.XPath("//span[text()='Review' or text()='View']")); } }
        public By EligibleAmount { get { return By.XPath("//input[contains(@name,'data[EligibleAmountUser]')]"); } }
        public By EligibleAmount_bobcat { get { return By.XPath("//input[contains(@name,'data[EligibleAmount]')]"); } }
        public By TotalActivityCostConverted { get { return By.Name("data[TotalActivityCostConverted]"); } }
        public By EligibleAmountConverted { get { return By.Name("data[EligibleAmountConverted]"); } }
        public By ReqAmountConverted { get { return By.Name("data[RequestedAmountConverted]"); } }
        public By ClaimStatusOnClaimReviewPage{ get { return By.XPath("//label[contains(text(),'Status')]/following-sibling::div[1]/label"); } }
        public By ActivityCategory{ get { return By.XPath("//label[contains(text(),'Activity Category')]/following-sibling::div[@role='combobox']"); } }
        public By ActivityCategoryTextbox{ get { return By.XPath("//label[text()='Activity Category']/parent::div//input[@type='text']"); } }
        public By ActivityType{ get { return By.XPath("//label[contains(text(),'Activity Type')]/parent::div[contains(@class,'formio-component-select') and contains(@style,'visible')]//div[@role='combobox']"); } }
        public By ActivityTypeTextbox{ get { return By.XPath("//label[contains(text(),'Activity Type')]/parent::div[contains(@class,'formio-component-select') and contains(@style,'visible')]//input[@type='text']"); } }
        public By ApprovedBrands{ get { return By.XPath("//label[contains(text(),'Approved Brands')]/parent::div[contains(@class,'formio-component-select')]//div[@role='combobox']"); } }
        public By ApprovedBrandsTextbox{ get { return By.XPath("//label[contains(text(),'Approved Brands')]/parent::div[contains(@class,'formio-component-select')]//input[@type='text']"); } }
        public By AccountNumber { get { return By.XPath("//label[contains(text(),'Account Number')]/parent::div[contains(@class,'formio-component-select')]//div[@role='combobox']"); } }
        public By AccountNumberTextbox { get { return By.XPath("//label[contains(text(),'Account Number')]/parent::div[contains(@class,'formio-component-select')]//input[@type='text']"); } }
        public By ProductType { get { return By.XPath("//label[contains(text(),'Product Type')]/following-sibling::div[@role='combobox']"); } }
        public By ProductTypeTextbox { get { return By.XPath("//label[text()='Product Type']/parent::div//input[@type='text']"); } }
        public By PendingStatusTabs { get { return (By.XPath("//li[@id='Pending']")); } }
        public By InProcessStatusTabs { get { return (By.XPath("//li[@id='InProcess']")); } }
        public By CompletedStatusTabs { get { return (By.XPath("//li[@id='Completed']")); } }
        public By DeclinedStatusTabs { get { return (By.XPath("//li[@id='Declined']")); } }
        public By ClaimIDGeneratedSuccessMessage { get { return (By.XPath("//div[contains(@class,'ng-star-inserted')]//h2")); } }
        public By FileUploadedSuccessfully { get { return (By.XPath("//i[contains(@class,'success-icon')]")); } }

       
        //AMNAT xpath
        public By AM_ActivityType { get { return (By.XPath("//label[contains(text(),'Activity Type')]/parent::div[contains(@class,'form-group has-feedback formio-component formio-component-select formio-component-Activities BR-select')]//div[@role='combobox']")); } }
        public By AM_ActivityTypeTextbox { get { return (By.XPath("//label[contains(text(),'Activity Type')]/parent::div[contains(@class,'form-group has-feedback formio-component formio-component-select formio-component-Activities BR-select')]//input[@type='text']")); } }

        //GEICO xpath
        public By SOB_Dropdown { get { return (By.XPath("//label[contains(text(),'SOB')]/following-sibling::div[@role='combobox']")); } }
        public By SOB_Textbox { get { return (By.XPath("//label[text()='SOB']/parent::div//input[@type='text']")); } }
        public By Category_Dropdown { get { return (By.XPath("//label[contains(text(),'Category')]/following-sibling::div[@role='combobox']")); } }
        public By Category_Textbox { get { return (By.XPath("//label[text()='Category']/parent::div//input[@type='text']")); } }
        public By Geico_MediaType { get { return (By.XPath("//label[contains(text(),'Media Type')]/parent::div[contains(@class,'form-group has-feedback formio-component formio-component-select formio-component-Activities BR-select')]//div[@role='combobox']")); } }
        public By Geico_MediaTypeTextbox { get { return (By.XPath("//label[contains(text(),'Media Type')]/parent::div[contains(@class,'form-group has-feedback formio-component formio-component-select formio-component-Activities BR-select')]//input[@type='text']")); } }
        public By Geico_VendorName { get { return (By.XPath("//input[@name='data[VendorName]']")); } }
        public By Geico_NextButton2 { get { return (By.XPath("//button[@name='data[Next]']")); } }
        public By PaymentDate { get { return (By.XPath("//span[contains(@class,'calendar')]//input[@type='text']")); } }

        //Farmers xpath
        public By MarketingStore { get { return (By.XPath("//div[contains(@class,'RadioAgencyStore')]//span[contains(text(),'No')]")); } }
        public By CommunityEngagement { get { return (By.XPath("//div[contains(@class,'RadioCommunityEngagement')]//span[contains(text(),'No')]")); } }
        public By AdBuilder { get { return (By.XPath("//div[contains(@class,'RadioMrktRequest')]//span[contains(text(),'Yes')]")); } }
        public By AgentName { get { return (By.XPath("//label[contains(text(),'Agent Name')]/parent::div[contains(@class,'formio-component-select') and contains(@style,'visible')]//div[@role='combobox']")); } }
        public By FundingType { get { return (By.XPath("//label[contains(text(),'Funding Type')]/parent::div[contains(@class,'formio-component-select') and contains(@style,'visible')]//div[@role='combobox']")); } }
        public By FundingTypeTextBox { get { return (By.XPath("//label[contains(text(),'Funding Type')]/parent::div[contains(@class,'formio-component-select') and contains(@style,'visible')]//input[@type='text']")); } }
        public By FR_NextButton1 { get { return (By.XPath("//button[ contains(@name,'data[submit]')]")); } }
        public By FR_NextButton2 { get { return (By.XPath("//button[ contains(@name,'data[Next]')]")); } }
        public By FR_NextButton3 { get { return (By.XPath("//button[contains(@class,'primary-button')]/span[contains(.,'NEXT')]")); } }
        public By FR_ActivityType { get { return (By.XPath("//label[contains(text(),'Activity Type')]/parent::div[contains(@class,'formio-component-Activities BR-select')]//div[contains(@class,'choices form-group formio-choices')]")); } }
        public By FR_ActivityTypeTextBox { get { return (By.XPath("//label[contains(text(),'Activity Type')]/parent::div[contains(@class,'formio-component-Activities BR-select')]//input[@type='text']")); } }
        public By FR_ActivityCost { get { return (By.XPath("//label[contains(text(),'Activity Cost')]/parent::div[contains(@class,'textfield formio-component-TotalActivityCost')]//input")); } }
        public By FR_ClaimUpload { get { return (By.XPath("//label[contains(text(),'UPLOAD')]")); } }
        public By FR_Submit { get { return (By.XPath("//span[text()='SUBMIT']/parent::span")); } }
        public By FR_SimpleSearch { get { return (By.XPath("//span[text()='SEARCH']")); } }



    }
}
