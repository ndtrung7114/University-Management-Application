namespace coursework.user_control.report
{
    partial class Teacher_attendance
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
            this.list_class_box = new System.Windows.Forms.ListBox();
            this.list_term_box = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.report_slot = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.list_slot = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_sumbit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.report_slot)).BeginInit();
            this.SuspendLayout();
            // 
            // list_class_box
            // 
            this.list_class_box.FormattingEnabled = true;
            this.list_class_box.Location = new System.Drawing.Point(200, 80);
            this.list_class_box.Name = "list_class_box";
            this.list_class_box.Size = new System.Drawing.Size(152, 537);
            this.list_class_box.TabIndex = 14;
            this.list_class_box.SelectedIndexChanged += new System.EventHandler(this.list_class_box_SelectedIndexChanged_1);
            // 
            // list_term_box
            // 
            this.list_term_box.FormattingEnabled = true;
            this.list_term_box.Location = new System.Drawing.Point(26, 81);
            this.list_term_box.Name = "list_term_box";
            this.list_term_box.Size = new System.Drawing.Size(139, 537);
            this.list_term_box.TabIndex = 13;
            this.list_term_box.SelectedIndexChanged += new System.EventHandler(this.list_term_box_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(775, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Report";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(268, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Term";
            // 
            // report_slot
            // 
            this.report_slot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.report_slot.Location = new System.Drawing.Point(578, 60);
            this.report_slot.Name = "report_slot";
            this.report_slot.Size = new System.Drawing.Size(444, 517);
            this.report_slot.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Attendance ";
            // 
            // list_slot
            // 
            this.list_slot.FormattingEnabled = true;
            this.list_slot.Location = new System.Drawing.Point(395, 81);
            this.list_slot.Name = "list_slot";
            this.list_slot.Size = new System.Drawing.Size(152, 537);
            this.list_slot.TabIndex = 17;
            this.list_slot.SelectedIndexChanged += new System.EventHandler(this.list_slot_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(463, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Slot";
            // 
            // btn_sumbit
            // 
            this.btn_sumbit.Location = new System.Drawing.Point(766, 594);
            this.btn_sumbit.Name = "btn_sumbit";
            this.btn_sumbit.Size = new System.Drawing.Size(75, 23);
            this.btn_sumbit.TabIndex = 18;
            this.btn_sumbit.Text = "SUBMIT";
            this.btn_sumbit.UseVisualStyleBackColor = true;
            this.btn_sumbit.Click += new System.EventHandler(this.btn_sumbit_Click);
            // 
            // Teacher_attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_sumbit);
            this.Controls.Add(this.list_slot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_class_box);
            this.Controls.Add(this.list_term_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.report_slot);
            this.Name = "Teacher_attendance";
            this.Size = new System.Drawing.Size(1048, 657);
            ((System.ComponentModel.ISupportInitialize)(this.report_slot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list_class_box;
        private System.Windows.Forms.ListBox list_term_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView report_slot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_slot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_sumbit;
    }
}
