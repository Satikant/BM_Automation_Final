using CFM_PARALLEL.Interactions_New;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.Common
{
    public class DateSelection
    {
        private IWebDriver Driver { get; set; }
        public By PrgEndDateNextMonth { get { return (By.XPath("(//span[contains(@class,'flatpickr-next-month')])[2]")); } }
        public By PrgTranDateNextMonth { get { return (By.XPath("(//span[contains(@class,'flatpickr-next-month')])[1]")); } }
        public By PrgExpDateNextMonth { get { return (By.XPath("(//span[contains(@class,'flatpickr-next-month')])[2]")); } }


        public DateSelection(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        //April 7, 2018
        //Console.WriteLine(DateTime.Today.ToString("MMMM dd, yyyy"));
        //Console.WriteLine(DateTime.Today.AddDays(20).ToString("MMMM dd, yyyy"));
        public string Ace_DateSelection_prgStartDate()
        {
            return DateTime.Today.AddDays(1).ToString("MMMM d, yyyy");
        }
        public string Ace_DateSelection_prgEndDate()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            for (int i = 1; i <= 12; i++)
            {
                bi.Click(PrgEndDateNextMonth);
            }
            return DateTime.Today.AddDays(360).ToString("MMMM d, yyyy");
            //return DateTime.Today.AddDays(3).ToString("MMMM d, yyyy");
        }
        public string Ace_DateSelection_prgTranDate()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            for (int i = 1; i <=13; i++)
            {
                bi.Click(PrgTranDateNextMonth);
            }
            return DateTime.Today.AddDays(370).ToString("MMMM d, yyyy");
            //return DateTime.Today.AddDays(4).ToString("MMMM d, yyyy");
        }
        public string Ace_DateSelection_prgExpirationDate()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            for (int i = 1; i <= 14; i++)
            {
                bi.Click(PrgExpDateNextMonth);
                //bi.WaitTime(1);
            }
            return DateTime.Today.AddDays(400).ToString("MMMM d, yyyy");
            //return DateTime.Today.AddDays(6).ToString("MMMM d, yyyy");
        }

        public static string Ace_DateSelection_claimStartDate()
        {
            return DateTime.Today.AddDays(2).ToString("MMMM d, yyyy");
        }
        public static string Ace_DateSelection_claimEndDate()
        {
            return DateTime.Today.AddDays(5).ToString("MMMM d, yyyy");
        }
        public static string Ace_DateSelection_bpaStartDate()
        {
            return DateTime.Today.AddDays(2).ToString("MMMM d, yyyy");
        }
        public static string Ace_DateSelection_bpaEndDate()
        {
            return DateTime.Today.AddDays(5).ToString("MMMM d, yyyy");
        }
        public static string Ace_DateValidation_StartDate()
        {
            return DateTime.Today.AddDays(1).ToString("MMMM d, yyyy");
        }
        public static string Ace_DateValidation_EndDate()
        {
            return DateTime.Today.AddDays(-1).ToString("MMMM d, yyyy");
        }
    }
}