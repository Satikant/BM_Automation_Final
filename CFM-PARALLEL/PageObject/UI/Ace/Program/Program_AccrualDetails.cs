using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Program
{
    public class Program_AccrualDetails
    {
        private IWebDriver Driver { get; set; }
        public Program_AccrualDetails(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }

        public By Accrual_Flat { get { return (By.XPath("//div[contains(@class,'formio-component-AccrualType')]//span[contains(.,'Flat')]")); } }
        public By Accrual_Rolling { get { return (By.XPath("//div[contains(@class,'formio-component-AccrualType')]//span[contains(.,'Rolling')]")); } }
        public By Accrual_Flat_Annual { get { return (By.XPath("//div[contains(@class,'formio-component-FlatAccrualPeriod')]//span[contains(.,'Annual')]")); } }
        public By Accrual_Flat_Monthly { get { return (By.XPath("//div[contains(@class,'formio-component-FlatAccrualPeriod')]//span[contains(.,'Monthly')]")); } }
        public By Accrual_Rolling_3 { get { return (By.XPath("//div[contains(@class,'formio-component-RollingAccrualPeriod')]//span[contains(.,'3 months')]")); } }
        public By Accrual_Rolling_6 { get { return (By.XPath("//div[contains(@class,'formio-component-RollingAccrualPeriod')]//span[contains(.,'6 months')]")); } }
        public By Accrual_Rolling_9 { get { return (By.XPath("//div[contains(@class,'formio-component-RollingAccrualPeriod')]//span[contains(.,'9 months')]")); } }
        public By Accrual_Rolling_12 { get { return (By.XPath("//div[contains(@class,'formio-component-RollingAccrualPeriod')]//span[contains(.,'12 months')]")); } }
        //public By TransactionDate { get { return (By.XPath("//div[contains(@class,'formio-component-LastTransactionDate')]/div/span")); } }
        public By TransactionDate { get { return (By.XPath("//*[contains(@name,'data[LastTransactionDate]')]//..//input[2]")); } }

        //public By ExpirationDate { get { return (By.XPath("//div[contains(@class,'formio-component-ExpirationDate')]/div/span")); } }
        public By ExpirationDate { get { return (By.XPath("//*[contains(@name,'data[ExpirationDate]')]//..//input[2]")); } }
        public By NextButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-next')]")); } }
        public By StartDate { get { return (By.XPath("//div[contains(@class,'formio-component-StartDate')]/div/span")); } }
        public By EndDate { get { return (By.XPath("//div[contains(@class,'formio-component-EndDate')]/div/span")); } }
        public By StartDateSelection(string prgSrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgSrtDate + "')]"));
        }
        public By EndDateSelection(string prgEndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgEndDate + "')])"));
        }
        public By LastTranDateSelection(string prgLastTranDate)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            int i = 0;
            for (i = 1; i <= 6; i++)
            {
                if (bi.IsElementDisplayed(By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgLastTranDate + "')])[" + i + "]")))
                {
                    break;
                }
            }
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgLastTranDate + "')])[" + i + "]"));
        }
        public By ExpirationDateSelection(string prgExpirationDate)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            int i = 0;
            for (i = 1; i <= 6; i++)
            {
                if (bi.IsElementDisplayed(By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgExpirationDate + "')])[" + i + "]")))
                {
                    break;
                }
            }
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgExpirationDate + "')])[" + i + "]"));
        }

        /// <summary>
        /// Method to work on Accrual Details stepper
        /// </summary>
        /// <param name="db_accrualType">Accrual Type Flat/Rolling</param>
        /// <param name="db_accrualPeriod"></param>
        public void ACE_Program_AccrualDetails(string db_accrualType, string db_accrualPeriod)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_AccrualDetails));
            try
            {

                bi.WaitVisible(NextButton);
                if (db_accrualType.Equals("Flat"))
                {
                    bi.WaitVisible(Accrual_Flat);
                    bi.ClickJavaScript(Accrual_Flat);
                    if (db_accrualPeriod.Equals("Annual"))
                    {
                        bi.WaitVisible(Accrual_Flat_Annual);
                        bi.ClickJavaScript(Accrual_Flat_Annual);
                    }
                    else if (db_accrualPeriod.Equals("Monthly"))
                    {
                        bi.WaitVisible(Accrual_Flat_Monthly);
                        bi.ClickJavaScript(Accrual_Flat_Monthly);
                    }
                }
                else if (db_accrualType.Equals("Rolling"))
                {
                    bi.WaitVisible(Accrual_Rolling);
                    bi.ClickJavaScript(Accrual_Rolling);
                    if (db_accrualPeriod.Equals("3 months"))
                    {
                        bi.WaitVisible(Accrual_Rolling_3);
                        bi.ClickJavaScript(Accrual_Rolling_3);
                    }
                    else if (db_accrualPeriod.Equals("6 months"))
                    {
                        bi.WaitVisible(Accrual_Rolling_6);
                        bi.ClickJavaScript(Accrual_Rolling_6);
                    }
                    else if (db_accrualPeriod.Equals("9 months"))
                    {
                        bi.WaitVisible(Accrual_Rolling_9);
                        bi.ClickJavaScript(Accrual_Rolling_9);
                    }
                    else if (db_accrualPeriod.Equals("12 months"))
                    {
                        bi.WaitVisible(Accrual_Rolling_12);
                        bi.ClickJavaScript(Accrual_Rolling_12);
                    }
                }
                bi.WaitVisible(TransactionDate);
                bi.Click(TransactionDate);
                bi.WaitTime(5);
                DateSelection dsTran = new DateSelection();
                bi.Click(LastTranDateSelection(dsTran.Ace_DateSelection_prgTranDate()));

                bi.WaitTime(5);
                bi.WaitVisible(ExpirationDate);
                bi.Click(ExpirationDate);
                bi.WaitTime(2);
                DateSelection dsExp = new DateSelection();
                bi.Click(ExpirationDateSelection(dsExp.Ace_DateSelection_prgExpirationDate()));
                bi.WaitTime(3);
                bi.ClickJavaScript(NextButton);
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("ACE_Program_AccrualDetails " + ex);
                Assert.Fail("ACE_Program_AccrualDetails " + ex);
            }
        }
    }
}
