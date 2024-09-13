namespace coursework
{
    partial class ResetPasswordForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_showpass = new System.Windows.Forms.CheckBox();
            this.tb_newpass = new System.Windows.Forms.TextBox();
            this.btn_change = new System.Windows.Forms.Button();
            this.cb_show_confirmpass = new System.Windows.Forms.CheckBox();
            this.tb_confirm_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cb_showpass);
            this.panel1.Controls.Add(this.tb_newpass);
            this.panel1.Controls.Add(this.btn_change);
            this.panel1.Controls.Add(this.cb_show_confirmpass);
            this.panel1.Controls.Add(this.tb_confirm_password);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(80, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 299);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "New Password:";
            // 
            // cb_showpass
            // 
            this.cb_showpass.AutoSize = true;
            this.cb_showpass.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_showpass.Location = new System.Drawing.Point(77, 123);
            this.cb_showpass.Name = "cb_showpass";
            this.cb_showpass.Size = new System.Drawing.Size(117, 20);
            this.cb_showpass.TabIndex = 19;
            this.cb_showpass.Text = "Show password";
            this.cb_showpass.UseVisualStyleBackColor = true;
            this.cb_showpass.CheckedChanged += new System.EventHandler(this.cb_showpass_CheckedChanged);
            // 
            // tb_newpass
            // 
            this.tb_newpass.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_newpass.Location = new System.Drawing.Point(77, 92);
            this.tb_newpass.Multiline = true;
            this.tb_newpass.Name = "tb_newpass";
            this.tb_newpass.PasswordChar = '*';
            this.tb_newpass.Size = new System.Drawing.Size(251, 25);
            this.tb_newpass.TabIndex = 18;
            // 
            // btn_change
            // 
            this.btn_change.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(143)))));
            this.btn_change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_change.FlatAppearance.BorderSize = 0;
            this.btn_change.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(31)))), ((int)(((byte)(62)))));
            this.btn_change.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(31)))), ((int)(((byte)(62)))));
            this.btn_change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_change.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_change.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_change.Location = new System.Drawing.Point(159, 249);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(82, 33);
            this.btn_change.TabIndex = 16;
            this.btn_change.Text = "Change";
            this.btn_change.UseVisualStyleBackColor = false;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // cb_show_confirmpass
            // 
            this.cb_show_confirmpass.AutoSize = true;
            this.cb_show_confirmpass.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_show_confirmpass.Location = new System.Drawing.Point(77, 204);
            this.cb_show_confirmpass.Name = "cb_show_confirmpass";
            this.cb_show_confirmpass.Size = new System.Drawing.Size(164, 20);
            this.cb_show_confirmpass.TabIndex = 15;
            this.cb_show_confirmpass.Text = "Show confirm password";
            this.cb_show_confirmpass.UseVisualStyleBackColor = true;
            this.cb_show_confirmpass.CheckedChanged += new System.EventHandler(this.cb_show_confirmpass_CheckedChanged);
            // 
            // tb_confirm_password
            // 
            this.tb_confirm_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_confirm_password.Location = new System.Drawing.Point(77, 173);
            this.tb_confirm_password.Multiline = true;
            this.tb_confirm_password.Name = "tb_confirm_password";
            this.tb_confirm_password.PasswordChar = '*';
            this.tb_confirm_password.Size = new System.Drawing.Size(251, 25);
            this.tb_confirm_password.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Confirm New Password:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "New Password";
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(3)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(559, 361);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResetPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetPasswordForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_newpass;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.CheckBox cb_show_confirmpass;
        private System.Windows.Forms.TextBox tb_confirm_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_showpass;
        private System.Windows.Forms.Label label1;
    }
}