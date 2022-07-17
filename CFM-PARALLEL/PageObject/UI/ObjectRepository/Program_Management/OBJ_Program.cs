using CFM_PARALLEL.Interactions_New;
using OpenQA.Selenium;


namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.Program_Management
{
    public class OBJ_Program
    {
        public  By leftNavProgram { get { return By.Id("prgProgramSnapshot"); } }
        //public By LeftNavAddProgram { get { return (By.Id("prgEdit")); } }
        public By btnNewprogram { get { return By.XPath("//button[contains(@class,'primary-button') and contains(.,'New Program')]"); } }
        //Program Name 
        public By ProgramName { get { return (By.XPath("//input[@name='data[ProgramName]']")); } }
        public By ProgramDesc { get { return (By.XPath("//textarea[@name='data[Description]']")); } }
        //public By ProgramCurrencyDropdown { get { return (By.XPath("//div[@class='choices form-group formio-choices']")); } }
        public By ProgramCurrencyDropdown { get { return (By.XPath("//div[@data-value='Choose Currency']")); } }

        //public By ProgramCurrencyText { get { return (By.XPath("//input[@class='choices__input choices__input--cloned']")); } }
        public By ProgramCurrencyText { get { return (By.XPath("//div[contains(@class,'ProgramCurrency')]/div/div[2]/input")); } }

        public By ProgramCurrencyTextOption { get { return (By.XPath("(//div[contains(@class,'choices__list')]//div[contains(@class,'choices__item choices__item--choice choices__item--selectable is-highlighted')])")); } }
        public By StartDate { get { return (By.XPath("//div[contains(@class,'formio-component-StartDate')]/div/span")); } }
        public By EndDate { get { return (By.XPath("//div[contains(@class,'formio-component-EndDate')]/div/span")); } }
        //public By BrowseLink { get { return (By.XPath("//div[contains(@class,'fileSelector')]")); } }
        public By BrowseLink { get { return (By.PartialLinkText("browse")); } }
        public By NextButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-next')]")); } }
        public By StartDateSelection(string prgSrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgSrtDate + "')]"));
        }
        public By EndDateSelection(string prgEndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgEndDate + "')])"));
        }
        public By LoadingEllipseImage { get { return By.XPath("//img[@src='assets/images/Ellipsis.gif']"); } }
        public By ClaimFlow { get { return (By.XPath("//span[contains(.,'Activity Type')]")); } }
       
        public By FundOrganizationHierarchy { get { return (By.XPath("//label[contains(@class,'control-label form-check-label')]//span[contains(.,'Organization')]")); } }
        public By FundMatchingHierarchy { get { return (By.XPath("//label[contains(@class,'control-label form-check-label')]//span[contains(.,'Matching Fund')]")); } }
        public By FundGroupHierarchy { get { return (By.XPath("//label[contains(@class,'control-label form-check-label')]//span[contains(.,'Group Hierarchy')]")); } }
        public By OverdraftYes { get { return (By.XPath("//div[contains(@class,'formio-component-AllowClaimOverdrawn')]//span[contains(.,'Yes')]")); } }
        public By OverdraftNo { get { return (By.XPath("//div[contains(@class,'formio-component-AllowClaimOverdrawn')]//span[contains(.,'No')]")); } }
        public By BrandingApprovalsYes { get { return (By.XPath("//div[contains(@class,'formio-component-BrandingRequired')]//span[contains(.,'Yes')]")); } }
        public By BrandingApprovalsNo { get { return (By.XPath("//div[contains(@class,'formio-component-BrandingRequired')]//span[contains(.,'No')]")); } }
        public By EComYes { get { return (By.XPath("//div[contains(@class,'formio-component-AllowECom')]//span[contains(.,'Yes')]")); } }
        public By EComNo { get { return (By.XPath("//div[contains(@class,'formio-component-AllowECom')]//span[contains(.,'No')]")); } }

        //public By NextButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-next')]")); } }
        public By Accrual_Flat { get { return (By.XPath("//div[contains(@class,'formio-component-AccrualType')]//span[contains(.,'Flat')]")); } }
        public By Accrual_Rolling { get { return (By.XPath("//div[contains(@class,'formio-component-AccrualType')]//span[contains(.,'Rolling')]")); } }
        public By Accrual_Flat_Annual { get { return (By.XPath("//div[contains(@class,'formio-component-FlatAccrualPeriod')]//span[contains(.,'Annual')]")); } }
        public By Accrual_Flat_Monthly { get { return (By.XPath("//div[contains(@class,'formio-component-FlatAccrualPeriod')]//span[contains(.,'Monthly')]")); } }
        public By Accrual_Rolling_3 { get { return (By.XPath("//div[contains(@class,'formio-component-RollingAccrualPeriod')]//span[contains(.,'3 months')]")); } }
        public By Accrual_Rolling_6 { get { return (By.XPath("//div[contains(@class,'formio-component-RollingAccrualPeriod')]//span[contains(.,'6 months')]")); } }
        public By Accrual_Rolling_9 { get { return (By.XPath("//div[contains(@class,'formio-component-RollingAccrualPeriod')]//span[contains(.,'9 months')]")); } }
        public By Accrual_Rolling_12 { get { return (By.XPath("//div[contains(@class,'formio-component-RollingAccrualPeriod')]//span[contains(.,'12 months')]")); } }
        //public By TransactionDate { get { return (By.XPath("//div[contains(@class,'formio-component-LastTransactionDate')]/div/span")); } }
        public By TransactionDate { get { return (By.XPath("//*[contains(@name,'data[LastTransactionDate]')]//..//input[2]")); } }

        //public By ExpirationDate { get { return (By.XPath("//div[contains(@class,'formio-component-ExpirationDate')]/div/span")); } }
        public By ExpirationDate { get { return (By.XPath("//*[contains(@name,'data[ExpirationDate]')]//..//input[2]")); } }
        //public By NextButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-next')]")); } }
        public By StartDate_AccrualSection { get { return (By.XPath("//div[contains(@class,'formio-component-StartDate')]/div/span")); } }
        public By EndDate_AccrualSection { get { return (By.XPath("//div[contains(@class,'formio-component-EndDate')]/div/span")); } }
        public By StartDateSelection_AccrualSection(string prgSrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgSrtDate + "')]"));
        }
        public By EndDateSelection_AccrualSection(string prgEndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgEndDate + "')])"));
        }
        public By LastTranDateSelection(string prgLastTranDate, IWebDriver Driver)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            int i = 0;
            for (i = 1; i <= 6; i++)
            {
                if (bi.IsElementDisplayed(By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgLastTranDate + "')])[" + i + "]")))
                {
                    break;
                }
            }
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgLastTranDate + "')])[" + i + "]"));
        }
        public By ExpirationDateSelection(string prgExpirationDate,IWebDriver Driver)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            int i = 0;
            for (i = 1; i <= 6; i++)
            {
                if (bi.IsElementDisplayed(By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgExpirationDate + "')])[" + i + "]")))
                {
                    break;
                }
            }
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgExpirationDate + "')])[" + i + "]"));
        }


        public By Reimbursement_Fixed { get { return (By.XPath("//div[contains(@class,'formio-component-ReimbursementType')]//span[contains(.,'Fixed')]")); } }
        public By Reimbursement_Variable { get { return (By.XPath("//div[contains(@class,'formio-component-ReimbursementType')]//span[contains(.,'Variable')]")); } }
        public By CappingYes { get { return (By.XPath("//div[contains(@class,'formio-component-AllowCapping')]//span[contains(.,'Yes')]")); } }
        public By CappingNo { get { return (By.XPath("//div[contains(@class,'formio-component-AllowCapping')]//span[contains(.,'No')]")); } }
        public By ReimburseFixedPercent { get { return (By.XPath("//input[contains(@name,'data[Activities][0][FixedReimbursement]')]")); } }
        //public By NextButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-next')]")); } }
        public By ActivitySelection(string activityoption)
        {
            return (By.XPath("//label[contains(@class,'control-label form-check-label')]//span[contains(.,'" + activityoption + "')]"));
        }
        public void ActivityOption(string activityoption, IWebDriver Driver)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            bi.Click(ActivitySelection(activityoption));
        }

        public By SubmitButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-submit')]")); } }
        public By LeftNavDashboard { get { return (By.Id("dashboard")); } }
        public By SubmitClaim { get { return (By.XPath("//button[contains(.,'Submit Claim')]")); } }


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

        public By imgLoading { get { return By.Id("loading-image"); } }
        public By lnkNewProgram { get { return By.XPath("//span[contains(text(),'New Program')]"); } }

        public By Programlabel { get { return By.XPath("//h1[contains(text(),'Programs')]"); } }
        public By active { get { return By.XPath("//a[text()='Active']"); } }
        public By open { get { return By.XPath("//a[text()='Open']"); } }
        public By closed { get { return By.XPath("//a[text()='Closed']"); } }
        public By inactive { get { return By.XPath("//a[text()='Inactive']"); } }


    }


}
