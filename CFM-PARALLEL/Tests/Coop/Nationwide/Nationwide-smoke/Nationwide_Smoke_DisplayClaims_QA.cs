using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.UI.Functions.Nationwide;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CFM_PARALLEL.Tests.Coop.Nationwide.Nationwide_smoke
{
   public class Nationwide_Smoke_DisplayClaims_QA : Base
    {
        public class Smoke_Nationwide_QA : Base
        {
            [Test, Parallelizable]
            [Category("CFM_NATIONWIDE_SMOKE")]
            public void ST_TC_NW_DisplayClaimCreation()
            {
                IWebDriver Driver = null;
                try
                {
                    Driver = OpenBrowser();
                    BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                    bl.BrowserURL_NATIONWIDE("LME1"); // LME login
                    bl.Click_CFMLink();
                    NW_DisplayClaims nW_DC = new NW_DisplayClaims(Driver);
                    // create display claim 
                    String DisplayClaimID = nW_DC.Create_DisplayClaim(Parameters.NW_RequestedAmount, Parameters.NW_StoreName, Parameters.NW_ProgramName);
                    string DisplayClaim_Status = nW_DC.Search_DisplayClaimStatus(DisplayClaimID); // Search_Display Claim Status
                    Assert.AreEqual(DisplayClaim_Status, "Pending Review"); //Assertion used to validate the Display Claim status
                    Console.WriteLine("The status of the Display Claim after submission is  " + DisplayClaim_Status);
                    CommonUtilities.Logout(Driver);
                    Driver.Quit();

                    // Approver requires admin login
                    Driver = OpenBrowser();
                    BrowserURLLaunch b2 = new BrowserURLLaunch(Driver);
                    b2.BrowserURL_NATIONWIDE("CORPORATE1"); // Admin login
                    b2.Click_CFMLink();

                    NW_DisplayClaims nW_DC1 = new NW_DisplayClaims(Driver);
                    nW_DC1.Review_DisplayClaim(DisplayClaimID, "Hold"); // Review Display claim
                    DisplayClaim_Status = nW_DC.Search_DisplayClaimStatus(DisplayClaimID); // Search_Display Claim Status
                    Assert.AreEqual(DisplayClaim_Status, "Hold"); //Assertion used to validate the Display Claim status
                    Console.WriteLine("The status of the fund request after approval is  " + DisplayClaim_Status);

                    CommonUtilities.Logout(Driver);
                    Driver.Quit();



                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Exception in ST_TC_NW_DisplayClaimCreation method : " + ex.Message);
                    throw;
                }
               
            }
        }
    }
}
