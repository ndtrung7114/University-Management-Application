using System.Runtime.CompilerServices;

namespace coursework
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_exit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_dashboard = new System.Windows.Forms.Button();
            this.panel_teacher = new System.Windows.Forms.Panel();
            this.btn_add_teacher = new System.Windows.Forms.Button();
            this.btn_teacher = new System.Windows.Forms.Button();
            this.btn_allteacher = new System.Windows.Forms.Button();
            this.btn_teacher_detail = new System.Windows.Forms.Button();
            this.panel_admin = new System.Windows.Forms.Panel();
            this.btn_add_admin = new System.Windows.Forms.Button();
            this.btn_admin = new System.Windows.Forms.Button();
            this.btn_all_admin = new System.Windows.Forms.Button();
            this.btn_admin_detail = new System.Windows.Forms.Button();
            this.panel_student = new System.Windows.Forms.Panel();
            this.btn_add_student = new System.Windows.Forms.Button();
            this.btn_student = new System.Windows.Forms.Button();
            this.btn_all_student = new System.Windows.Forms.Button();
            this.btn_student_detail = new System.Windows.Forms.Button();
            this.panel_report = new System.Windows.Forms.Panel();
            this.btn_curriculum = new System.Windows.Forms.Button();
            this.btn_report = new System.Windows.Forms.Button();
            this.btn_attendance = new System.Windows.Forms.Button();
            this.btn_mark = new System.Windows.Forms.Button();
            this.btn_time_table = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.dashBoard1 = new coursework.DashBoard();
            this.teacher_details1 = new coursework.form_usercontrol.Teacher_details();
            this.all_Teacher1 = new coursework.form_usercontrol.All_Teacher();
            this.all_Student1 = new coursework.All_Student();
            this.add_user1 = new coursework.form_usercontrol.Add_students();
            this.add_teacher1 = new coursework.form_usercontrol.Add_teacher();
            this.student_detail1 = new coursework.form_usercontrol.Student_detail();
            this.attendance_report1 = new coursework.user_control.report.Attendance_report();
            this.teacher_attendance1 = new coursework.user_control.report.Teacher_attendance();
            this.admin_attendance1 = new coursework.user_control.admin.admin_curriculum();
            this.set_mark1 = new coursework.user_control.teacher.set_mark();
            this.view_mark1 = new coursework.user_control.student.view_mark();
            this.curiculum1 = new coursework.user_control.student.Curiculum();
            this.admin_tracking_attendance1 = new coursework.user_control.admin.admin_tracking_attendance();
            this.weekly_timetable1 = new coursework.user_control.weekly_timetable();
            this.all_admin1 = new coursework.user_control.admin.All_admin();
            this.add_admin1 = new coursework.user_control.admin.Add_admin();
            this.admin_detail1 = new coursework.user_control.admin.Admin_detail();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel_teacher.SuspendLayout();
            this.panel_admin.SuspendLayout();
            this.panel_student.SuspendLayout();
            this.panel_report.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_exit
            // 
            this.lb_exit.AutoSize = true;
            this.lb_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_exit.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_exit.Location = new System.Drawing.Point(1181, 0);
            this.lb_exit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_exit.Name = "lb_exit";
            this.lb_exit.Size = new System.Drawing.Size(17, 18);
            this.lb_exit.TabIndex = 0;
            this.lb_exit.Text = "X";
            this.lb_exit.Click += new System.EventHandler(this.lb_exit_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tempus Sans ITC", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(459, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wellcome to Greenwich Viet Nam";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lb_exit);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 61);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(23, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.flowLayoutPanel1.Controls.Add(this.btn_dashboard);
            this.flowLayoutPanel1.Controls.Add(this.panel_teacher);
            this.flowLayoutPanel1.Controls.Add(this.panel_admin);
            this.flowLayoutPanel1.Controls.Add(this.panel_student);
            this.flowLayoutPanel1.Controls.Add(this.panel_report);
            this.flowLayoutPanel1.Controls.Add(this.btn_time_table);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 61);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(150, 659);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.AllowDrop = true;
            this.btn_dashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.btn_dashboard.FlatAppearance.BorderSize = 0;
            this.btn_dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dashboard.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dashboard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_dashboard.Location = new System.Drawing.Point(2, 2);
            this.btn_dashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Size = new System.Drawing.Size(148, 28);
            this.btn_dashboard.TabIndex = 0;
            this.btn_dashboard.Text = "Dashboard";
            this.btn_dashboard.UseVisualStyleBackColor = false;
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // panel_teacher
            // 
            this.panel_teacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.panel_teacher.Controls.Add(this.btn_add_teacher);
            this.panel_teacher.Controls.Add(this.btn_teacher);
            this.panel_teacher.Controls.Add(this.btn_allteacher);
            this.panel_teacher.Controls.Add(this.btn_teacher_detail);
            this.panel_teacher.Location = new System.Drawing.Point(2, 34);
            this.panel_teacher.Margin = new System.Windows.Forms.Padding(2);
            this.panel_teacher.MaximumSize = new System.Drawing.Size(150, 126);
            this.panel_teacher.MinimumSize = new System.Drawing.Size(150, 30);
            this.panel_teacher.Name = "panel_teacher";
            this.panel_teacher.Size = new System.Drawing.Size(150, 30);
            this.panel_teacher.TabIndex = 2;
            // 
            // btn_add_teacher
            // 
            this.btn_add_teacher.AllowDrop = true;
            this.btn_add_teacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_add_teacher.FlatAppearance.BorderSize = 0;
            this.btn_add_teacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_teacher.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_teacher.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_add_teacher.Location = new System.Drawing.Point(2, 92);
            this.btn_add_teacher.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add_teacher.Name = "btn_add_teacher";
            this.btn_add_teacher.Size = new System.Drawing.Size(148, 24);
            this.btn_add_teacher.TabIndex = 4;
            this.btn_add_teacher.Text = "Add Teacher";
            this.btn_add_teacher.UseVisualStyleBackColor = false;
            this.btn_add_teacher.Click += new System.EventHandler(this.btn_add_teacher_Click);
            // 
            // btn_teacher
            // 
            this.btn_teacher.AllowDrop = true;
            this.btn_teacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.btn_teacher.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_teacher.FlatAppearance.BorderSize = 0;
            this.btn_teacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_teacher.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_teacher.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_teacher.Location = new System.Drawing.Point(0, 0);
            this.btn_teacher.Margin = new System.Windows.Forms.Padding(2);
            this.btn_teacher.Name = "btn_teacher";
            this.btn_teacher.Size = new System.Drawing.Size(150, 30);
            this.btn_teacher.TabIndex = 1;
            this.btn_teacher.Text = "Teacher";
            this.btn_teacher.UseVisualStyleBackColor = false;
            this.btn_teacher.Click += new System.EventHandler(this.btn_teacher_Click_1);
            // 
            // btn_allteacher
            // 
            this.btn_allteacher.AllowDrop = true;
            this.btn_allteacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_allteacher.FlatAppearance.BorderSize = 0;
            this.btn_allteacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_allteacher.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_allteacher.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_allteacher.Location = new System.Drawing.Point(2, 32);
            this.btn_allteacher.Margin = new System.Windows.Forms.Padding(2);
            this.btn_allteacher.Name = "btn_allteacher";
            this.btn_allteacher.Size = new System.Drawing.Size(148, 26);
            this.btn_allteacher.TabIndex = 2;
            this.btn_allteacher.Text = "All Teacher";
            this.btn_allteacher.UseVisualStyleBackColor = false;
            this.btn_allteacher.Click += new System.EventHandler(this.btn_allteacher_Click);
            // 
            // btn_teacher_detail
            // 
            this.btn_teacher_detail.AllowDrop = true;
            this.btn_teacher_detail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_teacher_detail.FlatAppearance.BorderSize = 0;
            this.btn_teacher_detail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_teacher_detail.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_teacher_detail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_teacher_detail.Location = new System.Drawing.Point(2, 63);
            this.btn_teacher_detail.Margin = new System.Windows.Forms.Padding(2);
            this.btn_teacher_detail.Name = "btn_teacher_detail";
            this.btn_teacher_detail.Size = new System.Drawing.Size(148, 24);
            this.btn_teacher_detail.TabIndex = 3;
            this.btn_teacher_detail.Text = "Teacher Details";
            this.btn_teacher_detail.UseVisualStyleBackColor = false;
            this.btn_teacher_detail.Click += new System.EventHandler(this.btn_teacher_detail_Click);
            // 
            // panel_admin
            // 
            this.panel_admin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.panel_admin.Controls.Add(this.btn_add_admin);
            this.panel_admin.Controls.Add(this.btn_admin);
            this.panel_admin.Controls.Add(this.btn_all_admin);
            this.panel_admin.Controls.Add(this.btn_admin_detail);
            this.panel_admin.Location = new System.Drawing.Point(2, 68);
            this.panel_admin.Margin = new System.Windows.Forms.Padding(2);
            this.panel_admin.MaximumSize = new System.Drawing.Size(150, 126);
            this.panel_admin.MinimumSize = new System.Drawing.Size(150, 30);
            this.panel_admin.Name = "panel_admin";
            this.panel_admin.Size = new System.Drawing.Size(150, 126);
            this.panel_admin.TabIndex = 3;
            // 
            // btn_add_admin
            // 
            this.btn_add_admin.AllowDrop = true;
            this.btn_add_admin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_add_admin.FlatAppearance.BorderSize = 0;
            this.btn_add_admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_admin.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_admin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_add_admin.Location = new System.Drawing.Point(2, 92);
            this.btn_add_admin.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add_admin.Name = "btn_add_admin";
            this.btn_add_admin.Size = new System.Drawing.Size(148, 24);
            this.btn_add_admin.TabIndex = 4;
            this.btn_add_admin.Text = "Add Admin";
            this.btn_add_admin.UseVisualStyleBackColor = false;
            this.btn_add_admin.Click += new System.EventHandler(this.btn_add_admin_Click);
            // 
            // btn_admin
            // 
            this.btn_admin.AllowDrop = true;
            this.btn_admin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.btn_admin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_admin.FlatAppearance.BorderSize = 0;
            this.btn_admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_admin.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_admin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_admin.Location = new System.Drawing.Point(0, 0);
            this.btn_admin.Margin = new System.Windows.Forms.Padding(2);
            this.btn_admin.Name = "btn_admin";
            this.btn_admin.Size = new System.Drawing.Size(150, 28);
            this.btn_admin.TabIndex = 1;
            this.btn_admin.Text = "Admin";
            this.btn_admin.UseVisualStyleBackColor = false;
            this.btn_admin.Click += new System.EventHandler(this.btn_admin_Click);
            // 
            // btn_all_admin
            // 
            this.btn_all_admin.AllowDrop = true;
            this.btn_all_admin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_all_admin.FlatAppearance.BorderSize = 0;
            this.btn_all_admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_all_admin.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_all_admin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_all_admin.Location = new System.Drawing.Point(2, 32);
            this.btn_all_admin.Margin = new System.Windows.Forms.Padding(2);
            this.btn_all_admin.Name = "btn_all_admin";
            this.btn_all_admin.Size = new System.Drawing.Size(148, 26);
            this.btn_all_admin.TabIndex = 2;
            this.btn_all_admin.Text = "All Admin";
            this.btn_all_admin.UseVisualStyleBackColor = false;
            this.btn_all_admin.Click += new System.EventHandler(this.btn_all_admin_Click);
            // 
            // btn_admin_detail
            // 
            this.btn_admin_detail.AllowDrop = true;
            this.btn_admin_detail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_admin_detail.FlatAppearance.BorderSize = 0;
            this.btn_admin_detail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_admin_detail.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_admin_detail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_admin_detail.Location = new System.Drawing.Point(2, 63);
            this.btn_admin_detail.Margin = new System.Windows.Forms.Padding(2);
            this.btn_admin_detail.Name = "btn_admin_detail";
            this.btn_admin_detail.Size = new System.Drawing.Size(148, 24);
            this.btn_admin_detail.TabIndex = 3;
            this.btn_admin_detail.Text = "Admin Details";
            this.btn_admin_detail.UseVisualStyleBackColor = false;
            this.btn_admin_detail.Click += new System.EventHandler(this.btn_admin_detail_Click);
            // 
            // panel_student
            // 
            this.panel_student.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.panel_student.Controls.Add(this.btn_add_student);
            this.panel_student.Controls.Add(this.btn_student);
            this.panel_student.Controls.Add(this.btn_all_student);
            this.panel_student.Controls.Add(this.btn_student_detail);
            this.panel_student.Location = new System.Drawing.Point(2, 198);
            this.panel_student.Margin = new System.Windows.Forms.Padding(2);
            this.panel_student.MaximumSize = new System.Drawing.Size(150, 126);
            this.panel_student.MinimumSize = new System.Drawing.Size(150, 30);
            this.panel_student.Name = "panel_student";
            this.panel_student.Size = new System.Drawing.Size(150, 30);
            this.panel_student.TabIndex = 4;
            // 
            // btn_add_student
            // 
            this.btn_add_student.AllowDrop = true;
            this.btn_add_student.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_add_student.FlatAppearance.BorderSize = 0;
            this.btn_add_student.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_student.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_student.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_add_student.Location = new System.Drawing.Point(2, 92);
            this.btn_add_student.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add_student.Name = "btn_add_student";
            this.btn_add_student.Size = new System.Drawing.Size(148, 24);
            this.btn_add_student.TabIndex = 4;
            this.btn_add_student.Text = "Add Student";
            this.btn_add_student.UseVisualStyleBackColor = false;
            this.btn_add_student.Click += new System.EventHandler(this.btn_add_student_Click);
            // 
            // btn_student
            // 
            this.btn_student.AllowDrop = true;
            this.btn_student.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.btn_student.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_student.FlatAppearance.BorderSize = 0;
            this.btn_student.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_student.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_student.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_student.Location = new System.Drawing.Point(0, 0);
            this.btn_student.Margin = new System.Windows.Forms.Padding(2);
            this.btn_student.Name = "btn_student";
            this.btn_student.Size = new System.Drawing.Size(150, 30);
            this.btn_student.TabIndex = 1;
            this.btn_student.Text = "Student";
            this.btn_student.UseVisualStyleBackColor = false;
            this.btn_student.Click += new System.EventHandler(this.btn_student_Click);
            // 
            // btn_all_student
            // 
            this.btn_all_student.AllowDrop = true;
            this.btn_all_student.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_all_student.FlatAppearance.BorderSize = 0;
            this.btn_all_student.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_all_student.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_all_student.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_all_student.Location = new System.Drawing.Point(2, 32);
            this.btn_all_student.Margin = new System.Windows.Forms.Padding(2);
            this.btn_all_student.Name = "btn_all_student";
            this.btn_all_student.Size = new System.Drawing.Size(148, 26);
            this.btn_all_student.TabIndex = 2;
            this.btn_all_student.Text = "All Student";
            this.btn_all_student.UseVisualStyleBackColor = false;
            this.btn_all_student.Click += new System.EventHandler(this.btn_all_student_Click);
            // 
            // btn_student_detail
            // 
            this.btn_student_detail.AllowDrop = true;
            this.btn_student_detail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_student_detail.FlatAppearance.BorderSize = 0;
            this.btn_student_detail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_student_detail.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_student_detail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_student_detail.Location = new System.Drawing.Point(2, 63);
            this.btn_student_detail.Margin = new System.Windows.Forms.Padding(2);
            this.btn_student_detail.Name = "btn_student_detail";
            this.btn_student_detail.Size = new System.Drawing.Size(148, 24);
            this.btn_student_detail.TabIndex = 3;
            this.btn_student_detail.Text = "Student Details";
            this.btn_student_detail.UseVisualStyleBackColor = false;
            this.btn_student_detail.Click += new System.EventHandler(this.btn_student_detail_Click);
            // 
            // panel_report
            // 
            this.panel_report.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.panel_report.Controls.Add(this.btn_curriculum);
            this.panel_report.Controls.Add(this.btn_report);
            this.panel_report.Controls.Add(this.btn_attendance);
            this.panel_report.Controls.Add(this.btn_mark);
            this.panel_report.Location = new System.Drawing.Point(2, 232);
            this.panel_report.Margin = new System.Windows.Forms.Padding(2);
            this.panel_report.MaximumSize = new System.Drawing.Size(150, 126);
            this.panel_report.MinimumSize = new System.Drawing.Size(150, 30);
            this.panel_report.Name = "panel_report";
            this.panel_report.Size = new System.Drawing.Size(150, 126);
            this.panel_report.TabIndex = 5;
            // 
            // btn_curriculum
            // 
            this.btn_curriculum.AllowDrop = true;
            this.btn_curriculum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_curriculum.FlatAppearance.BorderSize = 0;
            this.btn_curriculum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_curriculum.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_curriculum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_curriculum.Location = new System.Drawing.Point(2, 92);
            this.btn_curriculum.Margin = new System.Windows.Forms.Padding(2);
            this.btn_curriculum.Name = "btn_curriculum";
            this.btn_curriculum.Size = new System.Drawing.Size(148, 24);
            this.btn_curriculum.TabIndex = 4;
            this.btn_curriculum.Text = "Curriculum";
            this.btn_curriculum.UseVisualStyleBackColor = false;
            this.btn_curriculum.Click += new System.EventHandler(this.btn_curriculum_Click);
            // 
            // btn_report
            // 
            this.btn_report.AllowDrop = true;
            this.btn_report.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.btn_report.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_report.FlatAppearance.BorderSize = 0;
            this.btn_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_report.Location = new System.Drawing.Point(0, 0);
            this.btn_report.Margin = new System.Windows.Forms.Padding(2);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(150, 30);
            this.btn_report.TabIndex = 1;
            this.btn_report.Text = "Reports";
            this.btn_report.UseVisualStyleBackColor = false;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // btn_attendance
            // 
            this.btn_attendance.AllowDrop = true;
            this.btn_attendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_attendance.FlatAppearance.BorderSize = 0;
            this.btn_attendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_attendance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_attendance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_attendance.Location = new System.Drawing.Point(2, 32);
            this.btn_attendance.Margin = new System.Windows.Forms.Padding(2);
            this.btn_attendance.Name = "btn_attendance";
            this.btn_attendance.Size = new System.Drawing.Size(148, 26);
            this.btn_attendance.TabIndex = 2;
            this.btn_attendance.Text = "Attendance Report";
            this.btn_attendance.UseVisualStyleBackColor = false;
            this.btn_attendance.Click += new System.EventHandler(this.btn_attendance_Click);
            // 
            // btn_mark
            // 
            this.btn_mark.AllowDrop = true;
            this.btn_mark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.btn_mark.FlatAppearance.BorderSize = 0;
            this.btn_mark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mark.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mark.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_mark.Location = new System.Drawing.Point(2, 63);
            this.btn_mark.Margin = new System.Windows.Forms.Padding(2);
            this.btn_mark.Name = "btn_mark";
            this.btn_mark.Size = new System.Drawing.Size(148, 24);
            this.btn_mark.TabIndex = 3;
            this.btn_mark.Text = "Mark Report";
            this.btn_mark.UseVisualStyleBackColor = false;
            this.btn_mark.Click += new System.EventHandler(this.btn_mark_Click);
            // 
            // btn_time_table
            // 
            this.btn_time_table.AllowDrop = true;
            this.btn_time_table.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.btn_time_table.FlatAppearance.BorderSize = 0;
            this.btn_time_table.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_time_table.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_time_table.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_time_table.Location = new System.Drawing.Point(2, 362);
            this.btn_time_table.Margin = new System.Windows.Forms.Padding(2);
            this.btn_time_table.Name = "btn_time_table";
            this.btn_time_table.Size = new System.Drawing.Size(148, 28);
            this.btn_time_table.TabIndex = 6;
            this.btn_time_table.Text = "Weekly Timetable";
            this.btn_time_table.UseVisualStyleBackColor = false;
            this.btn_time_table.Click += new System.EventHandler(this.btn_time_table_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.panel2.Controls.Add(this.dashBoard1);
            this.panel2.Controls.Add(this.teacher_details1);
            this.panel2.Controls.Add(this.all_Teacher1);
            this.panel2.Controls.Add(this.all_Student1);
            this.panel2.Controls.Add(this.add_user1);
            this.panel2.Controls.Add(this.add_teacher1);
            this.panel2.Controls.Add(this.student_detail1);
            this.panel2.Controls.Add(this.attendance_report1);
            this.panel2.Controls.Add(this.teacher_attendance1);
            this.panel2.Controls.Add(this.admin_attendance1);
            this.panel2.Controls.Add(this.set_mark1);
            this.panel2.Controls.Add(this.view_mark1);
            this.panel2.Controls.Add(this.curiculum1);
            this.panel2.Controls.Add(this.admin_tracking_attendance1);
            this.panel2.Controls.Add(this.weekly_timetable1);
            this.panel2.Controls.Add(this.all_admin1);
            this.panel2.Controls.Add(this.add_admin1);
            this.panel2.Controls.Add(this.admin_detail1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(150, 61);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1050, 659);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dashBoard1
            // 
            this.dashBoard1.Location = new System.Drawing.Point(0, 0);
            this.dashBoard1.Margin = new System.Windows.Forms.Padding(2);
            this.dashBoard1.Name = "dashBoard1";
            this.dashBoard1.Size = new System.Drawing.Size(1048, 657);
            this.dashBoard1.TabIndex = 1;
            // 
            // teacher_details1
            // 
            this.teacher_details1.Location = new System.Drawing.Point(0, 0);
            this.teacher_details1.Name = "teacher_details1";
            this.teacher_details1.Size = new System.Drawing.Size(1048, 657);
            this.teacher_details1.TabIndex = 6;
            // 
            // all_Teacher1
            // 
            this.all_Teacher1.Location = new System.Drawing.Point(0, 0);
            this.all_Teacher1.Name = "all_Teacher1";
            this.all_Teacher1.Size = new System.Drawing.Size(1048, 657);
            this.all_Teacher1.TabIndex = 4;
            // 
            // all_Student1
            // 
            this.all_Student1.Location = new System.Drawing.Point(0, 0);
            this.all_Student1.Margin = new System.Windows.Forms.Padding(2);
            this.all_Student1.Name = "all_Student1";
            this.all_Student1.Size = new System.Drawing.Size(1048, 657);
            this.all_Student1.TabIndex = 0;
            // 
            // add_user1
            // 
            this.add_user1.BackColor = System.Drawing.SystemColors.Menu;
            this.add_user1.Location = new System.Drawing.Point(0, 0);
            this.add_user1.Margin = new System.Windows.Forms.Padding(2);
            this.add_user1.Name = "add_user1";
            this.add_user1.Size = new System.Drawing.Size(1048, 657);
            this.add_user1.TabIndex = 2;
            // 
            // add_teacher1
            // 
            this.add_teacher1.Location = new System.Drawing.Point(0, 0);
            this.add_teacher1.Name = "add_teacher1";
            this.add_teacher1.Size = new System.Drawing.Size(1048, 657);
            this.add_teacher1.TabIndex = 5;
            // 
            // student_detail1
            // 
            this.student_detail1.BackColor = System.Drawing.SystemColors.Menu;
            this.student_detail1.Location = new System.Drawing.Point(0, 0);
            this.student_detail1.Margin = new System.Windows.Forms.Padding(2);
            this.student_detail1.Name = "student_detail1";
            this.student_detail1.Size = new System.Drawing.Size(1048, 657);
            this.student_detail1.TabIndex = 3;
            // 
            // attendance_report1
            // 
            this.attendance_report1.Location = new System.Drawing.Point(-1, 0);
            this.attendance_report1.Name = "attendance_report1";
            this.attendance_report1.Size = new System.Drawing.Size(1048, 657);
            this.attendance_report1.TabIndex = 7;
            // 
            // teacher_attendance1
            // 
            this.teacher_attendance1.Location = new System.Drawing.Point(0, 0);
            this.teacher_attendance1.Name = "teacher_attendance1";
            this.teacher_attendance1.Size = new System.Drawing.Size(1048, 657);
            this.teacher_attendance1.TabIndex = 8;
            // 
            // admin_attendance1
            // 
            this.admin_attendance1.Location = new System.Drawing.Point(0, 0);
            this.admin_attendance1.Name = "admin_attendance1";
            this.admin_attendance1.Size = new System.Drawing.Size(1048, 657);
            this.admin_attendance1.TabIndex = 9;
            // 
            // set_mark1
            // 
            this.set_mark1.Location = new System.Drawing.Point(0, 0);
            this.set_mark1.Name = "set_mark1";
            this.set_mark1.Size = new System.Drawing.Size(1048, 657);
            this.set_mark1.TabIndex = 11;
            // 
            // view_mark1
            // 
            this.view_mark1.BackColor = System.Drawing.SystemColors.Menu;
            this.view_mark1.Location = new System.Drawing.Point(0, 0);
            this.view_mark1.Name = "view_mark1";
            this.view_mark1.Size = new System.Drawing.Size(1048, 657);
            this.view_mark1.TabIndex = 10;
            // 
            // curiculum1
            // 
            this.curiculum1.Location = new System.Drawing.Point(0, -1);
            this.curiculum1.Name = "curiculum1";
            this.curiculum1.Size = new System.Drawing.Size(1048, 657);
            this.curiculum1.TabIndex = 12;
            // 
            // admin_tracking_attendance1
            // 
            this.admin_tracking_attendance1.BackColor = System.Drawing.SystemColors.Menu;
            this.admin_tracking_attendance1.Location = new System.Drawing.Point(-1, 0);
            this.admin_tracking_attendance1.Name = "admin_tracking_attendance1";
            this.admin_tracking_attendance1.Size = new System.Drawing.Size(1048, 657);
            this.admin_tracking_attendance1.TabIndex = 13;
            // 
            // weekly_timetable1
            // 
            this.weekly_timetable1.BackColor = System.Drawing.SystemColors.Menu;
            this.weekly_timetable1.Location = new System.Drawing.Point(-1, -1);
            this.weekly_timetable1.Name = "weekly_timetable1";
            this.weekly_timetable1.Size = new System.Drawing.Size(1048, 657);
            this.weekly_timetable1.TabIndex = 14;
            // 
            // all_admin1
            // 
            this.all_admin1.Location = new System.Drawing.Point(-1, 0);
            this.all_admin1.Name = "all_admin1";
            this.all_admin1.Size = new System.Drawing.Size(1048, 657);
            this.all_admin1.TabIndex = 15;
            // 
            // add_admin1
            // 
            this.add_admin1.Location = new System.Drawing.Point(0, -1);
            this.add_admin1.Name = "add_admin1";
            this.add_admin1.Size = new System.Drawing.Size(1048, 657);
            this.add_admin1.TabIndex = 17;
            // 
            // admin_detail1
            // 
            this.admin_detail1.Location = new System.Drawing.Point(-1, 0);
            this.admin_detail1.Name = "admin_detail1";
            this.admin_detail1.Size = new System.Drawing.Size(1048, 657);
            this.admin_detail1.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel_teacher.ResumeLayout(false);
            this.panel_admin.ResumeLayout(false);
            this.panel_student.ResumeLayout(false);
            this.panel_report.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lb_exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_dashboard;
        private System.Windows.Forms.Button btn_teacher;
        private System.Windows.Forms.Panel panel_teacher;
        private System.Windows.Forms.Button btn_add_teacher;
        private System.Windows.Forms.Button btn_teacher_detail;
        private System.Windows.Forms.Button btn_allteacher;
        private System.Windows.Forms.Panel panel_admin;
        private System.Windows.Forms.Button btn_add_admin;
        private System.Windows.Forms.Button btn_admin;
        private System.Windows.Forms.Button btn_all_admin;
        private System.Windows.Forms.Button btn_admin_detail;
        private System.Windows.Forms.Panel panel_student;
        private System.Windows.Forms.Button btn_add_student;
        private System.Windows.Forms.Button btn_student;
        private System.Windows.Forms.Button btn_all_student;
        private System.Windows.Forms.Button btn_student_detail;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
      
        
        private DashBoard dashBoard1;
        private All_Student all_Student1;
        private form_usercontrol.Add_students add_user1;
        private form_usercontrol.Student_detail student_detail1;
        private form_usercontrol.All_Teacher all_Teacher1;
        private form_usercontrol.Add_teacher add_teacher1;
        private form_usercontrol.Teacher_details teacher_details1;
        private System.Windows.Forms.Panel panel_report;
        private System.Windows.Forms.Button btn_curriculum;
        private System.Windows.Forms.Button btn_report;
        private System.Windows.Forms.Button btn_attendance;
        private System.Windows.Forms.Button btn_mark;
        private user_control.report.Attendance_report attendance_report1;
        private user_control.report.Teacher_attendance teacher_attendance1;
        private System.Windows.Forms.Button button1;
        private user_control.admin.admin_curriculum admin_attendance1;
        private user_control.teacher.set_mark set_mark1;
        private user_control.student.view_mark view_mark1;
        private user_control.student.Curiculum curiculum1;
        private user_control.admin.admin_tracking_attendance admin_tracking_attendance1;
        private user_control.weekly_timetable weekly_timetable1;
        private System.Windows.Forms.Button btn_time_table;
        private user_control.admin.All_admin all_admin1;
        private user_control.admin.Add_admin add_admin1;
        private user_control.admin.Admin_detail admin_detail1;
    }
}