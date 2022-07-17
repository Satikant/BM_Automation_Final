using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.UI.Functions.Nationwide;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.Tests.Coop.Nationwide.Nationwide_smoke
{
    public class Nationwide_Smoke_Fundrequest_QA
    {
        public class Smoke_Nationwide_QA : Base
        {
            [Test, Parallelizable]
            [Category("CFM_NATIONWIDE_SMOKE")]
            public void ST_TC_NW_FundRequestCreation_Deny()
            {
                IWebDriver Driver = null;
                try
                {
                    Driver = OpenBrowser();
                    BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                    bl.BrowserURL_NATIONWIDE("LME1"); // LME login
                    bl.Click_CFMLink();
                    NW_FundRequest nW_FR = new NW_FundRequest();
                    // create FundRequest
                    string FundRequestID = nW_FR.Create_FundRequest(Parameters.NW_RequestedAmount, Parameters.NW_StoreName, Parameters.NW_ProgramName,true);
                    string FundRequest_Status = nW_FR.Search_FundRequestStatus(FundRequestID); //  Search_FundRequestStatus 
                    Assert.AreEqual(FundRequest_Status, "Pending Review");// Assertion used to validate the fund request status
                    Console.WriteLine("The status of the fund request after submission is  " + FundRequest_Status);
                    CommonUtilities.Logout(Driver);
                    Driver.Quit();

                    // Approver requires admin login
                    Driver = OpenBrowser();
                    BrowserURLLaunch b2 = new BrowserURLLaunch(Driver);
                    b2.BrowserURL_NATIONWIDE("CORPORATE1"); // Admin login
                    b2.Click_CFMLink();
                    NW_FundRequest nW_FR1 = new NW_FundRequest();
                    nW_FR1.Review_FundRequest(FundRequestID, "Reject"); // Review FundRequset
                    FundRequest_Status = nW_FR1.Search_FundRequestStatus(FundRequestID); //Search_FundRequestStatus
                    Assert.AreEqual(FundRequest_Status, "Denied"); //Assertion used to validate the fund request status
                    Console.WriteLine("The status of the fund request after deny is  " + FundRequest_Status);
                    CommonUtilities.Logout(Driver);
                    Driver.Quit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Exception in ST_TC_NW_FundRequestCreation_Deny method : " + ex.Message);
                    throw;
                }
                finally
                {
                    Driver_CleanUp();
                }

            }

            [Test, Parallelizable]
            [Category("CFM_NATIONWIDE_SMOKE")]
            public void ST_TC_NW_FundRequestCreation_Approve()
            {
                IWebDriver Driver = null;
                try
                {
                    Driver = OpenBrowser();
                    BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                    bl.BrowserURL_NATIONWIDE("LME1"); // LME login
                    bl.Click_CFMLink();
                    NW_FundRequest nW_FR = new NW_FundRequest();

                    // create FundRequest
                    string FundRequestID = nW_FR.Create_FundRequest(Parameters.NW_RequestedAmount, Parameters.NW_StoreName, Parameters.NW_ProgramName,true);
                    string FundRequest_Status = nW_FR.Search_FundRequestStatus(FundRequestID); // Search_FundRequestStatus
                    Assert.AreEqual(FundRequest_Status, "Pending Review"); //Assertion used to validate the fund request status
                    Console.WriteLine("The status of the fund request after submission is  " + FundRequest_Status);
                    CommonUtilities.Logout(Driver);
                    Driver.Quit();

                   // Approver requires admin login
                    Driver = OpenBrowser();
                    BrowserURLLaunch b2 = new BrowserURLLaunch(Driver);
                    b2.BrowserURL_NATIONWIDE("CORPORATE1"); // Admin login
                    b2.Click_CFMLink();
                    NW_FundRequest nW_FR1 = new NW_FundRequest();
                    nW_FR1.Review_FundRequest(FundRequestID, "Approve"); // Review FundRequset
                    FundRequest_Status = nW_FR1.Search_FundRequestStatus(FundRequestID); //Search_FundRequestStatus
                    Assert.AreEqual(FundRequest_Status, "Approved"); //Assertion used to validate the fund request status
                    Console.WriteLine("The status of the fund request after approval is  " + FundRequest_Status);
                    CommonUtilities.Logout(Driver);
                    Driver.Quit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Exception in ST_TC_NW_FundRequestCreation_Approve method : " + ex.Message);
                    throw;
                }
                finally
                {
                    Driver_CleanUp();
                }
            }                                                               

        }

    }
}
