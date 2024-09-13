namespace coursework.user_control.admin
{
    partial class admin_curriculum
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_teacher = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.list_subject = new System.Windows.Forms.ListBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_major = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_year = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_semester = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_class = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_name = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_teacher_id = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Teacher_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.name_teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.major = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_student = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.list_semester = new System.Windows.Forms.ListBox();
            this.btn_set = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.list_subject_class = new System.Windows.Forms.ListBox();
            this.list_class = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.slot_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tab_teacher.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tab_student.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.tab_teacher);
            this.tabControl1.Controls.Add(this.tab_student);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1048, 657);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_teacher
            // 
            this.tab_teacher.BackColor = System.Drawing.SystemColors.Menu;
            this.tab_teacher.Controls.Add(this.panel1);
            this.tab_teacher.Controls.Add(this.dataGridView1);
            this.tab_teacher.Controls.Add(this.label1);
            this.tab_teacher.Location = new System.Drawing.Point(4, 4);
            this.tab_teacher.Name = "tab_teacher";
            this.tab_teacher.Padding = new System.Windows.Forms.Padding(3);
            this.tab_teacher.Size = new System.Drawing.Size(1040, 628);
            this.tab_teacher.TabIndex = 0;
            this.tab_teacher.Text = "Teacher";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.list_subject);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cb_major);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cb_year);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cb_semester);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cb_class);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cb_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cb_teacher_id);
            this.panel1.Location = new System.Drawing.Point(31, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 297);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(744, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Subjects";
            // 
            // list_subject
            // 
            this.list_subject.FormattingEnabled = true;
            this.list_subject.ItemHeight = 16;
            this.list_subject.Location = new System.Drawing.Point(611, 62);
            this.list_subject.Name = "list_subject";
            this.list_subject.Size = new System.Drawing.Size(333, 212);
            this.list_subject.TabIndex = 15;
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(219, 231);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(116, 43);
            this.btn_add.TabIndex = 14;
            this.btn_add.Text = "ADD";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Major:";
            // 
            // cb_major
            // 
            this.cb_major.FormattingEnabled = true;
            this.cb_major.Location = new System.Drawing.Point(341, 158);
            this.cb_major.Name = "cb_major";
            this.cb_major.Size = new System.Drawing.Size(121, 24);
            this.cb_major.TabIndex = 12;
            this.cb_major.SelectedIndexChanged += new System.EventHandler(this.cb_major_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Year:";
            // 
            // cb_year
            // 
            this.cb_year.FormattingEnabled = true;
            this.cb_year.Location = new System.Drawing.Point(103, 158);
            this.cb_year.Name = "cb_year";
            this.cb_year.Size = new System.Drawing.Size(121, 24);
            this.cb_year.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Semester:";
            // 
            // cb_semester
            // 
            this.cb_semester.FormattingEnabled = true;
            this.cb_semester.Location = new System.Drawing.Point(341, 82);
            this.cb_semester.Name = "cb_semester";
            this.cb_semester.Size = new System.Drawing.Size(121, 24);
            this.cb_semester.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Class:";
            // 
            // cb_class
            // 
            this.cb_class.FormattingEnabled = true;
            this.cb_class.Location = new System.Drawing.Point(106, 82);
            this.cb_class.Name = "cb_class";
            this.cb_class.Size = new System.Drawing.Size(121, 24);
            this.cb_class.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Name:";
            // 
            // cb_name
            // 
            this.cb_name.FormattingEnabled = true;
            this.cb_name.Location = new System.Drawing.Point(341, 19);
            this.cb_name.Name = "cb_name";
            this.cb_name.Size = new System.Drawing.Size(121, 24);
            this.cb_name.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Teacher ID:";
            // 
            // cb_teacher_id
            // 
            this.cb_teacher_id.FormattingEnabled = true;
            this.cb_teacher_id.Location = new System.Drawing.Point(103, 19);
            this.cb_teacher_id.Name = "cb_teacher_id";
            this.cb_teacher_id.Size = new System.Drawing.Size(121, 24);
            this.cb_teacher_id.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Teacher_id,
            this.image,
            this.name_teacher,
            this.class_name,
            this.semester,
            this.year,
            this.subject,
            this.major});
            this.dataGridView1.Location = new System.Drawing.Point(31, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(973, 212);
            this.dataGridView1.TabIndex = 1;
            // 
            // Teacher_id
            // 
            this.Teacher_id.HeaderText = "Teacher ID";
            this.Teacher_id.Name = "Teacher_id";
            // 
            // image
            // 
            this.image.HeaderText = "Image";
            this.image.Name = "image";
            this.image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // name_teacher
            // 
            this.name_teacher.HeaderText = "Name";
            this.name_teacher.Name = "name_teacher";
            // 
            // class_name
            // 
            this.class_name.HeaderText = "Class";
            this.class_name.Name = "class_name";
            // 
            // semester
            // 
            this.semester.HeaderText = "Semester";
            this.semester.Name = "semester";
            // 
            // year
            // 
            this.year.HeaderText = "Year";
            this.year.Name = "year";
            // 
            // subject
            // 
            this.subject.HeaderText = "Subject";
            this.subject.Name = "subject";
            // 
            // major
            // 
            this.major.HeaderText = "Major";
            this.major.Name = "major";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "attendance teacher";
            // 
            // tab_student
            // 
            this.tab_student.BackColor = System.Drawing.SystemColors.Menu;
            this.tab_student.Controls.Add(this.panel2);
            this.tab_student.Controls.Add(this.label2);
            this.tab_student.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.tab_student.Location = new System.Drawing.Point(4, 4);
            this.tab_student.Name = "tab_student";
            this.tab_student.Padding = new System.Windows.Forms.Padding(3);
            this.tab_student.Size = new System.Drawing.Size(1040, 628);
            this.tab_student.TabIndex = 1;
            this.tab_student.Text = "Student";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.list_semester);
            this.panel2.Controls.Add(this.btn_set);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Controls.Add(this.list_subject_class);
            this.panel2.Controls.Add(this.list_class);
            this.panel2.Location = new System.Drawing.Point(43, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(967, 509);
            this.panel2.TabIndex = 2;
            // 
            // list_semester
            // 
            this.list_semester.FormattingEnabled = true;
            this.list_semester.ItemHeight = 16;
            this.list_semester.Location = new System.Drawing.Point(142, 73);
            this.list_semester.Name = "list_semester";
            this.list_semester.Size = new System.Drawing.Size(112, 212);
            this.list_semester.TabIndex = 5;
            this.list_semester.SelectedIndexChanged += new System.EventHandler(this.list_semester_SelectedIndexChanged);
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(161, 414);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(93, 42);
            this.btn_set.TabIndex = 4;
            this.btn_set.Text = "SET";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(670, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Slot Time";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slot_number,
            this.date,
            this.time,
            this.room});
            this.dataGridView2.Location = new System.Drawing.Point(453, 73);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(494, 404);
            this.dataGridView2.TabIndex = 2;
            // 
            // list_subject_class
            // 
            this.list_subject_class.FormattingEnabled = true;
            this.list_subject_class.ItemHeight = 16;
            this.list_subject_class.Location = new System.Drawing.Point(287, 73);
            this.list_subject_class.Name = "list_subject_class";
            this.list_subject_class.Size = new System.Drawing.Size(123, 212);
            this.list_subject_class.TabIndex = 1;
            this.list_subject_class.SelectedIndexChanged += new System.EventHandler(this.list_subject_class_SelectedIndexChanged);
            // 
            // list_class
            // 
            this.list_class.FormattingEnabled = true;
            this.list_class.ItemHeight = 16;
            this.list_class.Location = new System.Drawing.Point(14, 73);
            this.list_class.Name = "list_class";
            this.list_class.Size = new System.Drawing.Size(99, 212);
            this.list_class.TabIndex = 0;
            this.list_class.SelectedIndexChanged += new System.EventHandler(this.list_class_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "attendance student";
            // 
            // slot_number
            // 
            this.slot_number.HeaderText = "Slot Number";
            this.slot_number.Name = "slot_number";
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.Width = 150;
            // 
            // time
            // 
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            // 
            // room
            // 
            this.room.HeaderText = "Room";
            this.room.Name = "room";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "Class";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(172, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "Term";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(324, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "Subject";
            // 
            // admin_curriculum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "admin_curriculum";
            this.Size = new System.Drawing.Size(1048, 657);
            this.tabControl1.ResumeLayout(false);
            this.tab_teacher.ResumeLayout(false);
            this.tab_teacher.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tab_student.ResumeLayout(false);
            this.tab_student.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_teacher;
        private System.Windows.Forms.TabPage tab_student;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_teacher_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_semester;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_class;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_major;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_year;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ListBox list_subject;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teacher_id;
        private System.Windows.Forms.DataGridViewImageColumn image;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn year;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn major;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox list_subject_class;
        private System.Windows.Forms.ListBox list_class;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.ListBox list_semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn slot_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn room;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}
