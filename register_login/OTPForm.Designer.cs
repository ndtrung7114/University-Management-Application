namespace coursework
{
    partial class OTPForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_1 = new System.Windows.Forms.TextBox();
            this.tb_2 = new System.Windows.Forms.TextBox();
            this.tb_3 = new System.Windows.Forms.TextBox();
            this.tb_4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_verify = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter OTP";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_verify);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tb_4);
            this.panel1.Controls.Add(this.tb_3);
            this.panel1.Controls.Add(this.tb_2);
            this.panel1.Controls.Add(this.tb_1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(120, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 243);
            this.panel1.TabIndex = 1;
            // 
            // tb_1
            // 
            this.tb_1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_1.Location = new System.Drawing.Point(50, 86);
            this.tb_1.Multiline = true;
            this.tb_1.Name = "tb_1";
            this.tb_1.Size = new System.Drawing.Size(38, 41);
            this.tb_1.TabIndex = 1;
            this.tb_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_2
            // 
            this.tb_2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_2.Location = new System.Drawing.Point(107, 86);
            this.tb_2.Multiline = true;
            this.tb_2.Name = "tb_2";
            this.tb_2.Size = new System.Drawing.Size(38, 41);
            this.tb_2.TabIndex = 2;
            this.tb_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_3
            // 
            this.tb_3.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_3.Location = new System.Drawing.Point(166, 86);
            this.tb_3.Multiline = true;
            this.tb_3.Name = "tb_3";
            this.tb_3.Size = new System.Drawing.Size(38, 41);
            this.tb_3.TabIndex = 3;
            this.tb_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_4
            // 
            this.tb_4.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_4.Location = new System.Drawing.Point(221, 86);
            this.tb_4.Multiline = true;
            this.tb_4.Name = "tb_4";
            this.tb_4.Size = new System.Drawing.Size(38, 41);
            this.tb_4.TabIndex = 4;
            this.tb_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please enter the 4-digit one time password (OTP) that \r\nwe sent to your registerd" +
    " email.";
            // 
            // btn_verify
            // 
            this.btn_verify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.btn_verify.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_verify.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_verify.Location = new System.Drawing.Point(50, 183);
            this.btn_verify.Name = "btn_verify";
            this.btn_verify.Size = new System.Drawing.Size(209, 44);
            this.btn_verify.TabIndex = 6;
            this.btn_verify.Text = "Verify";
            this.btn_verify.UseVisualStyleBackColor = false;
            this.btn_verify.Click += new System.EventHandler(this.btn_verify_Click);
            // 
            // OTPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(559, 361);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OTPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OTPForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_1;
        private System.Windows.Forms.TextBox tb_4;
        private System.Windows.Forms.TextBox tb_3;
        private System.Windows.Forms.TextBox tb_2;
        private System.Windows.Forms.Button btn_verify;
        private System.Windows.Forms.Label label2;
    }
}