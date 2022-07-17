using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.FundRequest;
using CFMAutomation.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions.Nationwide
{
    class NW_Payments
    {

        private IWebDriver Driver;
        private BasicInteractions bi;
        private OBJ_FundRequest obj_FundRequest;
        private OBJ_Payments obj_Payments;
        private Parameters parameters;

        //Constructor
        public NW_Payments(IWebDriver Driver)
        {
            this.Driver = Driver;

            bi = new BasicInteractions(Driver);
            obj_FundRequest = new OBJ_FundRequest();
            obj_Payments = new OBJ_Payments();
            parameters = new Parameters();


        }

        public void Create_PaperCheckProfile1()
        {
            try
            {
                bi.WaitVisible(obj_Payments.LeftNavPamentProfiles);
                bi.Click(obj_Payments.LeftNavPamentProfiles);
                bi.WaitTime(7);
                bi.WaitVisible(obj_Payments.PaymentProfilesPageEftnavpageheader);
                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilebutton);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfileslink);
               // bi.WaitVisible(obj_Payments.PaymentProfilesPageEftnav);
                //bi.WaitVisible(obj_Payments.PaymentProfilesPagePaperchecknav);

                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilebutton);
                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageheadertext);
                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageheadertext1);
                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePagebacktoallprofileslink);
                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageupdateuserprofilelink);
                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePagePaperCheckButton);
                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfileEFTButton);

                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagePaperCheckButton);
                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepchecksec);





                checkValuesPresent("Business Name");
                checkValuesPresent("Country");
                checkValuesPresent("Address");
                checkValuesPresent("Street");
                checkValuesPresent("City");
                checkValuesPresent("State");
                checkValuesPresent("Zipcode");

                bi.WaitTime(2);
                bi.Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckbusinessnametextbox, Parameters.NW_BusinessName);

                bi.WaitTime(2);

                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdown);
                bi.Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdownbox, Parameters.NW_Country);
                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdownboxselect);



                //bi.SelectByText(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdown, "United States of America");
                //bi.SelectByText(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcountrydropdownbox, "United States of America");


                bi.WaitTime(2);
                bi.Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckaddresstextbox, Parameters.NW_Address);

                bi.WaitTime(2);
                bi.Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstreettextbox, Parameters.NW_Street);

                bi.WaitTime(2);
                bi.Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckcitytextbox, Parameters.NW_City);

                bi.WaitTime(2);
                //bi.SelectByText(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdown, "Ohio");
                //bi.SelectByText(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdown, "United States of America");
                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdown);
                bi.Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdownbox, Parameters.NW_State);
                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckstatedropdownselect);

                
                bi.WaitTime(2);
                bi.Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepcheckzipcodetextbox, Parameters.NW_Zipcode);

                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTpapersubmitbutton);
                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTpapersubmitbutton);
                bi.WaitTime(3);

                bi.WaitVisible(obj_Payments.PaymentProfilesPagepaymentProfilecreatedscucesswindow);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagepaymentProfilecreatedscucesswindowbacktoallprofilebutton);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagepaymentProfilecreatedscucesswindowpaymentprofilebutton);

                bi.Click(obj_Payments.PaymentProfilesPagepaymentProfilecreatedscucesswindowbacktoallprofilebutton);
                bi.WaitTime(5);


                bi.WaitUntilElementClickable(obj_Payments.PaymentProfilesPagePaperchecknav, 60);
                bi.Click(obj_Payments.PaymentProfilesPagePaperchecknav);

                bi.WaitTime(3);
                checkPapaerCheckValuesPresent(Parameters.NW_Address);
                checkPapaerCheckValuesPresent(Parameters.NW_Street);
                checkPapaerCheckValuesPresent(Parameters.NW_City);
                checkPapaerCheckValuesPresent(Parameters.NW_State);
                checkPapaerCheckValuesPresent(Parameters.NW_Zipcode);

                bi.WaitTime(3);
                bi.ScrollToViewElement(obj_Payments.PaymentProfilesPagemappaymentProfileslink);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfileslink);
                bi.Click(obj_Payments.PaymentProfilesPagemappaymentProfileslink);

                bi.WaitTime(5);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentprofilespageheadervalue);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentprofilespageprogramnametextvalue);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentprofilespagepaymentprofiletextvalue);

                bi.WaitTime(3);
                bi.Click(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileediticon);
                bi.WaitTime(1);
                bi.Click(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditfilterdropdown);

                bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindow);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowefttextvalue);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowpaperchecktextvalue);


                //bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowprofilecountlists);
                bi.WaitVisible(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindow);

                bi.WaitTime(2);

                checkPapaerCheckValuesPresentinPoupWindow(Parameters.NW_Address);
                checkPapaerCheckValuesPresentinPoupWindow(Parameters.NW_Street);
                checkPapaerCheckValuesPresentinPoupWindow(Parameters.NW_City);
                checkPapaerCheckValuesPresentinPoupWindow(Parameters.NW_State);
                checkPapaerCheckValuesPresentinPoupWindow(Parameters.NW_Zipcode);

                bi.WaitTime(5);


               

            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }


       /* public string Create_PaperCheckProfile231(string NW_RequestedAmount)
        {
            try
            {
                bi.WaitVisible(obj_FundRequest.LeftNavFundRequest);
                bi.Click(obj_FundRequest.LeftNavFundRequest);
                bi.WaitTime(20);
                bi.WaitVisible(obj_FundRequest.CreateFundRequestButton);
                bi.Click(obj_FundRequest.CreateFundRequestButton);
                bi.WaitVisible(obj_FundRequest.StoreDropdown);
                //Fill details of Claim
                FillFundRequestDetails(NW_RequestedAmount);
                //Submit FundRequset
                string FundRequestID = SubmitFundRequest();
                return FundRequestID;

            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }*/

      

        //Values Available in Page 
        public void checkValuesPresent(string Name)
        {
            ////log4net.Config.XmlConfigurator.Configure();
            ////ILog logger = LogManager.GetLogger(typeof(ATTLandi_CA));

            try
            {
                bi.WaitForPageToLoad();
                IList<IWebElement> sectionList = bi.getElements(obj_Payments.PaymentProfilesPageAddPaymentProfilePagepchecksecvaluelist);
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

        

        public void checkPapaerCheckValuesPresent(string Name)
        {
            ////log4net.Config.XmlConfigurator.Configure();
            ////ILog logger = LogManager.GetLogger(typeof(ATTLandi_CA));

            try
            {
                bi.WaitForPageToLoad();
                IList<IWebElement> sectionList = bi.getElements(obj_Payments.PaymentProfilesPagepaperchecknavpageheadervaluelists);
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

        public void checkPapaerCheckValuesPresentinPoupWindow(string Name)
        {
            ////log4net.Config.XmlConfigurator.Configure();
            ////ILog logger = LogManager.GetLogger(typeof(ATTLandi_CA));

            try
            {
                bi.WaitForPageToLoad();
                IList<IWebElement> sectionList = bi.getElements(obj_Payments.PaymentProfilesPagemappaymentProfilespagePaymentProfileeditwindowpaperchecklists);
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
                bi.SelectByValue(obj_Payments.NationwideBusinessUnit, "430");
            }

            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in SelectNationwideBusinessUnit:" + ex.Message);
                throw;
            }
        }

        // emulate to real user
        public void EmulateUser()
        {
            try
            {
                bi.WaitVisible(obj_Payments.EmulateUser);
                bi.Click(obj_Payments.EmulateUser);
                bi.WaitVisible(obj_Payments.EmulateUserTextbox);
                bi.Click(obj_Payments.EmulateUserTextbox);
                bi.Type(obj_Payments.EmulateUserTextbox, Parameters.EmulateUserName);
                bi.WaitTime(5);
                bi.Type(obj_Payments.EmulateUserTextbox, Keys.Enter);
                bi.Click(obj_Payments.EmulationButton);
                bi.WaitVisible(obj_Payments.V5CFMLink);

                if (bi.IsElementPresent(obj_Payments.V5CFMLink))
                {
                    bi.WaitVisible(obj_Payments.V5CFMLink);
                    bi.Click(obj_Payments.V5CFMLink);
                    bi.WaitVisible(obj_Payments.LeftNavDashboard);
                }
                else
                {
                    Console.WriteLine("CFM Link is not Available");
                }
            }

            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in EmulateUser:" + ex.Message);
                throw;
            }
        }

        //Validation of payment
        public void Validate_Payment()
        {
            try
            {
                bi.WaitVisible(obj_Payments.LeftNavPamentProfiles);
                bi.WaitTime(2);

                bi.Click(obj_Payments.LeftNavPamentProfiles);
                bi.WaitVisible(obj_Payments.ElectronicFundTransfer);

                bi.IsElementPresent(obj_Payments.ElectronicFundTransfer);
                bi.Click(obj_Payments.ElectronicFundTransfer);
                bi.IsElementPresent(obj_Payments.PaperCheck);
                bi.Click(obj_Payments.PaperCheck);
                bi.WaitTime(2);
                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilebutton);

                //Validate EFT
                bi.WaitVisible(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTRoutingNumberTextbox);
                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTRoutingNumberTextbox);
                bi.Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTRoutingNumberTextbox, Parameters.NW_RoutingNumber);
                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTAccountNumberTextbox);
                bi.Type(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTAccountNumberTextbox, Parameters.NW_AccNumber);
                bi.Click(obj_Payments.PaymentProfilesPageAddPaymentProfilePageEFTAccountTypeDropdown);
                bi.Click(obj_Payments.SavingsAccountType);
                bi.Click(obj_Payments.Checkbox);

                bi.IsElementPresent(obj_Payments.SubmitButton);
                Console.WriteLine("Submit Button Available");






            }

            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Validate_Fund_Request method :" + ex.Message);
                throw;
            }

        }


        /*

        //Click Page/Link
        public void clickSection(string Name)
        {
            ////log4net.Config.XmlConfigurator.Configure();
            ////ILog logger = LogManager.GetLogger(typeof(ATTLandi_CA));
            try
            {
                //bi.WaitTime(1);
                bi.WaitForPageToLoad();
                int count = 1;
                IList<IWebElement> leftOption = bi.getElements(leftPanelOpetionList);
                int c = leftOption.Count();
                for (int i = 0; i < leftOption.Count; i++)
                {
                    string panel = ((leftOption)[i]).Text;
                    if (panel == Name)
                    {
                        ((leftOption)[i]).Click();
                        bi.WaitForPageToLoad();
                        Console.WriteLine(Name + "--> is present in Left Panel and We are able to click same");
                        break;
                    }
                    count++;
                }
                if (count > c)
                {
                    throw new Exception("Loop Exceeded -" + Name + " - Section Not Present");
                }

                Console.WriteLine("Validated & Able to Click the - " + Name + " - Section - Flow Passed");
            }
            catch (Exception error)
            {
                Console.WriteLine("Not able to Validate & Click the - " + Name + " - Section - Flow Failed - Due to - : " + error);
                throw error;
            }
        }

    */


    }
}
