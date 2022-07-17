using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Pre_Approvals;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval
{
    public class Preapproval_FullFlow
    {
        private IWebDriver Driver { get; set; }

        public Preapproval_FullFlow(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public string db_activity, db_lme, db_startdate, db_enddate, db_attachment, db_comments;
        public string Mongo_BPA_ID;
        public string BPA_ID;

       
        /// <summary>
        /// 
        /// </summary>
        public void Preapproval_DataBrowserURLLaunchRead()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Preapproval_FullFlow));
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
                SqlConnection connection_bpa_db = new SqlConnection(connection_db);
                string claim_query = "select * from CFMPreApproval";
                connection_bpa_db.Open();
                SqlCommand claim_cmd = new SqlCommand(claim_query, connection_bpa_db);
                using (SqlDataReader read = claim_cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        db_activity = read["activitytype"].ToString();
                        db_lme = read["lme"].ToString();
                        db_startdate = read["startdate"].ToString();
                        db_enddate = read["enddate"].ToString();
                        db_comments = read["comments"].ToString();
                        //Console.WriteLine(db_activity + " |"+ db_lme + " |" + db_startdate + " |" + db_enddate + " |" + db_comments);
                    }
                }
                connection_bpa_db.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Preapproval_DataBrowserURLLaunchRead DataBrowserURLLaunch connection error is: " + ex);
                Assert.Fail("Preapproval_DataBrowserURLLaunchRead DataBrowserURLLaunch connection error is: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void BrandingPreapproval_VerifyingonMangoDB(string BPA_ID)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Preapproval_FullFlow));
            try
            {
                var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDB"].ToString());
                var dataBrowserURLLaunch = client.GetDatabase(ConfigurationManager.AppSettings["MongoDbKey"].ToString());
                var collection = dataBrowserURLLaunch.GetCollection<BsonDocument>("BrandingRequest");
                //var x = collection.AsQueryable().ToList();
                //var BPACreated = x.Where(z => z["BrandingRequestId"] == Convert.ToInt64(BPA_ID.Substring(4))).Select(y => y["BrandingRequestId"].ToString());

                //if (BPACreated.Any())
                //{
                //    Console.WriteLine(BPA_ID + " BPA was created successfully, present in Mongo DB");
                //}
                //else
                //{
                //    Console.WriteLine("BPA was NOT created successfully, Not present in Mongo DB");
                //}
                //var filter = Builders<BsonDocument>.Filter.Eq("BrandingRequestId", "NumberLong("+BPA_ID.Substring(4)+")");
                var filter = Builders<BsonDocument>.Filter.Eq("BrandingRequestId", Convert.ToInt64(BPA_ID.Substring(4)));

                var list = collection.Find(filter).ToList();
                Assert.True(list.Count != 0);
                //{
                    Console.WriteLine("Newly Created BPA available in MangoDB");
                //}


            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();                
                Console.WriteLine("BrandingPreapproval_MongoDataBrowserURLLaunchRead failed due to: " + ex);
                Assert.Fail("BrandingPreapproval_MongoDataBrowserURLLaunchRead failed due to: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string ACE_Preapproval_Fullflow()
        {
            string GBPA_ID = null;
            try
            {

                Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                //pf.Preapproval_DataBrowserURLLaunchRead();
                Preapprovals_EnterDetails pe = new Preapprovals_EnterDetails(Driver);
                pe.Ace_Preapproval_EnterDetails(db_activity, db_lme, db_startdate, db_enddate);
                Preapprovals_AddAttachments pa = new Preapprovals_AddAttachments(Driver);
                string BPA_ID = pa.ACE_Preapproval_AddAttachment(db_comments);
                GBPA_ID = BPA_ID;
                //pf.BrandingPreapproval_MongoDataBrowserURLLaunchReadAsync(BPA_ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return GBPA_ID;
        }

        public string ACE_Preapproval_Fullflow_Smoke()
        {
            string GBPA_ID = null;
            try
            {
                Preapprovals_EnterDetails pe = new Preapprovals_EnterDetails(Driver);
                pe.Ace_Preapproval_EnterDetails(db_activity, db_lme, db_startdate, db_enddate);
                Preapprovals_AddAttachments pa = new Preapprovals_AddAttachments(Driver);
                BPA_ID = pa.ACE_Preapproval_AddAttachment_Smoke(db_comments);
                GBPA_ID= BPA_ID;
            }
            catch (Exception ex)
            {   
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return GBPA_ID;
        }

        public string Ace_SearchForPendingBPA()
        {
            string GBPA_ID = null;
            try
            {
                Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                Preapprovals_EnterDetails pe = new Preapprovals_EnterDetails(Driver);
                BPA_ID = pe.SearchAndGetPendingReviewBPAID();
                if (BPA_ID == null)
                {
                    pe.Ace_Preapproval_EnterDetails(db_activity, db_lme, db_startdate, db_enddate);
                    Preapprovals_AddAttachments pa = new Preapprovals_AddAttachments(Driver);
                    BPA_ID = pa.ACE_Preapproval_AddAttachment(db_comments);
                    pf.BrandingPreapproval_VerifyingonMangoDB(BPA_ID);
                }
                GBPA_ID= BPA_ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return GBPA_ID;
        }

        public void BPA_Resubmitted(string BPAID)
        {
            try
            {
                OBJ_PreApprovals obj_bpa = new OBJ_PreApprovals();
                BasicInteractions bi = new BasicInteractions(Driver);
                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.LeftNavPreapprovals);
                bi.Click(obj_bpa.LeftNavPreapprovals);
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_bpa.ImgLoading);

                bi.WaitTime(5);

                //**Simple Search functionality
                bi.WaitVisible(obj_bpa.SearchPreapprovals);
                bi.TypeClear(obj_bpa.SearchPreapprovals,BPAID);
                bi.Click(obj_bpa.AdvanceSearchButton);
                bi.WaitTillNotVisible(obj_bpa.LoadingImageBrandingPreApproval);
                bi.WaitTime(5);
                if(bi.IsElementPresent(obj_bpa.BPASearchResult(BPAID)))
                {
                    Console.WriteLine("Advance Search is working fine");
                    bi.Click(obj_bpa.BPASearchResult(BPAID));
                    bi.WaitTillNotVisible(obj_bpa.ImgLoading);
                    bi.WaitTime(5);
                }
                else
                {
                    Console.WriteLine("Advance search is not working");
                    Assert.Fail();
                }

                bi.WaitVisible(obj_bpa.EditButton);
                bi.Click(obj_bpa.EditButton);
                bi.WaitTillNotVisible(obj_bpa.ImgLoading);
                bi.WaitTime(5);

                bi.WaitVisible(obj_bpa.NextButton);
                bi.Click(obj_bpa.NextButton);
                bi.WaitTime(5);
                bi.WaitVisible(obj_bpa.SubmitButton1);
                bi.Click(obj_bpa.SubmitButton1);
                bi.WaitTillNotVisible(obj_bpa.ImgLoading);

                bi.WaitVisible(obj_bpa.ViewPreapprovalStatus);
                bi.Click(obj_bpa.ViewPreapprovalStatus);
                bi.WaitTillNotVisible(obj_bpa.ImgLoading);
                bi.WaitTime(5);

                Console.WriteLine(bi.GetText(obj_bpa.BPAID));
                String GblBPAID = bi.GetText(obj_bpa.BPAID);
                bi.WaitVisible(obj_bpa.BPAStatus);
                Console.WriteLine(bi.GetText(obj_bpa.BPAStatus));
                Assert.IsTrue (bi.GetText(obj_bpa.BPAStatus) == "Resubmitted");
                Console.WriteLine("BPA " + bi.GetText(obj_bpa.BPAID) + " Resubmitted successfully");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
