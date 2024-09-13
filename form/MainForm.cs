using coursework.user_control.admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    
    public partial class MainForm : Form
    {
        bool isTeacherCollapsed;
        bool isAdminCollapsed;
        bool isStudentCollapsed;
        bool isReportCollapsed;
        private Timer timerTeacher = new Timer();
        private Timer timerAdmin = new Timer();
        private Timer timerStudent = new Timer();
        private Timer timerReport = new Timer();
        public Role role;
        public string user_id;
        


        public MainForm(Role role, string user_id)
        {
            InitializeComponent();
            this.role = role;
            this.user_id = user_id;
            // Pass user_id and role to Dashboard control
            dashBoard1.InitializeDashboard(user_id, role);
            weekly_timetable1.Initialize(user_id, role);






            // Initialize panel heights and collapse states
            isTeacherCollapsed = panel_teacher.Height == panel_teacher.MinimumSize.Height;
            isAdminCollapsed = panel_admin.Height == panel_admin.MinimumSize.Height;
            isStudentCollapsed = panel_student.Height == panel_student.MinimumSize.Height;
            isReportCollapsed = panel_report.Height == panel_report.MinimumSize.Height;

            // Timer settings
            timerTeacher.Interval = 10;
            timerTeacher.Tick += timerTeacher_Tick;

            timerAdmin.Interval = 10;
            timerAdmin.Tick += timerAdmin_Tick;

            timerStudent.Interval = 10;
            timerStudent.Tick += timerStudent_Tick;

            timerReport.Interval = 10;
            timerReport.Tick += timerReport_Tick;

            // Configure the UI based on the user's role
            ConfigureUIBasedOnRole();
        }
        

        private void timerTeacher_Tick(object sender, EventArgs e)
        {
            if (isTeacherCollapsed)
            {
                panel_teacher.Height += 10;
                if (panel_teacher.Height >= panel_teacher.MaximumSize.Height)
                {
                    timerTeacher.Stop();
                    isTeacherCollapsed = false;
                }
            }
            else
            {
                panel_teacher.Height -= 10;
                if (panel_teacher.Height <= panel_teacher.MinimumSize.Height)
                {
                    timerTeacher.Stop();
                    isTeacherCollapsed = true;
                }
            }
        }
        private void ConfigureUIBasedOnRole()
        {
            // If the user is not an admin, remove the admin panel
            if (role != Role.Admin)
            {
                panel_admin.Visible = false;
                btn_add_student.Visible = false;
                btn_add_teacher.Visible = false;
            }
            
            
            

            
            // Add more role-based UI adjustments here as needed
        }

        private void timerAdmin_Tick(object sender, EventArgs e)
        {
            if (isAdminCollapsed)
            {
                panel_admin.Height += 10;
                if (panel_admin.Height >= panel_admin.MaximumSize.Height)
                {
                    timerAdmin.Stop();
                    isAdminCollapsed = false;
                }
            }
            else
            {
                panel_admin.Height -= 10;
                if (panel_admin.Height <= panel_admin.MinimumSize.Height)
                {
                    timerAdmin.Stop();
                    isAdminCollapsed = true;
                }
            }
        }

        private void timerStudent_Tick(object sender, EventArgs e)
        {
            if (isStudentCollapsed)
            {
                panel_student.Height += 10;
                if (panel_student.Height >= panel_student.MaximumSize.Height)
                {
                    timerStudent.Stop();
                    isStudentCollapsed = false;
                }
            }
            else
            {
                panel_student.Height -= 10;
                if (panel_student.Height <= panel_student.MinimumSize.Height)
                {
                    timerStudent.Stop();
                    isStudentCollapsed = true;
                }
            }
        }

        private void timerReport_Tick(object sender, EventArgs e)
        {
            if (isReportCollapsed)
            {
                panel_report.Height += 10;
                if (panel_report.Height >= panel_report.MaximumSize.Height)
                {
                    timerReport.Stop();
                    isReportCollapsed = false;
                }
            }
            else
            {
                panel_report.Height -= 10;
                if (panel_report.Height <= panel_report.MinimumSize.Height)
                {
                    timerReport.Stop();
                    isReportCollapsed = true;
                }
            }
        }
        private void btn_report_Click(object sender, EventArgs e)
        {
            timerReport.Start();
        }

        private void lb_exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_teacher_Click_1(object sender, EventArgs e)
        {
            timerTeacher.Start();
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            timerAdmin.Start();
        }

        private void btn_student_Click(object sender, EventArgs e)
        {
            timerStudent.Start();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ShowUserControl("dashBoard1");
        }

        private void btn_all_student_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ShowUserControl("all_Student1");
            all_Student1.DisplayAllStudents(user_id, role);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // This method is empty, so we'll leave it as is
        }

        private void btn_add_student_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ShowUserControl("add_user1");
            add_user1.DisplayAllStudents(user_id, role);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_student_detail_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ShowUserControl("student_detail1");
            student_detail1.Display_infor(user_id, role);
        }

        private void btn_allteacher_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ShowUserControl("all_Teacher1");
            all_Teacher1.DisplayAllTeachers(user_id, role);
        }

        private void btn_add_teacher_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ShowUserControl("add_teacher1");
            add_teacher1.DisplayAllTeachers(user_id, role);
        }

        private void btn_teacher_detail_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ShowUserControl("teacher_details1");
            teacher_details1.Display_infor(user_id, role);
        }
        private void HideAllUserControls()
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is UserControl)
                {
                    control.Visible = false;
                }
            }
        }
        private void ShowUserControl(string controlName)
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is UserControl && control.Name == controlName)
                {
                    control.Visible = true;
                    break;
                }
            }
        }

        private void btn_attendance_Click(object sender, EventArgs e)
        {
            HideAllUserControls();

            switch (this.role)
            {
                case Role.Student:
                    ShowUserControl("attendance_report1");
                    attendance_report1.load_infor_term(user_id);
                    break;

                case Role.Teacher:
                    ShowUserControl("teacher_attendance1");
                    teacher_attendance1.load_infor_term(user_id);
                    break;

                case Role.Admin:
                    ShowUserControl("admin_tracking_attendance1");
                    break;

                default:
                    // Handle any unexpected roles or do nothing
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btn_mark_Click(object sender, EventArgs e)
        {
            HideAllUserControls();

            if (this.role == Role.Student)
            {
                ShowUserControl("view_mark1");
                view_mark1.load_infor_term(user_id);
            }
            else if (this.role == Role.Teacher)
            {
                ShowUserControl("set_mark1");
                set_mark1.load_infor_term(user_id);
            }
            // For Admin role, all controls remain hidden
        }

        private void btn_curriculum_Click(object sender, EventArgs e)
        {
            HideAllUserControls();

            if (role == Role.Teacher || role == Role.Student)
            {
                ShowUserControl("curiculum1");
                curiculum1.Load_curriculum(user_id, role);
            }
            else if (role == Role.Admin)
            {
                ShowUserControl("admin_attendance1");
            }
        }

        private void btn_time_table_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ShowUserControl("weekly_timetable1");
            weekly_timetable1.HandleWeekChange();
        }

        private void btn_all_admin_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ShowUserControl("all_admin1");
            all_admin1.DisplayAllAdmins(user_id, role);

        }

        private void btn_admin_detail_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_admin_Click(object sender, EventArgs e)
        {

        }
    }
}
