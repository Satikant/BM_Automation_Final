using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.CampaignManager;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;

namespace CFM_PARALLEL.Tests.Campaign_Manager.Administration
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CM_TestScripts : Base
    {
        public string BusinessUnit = "Admin Tool";
        CM_Menus Admincm = new CM_Menus();
        //Homepage hpage = new Homepage();
        //Event even = new Event();
        //public object BUSelectionDropdown { get; private set; }

        [Test, Parallelizable]
        [Category("Campaign Manager")]
        public void Administrations()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_CampManager("STAGE");
                Pages.BrowserURLLaunch().CampMgrBUselection(BusinessUnit);
                Homepage hpage = new Homepage();
                hpage.CMPageredirection();
                Pages.BasicInteractions().Windowhandle();
                Pages.BasicInteractions().WaitTime(4);
                /*Redirect to Adminpage*/
                Admincm.AdminMenu();
                /*1.Event Page execution*/
                Event EventTile = new Event();
                EventTile.EventExecution();
                /*Redirect back to Adminpage*/
                Admincm.AdminMenu();
                /*2.Platform Page execution*/
                Platform PlatformTile = new Platform();
                PlatformTile.PlatFormExecution();
                /*Redirect back to Adminpage*/
                Admincm.AdminMenu();
                /*3.SubPlatform Page execution*/
                SubPlatform SubplatformTile = new SubPlatform();  
                SubplatformTile.SubPlatFormExecution();
                /*Redirect back to Adminpage*/
                Admincm.AdminMenu();
                /*4.SubTactic Page execution*/
                SubTactic SubtatcticTile = new SubTactic();
                SubtatcticTile.SubTacticExecution();
                /*Redirect to Adminpage*/
                Admincm.AdminMenu();
                /*5.TacticTypes Page execution*/
                TacticTypes TacticTypesTile = new TacticTypes();
                 TacticTypesTile.TacticTypesExecution();
                /*Redirect to Adminpage*/
                Admincm.AdminMenu();
                /*6.TacticMarketingTypes Page execution*/
                TacticMarketingTypes MarketingTiles = new TacticMarketingTypes();
                MarketingTiles.TacticMarketingTypesExecution();
                /*Redirect to Adminpage*/
                Admincm.AdminMenu();
                /*7.Tactic Page execution*/
                Tactics TacticTiles = new Tactics();
                TacticTiles.TacticExecution();
                /*Redirect to Adminpage*/
                Admincm.AdminMenu();
                /*8.ProgramType Page execution*/
                ProgramType ProgramTypeTiles = new ProgramType();
                ProgramTypeTiles.ProgTypeExecution();
                /*Redirect back to Adminpage*/
                Admincm.AdminMenu();
                /*9.Program Page execution*/
                Program ProgramTiles = new Program();
                ProgramTiles.ProgramExecution();
                /*Redirect to Adminpage*/
                Admincm.AdminMenu();
                /*10.JiraTenant Mapping Page execution*/
                JiraTenantMapping Tenantmapping = new JiraTenantMapping();
                Tenantmapping.JiraTenantMappingExecution();
                /*Redirect back to Adminpage*/
                Admincm.AdminMenu();
                /*JiratenantConfiguration Execution*/
                //JiraTenanntConfig TenantConfig = new JiraTenanntConfig();
                //TenantConfig.JiraTenanntConfigExecution();
                /*11.PackageType Execution*/
                PackageType package = new PackageType();
                package.PackageTypeExecution();
                /*Redirect to Adminpage*/
                Admincm.AdminMenu();
                /*12.PackageBeneficiary Execution*/
                PackageBeneficiary beneficary = new PackageBeneficiary();
                beneficary.PackageBeneficiaryExecution();
                /*Redirect to Adminpage*/
                Admincm.AdminMenu();
                /*13.Mediamapping Execution*/
                MediaMappings mediampping = new MediaMappings();
                mediampping.MediaMappingExecution();
                /*Redirect back to Adminpage*/
                Admincm.AdminMenu();
                /*14.Product page Execution*/
                Product products = new Product();
                products.ProductExecution();
            }
            catch (Exception ex)
            {
                //Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                //Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in Campaign Manager TestCase " + ex.Message);
                throw;
            }
        }
 
    }
}