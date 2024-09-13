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
    public partial class RegisterForm : Form
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            tb_password.PasswordChar = cb_showpass.Checked ? '\0' : '*';
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "" || tb_password.Text == "" || tb_email.Text == "" || cb_role.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Check if password and confirm password match
            if (tb_password.Text != tb_cf_pw.Text)
            {
                MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check password strength (optional)
            if (tb_password.Text.Length < 8 || !tb_password.Text.Any(char.IsDigit) || !tb_password.Text.Any(char.IsUpper) || !tb_password.Text.Any(char.IsLower))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one digit, one uppercase letter, and one lowercase letter", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        // Proceed with hashing the password
                        string hashedPassword = HashPassword(tb_password.Text.Trim());

                        //check whether account is existing elready

                        string selectUsername = "select count(person_id) from Person where username = @user";
                        string selectemail = "select count(person_id) from Person where email = @email";

                        using (SqlCommand checkUser = new SqlCommand(selectUsername, connect))
                        {
                            using (SqlCommand checkemail = new SqlCommand(selectemail, connect))
                            {
                                checkUser.Parameters.AddWithValue("@user", tb_username.Text.Trim());
                                int count = (int)checkUser.ExecuteScalar();
                                checkemail.Parameters.AddWithValue("@email",tb_email.Text.Trim());
                                int count_email = (int)checkemail.ExecuteScalar();

                                if (count >= 1)
                                {
                                    MessageBox.Show(tb_username.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                } else if(count_email >= 1)
                                {
                                    MessageBox.Show(tb_email.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                

                                
                                else
                                {
                                    DateTime today = DateTime.Now;


                                    string insertData = "insert into Person " + "(username, password, date_register, email, role)" + "values(@username, @password, @date_reg, @email, @role)" + "select scope_identity();";

                                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                    {
                                        cmd.Parameters.AddWithValue("@username", tb_username.Text.Trim());
                                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                                        cmd.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                                        cmd.Parameters.AddWithValue("@role", cb_role.SelectedIndex + 1);
                                        cmd.Parameters.AddWithValue("@date_reg", today);

                                        // Execute the insert command and get the new person_id
                                        int personId = Convert.ToInt32(cmd.ExecuteScalar());

                                        if (cb_role.SelectedIndex == 0)
                                        {
                                            string insertDataTeacher = "insert into Teacher (person_id) values(@person_id)";
                                            using (SqlCommand cmdTeacher = new SqlCommand(insertDataTeacher, connect))
                                            {
                                                cmdTeacher.Parameters.AddWithValue("@person_id", personId);
                                                cmdTeacher.ExecuteNonQuery();
                                            }
                                        } else if (cb_role.SelectedIndex == 1)
                                        {
                                            string insertDataAdmin = "insert into Admin (person_id) values(@person_id)";
                                            using (SqlCommand cmdAdmin = new SqlCommand(insertDataAdmin, connect))
                                            {
                                                cmdAdmin.Parameters.AddWithValue("@person_id", personId);
                                                cmdAdmin.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            string insertDataStudent = "insert into Student (person_id) values(@person_id)";
                                            using (SqlCommand cmdStudent = new SqlCommand(insertDataStudent, connect))
                                            {
                                                cmdStudent.Parameters.AddWithValue("@person_id", personId);
                                                cmdStudent.ExecuteNonQuery();
                                            }
                                        }



                                        MessageBox.Show("Register successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        Login login = new Login();
                                        login.Show();
                                        this.Hide();
                                    }

                                }

                            }
                            
                        }




                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cb_cf_pw_CheckedChanged(object sender, EventArgs e)
        {
            tb_cf_pw.PasswordChar = cb_cf_pw.Checked ? '\0' : '*';

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
    }
}
