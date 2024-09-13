namespace coursework.user_control.report
{
    partial class Attendance_report
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
            this.report_slot = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.list_term_box = new System.Windows.Forms.ListBox();
            this.list_subject_box = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_absent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.report_slot)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attendance ";
            // 
            // report_slot
            // 
            this.report_slot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.report_slot.Location = new System.Drawing.Point(496, 65);
            this.report_slot.Name = "report_slot";
            this.report_slot.Size = new System.Drawing.Size(536, 516);
            this.report_slot.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Term";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(327, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subjects";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(724, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Report";
            // 
            // list_term_box
            // 
            this.list_term_box.FormattingEnabled = true;
            this.list_term_box.Location = new System.Drawing.Point(36, 86);
            this.list_term_box.Name = "list_term_box";
            this.list_term_box.Size = new System.Drawing.Size(166, 537);
            this.list_term_box.TabIndex = 7;
            this.list_term_box.SelectedIndexChanged += new System.EventHandler(this.list_term_box_SelectedIndexChanged_1);
            // 
            // list_subject_box
            // 
            this.list_subject_box.FormattingEnabled = true;
            this.list_subject_box.Location = new System.Drawing.Point(259, 85);
            this.list_subject_box.Name = "list_subject_box";
            this.list_subject_box.Size = new System.Drawing.Size(189, 537);
            this.list_subject_box.TabIndex = 8;
            this.list_subject_box.SelectedIndexChanged += new System.EventHandler(this.list_subject_box_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lb_absent);
            this.panel1.Location = new System.Drawing.Point(496, 588);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 35);
            this.panel1.TabIndex = 9;
            // 
            // lb_absent
            // 
            this.lb_absent.AutoSize = true;
            this.lb_absent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_absent.Location = new System.Drawing.Point(20, 9);
            this.lb_absent.Name = "lb_absent";
            this.lb_absent.Size = new System.Drawing.Size(51, 16);
            this.lb_absent.TabIndex = 0;
            this.lb_absent.Text = "Absent:";
            // 
            // Attendance_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.list_subject_box);
            this.Controls.Add(this.list_term_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.report_slot);
            this.Controls.Add(this.label1);
            this.Name = "Attendance_report";
            this.Size = new System.Drawing.Size(1048, 657);
            ((System.ComponentModel.ISupportInitialize)(this.report_slot)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView report_slot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox list_term_box;
        private System.Windows.Forms.ListBox list_subject_box;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_absent;
    }
}
