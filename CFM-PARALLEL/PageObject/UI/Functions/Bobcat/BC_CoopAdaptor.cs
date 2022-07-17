using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Coop_Funds;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.StartUp;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions.Bobcat
{
    public class BC_CoopAdaptor
    {
        private IWebDriver Driver;
        private Base bs;
        private BrowserURLLaunch bl;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private BasicInteractions bi;
        private OBJ_CoopAdaptor obj_coopadaptor;
        private OBJ_Common obj_common;
        //Constructor
        public BC_CoopAdaptor(IWebDriver Driver)
        {
            this.Driver = Driver;
            bs = new Base();
            bl = new BrowserURLLaunch(Driver);
            obj_dashboard = new OBJ_Dashboard();
            bi = new BasicInteractions(Driver);
            obj_claims = new OBJ_Claims();
            obj_coopadaptor = new OBJ_CoopAdaptor();
        }
    }
}
