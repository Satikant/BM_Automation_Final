using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Pre_Approvals;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions
{
    public class BC_BPA
    {

        private OBJ_Dashboard obj_dashboard;
        private OBJ_PreApprovals obj_bpa;
        private OBJ_Common oBJ_Common;

        //Constructor
        public BC_BPA()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_bpa = new OBJ_PreApprovals();
            oBJ_Common = new OBJ_Common();
        }

        public void BPA_FullFlow_Validation()
        {
            try
            {
                //Navigating to Brand Submit PreApproval Screen
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.BtnSubmit,120);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitPreapprovals);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                
                //Entering Details for BPA
                BPAEnterDetails();

                //Adding Attachment
                BPAAddingAttachment();

                //Checking Submit Button Visibility
                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_bpa.SubmitButton2));
                Console.WriteLine("User Able to Pass Brand Pre Approval Values till Submit Button: PASSED");
            }
            catch (Exception ex)
            {               
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public void BPAEnterDetails()
        {
            try
            {
                //Entering Details for BPA
                Pages.BasicInteractions().WaitUntilElementVisible(obj_bpa.BPARefName,120);
                Pages.BasicInteractions().Clear(obj_bpa.BPARefName);
                Pages.BasicInteractions().Type(obj_bpa.BPARefName, "BPA-Reference Number-1234");
                Pages.BasicInteractions().WaitVisible(obj_bpa.StoreDropdown);
                Pages.BasicInteractions().Click(obj_bpa.StoreDropdown);
                Pages.BasicInteractions().WaitVisible(obj_bpa.StoreDropdownText);
                Pages.BasicInteractions().TypeClear(obj_bpa.StoreDropdownText, Parameters.Bobcat_Test_LME());          
                Pages.BasicInteractions().Type(obj_bpa.StoreDropdownText, Keys.Enter);
         
                Pages.BasicInteractions().WaitVisible(obj_bpa.DdlMediaType);
                Pages.BasicInteractions().Click(obj_bpa.DdlMediaType);
                Pages.BasicInteractions().TypeClear(obj_bpa.TxbsearchMediaType, "Print");
                Pages.BasicInteractions().Type(obj_bpa.TxbsearchMediaType, Keys.Enter);
                Pages.BasicInteractions().WaitVisible(obj_bpa.ActivityDropdown);
                Pages.BasicInteractions().Click(obj_bpa.ActivityDropdown);
                Pages.BasicInteractions().TypeClear(obj_bpa.ActivityDropdownText, "DirectMail");
                Pages.BasicInteractions().Type(obj_bpa.ActivityDropdownText, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_bpa.Startdate);
                Pages.BasicInteractions().Click(obj_bpa.Startdate);
                Pages.BasicInteractions().Click(obj_bpa.BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                Pages.BasicInteractions().WaitVisible(obj_bpa.Enddate);
                Pages.BasicInteractions().Click(obj_bpa.Enddate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                Pages.BasicInteractions().Click(obj_bpa.NextButton);
            }
            catch (Exception ex)
            {                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        
        public void BPAAddingAttachment()
        {
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(obj_bpa.Comment, 120);

                //File Upload                
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput,"CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitVisible(obj_bpa.Comment);
                Pages.BasicInteractions().Type(obj_bpa.Comment, "BPA-Comments");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_bpa.NextButton3, 120);
                Pages.BasicInteractions().Click(obj_bpa.NextButton3);
                Pages.BasicInteractions().WaitVisible(obj_bpa.SubmitButton2);
                Console.WriteLine("User Able to Pass Brand Pre Approval Values till Submit Button: PASSED");
            }
            catch (Exception ex)
            {    
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public string SubmitBPA()
        {
            string GblBPAID = string.Empty;
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_bpa.SubmitButton1);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_bpa.ViewPreapprovalStatus);
                Pages.BasicInteractions().Click(obj_bpa.ViewPreapprovalStatus);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                //Wait.WaitVisible(BPAID);

                Console.WriteLine(Pages.BasicInteractions().GetText(obj_bpa.BPAID));
                //preapproval_FullFlow.BPA_ID = Pages.BasicInteractions().GetText(obj_bpa.BPAID);
                GblBPAID = Pages.BasicInteractions().GetText(obj_bpa.BPAID);
                Pages.BasicInteractions().WaitVisible(obj_bpa.BPAStatus);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_bpa.BPAStatus));
                if (Pages.BasicInteractions().GetText(obj_bpa.BPAStatus) == "Approved")
                {
                    Console.WriteLine("BPA " + Pages.BasicInteractions().GetText(obj_bpa.BPAID) + " created successfully");
                }
                else
                {
                    Console.WriteLine("BPA " + Pages.BasicInteractions().GetText(obj_bpa.BPAID) + " is in " + Pages.BasicInteractions().GetText(obj_bpa.BPAStatus) + " status");
                }
                return GblBPAID;
            }
            catch (Exception ex)
            {
     
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }
        //BPA Creation
        public string BPACreation()
        {
            try
            {
                //Navigating to Brand Submit PreApproval Screen
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitPreapprovals);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                //Entering Details for BPA
                BPAEnterDetails();

                //Adding Attachment
                BPAAddingAttachment();

                //Submit and Get BPAID
                string GblBPAID = SubmitBPA();
                return GblBPAID;
            }
            catch (Exception ex)
            {
          
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        public void BPADateValidation()
        {
            try
            {
                //Navigating to Brand Submit PreApproval Screen
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitPreapprovals);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                //Entering Details for BPA
                Pages.BasicInteractions().WaitVisible(obj_bpa.BPARefName);
                Pages.BasicInteractions().Clear(obj_bpa.BPARefName);
                Pages.BasicInteractions().Type(obj_bpa.BPARefName, "BPA-Reference Number-1234");
                Pages.BasicInteractions().WaitVisible(obj_bpa.StoreDropdown);
                Pages.BasicInteractions().Click(obj_bpa.StoreDropdown);
                Pages.BasicInteractions().WaitVisible(obj_bpa.StoreDropdownText);
                Pages.BasicInteractions().TypeClear(obj_bpa.StoreDropdownText, Parameters.Bobcat_Test_LME());
                //Pages.BasicInteractions().WaitVisible(StoreDropdownTextOption);
                //Pages.BasicInteractions().Click(StoreDropdownTextOption);
                Pages.BasicInteractions().Type(obj_bpa.StoreDropdownText, Keys.Enter);
                //}
                Pages.BasicInteractions().WaitVisible(obj_bpa.DdlMediaType);
                Pages.BasicInteractions().Click(obj_bpa.DdlMediaType);
                Pages.BasicInteractions().TypeClear(obj_bpa.TxbsearchMediaType, "Print");
                //Pages.BasicInteractions().WaitVisible(ActivityTypeTextOption);
                //Pages.BasicInteractions().Click(ActivityTypeTextOption);
                Pages.BasicInteractions().Type(obj_bpa.TxbsearchMediaType, Keys.Enter);


                Pages.BasicInteractions().WaitVisible(obj_bpa.ActivityDropdown);
                Pages.BasicInteractions().Click(obj_bpa.ActivityDropdown);
                Pages.BasicInteractions().TypeClear(obj_bpa.ActivityDropdownText, "DirectMail");
                Pages.BasicInteractions().Type(obj_bpa.ActivityDropdownText, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_bpa.Startdate);
                Pages.BasicInteractions().Click(obj_bpa.Startdate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_bpa.BPAStartDateSelection(DateSelection.Ace_DateValidation_StartDate()));
                Pages.BasicInteractions().WaitTime(5);

                //Pages.BasicInteractions().WaitVisible(obj_bpa.Enddate);
                //Pages.BasicInteractions().ClickJavaScript(obj_bpa.Enddate);
                //Pages.BasicInteractions().WaitTime(5);
                //Pages.BasicInteractions().Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
                Pages.BasicInteractions().WaitVisible(obj_bpa.Enddate);
                Pages.BasicInteractions().Click(obj_bpa.Enddate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
                // Pages.BasicInteractions().Click(obj_bpa.NextButton);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_bpa.NextButton);
                Pages.BasicInteractions().WaitTime(2);
                Assert.AreEqual(Pages.BasicInteractions().GetText(obj_bpa.EndDateErrorMessage).ToString(), "End date cannot be less than Start date");
                Console.WriteLine("BPA Date Validation is throwing error when End Date is less than Start Date");
                Pages.BasicInteractions().WaitVisible(obj_bpa.Enddate);
                Pages.BasicInteractions().Click(obj_bpa.Enddate);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                Pages.BasicInteractions().WaitTime(3);
                Assert.IsFalse(Pages.BasicInteractions().IsElementPresent(obj_bpa.EndDateErrorMessage));
                Console.WriteLine("BPA Date Validation is working fine when End Date is greater than Start Date");             

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }


        //BPA Clone
        public void BPAClone(string BPAID)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().Click(obj_bpa.LeftNavPreapprovals);
                Console.WriteLine("Cloning " + BPAID);
                //Pages.BasicInteractions().WaitVisible(SearchPreapprovals);
                //Pages.BasicInteractions().Clear(SearchPreapprovals);
                //Pages.BasicInteractions().Type(SearchPreapprovals, BPAID);
                //Pages.BasicInteractions().WaitTime(5);
                //Pages.BasicInteractions().Click(BPASearchResult(BPAID));

                //**Advanced Search functionality
                Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchLink);
                Pages.BasicInteractions().Click(obj_bpa.AdvanceSearchLink);
                Pages.BasicInteractions().WaitVisible(obj_bpa.PendingReviewCheckbox);
                Pages.BasicInteractions().Click(obj_bpa.PendingReviewCheckbox);
                Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchBPAIDTextBox);
                Pages.BasicInteractions().Clear(obj_bpa.AdvanceSearchBPAIDTextBox);
                Pages.BasicInteractions().Type(obj_bpa.AdvanceSearchBPAIDTextBox, BPAID);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_bpa.AdvanceSearchButton);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_bpa.BPASearchResult(BPAID));
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_bpa.CloneButton);
                Pages.BasicInteractions().Click(obj_bpa.CloneButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);

                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(obj_bpa.NextButton);
                Pages.BasicInteractions().WaitTime(10);

                //Adding Attachment
                BPAAddingAttachment();

                string ClonedBPAID = SubmitBPA();

                if (ClonedBPAID != null)
                { Console.WriteLine("Cloned successfully"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //BPA Perform Action
        public void BPAPerformActionAndVerify(string BPAID, string Action)
        {
            try
            {
                //Searching BPA
                SearchBPA(BPAID);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_bpa.BPASearchResult(BPAID));
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);

                //Pages.BasicInteractions().WaitTime(20);
                //Wait.WaitVisible(BPAResponseDropdown);
                Pages.BasicInteractions().Click(obj_bpa.BPAResponseDropdown);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_bpa.BPAResponseAction(Action));
                //BPAComments.Type(action);
                Pages.BasicInteractions().Click(obj_bpa.BPASendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);

                //Search BPA and Get Status
                //String BPAStatus=SearchAndGetStatusOfBPA(BPAID);
                //Assert.AreEqual(BPAStatus.ToUpper(), Action.ToUpper());
                Console.WriteLine("The Specified Action Performed on BPA Successfully");
                Console.WriteLine(BPAID + " - " + Action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void SearchBPA(string BPAID)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().Click(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.LoadingImageBrandingPreApproval);
                // Pages.BasicInteractions().WaitTime(20);

                //**Simple Search functionality
                Pages.BasicInteractions().Clear(obj_bpa.SearchPreapprovals);
                Pages.BasicInteractions().Type(obj_bpa.SearchPreapprovals, BPAID);
                Pages.BasicInteractions().WaitTime(5);

                //**Advanced Search functionality
                // Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchLink);
                // Pages.BasicInteractions().Click(obj_bpa.AdvanceSearchLink);
                //// Pages.BasicInteractions().WaitVisible(obj_bpa.PendingReviewCheckbox);
                // //Pages.BasicInteractions().Click(obj_bpa.PendingReviewCheckbox);
                // Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchBPAIDTextBox);
                // Pages.BasicInteractions().Clear(obj_bpa.AdvanceSearchBPAIDTextBox);
                // Pages.BasicInteractions().Type(obj_bpa.AdvanceSearchBPAIDTextBox, BPAID);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_bpa.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.LoadingImageBrandingPreApproval);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public string SearchAndGetStatusOfBPA(string BPAID)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().Click(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                // Pages.BasicInteractions().WaitTime(20);

                //**Simple Search functionality
                Pages.BasicInteractions().Clear(obj_bpa.SearchPreapprovals);
                Pages.BasicInteractions().Type(obj_bpa.SearchPreapprovals, BPAID);
                Pages.BasicInteractions().WaitTime(5);

                //**Advanced Search functionality
                //Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchLink);
                //Pages.BasicInteractions().Click(obj_bpa.AdvanceSearchLink);
                //// Pages.BasicInteractions().WaitVisible(obj_bpa.PendingReviewCheckbox);
                ////Pages.BasicInteractions().Click(obj_bpa.PendingReviewCheckbox);
                //Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchBPAIDTextBox);
                //Pages.BasicInteractions().Clear(obj_bpa.AdvanceSearchBPAIDTextBox);
                //Pages.BasicInteractions().Type(obj_bpa.AdvanceSearchBPAIDTextBox, BPAID);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_bpa.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.LoadingImageBrandingPreApproval);

                Pages.BasicInteractions().WaitTime(5);
                //Pages.BasicInteractions().Click(obj_bpa.BPASearchResult(BPAID));
                //Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.imgLoading);
                string BPAStatus = Pages.BasicInteractions().GetText(obj_bpa.LblStatusBPASearchResult);
                return BPAStatus;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        public void BPACreation_Negative()
        {
            // BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(PreApproval_Negative));
            // Preapprovals_EnterDetails preapprovals_EnterDetails = new Preapprovals_EnterDetails(Driver);
            //Preapprovals_AddAttachments preapprovals_AddAttachments = new Preapprovals_AddAttachments(Driver);
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().Click(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
                //Pages.BasicInteractions().WaitVisible(SubmitPreapprovals);
                if (!Pages.BasicInteractions().IsElementPresent(obj_bpa.SubmitPreapproval_BPA))
                {
                    Console.WriteLine("Cannot create BPA, link to create BPA is not present in the application");
                }
                else
                {
                    Pages.BasicInteractions().ClickJavaScript(obj_bpa.SubmitPreapproval_BPA);
                    Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_bpa.NextButton);
                    Pages.BasicInteractions().Click(obj_bpa.NextButton);
                    if (BrowserURLLaunch.ROLES.Equals("CORPORATE1") || BrowserURLLaunch.ROLES.Equals("CORPORATE2"))
                    {
                        if (Pages.BasicInteractions().IsElementPresent(obj_bpa.ErrorStoreRequired))
                        {
                            Pages.BasicInteractions().WaitTime(5);
                            Pages.BasicInteractions().WaitVisible(obj_bpa.StoreDropdown);
                            Pages.BasicInteractions().Click(obj_bpa.StoreDropdown);
                            Pages.BasicInteractions().WaitVisible(obj_bpa.StoreDropdownText);
                            //preapprovals_EnterDetails.StoreDropdownText.Type(Parameters.Ace_Test_LME_00020());
                            //Pages.BasicInteractions().WaitVisible(preapprovals_EnterDetails.StoreDropdownTextOption);
                            //preapprovals_EnterDetails.StoreDropdownTextOption.Click();
                            Pages.BasicInteractions().Type(obj_bpa.StoreDropdownText, Keys.Enter);
                            Console.WriteLine("BPA NEGATIVE: Store selected for " + BrowserURLLaunch.ROLES);
                        }
                    }
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_bpa.NextButton);
                    if (Pages.BasicInteractions().IsElementPresent(obj_bpa.ErrorDealershipRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_bpa.BPARefName);
                        Pages.BasicInteractions().Clear(obj_bpa.BPARefName);
                        Pages.BasicInteractions().Type(obj_bpa.BPARefName, "BPA-Reference Number-1234");
                        Pages.BasicInteractions().WaitVisible(obj_bpa.StoreDropdown);
                        Pages.BasicInteractions().Click(obj_bpa.StoreDropdown);
                        Pages.BasicInteractions().WaitVisible(obj_bpa.StoreDropdownText);
                        Pages.BasicInteractions().TypeClear(obj_bpa.StoreDropdownText, Parameters.Bobcat_Test_LME());
                        //Pages.BasicInteractions().WaitVisible(StoreDropdownTextOption);
                        //Pages.BasicInteractions().Click(StoreDropdownTextOption);
                        Pages.BasicInteractions().Type(obj_bpa.StoreDropdownText, Keys.Enter);
                        Console.WriteLine("BPA NEGATIVE: Activity Type selected for " + BrowserURLLaunch.ROLES);
                    }
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_bpa.NextButton);
                    if (Pages.BasicInteractions().IsElementPresent(obj_bpa.ErrorMediaTypeRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_bpa.DdlMediaType);
                        Pages.BasicInteractions().Click(obj_bpa.DdlMediaType);
                        Pages.BasicInteractions().TypeClear(obj_bpa.TxbsearchMediaType, "Print");
                        //Pages.BasicInteractions().WaitVisible(ActivityTypeTextOption);
                        //Pages.BasicInteractions().Click(ActivityTypeTextOption);
                        Pages.BasicInteractions().Type(obj_bpa.TxbsearchMediaType, Keys.Enter);
                        Console.WriteLine("BPA NEGATIVE: Media Type selected ");
                    }
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_bpa.NextButton);
                    if (Pages.BasicInteractions().IsElementPresent(obj_bpa.ErrorActivityTypeRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_bpa.ActivityDropdown);
                        Pages.BasicInteractions().Click(obj_bpa.ActivityDropdown);
                        Pages.BasicInteractions().TypeClear(obj_bpa.ActivityDropdownText, "DirectMail");
                        Pages.BasicInteractions().Type(obj_bpa.ActivityDropdownText, Keys.Enter);
                        Console.WriteLine("BPA NEGATIVE: Activity Type selected ");
                    }
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_bpa.NextButton);
                    if (Pages.BasicInteractions().IsElementPresent(obj_bpa.ErrorStartDateRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_bpa.Startdate);
                        Pages.BasicInteractions().Click(obj_bpa.Startdate);
                        Pages.BasicInteractions().WaitTime(1);
                        Pages.BasicInteractions().Click(obj_bpa.BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                        Console.WriteLine("BPA NEGATIVE: Start Date selected for " + BrowserURLLaunch.ROLES);
                    }
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_bpa.NextButton);
                    if (Pages.BasicInteractions().IsElementPresent(obj_bpa.ErrorEndDateRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_bpa.Enddate);
                        Pages.BasicInteractions().Click(obj_bpa.Enddate);
                        Pages.BasicInteractions().WaitTime(1);
                        Pages.BasicInteractions().Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                        Console.WriteLine("BPA NEGATIVE: End Date selected for " + BrowserURLLaunch.ROLES);
                    }
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_bpa.NextButton);

                    Pages.BasicInteractions().WaitVisible(obj_bpa.SubmitButton1);
                    Pages.BasicInteractions().Click(obj_bpa.SubmitButton1);
                    Pages.BasicInteractions().WaitTime(3);
                    if (Pages.BasicInteractions().IsElementPresent(obj_bpa.ErrorAttachmentRequired))
                    {
                        Pages.BasicInteractions().Click(obj_bpa.UploadFile);
                        Pages.BasicInteractions().WaitTime(5);
                        CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                        Pages.BasicInteractions().WaitTime(5);
                        if (Pages.BasicInteractions().IsElementPresent(obj_bpa.AttachementRemove))
                        {
                            Console.WriteLine("BPA NEGATIVE: Attachment added for " + BrowserURLLaunch.ROLES);
                        }
                        else
                        {
                            Console.WriteLine("BPA NEGATIVE: Attachement not attached");
                        }
                    }
                    else
                    {
                        Console.WriteLine("BPA NEGATIVE: Attachment Error message not shown");
                    }

                    if (Pages.BasicInteractions().IsElementPresent(obj_bpa.SubmitButton1))
                    {
                        Console.WriteLine("BPA NEGATIVE: Submit Button for submitting a BPA is present");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
                throw;
            }
        }

        public void BPA_AdvanceSearch(string BPAID)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(PreApproval_AdvanceSearch));
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().Click(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);

                Pages.BasicInteractions().WaitTime(5);


                //**Advanced Search functionality
                Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchLink);
                Pages.BasicInteractions().Click(obj_bpa.AdvanceSearchLink);
                Pages.BasicInteractions().WaitVisible(obj_bpa.ApprovedCheckbox);
                Pages.BasicInteractions().Click(obj_bpa.ApprovedCheckbox);
                Pages.BasicInteractions().WaitVisible(obj_bpa.PendingReviewCheckbox);
                Pages.BasicInteractions().Click(obj_bpa.PendingReviewCheckbox);
                Pages.BasicInteractions().WaitVisible(obj_bpa.HoldCheckbox);
                Pages.BasicInteractions().Click(obj_bpa.HoldCheckbox);
                Pages.BasicInteractions().WaitVisible(obj_bpa.NeedsInformationCheckbox);
                Pages.BasicInteractions().Click(obj_bpa.NeedsInformationCheckbox);
                Pages.BasicInteractions().WaitVisible(obj_bpa.DeniedCheckbox);
                Pages.BasicInteractions().Click(obj_bpa.DeniedCheckbox);
                Pages.BasicInteractions().WaitVisible(obj_bpa.ClosedCheckbox);
                Pages.BasicInteractions().Click(obj_bpa.ClosedCheckbox);
                //Pages.BasicInteractions().WaitVisible(obj_bpa.ResubmittedCheckbox);
                //Pages.BasicInteractions().Click(obj_bpa.ResubmittedCheckbox);
                Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchBPAIDTextBox);
                Pages.BasicInteractions().Clear(obj_bpa.AdvanceSearchBPAIDTextBox);
                Pages.BasicInteractions().Type(obj_bpa.AdvanceSearchBPAIDTextBox, BPAID);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_bpa.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_bpa.AdvanceSearchButton);

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_bpa.BPASearchResult(BPAID));
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementPresent(obj_bpa.BPAResponseDropdown))
                {
                    Console.WriteLine("Advance Search is working fine");
                }
                else
                {
                    Console.WriteLine("Advance search is not working");
                }
            
            }
            catch (Exception e)
            {
                Console.WriteLine("PreApproval_AdvanceSearch " + e);
                Assert.Fail("PreApproval_AdvanceSearch " + e);
     
            }

        }

        public void BPA_Resubmitted(string BPAID)
        {

            try
            {
                //OBJ_BrandPreApprovals obj_bpa = new OBJ_BrandPreApprovals();
                //BasicInteractions bi = new BasicInteractions(Driver);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().Click(obj_bpa.LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);

                Pages.BasicInteractions().WaitTime(5);

                //**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(obj_bpa.SearchPreapprovals);
                Pages.BasicInteractions().TypeClear(obj_bpa.SearchPreapprovals, BPAID);
                Pages.BasicInteractions().Click(obj_bpa.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.LoadingImageBrandingPreApproval);
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementPresent(obj_bpa.BPASearchResult(BPAID)))
                {
                    Console.WriteLine("Advance Search is working fine");
                    Pages.BasicInteractions().Click(obj_bpa.BPASearchResult(BPAID));
                    Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                    Pages.BasicInteractions().WaitTime(5);
                }
                else
                {
                    Console.WriteLine("Advance search is not working");
                    Assert.Fail();
                }

                Pages.BasicInteractions().WaitVisible(obj_bpa.EditButton);
                Pages.BasicInteractions().Click(obj_bpa.EditButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_bpa.NextButton);
                Pages.BasicInteractions().Click(obj_bpa.NextButton);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_bpa.SubmitButton1);
                Pages.BasicInteractions().Click(obj_bpa.SubmitButton1);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_bpa.ViewPreapprovalStatus);
                Pages.BasicInteractions().Click(obj_bpa.ViewPreapprovalStatus);
                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                //Wait.WaitVisible(BPAID);

                Console.WriteLine(Pages.BasicInteractions().GetText(obj_bpa.BPAID));
                //preapproval_FullFlow.BPA_ID = Pages.BasicInteractions().GetText(obj_bpa.BPAID);
                String GblBPAID = Pages.BasicInteractions().GetText(obj_bpa.BPAID);
                Pages.BasicInteractions().WaitVisible(obj_bpa.BPAStatus);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_bpa.BPAStatus));
                Assert.IsTrue(Pages.BasicInteractions().GetText(obj_bpa.BPAStatus) == "Resubmitted");
                //{
                Console.WriteLine("BPA " + Pages.BasicInteractions().GetText(obj_bpa.BPAID) + " Resubmitted successfully");

                //return GblBPAID;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
        }
    }
}
