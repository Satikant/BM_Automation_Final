
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_PerformAction
    {
        public Claim_PerformAction()
        {
           
        }
        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }
        public By AdvanceSearchStatus { get { return (By.XPath("//label[text()='Status']/parent::div//div[contains(@class,'ui-multiselect-label-container')]")); } }


        public By SearchClaim { get { return (By.Id("searchId")); } }
        public By AdvanceSearchLink { get { return (By.XPath("//button[@id='advSearchbtn')]")); } }
        public By AdvanceSearchClaimIDTextBox { get { return (By.Id("claimId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//li[@aria-label='PendingReview']//div[contains(@class,'chkbox-box')]")); } }
        public By ApprovedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Approved')]")); } }
        public By ClaimSearchResult(string ClaimId) { return (By.PartialLinkText(ClaimId)); }
        public By ClaimResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'ReviewerAction')]//div//label")); } }
        public By ClaimResponse(string action) { return (By.XPath("//li[contains(@class,'ui-dropdown-item')]/span[contains(.,'" + action + "')]")); }
        public By ClaimApprovedAmount { get { return (By.Id("approvedAmount")); } }
        public By ClaimReviewCodeDropdown { get { return (By.XPath("//p-multiselect[contains(@formcontrolname,'ReviewCode')]")); } }
        public By ClaimReviewCodeText { get { return (By.XPath("//div[contains(@class,'ui-multiselect-filter-container')]//input")); } }
        //public By ClaimReviewCodeTextSelect { get { return (By.XPath("//li[contains(@class,'ui-multiselect-item ui-corner-all ng-star-inserted')]//div[contains(@class,'ui-chkbox ui-widget')]")); } }
        public By ClaimReviewCodeTextSelect { get { return (By.XPath("(//div[contains(@class,'ui-chkbox-box ui-widget ui-corner-all ui-state-default')])[2]")); } }
        public By ClaimComments { get { return (By.XPath("//textarea[contains(@formcontrolname,'ReviewComment')]")); } }
        public By ClaimSendResponseButton { get { return (By.Id("sendRespond")); } }
        public By ClaimActionMessage { get { return (By.XPath("//label[contains(@contains(@class,'Approve')]")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By tblCalimFirstRow { get { return By.XPath("//tbody[contains(@class,'ui-datatable-data')]/tr[1]/td[2]/span[2]/a"); } }
        public By imgLoadingClaim { get { return By.XPath("//img[@src='assets/images/Ellipsis.gif']"); } }
        public By tblStatusClaim { get { return By.XPath("//tbody[contains(@class,'ui-datatable-data')]/tr[1]/td[7]/span[2]/span"); } }
        public By ProgramList(string prgname) { return (By.XPath("//ul[contains(@class,'nav nav-tabs')]//li//a[contains(.,'" + prgname + "')]")); }
        public By OtherProgramsLink { get { return (By.PartialLinkText("Other Programs")); } }
        //public By ImgLoadingSnapshot { get { return By.Id("loading-image-snapshot"); } }
        //public By LoadingImageClaim { get { return By.Id("loading-image-claim"); } }
        public By ImgLoadingSnapshot { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }
        public By LoadingImageClaim { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }
        public By CostCenterTextbox { get { return By.XPath("//label[contains(text(),'Cost Center')]/parent::div//input[@type='text']"); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClaimId"></param>
        /// <param name="action"></param>
        /// <param name="reason"></param>
        public void ACE_Claim_PerformAction(string ClaimId, string action)
        {
           
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(LeftNavClaim);
                Pages.BasicInteractions().Click(LeftNavClaim);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoadingClaim);
                ////**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(SearchClaim);
                Pages.BasicInteractions().Clear(SearchClaim);
                Pages.BasicInteractions().Type(SearchClaim,ClaimId);
                //SearchClaim.Type(Keys.Enter);
                //Wait.WaitTime(10);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                //Pages.BasicInteractions().Click(AdvanceSearchLink);
                ////Pages.BasicInteractions().WaitVisible(PendingReviewCheckbox);
                ////Pages.BasicInteractions().Click(PendingReviewCheckbox);
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(AdvanceSearchClaimIDTextBox, ClaimId);
                
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoadingClaim);

                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(ClaimSearchResult(ClaimId));
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(ClaimResponseDropdown);
                Pages.BasicInteractions().Click(ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(ClaimResponse(action));
                if (action.Equals("Approve"))
                {
                    Pages.BasicInteractions().Clear(ClaimApprovedAmount);
                    Pages.BasicInteractions().Type(ClaimApprovedAmount, "10");
                }
                Pages.BasicInteractions().WaitVisible(ClaimSendResponseButton);
                Pages.BasicInteractions().Click(ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Type(ClaimReviewCodeText, Keys.Tab);

                Pages.BasicInteractions().Click(ClaimReviewCodeTextSelect);
                //Pages.BasicInteractions().Type(ClaimReviewCodeText, Keys.Enter);

                //Pages.BasicInteractions().Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                //Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitVisible(SearchClaim);
                Pages.BasicInteractions().Clear(SearchClaim);
                //SearchClaim.Click();
                //Pages.BasicInteractions().Type(SearchClaim, ClaimId);
                //Pages.BasicInteractions().Type(SearchClaim, Keys.Enter);
                //Pages.BasicInteractions().WaitTime(10);
                //Pages.BasicInteractions().Click(ClaimSearchResult(ClaimId));
                //Pages.BasicInteractions().WaitTime(30);
                Console.WriteLine(ClaimId + " - " + action);
                //if (action.Equals("Approve"))
                //{
                //    Claim_FullFlow cf = new Claim_FullFlow(Driver);
                //    cf.Claim_DataBrowserURLLaunchInsert(ClaimId);
                //}
                //Pages.BasicInteractions().WaitTime(10);
            }
            catch (Exception ex)
            {

                Console.WriteLine("ACE_Claim_PerformAction " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
        public void ACE_Claim_PendingReview(string ClaimId)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(LeftNavClaim);
                Pages.BasicInteractions().Click(LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoadingClaim);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                Pages.BasicInteractions().Click(AdvanceSearchLink);
                //Pages.BasicInteractions().WaitVisible(PendingReviewCheckbox);
                //Pages.BasicInteractions().Click(PendingReviewCheckbox);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchClaimIDTextBox);
                Pages.BasicInteractions().Clear(AdvanceSearchClaimIDTextBox);
                Pages.BasicInteractions().Type(AdvanceSearchClaimIDTextBox, ClaimId);
               

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoadingClaim);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(ClaimSearchResult(ClaimId));
                Pages.BasicInteractions().WaitTime(20);
                Pages.BasicInteractions().WaitVisible(ClaimResponseDropdown);
                Pages.BasicInteractions().Click(ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(5);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ACE_Claim_PerformAction " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }

        public void ACE_Claim_PerformActionOD(string ClaimId, string action, string reason, double AmountBeforeApproval, string expectation)
        {
            OBJ_Claims obj_claims = new OBJ_Claims();
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(LeftNavClaim);
                Pages.BasicInteractions().Click(LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoadingClaim);
                Pages.BasicInteractions().WaitTime(5);

                //**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, ClaimId);
                //Pages.BasicInteractions().Type(obj_claims.SearchClaim,Keys.Enter);
                //Pages.BasicInteractions().WaitTime(10);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                //Pages.BasicInteractions().Click(AdvanceSearchLink);
                ////Pages.BasicInteractions().WaitVisible(PendingReviewCheckbox);
                ////Pages.BasicInteractions().Click(PendingReviewCheckbox);
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(AdvanceSearchClaimIDTextBox, ClaimId);
                //Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(ClaimSearchResult(ClaimId));
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(ClaimResponseDropdown);
                Pages.BasicInteractions().Click(ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(ClaimResponse(action));
                if (action.Equals("Approve"))
                {
                    Pages.BasicInteractions().Clear(ClaimApprovedAmount);
                    Pages.BasicInteractions().Type(ClaimApprovedAmount, Parameters.ClaimRequestedAmount_ACE("YES"));
                }
                Pages.BasicInteractions().WaitVisible(ClaimSendResponseButton);
                Pages.BasicInteractions().Click(ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().TypeClear(ClaimReviewCodeText, reason);
                Pages.BasicInteractions().Click(ClaimReviewCodeTextSelect);
                Pages.BasicInteractions().Type(ClaimReviewCodeText, Keys.Enter);
                //Pages.BasicInteractions().Click(ClaimReviewCodeDropdown);

                // Pages.BasicInteractions().Type(ClaimReviewCodeText, Keys.Tab);
                //Pages.BasicInteractions().TypeClear(ClaimComments, "Claim-Perform Action Comments: " + action);
                //Pages.BasicInteractions().WaitTime(2);
                //Pages.BasicInteractions().Click(ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(SearchClaim);
                Pages.BasicInteractions().Clear(SearchClaim);
                Console.WriteLine(ClaimId + " - " + action);
                //var avalableFundNow = "";
                //ACE_Claim_Validation(out avalableFundNow, AmountBeforeApproval, Expectation: expectation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ACE_Claim_PerformAction " + ex);
                Assert.Fail("ACE_Claim_PerformAction " + ex);
            }
        }

        public By clickOtherProgram { get { return (By.XPath("//a[@class='dropdown-toggle']")); } }
        public By ProgramName { get { return (By.XPath("//a[@data-toggle='tab'][contains(text(),'QAAutomation26')]")); } }
        public By AvailableFunds { get { return (By.XPath("//span[@class='float-Right Approved']")); } }//$(148,499,172.16)
        public By dashoboard { get { return (By.XPath("//span[contains(text(),'DASHBOARD')]")); } }//$(148,499,172.16)
        public string AvailableBalance = string.Empty;                                                                                     //span[contains(text(),'DASHBOARD')]

        public void ACE_Claim_Validation(out string AvailableMoney, double BeforeFundAmount, string ProgramName = "QAProgramOverdrawn", string Expectation = "N/A")
        {
            try
            {
                ProgramName = Parameters.Ace_ProgramName("YES");
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(dashoboard);
                Pages.BasicInteractions().Click(dashoboard);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTime(5);
                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(clickOtherProgram);
                //Pages.BasicInteractions().Click(clickOtherProgram);
                //Pages.BasicInteractions().WaitTime(10);
                //ProgramName = "//a[@data-toggle='tab'][contains(text(),'" + ProgramName + "')]";
                //Driver.FindElement(By.XPath(ProgramName)).Click();
                
                if (Pages.BasicInteractions().IsElementDisplayed(ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(ProgramList(ProgramName));

                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(OtherProgramsLink);
                    Pages.BasicInteractions().Click(OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(ProgramList(ProgramName));
                }
                
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoadingSnapshot);
                Pages.BasicInteractions().WaitTime(5);
                var str = Pages.BasicInteractions().GetText(AvailableFunds);
                //var str = "//$(148,499,172.16)";
                char[] n = str.ToCharArray();
                AvailableMoney = "";
                for (int i = 0; i < n.Length; i++)
                {
                    if (n[i] != '$' && n[i] != ',' && n[i] != '(' && n[i] != ')')
                    {
                        AvailableMoney = AvailableMoney + n[i];
                    }
                }

                float value;
                float.TryParse(AvailableMoney, out value);

                switch (Expectation)
                {
                    case "IncreaseInValue":

                        if (value > BeforeFundAmount)
                        {
                            if (BeforeFundAmount == (value - 4000))
                            {
                                Console.WriteLine("Available Fund correct {0} as per Calculations-->", AvailableMoney);
                            }
                        }
                        else
                        {
                            throw new Exception("Amount is not proper  it showing as -->" + value);
                        }
                        break;
                    case "AmountAfterNeedChange":
                        if (value > BeforeFundAmount)
                        {
                            if (BeforeFundAmount == (value - 4000))
                            {
                                Console.WriteLine("Available Fund correct {0} as per Calculations-->", AvailableMoney);
                            }
                        }
                        else
                        {
                            throw new Exception("Amount is not proper  it showing as -->" + value);
                        }
                        break;
                    case "N/A":
                        Console.WriteLine("Available Fund now-->" + AvailableMoney);
                        break;
                    case "Hold":
                        Console.WriteLine("Available Fund now-->" + AvailableMoney);
                        break;
                    case "DenyValue":
                        Console.WriteLine("Available Fund now-->" + AvailableMoney);
                        break;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Not able to fillDealer creation Page - Flow Failed - Due to - : " + error);
                throw error;
            }
        }

        //Search for Approved Claims
        public string SearchAndGetClaimIdofApprovedClaim()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(LeftNavClaim);
                Pages.BasicInteractions().Click(LeftNavClaim);
                //Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                ////**Simple Search functionality
                //Wait.WaitVisible(SearchClaim);
                //SearchClaim.Clear();
                //SearchClaim.Type(ClaimId);
                //SearchClaim.Type(Keys.Enter);
                //Wait.WaitTime(10);

                //**Advance Search functionality
                Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                Pages.BasicInteractions().Click(AdvanceSearchLink);
                Pages.BasicInteractions().WaitVisible(ApprovedCheckbox);
                Pages.BasicInteractions().Click(ApprovedCheckbox);
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(AdvanceSearchClaimIDTextBox, ClaimId);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(10);
                String ClaimID=Pages.BasicInteractions().GetText(tblCalimFirstRow);
                return ClaimID;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception:" + ex.Message);
                throw ex;
            }
        }


        //Search for Approved Claims
        public string SearchAndGetClaimIdofPendingReviewClaim()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(LeftNavClaim);
                Pages.BasicInteractions().Click(LeftNavClaim);
                Pages.BasicInteractions().WaitTime(10);
               // Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

               
                //**Advance Search functionality
                Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                Pages.BasicInteractions().Click(AdvanceSearchLink);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchStatus);
                Pages.BasicInteractions().Click(AdvanceSearchStatus);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(PendingReviewCheckbox);
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(AdvanceSearchClaimIDTextBox, ClaimId);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(LoadingImageClaim);
                String ClaimID = Pages.BasicInteractions().GetText(tblCalimFirstRow);
                return ClaimID;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Exception:" + ex.Message);
                throw ex;
            }
        }

        //Search and Get Claim Status
        //Search for Approved Claims
        public string GetClaimStatus(String ClaimID)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(LeftNavClaim);
                Pages.BasicInteractions().Click(LeftNavClaim);
                //Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                ////**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(SearchClaim);
                Pages.BasicInteractions().Clear(SearchClaim);
                Pages.BasicInteractions().Type(SearchClaim, ClaimID);
                //Pages.BasicInteractions().Type(SearchClaim,Keys.Enter);
                //Pages.BasicInteractions().WaitTime(10);

                ////**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                //Pages.BasicInteractions().Click(AdvanceSearchLink);
                //Pages.BasicInteractions().WaitVisible(ApprovedCheckbox);
                //Pages.BasicInteractions().Click(PendingReviewCheckbox);
                ////Pages.BasicInteractions().WaitVisible(AdvanceSearchClaimIDTextBox);
                ////Pages.BasicInteractions().Clear(AdvanceSearchClaimIDTextBox);
                ////Pages.BasicInteractions().Type(AdvanceSearchClaimIDTextBox, ClaimId);
                //Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);

                Pages.BasicInteractions().WaitTillNotVisible(imgLoadingClaim);
                Pages.BasicInteractions().WaitTime(10);
                return Pages.BasicInteractions().GetText(tblStatusClaim);
            }
            catch (Exception ex)
            { 

                Console.WriteLine("Exception:" + ex.Message);
                throw ex;
            }
        }

        public void ACE_Claim_Approve(string ClaimId, string action, string reason,string ApprovalAmount)
        {
            OBJ_Claims obj_claims = new OBJ_Claims();
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Claim_PerformAction));
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(LeftNavClaim);
                Pages.BasicInteractions().Click(LeftNavClaim);
                //Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                //**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, ClaimId);
                //Pages.BasicInteractions().Type(obj_claims.SearchClaim,Keys.Enter);
                //Pages.BasicInteractions().WaitTime(10);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                //Pages.BasicInteractions().Click(AdvanceSearchLink);
                ////Pages.BasicInteractions().WaitVisible(PendingReviewCheckbox);
                ////Pages.BasicInteractions().Click(PendingReviewCheckbox);
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(AdvanceSearchClaimIDTextBox, ClaimId);
                //Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);

                Pages.BasicInteractions().Click(ClaimSearchResult(ClaimId));
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                //Pages.BasicInteractions().WaitTime(20);
                Pages.BasicInteractions().WaitVisible(ClaimResponseDropdown);
                Pages.BasicInteractions().Click(ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(ClaimResponse(action));
                if (action.Equals("Approve"))
                {
                    Pages.BasicInteractions().Clear(ClaimApprovedAmount);
                    Pages.BasicInteractions().Type(ClaimApprovedAmount, ApprovalAmount);
                }
                Pages.BasicInteractions().WaitVisible(ClaimSendResponseButton);
                Pages.BasicInteractions().Click(ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Type(ClaimReviewCodeText, reason);
                Pages.BasicInteractions().Click(ClaimReviewCodeTextSelect);
                //Pages.BasicInteractions().Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                //Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitVisible(SearchClaim);
                Pages.BasicInteractions().Clear(SearchClaim);
                //SearchClaim.Click();
                //Pages.BasicInteractions().Type(SearchClaim, ClaimId);
                //Pages.BasicInteractions().Type(SearchClaim, Keys.Enter);
                //Pages.BasicInteractions().WaitTime(10);
                //Pages.BasicInteractions().Click(ClaimSearchResult(ClaimId));
                //Pages.BasicInteractions().WaitTime(30);
                Console.WriteLine(ClaimId + " - " + action);
                //if (action.Equals("Approve"))
                //{
                //    Claim_FullFlow cf = new Claim_FullFlow(Driver);
                //    cf.Claim_DataBrowserURLLaunchInsert(ClaimId);
                //}
                //Pages.BasicInteractions().WaitTime(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ACE_Claim_PerformAction " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
