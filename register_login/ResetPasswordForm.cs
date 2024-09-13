using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace coursework
{
    public partial class ResetPasswordForm : Form
    {
        private string email;
        public ResetPasswordForm(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            string newPassword = tb_newpass.Text;
            string confirmPassword = tb_confirm_password.Text;

            // Validate the new password
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter the new password and confirm it.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check password strength (optional)
            if (tb_newpass.Text.Length < 8 || !tb_newpass.Text.Any(char.IsDigit) || !tb_newpass.Text.Any(char.IsUpper) || !tb_newpass.Text.Any(char.IsLower))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one digit, one uppercase letter, and one lowercase letter", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the password in the database
            try
            {
                UpdatePassword(email, newPassword);
                MessageBox.Show("Password changed successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            tb_newpass.PasswordChar = cb_showpass.Checked ? '\0' : '*';
        }

        private void cb_show_confirmpass_CheckedChanged(object sender, EventArgs e)
        {
            tb_confirm_password.PasswordChar = cb_show_confirmpass.Checked ? '\0' : '*';
        }
        private void UpdatePassword(string email, string newPassword)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\management_system.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "UPDATE Person SET password = @password WHERE email = @mail";
            connect.Open();

            try
            {
                string hashedPassword = HashPassword(newPassword);

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    command.Parameters.AddWithValue("@mail", email);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No user found with the provided email.");
                    }
                }
            }
            finally
            {
                connect.Close();
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
