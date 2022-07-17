using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.PageObject.UI.Ace.Disbursement;
using CFM_PARALLEL.PageObject.UI.Functions;
using CFM_PARALLEL.PageObject.UI.Functions.Amnat.BrandPreApproval;
using CFM_PARALLEL.PageObject.UI.Functions.Amnat.Claim;
using CFM_PARALLEL.PageObject.UI.Functions.Amnat.Dashboard;
using CFM_PARALLEL.PageObject.UI.Functions.Amnat.Programs;
using CFM_PARALLEL.PageObject.UI.Functions.Bobcat;
using CFM_PARALLEL.PageObject.UI.Functions.Farmers.Claim;
using CFM_PARALLEL.PageObject.UI.Functions.Farmers.Dashboard;
using CFM_PARALLEL.PageObject.UI.Functions.Geico;
using CFM_PARALLEL.PageObject.UI.Functions.Geico.Claims;
using CFM_PARALLEL.PageObject.UI.Functions.Geico.Program;
using CFM_PARALLEL.PageObject.UI.Functions.Masco;
using CFM_PARALLEL.PageObject.UI.Functions.Masco.BrandPreApproval;
using CFM_PARALLEL.PageObject.UI.Functions.Masco.Claims;
using CFM_PARALLEL.PageObject.UI.Functions.Masco.Dashboard;
using CFM_PARALLEL.PageObject.UI.Functions.Masco.FundPreApproval;
using CFM_PARALLEL.PageObject.UI.Functions.Masco.Programs;
using CFM_PARALLEL.PageObject.UI.Functions.Nationwide;
using CFM_PARALLEL.PageObject.UI.Functions.Nationwide.Dashboard;
using CFM_PARALLEL.PageObject.UI.Functions.Nationwide.Disbursements;
using CFM_PARALLEL.PageObject.UI.Functions.Nationwide.Programs;
using CFM_PARALLEL.PageObject.UI.Functions.Pandora;
using CFM_PARALLEL.PageObject.UI.Functions.Prod_BU.BrandPreApproval;
using CFM_PARALLEL.PageObject.UI.Functions.Prod_BU.Claims;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.Transactions;

namespace CFM_PARALLEL.PageObject.PageFactory
{
    class Pages : Base
    {
        //COMMON
        private static CommonFunctions commonFunctions;
        private static BasicInteractions basicInteractions;
        private static BrowserURLLaunch browserURLLaunch;
        private static Dashboard_Landing dashboard_Landing;
        private static Claim_FullFlow claim_FullFlow;
        private static Preapproval_FullFlow preapproval_FullFlow;
        private static Transaction_Accrual transaction_Accrual;

        //MASCO
        private static MS_FundRequest mS_FundRequest;
        private static MS_Dashboard ms_Dashboard;
        private static MS_FundPreApproval mS_FundPreApproval;
        private static MS_Claims mS_Claims;
        private static MS_Programs mS_Programs;
        private static MS_Transaction mS_Transaction;
        private static MS_BrandPreApproval mS_BrandPreApproval;
        private static MS_DisplayClaims mS_DisplayClaims;
       
        //AMNAT
        private static AM_Dashboard aM_Dashboard;
        private static AM_BrandPreApproval aM_BrandPreApproval;
        private static AM_Programs aM_Programs;
        private static AM_Claims aM_Claims;


        // BOBCAT

        private static BC_Claim bC_Claim;
        private static BC_Dashboard bC_Dashboard;
        private static BC_BPA bC_BPA;
        private static BC_CoopAdaptor bC_CoopAdaptor;

        //NATIONWIDE

        private static NW_Payments nW_Payments;
        private static NW_Claims nW_Claims;
        private static NW_Dashboard nW_Dashboard;
        private static NW_Programs nW_Programs;
        private static NW_Disbursements nW_Disbursements;
        private static ManualDisbursement manualDisbursement;
        private static NW_FundRequest nW_FundRequest;

        //PANDORA

        private static PN_Claim pN_Claim;
        private static PN_Dashboard pN_Dashboard;

        //GEICO

        private static Geico_Claims geico_Claims;        
        private static Geico_Dashboard geico_Dashboard;        
        private static Geico_Program geico_Program;

        //PROD QA BU

        private static Prod_BU_BPA prod_BU_BPA;
        private static Claims_DisplayClaim claims_DisplayClaim;

        //FARMERS
        private static Farmers_Dashboard farmers_Dashboard;
        private static Farmers_Claim farmers_Claim;



        public static void TearDownPages() // teardown necessary to allow objects to be created for another test cases
        {
            commonFunctions = null;
            browserURLLaunch = null;
            basicInteractions = null;
            dashboard_Landing = null;
            claim_FullFlow = null;
            preapproval_FullFlow = null;
            transaction_Accrual = null;

            //MASCO
            mS_FundRequest = null;
            ms_Dashboard = null;
            mS_FundPreApproval = null;
            mS_Claims = null;
            mS_Programs = null;
            mS_Transaction = null;
            mS_BrandPreApproval = null;
            mS_DisplayClaims = null;

            //AMNAT
            aM_Dashboard = null;
            aM_BrandPreApproval = null;
            aM_Programs = null;
            aM_Claims = null;
            
            //BOBCAT

            bC_Claim = null;
            bC_Dashboard = null;
            bC_BPA = null;
            bC_CoopAdaptor = null;


            //NATIONWIDE

            nW_Payments = null;
            nW_Claims = null;
            nW_Dashboard = null;
            nW_Programs = null;
            nW_Disbursements = null;
            manualDisbursement = null;
            nW_FundRequest = null;

            //PANDORA

            pN_Claim = null;
            pN_Dashboard = null;

            //GEICO
            geico_Claims = null;
            geico_Dashboard = null;
            geico_Program = null;

            //Prod QA BU
            prod_BU_BPA = null;
            claims_DisplayClaim = null;

            //Farmers
            farmers_Dashboard = null;
            farmers_Claim = null;
        }

        public static CommonFunctions CommonFunctions() { // SingleTon Design pattern , enables single object creation for multiple usages in a test case

           // if (commonFunctions == null)
                commonFunctions = new CommonFunctions();
            return commonFunctions;
        }

        public static BrowserURLLaunch BrowserURLLaunch()
        {
            //if (browserURLLaunch == null) //
                browserURLLaunch = new BrowserURLLaunch(Driver);
            return browserURLLaunch;
        }

        public static BasicInteractions BasicInteractions()
        {
           // if (basicInteractions == null)
                basicInteractions = new BasicInteractions(Driver);
            return basicInteractions;
        }

        public static Dashboard_Landing Dashboard_Landing()
        {
            //if (dashboard_Landing == null)
                dashboard_Landing = new Dashboard_Landing();
            return dashboard_Landing;
        }

        public static Transaction_Accrual Transaction_Accrual()
        {
           // if (transaction_Accrual == null)
                transaction_Accrual = new Transaction_Accrual();
            return transaction_Accrual;
        }

        public static Claim_FullFlow Claim_FullFlow()
        {
            //if (claim_FullFlow == null)
                claim_FullFlow = new Claim_FullFlow(Driver);
            return claim_FullFlow;
        }

        public static Preapproval_FullFlow Preapproval_FullFlow()
        {
           // if (preapproval_FullFlow == null)
                preapproval_FullFlow = new Preapproval_FullFlow(Driver);
            return preapproval_FullFlow;
        }

        //MASCO Classes begin

        public static MS_FundRequest MS_FundRequest()
        {
           // if (mS_FundRequest == null)// create object only if it is needed
                mS_FundRequest = new MS_FundRequest();
            return mS_FundRequest;
        }

        public static MS_BrandPreApproval MS_BrandPreApproval()
        {
           // if (mS_BrandPreApproval == null)// create object only if it is needed
                mS_BrandPreApproval = new MS_BrandPreApproval();
            return mS_BrandPreApproval;
        }

        public static MS_Dashboard MS_Dashboard()
        {
          //  if (ms_Dashboard == null)
                ms_Dashboard = new MS_Dashboard();
            return ms_Dashboard;
        }

        public static MS_DisplayClaims MS_DisplayClaims()
        {
           // if (mS_DisplayClaims == null)
                mS_DisplayClaims = new MS_DisplayClaims();
            return mS_DisplayClaims;
        }

        public static MS_Claims MS_Claims()
        {
           // if (mS_Claims == null)
                mS_Claims = new MS_Claims();
            return mS_Claims;
        }

        public static MS_Programs MS_Programs()
        {
           // if (mS_Programs == null)
                mS_Programs = new MS_Programs();
            return mS_Programs;
        }

        public static MS_Transaction MS_Transaction()
        {
          //  if (mS_Transaction == null)
                mS_Transaction = new MS_Transaction();
            return mS_Transaction;
        }

        public static MS_FundPreApproval MS_FundPreApproval()
        {
           // if (mS_FundPreApproval == null)
                mS_FundPreApproval = new MS_FundPreApproval();
            return mS_FundPreApproval;
        } //MASCO Classes end             
               

        //AMNAT

        public static AM_Dashboard AM_Dashboard()
        {
          //  if (aM_Dashboard == null)
                aM_Dashboard = new AM_Dashboard();
            return aM_Dashboard;
        }

        public static AM_BrandPreApproval AM_BrandPreApproval()
        {
           // if (aM_BrandPreApproval == null)
                aM_BrandPreApproval = new AM_BrandPreApproval();
            return aM_BrandPreApproval;
        }

        public static AM_Programs AM_Programs()
        {
           // if (aM_Programs == null)
                aM_Programs = new AM_Programs();
            return aM_Programs;
        }

        public static AM_Claims AM_Claims()
        {
            //if (aM_Claims == null)
                aM_Claims = new AM_Claims();
            return aM_Claims;
        }

        //BOBCAT

        public static BC_CoopAdaptor BC_CoopAdaptor()
        {
            //if (bC_CoopAdaptor == null)
                bC_CoopAdaptor = new BC_CoopAdaptor();
            return bC_CoopAdaptor;
        }

        public static BC_Claim BC_Claim()
        {
           // if (bC_Claim == null)
                bC_Claim = new BC_Claim();
            return bC_Claim;
        }

        public static BC_Dashboard BC_Dashboard()
        {
           // if (bC_Dashboard == null)
                bC_Dashboard = new BC_Dashboard();
            return bC_Dashboard;
        }

        public static BC_BPA BC_BPA()
        {
           // if (bC_BPA == null)
                bC_BPA = new BC_BPA();
            return bC_BPA;
        }

        //NATIONWIDE

        public static NW_Payments NW_Payments()
        {
            if (nW_Payments == null)
                nW_Payments = new NW_Payments();
            return nW_Payments;
        }

        public static NW_Claims NW_Claims()
        {
            if (nW_Claims == null)
                nW_Claims = new NW_Claims(Driver);
            return nW_Claims;
        }

        public static NW_Dashboard NW_Dashboard()
        {
            if (nW_Dashboard == null)
                nW_Dashboard = new NW_Dashboard();
            return nW_Dashboard;
        }

        public static NW_Programs NW_Programs()
        {
            if (nW_Programs == null)
                nW_Programs = new NW_Programs();
            return nW_Programs;
        }

        public static NW_Disbursements NW_Disbursements()
        {
            if (nW_Disbursements == null)
                nW_Disbursements = new NW_Disbursements();
            return nW_Disbursements;
        }

        public static ManualDisbursement ManualDisbursement()
        {
            //if (manualDisbursement == null)
                manualDisbursement = new ManualDisbursement();
            return manualDisbursement;
        }
        
         public static NW_FundRequest NW_FundRequest()
        {
            //if (nW_FundRequest == null)
            nW_FundRequest = new NW_FundRequest();
            return nW_FundRequest;
        }

        //PANDORA

        public static PN_Claim PN_Claim()
        {
           // if (pN_Claim == null)
                pN_Claim = new PN_Claim();
            return pN_Claim;

        }

        public static PN_Dashboard PN_Dashboard()
        {
           // if (pN_Dashboard == null)
                pN_Dashboard = new PN_Dashboard();
            return pN_Dashboard;
        }

        // GEICO

        public static Geico_Claims Geico_Claims()
        {
            //if (geico_Claims == null)
                geico_Claims = new Geico_Claims();
            return geico_Claims;

        }

        public static Geico_Dashboard Geico_Dashboard()
        {
           // if (geico_Dashboard == null)
                geico_Dashboard = new Geico_Dashboard();
            return geico_Dashboard;

        }

        public static Geico_Program Geico_Program()
        {
            //if (geico_Program == null)
                geico_Program = new Geico_Program();
            return geico_Program;

        }
        
        // Prod QA BU

        public static Prod_BU_BPA Prod_BU_BPA()
        {
            //if (prod_BU_BPA == null)
            prod_BU_BPA = new Prod_BU_BPA();
            return prod_BU_BPA;
        }        

        public static Claims_DisplayClaim Claims_DisplayClaim()
        {
            //if (claims_DisplayClaim == null)
            claims_DisplayClaim = new Claims_DisplayClaim();
            return claims_DisplayClaim;
        }

        // FARMERS

        public static Farmers_Dashboard Farmers_Dashboard()
        {
            //if (farmers_Dashboard == null)
            farmers_Dashboard = new Farmers_Dashboard();
            return farmers_Dashboard;
        }

        public static Farmers_Claim Farmers_Claim()
        {
            //if (Farmers_Claim == null)
            farmers_Claim = new Farmers_Claim();
            return farmers_Claim;
        }

    }
}
