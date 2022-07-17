using CFM_PARALLEL.PageObject.PageFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.CampaignManager
{
    class CM_Menus
    {
            public By Sidemenu_Admin { get { return (By.XPath("//span[text()='Administration']")); } }
            public void AdminMenu()
            {
                try
                {
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().GetCurrentUrl();
                Console.WriteLine("GET Current URL");
                Pages.BasicInteractions().WaitVisible(Sidemenu_Admin);
                Pages.BasicInteractions().Click(Sidemenu_Admin);
                Pages.BasicInteractions().WaitTime(3);
            }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Message: " + ex.Message);
                    throw;
                }
            }
        public void ReportMenu()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

    }
    }