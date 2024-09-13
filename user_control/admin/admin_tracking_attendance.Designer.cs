namespace coursework.user_control.admin
{
    partial class admin_tracking_attendance
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.list_term = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.list_class = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.list_sub = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attendance";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.list_sub);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.list_class);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.list_term);
            this.panel1.Location = new System.Drawing.Point(18, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 578);
            this.panel1.TabIndex = 1;
            // 
            // list_term
            // 
            this.list_term.FormattingEnabled = true;
            this.list_term.Location = new System.Drawing.Point(13, 94);
            this.list_term.Name = "list_term";
            this.list_term.Size = new System.Drawing.Size(91, 342);
            this.list_term.TabIndex = 0;
            this.list_term.SelectedIndexChanged += new System.EventHandler(this.list_term_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(348, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(654, 529);
            this.dataGridView1.TabIndex = 1;
            // 
            // list_class
            // 
            this.list_class.FormattingEnabled = true;
            this.list_class.Location = new System.Drawing.Point(122, 94);
            this.list_class.Name = "list_class";
            this.list_class.Size = new System.Drawing.Size(96, 342);
            this.list_class.TabIndex = 2;
            this.list_class.SelectedIndexChanged += new System.EventHandler(this.list_class_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Semester";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Subject";
            // 
            // list_sub
            // 
            this.list_sub.FormattingEnabled = true;
            this.list_sub.Location = new System.Drawing.Point(236, 94);
            this.list_sub.Name = "list_sub";
            this.list_sub.Size = new System.Drawing.Size(96, 342);
            this.list_sub.TabIndex = 5;
            this.list_sub.SelectedIndexChanged += new System.EventHandler(this.list_sub_SelectedIndexChanged);
            // 
            // admin_tracking_attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "admin_tracking_attendance";
            this.Size = new System.Drawing.Size(1048, 657);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox list_term;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox list_class;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox list_sub;
        private System.Windows.Forms.Label label3;
    }
}
