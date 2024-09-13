namespace coursework.user_control
{
    partial class weekly_timetable
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
            this.cb_year = new System.Windows.Forms.ComboBox();
            this.cb_week = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.time_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_year
            // 
            this.cb_year.FormattingEnabled = true;
            this.cb_year.Location = new System.Drawing.Point(21, 27);
            this.cb_year.Name = "cb_year";
            this.cb_year.Size = new System.Drawing.Size(121, 21);
            this.cb_year.TabIndex = 1;
            this.cb_year.SelectedIndexChanged += new System.EventHandler(this.cb_year_SelectedIndexChanged);
            // 
            // cb_week
            // 
            this.cb_week.FormattingEnabled = true;
            this.cb_week.Location = new System.Drawing.Point(21, 55);
            this.cb_week.Name = "cb_week";
            this.cb_week.Size = new System.Drawing.Size(121, 21);
            this.cb_week.TabIndex = 2;
            this.cb_week.SelectedIndexChanged += new System.EventHandler(this.cb_week_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time_date,
            this.mon,
            this.tue,
            this.wed,
            this.thu,
            this.fri,
            this.sat,
            this.sun});
            this.dataGridView1.Location = new System.Drawing.Point(3, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1042, 560);
            this.dataGridView1.TabIndex = 3;
            // 
            // time_date
            // 
            this.time_date.HeaderText = "TIME / DATE";
            this.time_date.Name = "time_date";
            this.time_date.Width = 125;
            // 
            // mon
            // 
            this.mon.HeaderText = "MON (07/07)";
            this.mon.Name = "mon";
            this.mon.Width = 125;
            // 
            // tue
            // 
            this.tue.HeaderText = "TUE (08/07)";
            this.tue.Name = "tue";
            this.tue.Width = 125;
            // 
            // wed
            // 
            this.wed.HeaderText = "WED (09/07)";
            this.wed.Name = "wed";
            this.wed.Width = 125;
            // 
            // thu
            // 
            this.thu.HeaderText = "THU (10/07)";
            this.thu.Name = "thu";
            this.thu.Width = 125;
            // 
            // fri
            // 
            this.fri.HeaderText = "FRI (11/07)";
            this.fri.Name = "fri";
            this.fri.Width = 125;
            // 
            // sat
            // 
            this.sat.HeaderText = "SAT (12/07)";
            this.sat.Name = "sat";
            this.sat.Width = 125;
            // 
            // sun
            // 
            this.sun.HeaderText = "SUN (13/07)";
            this.sun.Name = "sun";
            this.sun.Width = 125;
            // 
            // weekly_timetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cb_week);
            this.Controls.Add(this.cb_year);
            this.Name = "weekly_timetable";
            this.Size = new System.Drawing.Size(1048, 657);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_year;
        private System.Windows.Forms.ComboBox cb_week;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn mon;
        private System.Windows.Forms.DataGridViewTextBoxColumn tue;
        private System.Windows.Forms.DataGridViewTextBoxColumn wed;
        private System.Windows.Forms.DataGridViewTextBoxColumn thu;
        private System.Windows.Forms.DataGridViewTextBoxColumn fri;
        private System.Windows.Forms.DataGridViewTextBoxColumn sat;
        private System.Windows.Forms.DataGridViewTextBoxColumn sun;
    }
}
