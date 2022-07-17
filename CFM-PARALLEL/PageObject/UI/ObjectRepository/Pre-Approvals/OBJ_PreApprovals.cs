using OpenQA.Selenium;
namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.Pre_Approvals
{
    class OBJ_PreApprovals
    {
        // Pre-approvals link in CFM Landing Page
        public By LeftNavPreapprovals { get { return (By.Id("brandingList")); } }
        // Submit Pre-approvals button
        public By Submit { get { return By.XPath("//button[contains(@class,'dropdown-toggle') and contains(@aria-expanded,true)]"); } }
        public By SubmitPreapprovals { get { return (By.XPath("//a[contains(@class,'submit-menu-item') and contains(.,'Brand Pre-Approval')]")); } }
        public By SubmitPreapproval_BPA { get { return By.Id("submitBranding"); } }
        //Enter Branding Reference Name
        public By BPARefName { get { return (By.XPath("//input[contains(@name,'data[BrandingReference]')]")); } }
        // Select Activity from Activity dropdown
        public By StoreDropdown
        {
            get
            {
                return (By.XPath("//div[contains(@class,'formio-component-LMEId')]//div[contains(@class,'form-control')]"));
            }
        }
        public By StoreDropdownText
        {
            get
            {
                return (By.XPath("//label[contains(text(),'Dealer')]/parent::div//input[@type='text']"));
            }
        }
        public By StoreTextbox { get { return (By.XPath("//label[contains(text(),'Store')]/parent::div//input[@type='text']")); } }
        public By StoreDropdownTextOption { get { return (By.XPath("(//div[contains(@class,'choices__list')])[1]")); } }

        public By DdlMediaType { get { return By.XPath("//div[contains(@class,'MediaType BR-select')]"); } }
        public By TxbsearchMediaType { get { return By.XPath("//div[contains(@class,'MediaType BR-select')]/div/div[2]/input"); } }

        public By ActivityDropdown { get { return By.XPath("//div[contains(@class,'Activities')]"); } }
        public By ActivityDropdownText { get { return By.XPath("//div[contains(@class,'Activities')]/div/div[2]/input"); } }
        public By ActivityTypeTextOption { get { return (By.XPath("(//div[contains(@class,'choices__list')]//div[contains(@class,'choices__item choices__item--choice choices__item--selectable is-highlighted')])[2]")); } }

        //Select Start date  
        public By Startdate { get { return By.XPath("//div[contains(@class,'formio-component-StartDate')]//div"); } }
        //Select End date
        public By Enddate { get { return By.XPath("//div[contains(@class,'formio-component-EndDate')]//div"); } }
        public By NextButton { get { return By.XPath("//button[contains(@name,'data[Next]')]"); } }
        public By BPAStartDateSelection(string SrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + SrtDate + "')]"));
        }
        public By BPAEndDateSelection(string EndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + EndDate + "')])[2]"));
        }
        public By ErrorTechnical { get { return (By.XPath("//h1[contains(.,'technical error occured')]")); } }
        public By Error500Internal { get { return (By.XPath("//hi[contains(.,'Error 500: Internal Server Error')]")); } }
        public By ImgLoading { get { return By.Id("loading-image"); } }
        public By EndDateErrorMsg { get { return (By.XPath("(//div[contains(@class,'formio-errors')]//p)[2]")); } }
        public By EndDateErrorMessage { get { return By.XPath("//div[contains(@class,'formio-errors invalid-feedback')]//p"); } }
        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }
        public By SearchClaim { get { return (By.Id("searchId")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchClaimIDTextBox { get { return (By.Id("claimId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Review')]")); } }
        public By ApprovedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Approved')]")); } }
        public By ClaimSearchResult(string ClaimId) { return (By.PartialLinkText(ClaimId)); }
        public By ClaimResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'ReviewerAction')]//div//label")); } }
        public By ClaimResponse(string action) { return (By.XPath("//li[contains(@class,'ui-dropdown-item')]/span[contains(.,'" + action + "')]")); }
        public By ClaimApprovedAmount { get { return (By.Id("approvedAmount")); } }
        public By ClaimReviewCodeDropdown { get { return (By.XPath("//p-multiselect[contains(@formcontrolname,'ReviewCode')]")); } }
        public By ClaimReviewCodeText { get { return (By.XPath("//div[contains(@class,'ui-multiselect-filter-container')]//input")); } }
        public By ClaimReviewCodeTextSelect { get { return (By.XPath("(//div[contains(@class,'ui-chkbox-box ui-widget ui-corner-all ui-state-default')])[2]")); } }
        public By ClaimComments { get { return (By.XPath("//textarea[contains(@formcontrolname,'ReviewComment')]")); } }
        public By ClaimSendResponseButton { get { return (By.Id("sendRespond")); } }
        public By ClaimActionMessage { get { return (By.XPath("//label[contains(@contains(@class,'Approve')]")); } }
        public By TblBPAFirstrow { get { return By.XPath("//tbody[contains(@class,'table')]//tr[1]/td[1]//a"); } }
        public By UploadFile { get { return (By.XPath("//label[contains(text(),'Upload')]")); } }
        //Provide Comments
        public By Comment { get { return By.XPath("//textarea[contains(@class,'textarea-comment')]"); } }
        public By SubmitButton1 { get { return By.XPath("//span[text()='Submit']"); } }
        public By SubmitButton2 { get { return By.XPath("//button[contains(text(),'Submit')]"); } }
        public By ViewPreapprovalStatus { get { return By.XPath("//div[contains(@class,'col-sm-12')]/li[2]"); } }
        public By BPAID { get { return By.XPath("//div[contains(@class,'ng-star-inserted')]/h1"); } }
        public By BPAStatus { get { return By.XPath("//div[contains(@class,'col-sm-12')]/label[2]"); } }
        //objects for cloning BPA
        public By SearchPreapprovals { get { return (By.Id("searchId")); } }
        public By BPASearchResult(string BPAID) { return (By.PartialLinkText(BPAID)); }
        public By CloneButton { get { return (By.XPath("//button[@id='clone']")); } }
        public By EditButton { get { return (By.Id("edit")); } }
        public By BPASuccessMessage { get { return (By.XPath("//div[contains(@class,'ui-toast-detail')]")); } }        
        public By AdvanceSearchBPAIDTextBox { get { return (By.Id("brandingRequestId")); } }
        public By LoadingImageBrandingPreApproval { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }        
        public By BPAResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@styleclass,'advSearch')]/div//label")); } }
        public By BPAReviewCodesDropdown { get { return (By.XPath("//label[contains(text(),'Review Codes')]/parent::div//div[contains(@class,'ui-multiselect-label-container')]")); } }
        public By BPAResponseAction(string action)
        {
            return (By.XPath("//li[contains(@class,'ui-dropdown-item')]/span[contains(.,'" + action + "')]"));
        }
        public By BPAComments { get { return (By.XPath("//textarea[contains(@class,'col-sm-4 col-md-4 ng-pristine ng-valid ng-touched')]")); } }
        public By BPASendResponseButton { get { return (By.Id("sendRespond")); } }
        public By LblStatusBPASearchResult { get { return By.XPath("//tbody[contains(@class,'ui-datatable')]/tr/td[6]/span[2]/span"); } }
        public By ErrorStoreRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Store')]")); } }
        public By ErrorActivityTypeRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Activity Type')]")); } }
        public By ErrorDealershipRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Dealership')]")); } }
        public By ErrorMediaTypeRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Media Type')]")); } }
        public By ErrorStartDateRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Start Date')]")); } }
        public By ErrorEndDateRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'End Date')]")); } }
        public By ErrorAttachDocument { get { return (By.XPath("//div[contains(@class,'ui-growl-item')]")); } }
        public By AttachementRemove { get { return (By.XPath("//i[contains(@class,'fa fa-times-circle cursor-pointer')]")); } }        
        public By ErrorInvoiceRequired { get { return By.XPath("//div[@class='ui-toast-detail' and contains(.,'Invoice # cannot be blank')]"); } }
        public By ErrorAttachmentRequired { get { return By.XPath("//div[@class='ui-toast-detail' and contains(.,'Required atleast one support document')]"); } }                      
        public By HoldCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Hold')]")); } }
        public By NeedsInformationCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Needs Information')]")); } }
        public By DeniedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Denied')]")); } }
        public By ClosedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Closed')]")); } }
        public By ResubmittedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Resubmitted')]")); } }
        public By BrandName { get { return By.XPath("//label[contains(text(),'Brand Name')]/parent::div[contains(@class,'formio-component-select')]//div[@role='combobox']"); } }
        public By BrandNameTextbox { get { return By.XPath("//label[contains(text(),'Brand Name')]/parent::div[contains(@class,'formio-component-select')]//input[@type='text']"); } }
        public By AccountNumber { get { return By.XPath("//label[contains(text(),'Account Number')]/parent::div[contains(@class,'formio-component-select')]//div[@role='combobox']"); } }
        public By AccountNumberTextbox { get { return By.XPath("//label[contains(text(),'Account Number')]/parent::div[contains(@class,'formio-component-select')]//input[@type='text']"); } }
        public By BPA_ActivityType { get { return By.XPath("//label[contains(text(),'Activity Type')]/parent::div[contains(@class,'formio-component-select')]//div[@role='combobox']"); } }
        public By BPA_ActivityTypeTextbox { get { return By.XPath("//label[contains(text(),'Activity Type')]/parent::div[contains(@class,'formio-component-select')]//input[@type='text']"); } }
        public By BPA_MediaType { get { return By.XPath("//label[contains(text(),'Media Type')]/parent::div[contains(@class,'formio-component-select')]//div[@role='combobox']"); } }
        public By BPA_MediaTypeTextbox { get { return By.XPath("//label[contains(text(),'Media Type')]/parent::div[contains(@class,'formio-component-select')]//input[@type='text']"); } }


        //FPA details
        public By SubmitFundPreApproval { get { return (By.XPath("//a[contains(text(),'Submit Fund Pre-Approval')]")); } }
        public By FPA_Program { get { return (By.XPath("//label[contains(text(),'Program')]/parent::div[contains(@class,'formio-component-select')]//div[@role='combobox']")); } }
        public By FPA_ProgramTextbox { get { return (By.XPath("//label[contains(text(),'Program')]/parent::div[contains(@class,'formio-component-select')]//input[@type='text']")); } }
        public By FPA_Store { get { return (By.XPath("//label[contains(text(),'Store')]/parent::div[contains(@class,'formio-component-select')]//div[@role='combobox']")); } }
        public By FPA_StoreTextbox { get { return (By.XPath("//label[contains(text(),'Store')]/parent::div[contains(@class,'formio-component-select')]//input[@type='text']")); } }
        public By FPA_NextButton1 { get { return (By.XPath("//button[contains(@name,'data[submit]')]")); } }
        public By FPA_NextButton2 { get { return (By.XPath("//button[contains(@name,'data[Next]')]")); } }
        public By FPA_NextButton3 { get { return (By.XPath("//span[contains(text(),'Next')]")); } }
        public By NextButton3 { get { return (By.XPath("//span[contains(text(),'Next')]/parent::span")); } }
        public By PreApprovalReferenceTextbox { get { return (By.XPath("//input[@name='data[PreApprovalReference]']")); } }
        public By FPA_StartDate { get { return (By.XPath("//label[contains(text(),'Start Date')]/parent::div//div[contains(@class,'input-group')]")); } }
        public By FPA_EndDate { get { return (By.XPath("//label[contains(text(),'End Date')]/parent::div//div[contains(@class,'input-group')]")); } }
        public By FPA_TotalActivityCost { get { return (By.XPath("//input[@name='data[TotalActivityCost]']")); } }
        public By FPA_RequestedAmount { get { return (By.XPath("//input[@name='data[EligibleAmount]']")); } }
        public By FPA_SuccessMessage { get { return (By.XPath("//div[contains(@class,'ng-star-inserted')]/h2")); } }
        public By SimpleSearchTextbox { get { return (By.XPath("//input[@type='text' and contains(@placeholder,'Search')]")); } }
        public By SimpleSearchButton { get { return (By.XPath("//span[contains(text(),'Search')]")); } }
        public By FirstRow_FPAId_Link { get { return (By.XPath("//label[contains(text(),'Showing')]//following::a[contains(text(),'PA-')][1]")); } }
        public By FPAStatus { get { return By.XPath("//label[contains(text(),'Showing')]//following::a[contains(text(),'PA-')][1]//following::span[1]"); } }
        public By LeftNavFundPreApproval { get { return By.XPath("//a[@id='ManagePreApproval']"); } }


        //AMNAT BPA details

        public By AM_SubmissionBPAOption { get { return (By.XPath("//span[contains(text(),'Submisison')]")); } }
        public By AM_BPAlabel { get { return (By.XPath("//label[contains(text(),'Is this Brand Pre-Approval a request or submission type?')]")); } }



    }
}
