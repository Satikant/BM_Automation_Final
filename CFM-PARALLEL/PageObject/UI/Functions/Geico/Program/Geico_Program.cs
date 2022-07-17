using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Program_Management;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Geico.Program
{
    public class Geico_Program
    {
        private OBJ_Program obj_Program;
        private OBJ_Dashboard obj_dashboard;

        public Geico_Program()
        {
            obj_Program = new OBJ_Program();
            obj_dashboard = new OBJ_Dashboard();
        }


       public void ValidateLabels_CreateNewProgram()
        {
            try
            {
                Pages.BasicInteractions().Click(obj_Program.leftNavProgram);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_Program.lnkNewProgram);
                //db.validatePageHeaderValues("New Program");
                Pages.BasicInteractions().WaitTillNotVisible(obj_Program.imgLoading);
                Pages.BasicInteractions().WaitTime(10);
                Pages.Dashboard_Landing().ValidatePageLabelValues("Program Name");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Description");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Program Currency");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Start Date");
                Pages.Dashboard_Landing().ValidatePageLabelValues("End Date");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Upload Program Guidelines(max 5 attachments)");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in ValidateLabels_CreateNewProgram method " + ex.Message);
                throw;
            }
        }

        public void Validate_Programs()
        {
            try
            {
                Pages.Dashboard_Landing().ClickParticularValueSection("PROGRAMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitTime(20);

                Pages.BasicInteractions().WaitUntilElementVisible(obj_Program.Programlabel, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_Program.active, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_Program.open, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_Program.inactive, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_Program.closed, 5);

                Pages.BasicInteractions().Click(obj_Program.open, 5);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_Program.inactive, 5);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_Program.closed, 5);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitTime(10);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Validate_Programs method: " + ex.Message);
                throw;
            }
        }

    }
}
