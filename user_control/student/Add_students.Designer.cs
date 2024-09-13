namespace coursework.form_usercontrol
{
    partial class Add_students
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_semester_name = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_class = new System.Windows.Forms.ComboBox();
            this.cb_semester = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_major = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_gender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.browse_image = new System.Windows.Forms.Button();
            this.image = new System.Windows.Forms.PictureBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_cur = new System.Windows.Forms.Label();
            this.tb_telephone = new System.Windows.Forms.TextBox();
            this.lb_telephone = new System.Windows.Forms.Label();
            this.tb_mail = new System.Windows.Forms.TextBox();
            this.lb_mail = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tb_student_id = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 368);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 11);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(997, 344);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.tb_student_id);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cb_semester_name);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cb_class);
            this.panel2.Controls.Add(this.cb_semester);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cb_major);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cb_gender);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.browse_image);
            this.panel2.Controls.Add(this.image);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lb_cur);
            this.panel2.Controls.Add(this.tb_telephone);
            this.panel2.Controls.Add(this.lb_telephone);
            this.panel2.Controls.Add(this.tb_mail);
            this.panel2.Controls.Add(this.lb_mail);
            this.panel2.Controls.Add(this.tb_name);
            this.panel2.Controls.Add(this.label2);
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(12, 400);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1021, 243);
            this.panel2.TabIndex = 1;
            // 
            // cb_semester_name
            // 
            this.cb_semester_name.FormattingEnabled = true;
            this.cb_semester_name.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cb_semester_name.Location = new System.Drawing.Point(587, 190);
            this.cb_semester_name.Margin = new System.Windows.Forms.Padding(2);
            this.cb_semester_name.Name = "cb_semester_name";
            this.cb_semester_name.Size = new System.Drawing.Size(138, 21);
            this.cb_semester_name.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(495, 190);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Semester name:";
            // 
            // cb_class
            // 
            this.cb_class.FormattingEnabled = true;
            this.cb_class.Location = new System.Drawing.Point(587, 24);
            this.cb_class.Margin = new System.Windows.Forms.Padding(2);
            this.cb_class.Name = "cb_class";
            this.cb_class.Size = new System.Drawing.Size(138, 21);
            this.cb_class.TabIndex = 20;
            // 
            // cb_semester
            // 
            this.cb_semester.FormattingEnabled = true;
            this.cb_semester.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cb_semester.Location = new System.Drawing.Point(587, 139);
            this.cb_semester.Margin = new System.Windows.Forms.Padding(2);
            this.cb_semester.Name = "cb_semester";
            this.cb_semester.Size = new System.Drawing.Size(138, 21);
            this.cb_semester.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(483, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Number Semester:";
            // 
            // cb_major
            // 
            this.cb_major.FormattingEnabled = true;
            this.cb_major.Items.AddRange(new object[] {
            "IT",
            "Design",
            "Business"});
            this.cb_major.Location = new System.Drawing.Point(587, 71);
            this.cb_major.Margin = new System.Windows.Forms.Padding(2);
            this.cb_major.Name = "cb_major";
            this.cb_major.Size = new System.Drawing.Size(138, 21);
            this.cb_major.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(537, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Major:";
            // 
            // cb_gender
            // 
            this.cb_gender.FormattingEnabled = true;
            this.cb_gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cb_gender.Location = new System.Drawing.Point(58, 119);
            this.cb_gender.Margin = new System.Windows.Forms.Padding(2);
            this.cb_gender.Name = "cb_gender";
            this.cb_gender.Size = new System.Drawing.Size(138, 21);
            this.cb_gender.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(545, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Class:";
            // 
            // browse_image
            // 
            this.browse_image.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.browse_image.Location = new System.Drawing.Point(857, 126);
            this.browse_image.Margin = new System.Windows.Forms.Padding(2);
            this.browse_image.Name = "browse_image";
            this.browse_image.Size = new System.Drawing.Size(86, 19);
            this.browse_image.TabIndex = 12;
            this.browse_image.Text = "Import";
            this.browse_image.UseVisualStyleBackColor = true;
            this.browse_image.Click += new System.EventHandler(this.browse_image_Click);
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.image.Location = new System.Drawing.Point(857, 18);
            this.image.Margin = new System.Windows.Forms.Padding(2);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(86, 106);
            this.image.TabIndex = 11;
            this.image.TabStop = false;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(13, 179);
            this.btn_add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(85, 35);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "ADD";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(8, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Gender:";
            // 
            // lb_cur
            // 
            this.lb_cur.AutoSize = true;
            this.lb_cur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cur.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_cur.Location = new System.Drawing.Point(239, 72);
            this.lb_cur.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_cur.Name = "lb_cur";
            this.lb_cur.Size = new System.Drawing.Size(77, 15);
            this.lb_cur.TabIndex = 6;
            this.lb_cur.Text = "Date of Birth:";
            // 
            // tb_telephone
            // 
            this.tb_telephone.Location = new System.Drawing.Point(301, 21);
            this.tb_telephone.Margin = new System.Windows.Forms.Padding(2);
            this.tb_telephone.Name = "tb_telephone";
            this.tb_telephone.Size = new System.Drawing.Size(138, 20);
            this.tb_telephone.TabIndex = 5;
            // 
            // lb_telephone
            // 
            this.lb_telephone.AutoSize = true;
            this.lb_telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_telephone.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_telephone.Location = new System.Drawing.Point(239, 24);
            this.lb_telephone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_telephone.Name = "lb_telephone";
            this.lb_telephone.Size = new System.Drawing.Size(69, 15);
            this.lb_telephone.TabIndex = 4;
            this.lb_telephone.Text = "Telephone:";
            // 
            // tb_mail
            // 
            this.tb_mail.Location = new System.Drawing.Point(58, 65);
            this.tb_mail.Margin = new System.Windows.Forms.Padding(2);
            this.tb_mail.Name = "tb_mail";
            this.tb_mail.Size = new System.Drawing.Size(138, 20);
            this.tb_mail.TabIndex = 3;
            // 
            // lb_mail
            // 
            this.lb_mail.AutoSize = true;
            this.lb_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_mail.Location = new System.Drawing.Point(10, 71);
            this.lb_mail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_mail.Name = "lb_mail";
            this.lb_mail.Size = new System.Drawing.Size(42, 15);
            this.lb_mail.TabIndex = 2;
            this.lb_mail.Text = "Email:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(58, 18);
            this.tb_name.Margin = new System.Windows.Forms.Padding(2);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(138, 20);
            this.tb_name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(10, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Home - Add Student";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // tb_student_id
            // 
            this.tb_student_id.Location = new System.Drawing.Point(301, 119);
            this.tb_student_id.Margin = new System.Windows.Forms.Padding(2);
            this.tb_student_id.Name = "tb_student_id";
            this.tb_student_id.Size = new System.Drawing.Size(138, 20);
            this.tb_student_id.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(230, 124);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Student ID:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(321, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // Add_students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Add_students";
            this.Size = new System.Drawing.Size(1048, 657);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_cur;
        private System.Windows.Forms.TextBox tb_telephone;
        private System.Windows.Forms.Label lb_telephone;
        private System.Windows.Forms.TextBox tb_mail;
        private System.Windows.Forms.Label lb_mail;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Button browse_image;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_gender;
        private System.Windows.Forms.ComboBox cb_semester;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_major;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_class;
        private System.Windows.Forms.ComboBox cb_semester_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tb_student_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
