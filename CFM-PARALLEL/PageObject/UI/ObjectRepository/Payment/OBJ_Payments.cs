using OpenQA.Selenium;


namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.FundRequest
{
    class OBJ_Payments
    {
        public By LeftNavFundRequest { get { return (By.XPath("//a[@id='fundrequestList']")); } }

        public By LeftNavPamentProfiles { get { return (By.XPath("//span[contains(text(),'PAYMENT PROFILES')]")); } }
        
        public By PaymentProfilesPageEftnavpageheader { get { return (By.XPath("//div[contains(text(),'Bank Accounts')]")); } }

        public By PaymentProfilesPageEftnavpageroutingnumbervaluelists { get { return (By.XPath("//div[contains(text(),'Routing Number')]//..//div")); } }

        public By PaymentProfilesPageEftnavpageaccnumvaluelists { get { return (By.XPath("//div[contains(text(),'Routing Number')]//..//..//div")); } }

        public By PaymentProfilesPagePaperchecknav { get { return (By.XPath("//span[text()='Paper Check']")); } }

        public By PaymentProfilesPagePaperchecknavpageheader { get { return (By.XPath("//div[contains(text(),'Addresses')]")); } }

        //public By PaymentProfilesPagepaperchecknavpageheadervaluelists { get { return (By.XPath("//div[contains(text(),'Addresses')]//..//div//span")); } }
        public By PaymentProfilesPagepaperchecknavpageheadervaluelists { get { return (By.XPath("//div[contains(text(),'Addresses')]//..//span")); } }

        public By PaymentProfilesPagemappaymentProfileslink { get { return (By.XPath("//span[text()='Map Payment Profiles']")); } }

        public By PaymentProfilesPageAddPaymentProfilePageheadertext { get { return (By.XPath("//h1[text()='Add Payment Profile']")); } }

        public By PaymentProfilesPageAddPaymentProfilePagePaperCheckButton { get { return (By.XPath("//div[text()='Paper Check ' or text()='Paper Check']")); } }

        public By PaymentProfilesPageAddPaymentProfileEFTButton { get { return (By.XPath("//div[text()='Electronic Funds Transfer ' or text()='Electronic Funds Transfer']")); } }

        public By PaymentProfilesPageAddPaymentProfilePageheadertext1 { get { return (By.XPath("//label[contains(text(),'Select Payment Type')]")); } }

        public By PaymentProfilesPageAddPaymentProfilePagebacktoallprofileslink { get { return (By.XPath("//*[text()='Back to all profiles']//..//i")); } }

        public By PaymentProfilesPageAddPaymentProfilePageupdateuserprofilelink { get { return (By.XPath("//*[text()='Update User Profile']")); } }

        public By PaymentProfilesPageAddPaymentProfilePageEFTsec { get { return (By.XPath("//label[contains(text(),'Enter Account Details')]")); } }

        public By PaymentProfilesPageAddPaymentProfilePageEFTpaperchecksecvaluelist { get { return (By.XPath("//div//label")); } }

        public By PaymentProfilesPageAddPaymentProfilePageEFTpapersubmitbutton { get { return (By.XPath("//button//*[text()='Submit']")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepchecksec { get { return (By.XPath("//label[contains(text(),'Enter the mailing address for Paper Check')]")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepchecksecvaluelist { get { return (By.XPath("//div//label")); } }

        public By PaymentProfilesPagepaymentProfilecreatedscucesswindow { get { return (By.XPath("//div[contains(text(),'Payment Profile Created Successfully')]")); } }

        public By PaymentProfilesPagepaymentProfilecreatedscucesswindowbacktoallprofilebutton { get { return (By.XPath("//button[contains(text(),'Back to all profiles')]")); } }

        public By PaymentProfilesPagepaymentProfilecreatedscucesswindowpaymentprofilebutton { get { return (By.XPath("//button//*[contains(text(),'Payment Profile')]")); } }

        public By PaymentProfilesPagemappaymentprofilespageheadervalue { get { return (By.XPath("//h1[text()='Map Payment Profiles']")); } }

        public By PaymentProfilesPagemappaymentprofilespagestorevalue { get { return (By.XPath("//div[@class='ui-dropdown-label-container']//label")); } }

        public By PaymentProfilesPagemappaymentprofilespageprogramnametextvalue { get { return (By.XPath("//*[contains(text(),'Program Name')]")); } }

        public By PaymentProfilesPagemappaymentprofilespagepaymentprofiletextvalue { get { return (By.XPath("//th[contains(text(),'Payment Profile')]")); } }

        public By PaymentProfilesPagemappaymentprofilespagefieldvaluelists { get { return (By.XPath("//div//tr//td")); } } //Program Name Lists

        public By PaymentProfilesPagemappaymentProfilespagePaymentProfileediticon { get { return (By.XPath("(//div//i[text()='edit'])[1]")); } }

        public By PaymentProfilesPagemappaymentProfilespagePaymentProfileeditfilterdropdown { get { return (By.XPath("(//div//p-dropdown[@filter='true'])[1]")); } }

        public By PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindow { get { return (By.XPath("//div[@class='ui-dropdown-items-wrapper']")); } }

        public By PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowprofilecountlists { get { return (By.XPath("//p-dropdownitem//li[@role='option']")); } }

        public By PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowefttextvalue { get { return (By.XPath("//div//span[text()='Electronic Funds Transfer']")); } }

        public By PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindoweftvaluelists { get { return (By.XPath("//div[@class='ui-dropdown-items-wrapper']//div")); } }

        public By PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowpaperchecktextvalue { get { return (By.XPath("//div//span[text()='Paper Check']")); } }

        public By PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowpaperchecklists { get { return (By.XPath("//div[@class='ui-dropdown-items-wrapper']//div//span")); } }

        public By PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowsavebutton { get { return (By.XPath("//button//*[text()='Save']")); } }

        //Add Payment Profile - Enter Account Details

        public By AddPaymentProfileHeader { get { return (By.XPath("//h1[contains(text(),'Add Payment Profile')]")); } }
        public By AddPaymentProfileButton { get { return (By.XPath("//button//span[text()='Payment Profile']")); } }

        public By PaymentProfilesPageAddPaymentProfilePageEFTRoutingNumberTextbox { get { return (By.XPath("//input[@type='number' and @minlength='9']")); } }

        public By PaymentProfilesPageAddPaymentProfilePageEFTAccountNumberTextbox { get { return (By.XPath("//input[@type='number' and @minlength='3' and @maxlength='17']")); } }

        public By PaymentProfilesPageAddPaymentProfilePageEFTAccountTypeDropdown { get { return (By.XPath("//label[contains(text(),'Please Select')]")); } }

        public By PaymentProfilesPageAddPaymentProfilePageEFTaccounttypedropdownvalues { get { return (By.XPath("(//p-dropdownitem//span)[1]")); } }

        public By PaymentProfilesPageAddPaymentProfilePageEFTaccounttypedropdownvalues1 { get { return (By.XPath("//p-dropdownitem//span")); } }

        //Add Payment Profile - Enter the mailing address for Paper Check

        public By PaymentProfilesPageAddPaymentProfilePagepcheckbusinessnametextbox { get { return (By.XPath("//input[@formcontrolname='BusinessName']")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdown { get { return (By.XPath("//label[contains(text(),'Select a country')]")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdownusa { get { return (By.XPath("//p-dropdownitem//div[contains(text(),'United States of America')]")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdownbox { get { return (By.XPath("//input[@placeholder='Search by country name...']")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdownboxselect { get { return (By.XPath("(//p-dropdownitem//div)[2]")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckaddresstextbox { get { return (By.XPath("//input[@formcontrolname='Address']")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckstreettextbox { get { return (By.XPath("//input[@formcontrolname='Street']")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckcitytextbox { get { return (By.XPath("//input[@formcontrolname='City']")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdown { get { return (By.XPath("//label[contains(text(),'Select a state')]")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdownbox { get { return (By.XPath("//input[@placeholder='Search by state name...']")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdownohio { get { return (By.XPath("//p-dropdownitem//div[contains(text(),'United States of America')]")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdownselect { get { return (By.XPath("(//p-dropdownitem//span)[1]")); } }

        public By PaymentProfilesPageAddPaymentProfilePagepcheckzipcodetextbox { get { return (By.XPath("//input[@formcontrolname='Zipcode']")); } }

        public By NationwideBusinessUnit { get { return (By.XPath("//select[@id='MainContent_ddlBusinessUnit']")); } }
        public By EmulateUser { get { return (By.XPath("//div[contains(text(),'Emulate')]")); } }
        public By EmulateUserTextbox { get { return (By.XPath("//ul[contains(@class,'emulationTextBox')]//input")); } }
        public By EmulationButton { get { return (By.XPath("//input[@id='emulationButton']")); } }
        public By V5CFMLink { get { return (By.XPath("//a[contains(@href,'CFM.aspx')]")); } }
        public By ElectronicFundTransfer { get { return (By.XPath("//span[contains(text(),'Electronic Funds Transfer')]")); } }
        public By PaperCheck { get { return (By.XPath("//span[contains(text(),'Paper Check')]")); } }
        public By LeftNavDashboard { get { return (By.XPath("//a[@id='dashboard']")); } }
        public By SavingsAccountType { get { return (By.XPath("//span[text()='Savings']")); } }
        public By Checkbox { get { return (By.XPath("//div[contains(@class,'ui-chkbox-box')]")); } }
        public By SubmitButton { get { return (By.XPath("//button[contains(@class,'primary-button')]")); } }
        public By LeftNavPayments { get { return (By.XPath("//span[contains(text(),'PAYMENTS')]")); } }
        public By PendingStatusTabs { get { return (By.XPath("//li[@id='Pending']")); } }
        public By CompletedStatusTabs { get { return (By.XPath("//li[@id='Completed']")); } }
        public By FailedStatusTabs { get { return (By.XPath("//li[@id='Failed']")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By DownloadReportLink { get { return By.XPath("//span[text()='Download Report']"); } }
        public By NW_Payments_FirstRowClaimIDStatus { get { return By.XPath("//tbody[@class='ui-table-tbody']//tr[@class='ng-star-inserted']//td[5]"); } }
        public By AddpaymentProfile_PaperCheck { get { return By.XPath("//div[contains(text(),'Paper')]"); } }
        public By DisbursementID_PaymentPage { get { return By.XPath("//div[contains(text(),'DISB-')]"); } }
        public By TransactionID { get { return By.XPath("//div[contains(text(),'pmt-')]"); } }
        public By PaperCheckNumber { get { return By.XPath("//div[contains(text(),'Check Number')]/following-sibling::div"); } }
                          
    }
}
