using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;


namespace coursework
{
    public enum Role
    {
        Teacher,
        Admin,
        Student
    }
    public partial class Login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\management_system.mdf;Integrated Security=True;Connect Timeout=30");
        public Login()
        {
            InitializeComponent();
            LoadLoginInfo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text.Trim();
            string password = tb_password.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /*try
            {*/
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();

                    // Retrieve hashed password and role from database
                    string selectQuery = "SELECT password, role FROM Person WHERE username = @username;";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashedPasswordFromDB = reader["password"].ToString();
                                int role = Convert.ToInt32(reader["role"]);

                                string hashedPasswordInput = HashPassword(password);

                                if (hashedPasswordInput == hashedPasswordFromDB)
                                {
                                    string userId = "";
                                    reader.Close();

                                    // Retrieve the ID based on the role
                                    if (role == 1) // Admin
                                    {
                                         userId = GetTeacherId(username);
                                    }
                                    else if (role == 2) // Teacher
                                    {
                                        userId = GetAdminId(username);
                                    }
                                    else if (role == 3) // Student
                                    {
                                        userId = GetStudentId(username);
                                    }

                                    MessageBox.Show("Login successful!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //save information
                                    if (cb_remember.Checked)
                                    {
                                        SaveLoginInfo(username, password);
                                    }
                                    else
                                    {
                                        ClearLoginInfo();
                                    }

                                    MainForm main = new MainForm((Role)(role - 1), userId); // Pass the role to MainForm
                                    main.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("User not found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        }
                    }
            /*}
            catch (Exception ex)
            {
                MessageBox.Show("Error login: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }*/

        }

        // Method to get Admin ID
        private string GetAdminId(string username)
        {
            string query = "SELECT a.admin_id FROM Person p INNER JOIN Admin a ON p.person_id = a.person_id WHERE p.username = @username;";
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@username", username);
                return Convert.ToString(cmd.ExecuteScalar());
            }
        }

        // Method to get Teacher ID
        private string GetTeacherId(string username)
        {
            string query = "SELECT t.teacher_id FROM Person p INNER JOIN Teacher t ON p.person_id = t.person_id WHERE p.username = @username;";
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@username", username);
                return Convert.ToString(cmd.ExecuteScalar());
            }
        }

        // Method to get Student ID
        private string GetStudentId(string username)
        {
            string query = "SELECT s.student_id FROM Person p INNER JOIN Student s ON p.person_id = s.person_id WHERE p.username = @username;";
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@username", username);
                return Convert.ToString(cmd.ExecuteScalar());
            }
        }

        private void lb_forgot_pw_Click(object sender, EventArgs e)
        {
            ForgotpasswordForm forgot_pass = new ForgotpasswordForm();
            forgot_pass.Show();
            this.Hide ();
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // ComputeHash returns byte array, convert it to a 'human-readable' string of hexadecimal values
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void SaveLoginInfo(string username, string password)
        {
            Properties.Settings.Default.Username = username;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.RememberMe = true;
            Properties.Settings.Default.Save();
        }
        private void ClearLoginInfo()
        {
            Properties.Settings.Default.Username = string.Empty;
            Properties.Settings.Default.Password = string.Empty;
            Properties.Settings.Default.RememberMe = false;
            Properties.Settings.Default.Save();
        }

        private void LoadLoginInfo()
        {
            if (Properties.Settings.Default.RememberMe)
            {
                tb_username.Text = Properties.Settings.Default.Username;
                tb_password.Text = Properties.Settings.Default.Password;
                cb_remember.Checked = true;
            }
        }

        private void cb_remember_pass(object sender, EventArgs e)
        {

        }
    }
}
