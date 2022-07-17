using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Program_Management;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Amnat.Programs
{
    public class AM_Programs
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Program oBJ_Program;
        
        public AM_Programs()
        {
            obj_dashboard = new OBJ_Dashboard();
            oBJ_Program = new OBJ_Program();
        }
        public void Validate_Programs()
        {
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.Dashboard_Landing().ClickParticularValueSection("PROGRAMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.Programlabel, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.active, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.open, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.inactive, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.closed, 5);

                Pages.BasicInteractions().Click(oBJ_Program.open, 5);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(oBJ_Program.inactive, 5);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(oBJ_Program.closed, 5);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();  
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Validate_Programs method: " + ex.Message);
                throw;
            }
        }
    }
}
