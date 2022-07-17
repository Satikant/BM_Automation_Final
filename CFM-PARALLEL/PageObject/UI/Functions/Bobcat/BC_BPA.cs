using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Pre_Approvals;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions
{
    public class BC_BPA
    {
        private IWebDriver Driver;
        private Base bs;
        private BrowserURLLaunch bl;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private BasicInteractions bi;
        private CommonFunctions cf;
        private OBJ_BrandPreApprovals obj_bpa;
        public static string file = System.IO.Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";

        //Constructor
        public BC_BPA(IWebDriver Driver)
        {
            this.Driver = Driver;
            bs = new Base();
            bl = new BrowserURLLaunch(Driver);
            obj_dashboard = new OBJ_Dashboard();
            bi = new BasicInteractions(Driver);
            obj_claims = new OBJ_Claims();
            cf = new CommonFunctions(Driver);
            obj_bpa = new OBJ_BrandPreApprovals();
        }

        public void BPAValidationAtLMELevel()
        {
            try
            {
                //Navigating to Brand Submit PreApproval Screen
                bi.WaitTime(10);
                bi.WaitVisible(obj_dashboard.btnSubmit);
                bi.Click(obj_dashboard.btnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.btnSubmitPreapprovals);
                bi.Click(obj_dashboard.btnSubmitPreapprovals);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

                //Entering Details for BPA
                BPAEnterDetails();

                //Adding Attachment
                //BPAAddingAttachment();
                
                //Checking Submit Button Visibility
                //bi.IsElementDisplayed(obj_bpa.SubmitButton);
                Console.WriteLine("User Able to Pass Brand Pre Approval Values till Submit Button: PASSED");
            }
            catch(Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void BPAEnterDetails()
        {
            try
            {
                //Entering Details for BPA
                bi.WaitVisible(obj_bpa.BPARefName);
                bi.Clear(obj_bpa.BPARefName);
                bi.Type(obj_bpa.BPARefName, "BPA-Reference Number-1234");
                bi.WaitVisible(obj_bpa.StoreDropdown);
                bi.Click(obj_bpa.StoreDropdown);
                bi.WaitVisible(obj_bpa.StoreDropdownText);
                bi.TypeClear(obj_bpa.StoreDropdownText, Parameters.Bobcat_Test_LME());
                //bi.WaitVisible(StoreDropdownTextOption);
                //bi.Click(StoreDropdownTextOption);
                bi.Type(obj_bpa.StoreDropdownText, Keys.Enter);
                //}
                bi.WaitVisible(obj_bpa.ddlMediaType);
                bi.Click(obj_bpa.ddlMediaType);
                bi.TypeClear(obj_bpa.txbsearchMediaType, "Print");
                //bi.WaitVisible(ActivityTypeTextOption);
                //bi.Click(ActivityTypeTextOption);
                bi.Type(obj_bpa.txbsearchMediaType, Keys.Enter);


                bi.WaitVisible(obj_bpa.ActivityDropdown);
                bi.Click(obj_bpa.ActivityDropdown);
                bi.TypeClear(obj_bpa.ActivityDropdownText, "DirectMail");
                bi.Type(obj_bpa.ActivityDropdownText, Keys.Enter);

                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.Startdate);
                bi.Click(obj_bpa.Startdate);
                bi.Click(obj_bpa.BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                bi.WaitVisible(obj_bpa.Enddate);
                bi.Click(obj_bpa.Enddate);
                bi.WaitTime(5);
                bi.Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                bi.Click(obj_bpa.NextButton);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        public void BPAAddingAttachment()
        {
            try
            {
                bi.WaitTime(5);
                bi.Click(obj_bpa.UploadFile);
                bi.IsElementDisplayed(obj_bpa.UploadFile);
                bi.WaitTime(5);

                //File Upload
                //While commiting to Git, uncomment UploadFileInChrome() and comment UploadFileInChromeUsingAutoIT()
                //Common.CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                //CommonUtilities.UploadFileInChromeUsingAutoIT("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Common.CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");

                //System.Windows.Forms.SendKeys.SendWait("^a");
                //Wait.WaitTime(3);
                ////File path from deployment items
                ////System.Windows.Forms.SendKeys.SendWait(file);
                //System.Windows.Forms.SendKeys.SendWait("D:\\AutomationFileAttachment\\CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                //Wait.WaitTime(3);
                //System.Windows.Forms.SendKeys.SendWait(@"{Enter}");

                bi.WaitVisible(obj_bpa.Comment);
                bi.Type(obj_bpa.Comment, "BPA-Comments");
                bi.WaitTime(5);
            }
            catch(Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public string SubmitBPA()
        {
            string GblBPAID = string.Empty;
            try
            {
                bi.WaitTime(5);
                bi.Click(obj_bpa.SubmitButton);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);
                bi.WaitTime(10);
                bi.WaitVisible(obj_bpa.ViewPreapprovalStatus);
                bi.Click(obj_bpa.ViewPreapprovalStatus);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);
                bi.WaitTime(5);
                //Wait.WaitVisible(BPAID);

                Console.WriteLine(bi.GetText(obj_bpa.BPAID));
                //preapproval_FullFlow.BPA_ID = bi.GetText(obj_bpa.BPAID);
                GblBPAID = bi.GetText(obj_bpa.BPAID);
                bi.WaitVisible(obj_bpa.BPAStatus);
                Console.WriteLine(bi.GetText(obj_bpa.BPAStatus));
                if (bi.GetText(obj_bpa.BPAStatus) == "Approved")
                {
                    Console.WriteLine("BPA " + bi.GetText(obj_bpa.BPAID) + " created successfully");
                }
                else
                {
                    Console.WriteLine("BPA " + bi.GetText(obj_bpa.BPAID) + " is in " + bi.GetText(obj_bpa.BPAStatus) + " status");
                }
                return GblBPAID;
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
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
                bi.WaitTime(10);
                bi.WaitVisible(obj_dashboard.btnSubmit);
                bi.Click(obj_dashboard.btnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.btnSubmitPreapprovals);
                bi.Click(obj_dashboard.btnSubmitPreapprovals);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

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
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        public void BPADateValidation()
        {
            try
            {
                //Navigating to Brand Submit PreApproval Screen
                bi.WaitTime(10);
                bi.WaitVisible(obj_dashboard.btnSubmit);
                bi.Click(obj_dashboard.btnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.btnSubmitPreapprovals);
                bi.Click(obj_dashboard.btnSubmitPreapprovals);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

                //Entering Details for BPA
                bi.WaitVisible(obj_bpa.BPARefName);
                bi.Clear(obj_bpa.BPARefName);
                bi.Type(obj_bpa.BPARefName, "BPA-Reference Number-1234");
                bi.WaitVisible(obj_bpa.StoreDropdown);
                bi.Click(obj_bpa.StoreDropdown);
                bi.WaitVisible(obj_bpa.StoreDropdownText);
                bi.TypeClear(obj_bpa.StoreDropdownText, Parameters.Bobcat_Test_LME());
                //bi.WaitVisible(StoreDropdownTextOption);
                //bi.Click(StoreDropdownTextOption);
                bi.Type(obj_bpa.StoreDropdownText, Keys.Enter);
                //}
                bi.WaitVisible(obj_bpa.ddlMediaType);
                bi.Click(obj_bpa.ddlMediaType);
                bi.TypeClear(obj_bpa.txbsearchMediaType, "Print");
                //bi.WaitVisible(ActivityTypeTextOption);
                //bi.Click(ActivityTypeTextOption);
                bi.Type(obj_bpa.txbsearchMediaType, Keys.Enter);


                bi.WaitVisible(obj_bpa.ActivityDropdown);
                bi.Click(obj_bpa.ActivityDropdown);
                bi.TypeClear(obj_bpa.ActivityDropdownText, "DirectMail");
                bi.Type(obj_bpa.ActivityDropdownText, Keys.Enter);

                bi.WaitVisible(obj_bpa.Startdate);
                bi.Click(obj_bpa.Startdate);
                bi.WaitTime(1);
                bi.Click(obj_bpa.BPAStartDateSelection(DateSelection.Ace_DateValidation_StartDate()));
                bi.WaitTime(5);

                //bi.WaitVisible(obj_bpa.Enddate);
                //bi.ClickJavaScript(obj_bpa.Enddate);
                //bi.WaitTime(5);
                //bi.Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
                bi.WaitVisible(obj_bpa.Enddate);
                bi.Click(obj_bpa.Enddate);
                bi.WaitTime(1);
                bi.Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
               // bi.Click(obj_bpa.NextButton);
                bi.WaitTime(5);
                bi.Click(obj_bpa.NextButton);
                bi.WaitTime(2);
                Assert.AreEqual(bi.GetText(obj_bpa.EndDateErrorMessage).ToString(), "End date cannot be less than Start date");
                Console.WriteLine("BPA Date Validation is throwing error when End Date is less than Start Date");
                bi.WaitVisible(obj_bpa.Enddate);
                bi.Click(obj_bpa.Enddate);
                bi.WaitTime(3);
                bi.Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                bi.WaitTime(3);
                Assert.IsFalse(bi.IsElementPresent(obj_bpa.EndDateErrorMessage));
                //{
                    Console.WriteLine("BPA Date Validation is working fine when End Date is greater than Start Date");
                //}

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }


        //BPA Clone
        public void BPAClone(string BPAID)
        {
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_bpa.LeftNavPreapprovals);
                bi.Click(obj_bpa.LeftNavPreapprovals);
                Console.WriteLine("Cloning " + BPAID);
                //bi.WaitVisible(SearchPreapprovals);
                //bi.Clear(SearchPreapprovals);
                //bi.Type(SearchPreapprovals, BPAID);
                //bi.WaitTime(5);
                //bi.Click(BPASearchResult(BPAID));

                //**Advanced Search functionality
                bi.WaitVisible(obj_bpa.AdvanceSearchLink);
                bi.Click(obj_bpa.AdvanceSearchLink);
                bi.WaitVisible(obj_bpa.PendingReviewCheckbox);
                bi.Click(obj_bpa.PendingReviewCheckbox);
                bi.WaitVisible(obj_bpa.AdvanceSearchBPAIDTextBox);
                bi.Clear(obj_bpa.AdvanceSearchBPAIDTextBox);
                bi.Type(obj_bpa.AdvanceSearchBPAIDTextBox, BPAID);
                bi.WaitTime(10);
                bi.WaitVisible(obj_bpa.AdvanceSearchButton);
                bi.Click(obj_bpa.AdvanceSearchButton);

                bi.WaitTime(5);
                bi.Click(obj_bpa.BPASearchResult(BPAID));
                bi.WaitTillNotVisible(obj_bpa.imgLoading);

                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.CloneButton);
                bi.Click(obj_bpa.CloneButton);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);

                bi.WaitTime(5);

                bi.Click(obj_bpa.NextButton);
                bi.WaitTime(10);
                
                //Adding Attachment
                BPAAddingAttachment();

                string ClonedBPAID=SubmitBPA();

                if (ClonedBPAID != null)
                { Console.WriteLine("Cloned successfully"); }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //BPA Perform Action
        public void BPAPerformActionAndVerify(string BPAID,string Action)
        {
            try
            {
                //Searching BPA
                SearchBPA(BPAID);

                bi.WaitTime(5);
                bi.Click(obj_bpa.BPASearchResult(BPAID));
                bi.WaitTillNotVisible(obj_bpa.imgLoading);

                //bi.WaitTime(20);
                //Wait.WaitVisible(BPAResponseDropdown);
                bi.Click(obj_bpa.BPAResponseDropdown);
                bi.WaitTime(2);
                bi.Click(obj_bpa.BPAResponseAction(Action));
                //BPAComments.Type(action);
                bi.Click(obj_bpa.BPASendResponseButton);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);

                //Search BPA and Get Status
                //String BPAStatus=SearchAndGetStatusOfBPA(BPAID);
                //Assert.AreEqual(BPAStatus.ToUpper(), Action.ToUpper());
                Console.WriteLine("The Specified Action Performed on BPA Successfully");
                Console.WriteLine(BPAID + " - " + Action);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void SearchBPA(string BPAID)
        {
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_bpa.LeftNavPreapprovals);
                bi.Click(obj_bpa.LeftNavPreapprovals);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);
                bi.WaitTillNotVisible(obj_bpa.loadingImageBrandingPreApproval);
                // bi.WaitTime(20);

                //**Simple Search functionality
                bi.Clear(obj_bpa.SearchPreapprovals);
                bi.Type(obj_bpa.SearchPreapprovals, BPAID);
                bi.WaitTime(5);

                //**Advanced Search functionality
               // bi.WaitVisible(obj_bpa.AdvanceSearchLink);
               // bi.Click(obj_bpa.AdvanceSearchLink);
               //// bi.WaitVisible(obj_bpa.PendingReviewCheckbox);
               // //bi.Click(obj_bpa.PendingReviewCheckbox);
               // bi.WaitVisible(obj_bpa.AdvanceSearchBPAIDTextBox);
               // bi.Clear(obj_bpa.AdvanceSearchBPAIDTextBox);
               // bi.Type(obj_bpa.AdvanceSearchBPAIDTextBox, BPAID);
     
                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.AdvanceSearchButton);
                bi.Click(obj_bpa.AdvanceSearchButton);
                bi.WaitTillNotVisible(obj_bpa.loadingImageBrandingPreApproval);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public string SearchAndGetStatusOfBPA(string BPAID)
        {
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_bpa.LeftNavPreapprovals);
                bi.Click(obj_bpa.LeftNavPreapprovals);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);
                // bi.WaitTime(20);

                //**Simple Search functionality
                bi.Clear(obj_bpa.SearchPreapprovals);
                bi.Type(obj_bpa.SearchPreapprovals, BPAID);
                bi.WaitTime(5);

                //**Advanced Search functionality
                //bi.WaitVisible(obj_bpa.AdvanceSearchLink);
                //bi.Click(obj_bpa.AdvanceSearchLink);
                //// bi.WaitVisible(obj_bpa.PendingReviewCheckbox);
                ////bi.Click(obj_bpa.PendingReviewCheckbox);
                //bi.WaitVisible(obj_bpa.AdvanceSearchBPAIDTextBox);
                //bi.Clear(obj_bpa.AdvanceSearchBPAIDTextBox);
                //bi.Type(obj_bpa.AdvanceSearchBPAIDTextBox, BPAID);

                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.AdvanceSearchButton);
                bi.Click(obj_bpa.AdvanceSearchButton);
                bi.WaitTillNotVisible(obj_bpa.loadingImageBrandingPreApproval);

                bi.WaitTime(5);
                //bi.Click(obj_bpa.BPASearchResult(BPAID));
                //bi.WaitTillNotVisible(obj_bpa.imgLoading);
                string BPAStatus=bi.GetText(obj_bpa.lblStatusBPASearchResult);
                return BPAStatus;

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
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
                bi.WaitVisible(obj_bpa.LeftNavPreapprovals);
                bi.Click(obj_bpa.LeftNavPreapprovals);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);
                bi.WaitTime(10);
                //bi.WaitVisible(SubmitPreapprovals);
                if (!bi.IsElementPresent(obj_bpa.submitPreapproval_BPA))
                {
                    Console.WriteLine("Cannot create BPA, link to create BPA is not present in the application");
                }
                else
                {
                    bi.ClickJavaScript(obj_bpa.submitPreapproval_BPA);
                    bi.WaitTillNotVisible(obj_bpa.imgLoading);
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_bpa.NextButton);
                    bi.Click(obj_bpa.NextButton);
                    BrowserURLLaunch BrowserURLLaunch = new BrowserURLLaunch(Driver);
                    if (BrowserURLLaunch.ROLES.Equals("CORPORATE1") || BrowserURLLaunch.ROLES.Equals("CORPORATE2"))
                    {
                        if (bi.IsElementPresent(obj_bpa.ErrorStoreRequired))
                        {
                            bi.WaitTime(5);
                            bi.WaitVisible(obj_bpa.StoreDropdown);
                            bi.Click(obj_bpa.StoreDropdown);
                            bi.WaitVisible(obj_bpa.StoreDropdownText);
                            //preapprovals_EnterDetails.StoreDropdownText.Type(Parameters.Ace_Test_LME_00020());
                            //bi.WaitVisible(preapprovals_EnterDetails.StoreDropdownTextOption);
                            //preapprovals_EnterDetails.StoreDropdownTextOption.Click();
                            bi.Type(obj_bpa.StoreDropdownText, Keys.Enter);
                            Console.WriteLine("BPA NEGATIVE: Store selected for " + BrowserURLLaunch.ROLES);
                        }
                    }
                    bi.WaitTime(5);
                    bi.Click(obj_bpa.NextButton);
                    if (bi.IsElementPresent(obj_bpa.ErrorDealershipRequired))
                    {
                        bi.WaitVisible(obj_bpa.BPARefName);
                        bi.Clear(obj_bpa.BPARefName);
                        bi.Type(obj_bpa.BPARefName, "BPA-Reference Number-1234");
                        bi.WaitVisible(obj_bpa.StoreDropdown);
                        bi.Click(obj_bpa.StoreDropdown);
                        bi.WaitVisible(obj_bpa.StoreDropdownText);
                        bi.TypeClear(obj_bpa.StoreDropdownText, Parameters.Bobcat_Test_LME());
                        //bi.WaitVisible(StoreDropdownTextOption);
                        //bi.Click(StoreDropdownTextOption);
                        bi.Type(obj_bpa.StoreDropdownText, Keys.Enter);
                        Console.WriteLine("BPA NEGATIVE: Activity Type selected for " + BrowserURLLaunch.ROLES);
                    }
                    bi.WaitTime(5);
                    bi.Click(obj_bpa.NextButton);
                    if (bi.IsElementPresent(obj_bpa.ErrorMediaTypeRequired))
                    {
                        bi.WaitVisible(obj_bpa.ddlMediaType);
                        bi.Click(obj_bpa.ddlMediaType);
                        bi.TypeClear(obj_bpa.txbsearchMediaType, "Print");
                        //bi.WaitVisible(ActivityTypeTextOption);
                        //bi.Click(ActivityTypeTextOption);
                        bi.Type(obj_bpa.txbsearchMediaType, Keys.Enter);
                        Console.WriteLine("BPA NEGATIVE: Media Type selected ");
                    }
                    bi.WaitTime(5);
                    bi.Click(obj_bpa.NextButton);
                    if (bi.IsElementPresent(obj_bpa.ErrorActivityTypeRequired))
                    {
                        bi.WaitVisible(obj_bpa.ActivityDropdown);
                        bi.Click(obj_bpa.ActivityDropdown);
                        bi.TypeClear(obj_bpa.ActivityDropdownText, "DirectMail");
                        bi.Type(obj_bpa.ActivityDropdownText, Keys.Enter);
                        Console.WriteLine("BPA NEGATIVE: Activity Type selected ");
                    }
                    bi.WaitTime(5);
                    bi.Click(obj_bpa.NextButton);
                    if (bi.IsElementPresent(obj_bpa.ErrorStartDateRequired))
                    {
                        bi.WaitVisible(obj_bpa.Startdate);
                        bi.Click(obj_bpa.Startdate);
                        bi.WaitTime(1);
                        bi.Click(obj_bpa.BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                        Console.WriteLine("BPA NEGATIVE: Start Date selected for " + BrowserURLLaunch.ROLES);
                    }
                    bi.WaitTime(5);
                    bi.Click(obj_bpa.NextButton);
                    if (bi.IsElementPresent(obj_bpa.ErrorEndDateRequired))
                    {
                        bi.WaitVisible(obj_bpa.Enddate);
                        bi.Click(obj_bpa.Enddate);
                        bi.WaitTime(1);
                        bi.Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                        Console.WriteLine("BPA NEGATIVE: End Date selected for " + BrowserURLLaunch.ROLES);
                    }
                    bi.WaitTime(5);
                    bi.Click(obj_bpa.NextButton);

                    bi.WaitVisible(obj_bpa.SubmitButton);
                    bi.Click(obj_bpa.SubmitButton);
                    bi.WaitTime(3);
                    if (bi.IsElementPresent(obj_bpa.ErrorAttachmentRequired))
                    {
                        bi.Click(obj_bpa.UploadFile);
                        bi.WaitTime(5);
                        CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                        bi.WaitTime(5);
                        if (bi.IsElementPresent(obj_bpa.AttachementRemove))
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

                    if (bi.IsElementPresent(obj_bpa.SubmitButton))
                    {
                        Console.WriteLine("BPA NEGATIVE: Submit Button for submitting a BPA is present");
                    }
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Exception: " + ex);
                throw;
            }
        }

        public void BPA_AdvanceSearch(string BPAID)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(PreApproval_AdvanceSearch));
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.LeftNavPreapprovals);
                bi.Click(obj_bpa.LeftNavPreapprovals);
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);

                bi.WaitTime(5);


                //**Advanced Search functionality
                bi.WaitVisible(obj_bpa.AdvanceSearchLink);
                bi.Click(obj_bpa.AdvanceSearchLink);
                bi.WaitVisible(obj_bpa.ApprovedCheckbox);
                bi.Click(obj_bpa.ApprovedCheckbox);
                bi.WaitVisible(obj_bpa.PendingReviewCheckbox);
                bi.Click(obj_bpa.PendingReviewCheckbox);
                bi.WaitVisible(obj_bpa.HoldCheckbox);
                bi.Click(obj_bpa.HoldCheckbox);
                bi.WaitVisible(obj_bpa.NeedsInformationCheckbox);
                bi.Click(obj_bpa.NeedsInformationCheckbox);
                bi.WaitVisible(obj_bpa.DeniedCheckbox);
                bi.Click(obj_bpa.DeniedCheckbox);
                bi.WaitVisible(obj_bpa.ClosedCheckbox);
                bi.Click(obj_bpa.ClosedCheckbox);
                //bi.WaitVisible(obj_bpa.ResubmittedCheckbox);
                //bi.Click(obj_bpa.ResubmittedCheckbox);
                bi.WaitVisible(obj_bpa.AdvanceSearchBPAIDTextBox);
                bi.Clear(obj_bpa.AdvanceSearchBPAIDTextBox);
                bi.Type(obj_bpa.AdvanceSearchBPAIDTextBox, BPAID);
                bi.WaitTime(10);
                bi.WaitVisible(obj_bpa.AdvanceSearchButton);
                bi.Click(obj_bpa.AdvanceSearchButton);

                bi.WaitTime(10);
                bi.Click(obj_bpa.BPASearchResult(BPAID));
                bi.WaitTime(5);
                if (bi.IsElementPresent(obj_bpa.BPAResponseDropdown))
                {
                    Console.WriteLine("Advance Search is working fine");
                }
                else
                {
                    Console.WriteLine("Advance search is not working");
                }
                //Wait.WaitVisible(BPAResponseDropdown);
                //BPAResponseDropdown.Click();
                //Wait.WaitTime(5);
                //BPAResponseAction(action).Click();
                //BPAComments.Type(action);
                //BPASendResponseButton.Click();
                //Wait.WaitVisible(SearchPreapprovals);
                //SearchPreapprovals.Clear();
                //SearchPreapprovals.Type(BPAID);
                //BPASearchResult(BPAID).Click();
                //Console.WriteLine(BPAID + " - " + action);
            }
            catch (Exception e)
            {
                Console.WriteLine("PreApproval_AdvanceSearch " + e);
                Assert.Fail("PreApproval_AdvanceSearch " + e);
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

            }

        }

        public void BPA_Resubmitted(string BPAID)
        {

            try
            {
                //OBJ_BrandPreApprovals obj_bpa = new OBJ_BrandPreApprovals();
                //BasicInteractions bi = new BasicInteractions(Driver);
                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.LeftNavPreapprovals);
                bi.Click(obj_bpa.LeftNavPreapprovals);
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);

                bi.WaitTime(5);

                //**Simple Search functionality
                bi.WaitVisible(obj_bpa.SearchPreapprovals);
                bi.TypeClear(obj_bpa.SearchPreapprovals, BPAID);
                bi.Click(obj_bpa.AdvanceSearchButton);
                bi.WaitTillNotVisible(obj_bpa.loadingImageBrandingPreApproval);
                bi.WaitTime(5);
                if (bi.IsElementPresent(obj_bpa.BPASearchResult(BPAID)))
                {
                    Console.WriteLine("Advance Search is working fine");
                    bi.Click(obj_bpa.BPASearchResult(BPAID));
                    bi.WaitTillNotVisible(obj_bpa.imgLoading);
                    bi.WaitTime(5);
                }
                else
                {
                    Console.WriteLine("Advance search is not working");
                    Assert.Fail();
                }

                bi.WaitVisible(obj_bpa.EditButton);
                bi.Click(obj_bpa.EditButton);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);
                bi.WaitTime(5);

                bi.WaitVisible(obj_bpa.NextButton);
                bi.Click(obj_bpa.NextButton);
                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.SubmitButton);
                bi.Click(obj_bpa.SubmitButton);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);
                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.ViewPreapprovalStatus);
                bi.Click(obj_bpa.ViewPreapprovalStatus);
                bi.WaitTillNotVisible(obj_bpa.imgLoading);
                bi.WaitTime(5);
                //Wait.WaitVisible(BPAID);

                Console.WriteLine(bi.GetText(obj_bpa.BPAID));
                //preapproval_FullFlow.BPA_ID = bi.GetText(obj_bpa.BPAID);
                String GblBPAID = bi.GetText(obj_bpa.BPAID);
                bi.WaitVisible(obj_bpa.BPAStatus);
                Console.WriteLine(bi.GetText(obj_bpa.BPAStatus));
                Assert.IsTrue(bi.GetText(obj_bpa.BPAStatus) == "Resubmitted");
                //{
                Console.WriteLine("BPA " + bi.GetText(obj_bpa.BPAID) + " Resubmitted successfully");

                //return GblBPAID;

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                Console.WriteLine("Exception:" + ex.Message);
            }
        }
    }
}
