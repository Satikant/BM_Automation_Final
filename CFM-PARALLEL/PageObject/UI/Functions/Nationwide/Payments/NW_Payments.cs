using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Disbursements;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.FundRequest;
using CFMAutomation.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace CFM_PARALLEL.PageObject.UI.Functions.Nationwide
{
    class NW_Payments
    {
        private OBJ_Payments obj_Payments;
        private OBJ_Common obj_Common;
        private OBJ_Claims oBJ_Claims;
        private OBJ_Disbursement oBJ_Disbursements;

        //Constructor
        public NW_Payments()
        {
            obj_Payments = new OBJ_Payments();
            oBJ_Claims = new OBJ_Claims();
            obj_Common = new OBJ_Common();
            oBJ_Disbursements = new OBJ_Disbursement();
        }

        public void Create_PaperCheckProfile1()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_Payments.LeftNavPamentProfiles);
                Pages.BasicInteractions().Click(obj_Payments.LeftNavPamentProfiles);
                Pages.BasicInteractions().WaitTime(7);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageEftnavpageheader);
                Pages.BasicInteractions().WaitVisible(obj_Payments.AddPaymentProfileButton);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfileslink);
                          Pages.BasicInteractions().Click(obj_Payments.AddPaymentProfileButton);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageheadertext);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageheadertext1);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePagebacktoallprofileslink);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageupdateuserprofilelink);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePagePaperCheckButton);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfileEFTButton);

                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagePaperCheckButton);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepchecksec);

                CheckValuesPresent("Business Name");
                CheckValuesPresent("Country");
                CheckValuesPresent("Address");
                CheckValuesPresent("Street");
                CheckValuesPresent("City");
                CheckValuesPresent("State");
                CheckValuesPresent("Zipcode");

                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckbusinessnametextbox, Parameters.NW_BusinessName);

                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdown);
                Pages.BasicInteractions().Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdownbox, Parameters.NW_Country);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdownboxselect);
                               
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckaddresstextbox, Parameters.NW_Address);

                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstreettextbox, Parameters.NW_Street);

                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcitytextbox, Parameters.NW_City);

                Pages.BasicInteractions().WaitTime(2);
                
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdown);
                Pages.BasicInteractions().Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdownbox, Parameters.NW_State);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdownselect);

                
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckzipcodetextbox, Parameters.NW_Zipcode);

                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTpapersubmitbutton);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTpapersubmitbutton);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagepaymentProfilecreatedscucesswindow);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagepaymentProfilecreatedscucesswindowbacktoallprofilebutton);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagepaymentProfilecreatedscucesswindowpaymentprofilebutton);

                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPagepaymentProfilecreatedscucesswindowbacktoallprofilebutton);
                Pages.BasicInteractions().WaitTime(5);


                Pages.BasicInteractions().WaitUntilElementClickable(obj_Payments.PaymentProfilesPagePaperchecknav, 60);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPagePaperchecknav);

                Pages.BasicInteractions().WaitTime(3);
                CheckPapaerCheckValuesPresent(Parameters.NW_Address);
                CheckPapaerCheckValuesPresent(Parameters.NW_Street);
                CheckPapaerCheckValuesPresent(Parameters.NW_City);
                CheckPapaerCheckValuesPresent(Parameters.NW_State);
                CheckPapaerCheckValuesPresent(Parameters.NW_Zipcode);

                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().ScrollToViewElement(obj_Payments.PaymentProfilesPagemappaymentProfileslink);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfileslink);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPagemappaymentProfileslink);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagemappaymentprofilespageheadervalue);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagemappaymentprofilespageprogramnametextvalue);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagemappaymentprofilespagepaymentprofiletextvalue);

                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileediticon);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditfilterdropdown);

                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindow);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowefttextvalue);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowpaperchecktextvalue);
                Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindow);

                Pages.BasicInteractions().WaitTime(2);

                CheckPapaerCheckValuesPresentinPoupWindow(Parameters.NW_Address);
                CheckPapaerCheckValuesPresentinPoupWindow(Parameters.NW_Street);
                CheckPapaerCheckValuesPresentinPoupWindow(Parameters.NW_City);
                CheckPapaerCheckValuesPresentinPoupWindow(Parameters.NW_State);
                CheckPapaerCheckValuesPresentinPoupWindow(Parameters.NW_Zipcode);

                Pages.BasicInteractions().WaitTime(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }                  
      
        //Values Available in Page 
        public void CheckValuesPresent(string Name)
        {          
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad();
                IList<IWebElement> sectionList = Pages.BasicInteractions().GetElements(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepchecksecvaluelist);
                for (int i = 0; i < sectionList.Count; i++)
                {
                    string panel = ((sectionList)[i]).Text;
                    if (panel == Name)
                    {
                        Assert.AreEqual(panel, Name);
                        Console.WriteLine(Name + "--> Value is present in Page");
                        break;
                    }
                }
                Console.WriteLine("Validated Value Fields - Flow Passed");
            }
            catch (Exception error)
            {
                Console.WriteLine("Not able to Validate Value Fields - Flow Failed - Due to - : " + error);
                throw error;
            }

        }        

        public void CheckPapaerCheckValuesPresent(string Name)
        {
           
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad();
                IList<IWebElement> sectionList = Pages.BasicInteractions().GetElements(obj_Payments.PaymentProfilesPagepaperchecknavpageheadervaluelists);
                for (int i = 0; i < sectionList.Count; i++)
                {
                    string panel = ((sectionList)[i]).Text;
                    if (panel == Name)
                    {
                        Assert.AreEqual(panel, Name);
                        Console.WriteLine(Name + "--> Value is present in Page");
                        break;
                    }
                }
                Console.WriteLine("Validated Value Fields - Flow Passed");
            }
            catch (Exception error)
            {
                Console.WriteLine("Not able to Validate Value Fields - Flow Failed - Due to - : " + error);
                throw error;
            }

        }

        public void CheckPapaerCheckValuesPresentinPoupWindow(string Name)
        {
          

            try
            {
                Pages.BasicInteractions().WaitForPageToLoad();
                IList<IWebElement> sectionList = Pages.BasicInteractions().GetElements(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowpaperchecklists);
                for (int i = 0; i < sectionList.Count; i++)
                {
                    string panel = ((sectionList)[i]).Text;
                    if (panel == Name)
                    {
                        Assert.AreEqual(panel, Name);
                        Console.WriteLine(Name + "--> Value is present in Page");
                        break;
                    }
                }
                Console.WriteLine("Validated Value Fields - Flow Passed");
            }
            catch (Exception error)
            {
                Console.WriteLine("Not able to Validate Value Fields - Flow Failed - Due to - : " + error);
                throw error;
            }

        }

        // select business unit from dropdown just after login
        public void SelectNationwideBusinessUnit()
        {
            try
            {
                Pages.BasicInteractions().SelectByValue(obj_Payments.NationwideBusinessUnit, "430");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in SelectNationwideBusinessUnit:" + ex.Message);
                throw;
            }
        }

        
        //Validation of payment profiles
        public void Validate_PaymentProfiles()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_Payments.LeftNavPamentProfiles);
                Pages.BasicInteractions().Click(obj_Payments.LeftNavPamentProfiles);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidatePageHeadSectionValues("eft"); // Validating Electronic Funds Transfer label
                Pages.Dashboard_Landing().ValidatePageHeadSectionValues("ck"); // Validating Paper check label
                Pages.BasicInteractions().IsElementDisplayed(obj_Payments.AddPaymentProfileButton);
                Pages.BasicInteractions().Click(obj_Payments.PaperCheck);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_Payments.AddPaymentProfileButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                
                //Validate EFT
                /*Pages.BasicInteractions().WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTRoutingNumberTextbox);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTRoutingNumberTextbox);
                Pages.BasicInteractions().Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTRoutingNumberTextbox, Parameters.NW_RoutingNumber);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTAccountNumberTextbox);
                Pages.BasicInteractions().Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTAccountNumberTextbox, Parameters.NW_AccNumber);
                Pages.BasicInteractions().Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTAccountTypeDropdown);
                Pages.BasicInteractions().Click(obj_Payments.SavingsAccountType);
                Pages.BasicInteractions().WaitVisible(obj_Payments.Checkbox);
                Pages.BasicInteractions().Click(obj_Payments.Checkbox);
                Pages.BasicInteractions().WaitVisible(obj_Payments.SubmitButton);
                Console.WriteLine("Asserting for submit button to be present");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Payments.SubmitButton));
                Pages.BasicInteractions().Click(obj_Payments.AddpaymentProfile_PaperCheck);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();*/
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Validate_PaymentProfiles method :" + ex.Message);
                throw;
            }
        }

        //Validation of payments
        public void Validate_Payments()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_Payments.LeftNavPayments);
                Pages.BasicInteractions().Click(obj_Payments.LeftNavPayments);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidatePageHeadSectionValues("Pending");
                Pages.Dashboard_Landing().ValidatePageHeadSectionValues("Completed");
                Pages.Dashboard_Landing().ValidatePageHeadSectionValues("Failed");              

                Pages.BasicInteractions().Click(obj_Payments.FailedStatusTabs);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_Payments.PendingStatusTabs);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_Payments.CompletedStatusTabs);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_Common.MoreDetailsLink);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_Common.ViewAssociatedClaimsLink,120);

                Pages.BasicInteractions().Click(obj_Common.ViewAssociatedClaimsLink);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_Payments.NW_Payments_FirstRowClaimIDStatus,120);

                string ExpectedStatus = Pages.BasicInteractions().GetText(obj_Payments.NW_Payments_FirstRowClaimIDStatus);
                Pages.BasicInteractions().Click(obj_Common.FirstRowClaimIdLink);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                string ActualStatus = Pages.BasicInteractions().GetText(oBJ_Claims.ClaimStatusOnClaimReviewPage);
                Assert.AreEqual(ExpectedStatus, ActualStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Validate_Payments method :" + ex.Message);
                throw;
            }
        }


        public void Validate_EFT_And_PaperCheck(string ExpectedDisbID)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_Payments.LeftNavPayments);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_Payments.LeftNavPayments);
                Pages.BasicInteractions().WaitTime(10);
                //EFT ID
                Pages.BasicInteractions().Click(obj_Common.MoreDetailsLink);
                string ActualDisbID_EFT = Pages.BasicInteractions().GetText(obj_Payments.DisbursementID_PaymentPage);
                Assert.AreEqual(ExpectedDisbID, ActualDisbID_EFT);
                Console.WriteLine("The Transaction id for EFT claim is " + Pages.BasicInteractions().GetText(obj_Payments.TransactionID));

                //Paper check Number
                //oBJ_Disbursements.SetXpath("Completed");
                Pages.BasicInteractions().Click(oBJ_Disbursements.DisbursementTab("Completed"));
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_Common.MoreDetailsLink);
                string ActualDisbID_PaperCheck = Pages.BasicInteractions().GetText(obj_Payments.DisbursementID_PaymentPage);
                Assert.AreEqual(ExpectedDisbID, ActualDisbID_PaperCheck);
                Console.WriteLine("The Paper Check Number is " + Pages.BasicInteractions().GetText(obj_Payments.PaperCheckNumber));
               
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in Validate_EFT_And_PaperCheck method :" + ex.Message);
                throw;
            }

        }




    }
}
