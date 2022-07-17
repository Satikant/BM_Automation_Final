using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_FullFlow
    {
        private IWebDriver Driver { get; set; }
        public Claim_FullFlow(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public string db_preapproval, db_lme, db_program, db_claimref, db_products,
            db_activitytype, db_startdate, db_enddate, db_totalactivitycost, db_requestclaim, db_invoicenum, db_attachment, db_comments, db_flag, db_bpachoice;
        public string CLAIM_ID;
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
        public By ImgLoading { get { return By.Id("loading-image"); } }
        public By TblCalimFirstRow { get { return By.XPath("//tbody[contains(@class,'ui-datatable-data')]/tr[1]/td[2]/span[2]/a"); } }

        public void Claim_DataBrowserURLLaunchRead(string bpaChoice)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
           
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
                SqlConnection connection_claim_db = new SqlConnection(connection_db);
                string claim_query = "SELECT * FROM CFMCLAIM where bpachoice='" + bpaChoice + "'";
                connection_claim_db.Open();
                SqlCommand claim_cmd = new SqlCommand(claim_query, connection_claim_db);
                using (SqlDataReader read = claim_cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        db_preapproval = read["preapproval"].ToString();
                        db_lme = read["LME"].ToString();
                        db_program = read["program"].ToString();
                        db_claimref = read["claimref"].ToString();
                        db_products = read["products"].ToString();
                        db_activitytype = read["activitytype"].ToString();
                        db_startdate = read["startdate"].ToString();
                        db_enddate = read["enddate"].ToString();
                        db_totalactivitycost = read["totalactivitycost"].ToString();
                        db_requestclaim = read["requestclaim"].ToString();
                        db_invoicenum = read["invoicenum"].ToString();
                        db_attachment = read["attachment"].ToString();
                        db_comments = read["comments"].ToString();
                        db_flag = read["flag"].ToString();
                        db_bpachoice = read["bpachoice"].ToString();
                    }
                }
                connection_claim_db.Close();
            }
            catch (Exception ex)
            {                           
                Console.WriteLine("DataBrowserURLLaunch connection error is: " + ex);
                Assert.Fail("DataBrowserURLLaunch connection error is: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public void Claim_DataBrowserURLLaunchInsert(string db_claim_id)
        { 
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
                SqlConnection connection_claim_db = new SqlConnection(connection_db);
                string claim_query = "INSERT INTO CFMDISBURSEMENT(CLAIM_ID) VALUES ('" + db_claim_id + "')";
                connection_claim_db.Open();
                SqlCommand claim_cmd = new SqlCommand(claim_query, connection_claim_db);
                claim_cmd.ExecuteNonQuery();
                Console.WriteLine(db_claim_id + " Claim ID inserted into table");
                connection_claim_db.Close();
            }
            catch (Exception ex)
            {              
                Console.WriteLine("DataBrowserURLLaunch connection error is: " + ex);
                Assert.Fail("DataBrowserURLLaunch connection error is: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }        

        public string Ace_Claim_FullFlow(string bpaChoice, string bpaID, string ProgramOverDrawn = "NO", string Env="QA")
        {
            try
            {
                Claim_ChooseProgram cc = new Claim_ChooseProgram(Driver);
                cc.Ace_Claim_ChooseProgram(bpaID, bpaChoice, db_lme, Env, ProgramOverDrawn);
                Claim_EnterDetails ce = new Claim_EnterDetails(Driver);
                if (ProgramOverDrawn == "NO")
                {
                    ce.Ace_Claim_EnterDetails(db_activitytype, bpaChoice);
                }
                else
                {
                    ce.Ace_Claim_EnterDetailsOverD(db_activitytype, bpaChoice);
                }
                Claim_AttachDocuments ca = new Claim_AttachDocuments(Driver);
                ca.Ace_Claim_AttachDocument();
                if (Env.ToUpper() != "PROD".ToUpper())
                {
                    Claim_ReviewSubmit cr = new Claim_ReviewSubmit(Driver);
                    CLAIM_ID = cr.Ace_Claim_ReviewSubmit();
                    return CLAIM_ID;
                }
                else
                {
                    Console.WriteLine("Skipping Submitting Claim in Prod Env");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw ex;
            }
        }

        //public string Ace_Claim_FullFlow_Smoke(string bpaChoice, string bpaID, string ProgramOverDrawn = "NO")
        //{
        //    Claim_FullFlow cf = new Claim_FullFlow(Driver);
        //    //cf.Claim_DataBrowserURLLaunchRead(bpaChoice);
        //    Claim_ChooseProgram cc = new Claim_ChooseProgram(Driver);
        //    cc.Ace_Claim_ChooseProgram(bpaID, bpaChoice, db_lme, ProgramOverDrawn);
        //    Claim_EnterDetails ce = new Claim_EnterDetails(Driver);
        //    if (ProgramOverDrawn == "NO")
        //    {
        //        ce.Ace_Claim_EnterDetails(db_activitytype, bpaChoice);
        //    }
        //    else
        //    {
        //        ce.Ace_Claim_EnterDetailsOverD(db_activitytype, bpaChoice);
        //    }
        //    Claim_AttachDocuments ca = new Claim_AttachDocuments(Driver);
        //    ca.Ace_Claim_AttachDocument();
        //    Claim_ReviewSubmit cr = new Claim_ReviewSubmit(Driver);
        //    CLAIM_ID = cr.Ace_Claim_ReviewSubmit();
        //    return CLAIM_ID;
        //}

        //public string Ace_Claim_FullFlowOverDew(string bpaChoice, string bpaID, string ProgramOverDrawn = "YES")
        //{
        //    Claim_FullFlow cf = new Claim_FullFlow(Driver);
        //    //cf.Claim_DataBrowserURLLaunchRead(bpaChoice);
        //    Claim_ChooseProgram cc = new Claim_ChooseProgram(Driver);
        //    cc.Ace_Claim_ChooseProgram(bpaID, bpaChoice, db_lme, ProgramOverDrawn);
        //    Claim_EnterDetails ce = new Claim_EnterDetails(Driver);
        //    ce.Ace_Claim_EnterDetailsOverD(db_activitytype, bpaChoice);
        //    Claim_AttachDocuments ca = new Claim_AttachDocuments(Driver);
        //    ca.Ace_Claim_AttachDocument();
        //    Claim_ReviewSubmit cr = new Claim_ReviewSubmit(Driver);
        //    CLAIM_ID = cr.Ace_Claim_ReviewSubmit();
        //    return CLAIM_ID;
        //}

        public string NavigatetoCalimsAndGetExistingApprovedClaimID()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(LeftNavClaim);
                Pages.BasicInteractions().Click(LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);

                ////**simple search functionality
                //wait.waitvisible(searchclaim);
                //searchclaim.clear();
                //searchclaim.type(claimid);
                //searchclaim.type(keys.enter);
                //wait.waittime(10);

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
                string ClaimID = Pages.BasicInteractions().GetText(TblCalimFirstRow);
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
            BasicInteractions bi = new BasicInteractions(Driver);
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(LeftNavClaim);
                Pages.BasicInteractions().Click(LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);

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
                Pages.BasicInteractions().Click(PendingReviewCheckbox);
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(AdvanceSearchClaimIDTextBox, ClaimId);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(10);
                string ClaimID = Pages.BasicInteractions().GetText(TblCalimFirstRow);
                return ClaimID;
            }
            catch (Exception ex)
            {              
                Console.WriteLine("Exception:" + ex.Message);
                throw ex;
            }
        }       
    }
}
