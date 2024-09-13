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
using System.IO;

namespace coursework.form_usercontrol
{
    public partial class Edit_teacher : Form
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        private string teacherId;
        private string image_path;
        public Edit_teacher(string teacher_id)
        {
            InitializeComponent();
            
            this.teacherId = teacher_id;
            display_infor(teacherId);
            PopulateComboBox();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                // Start with an empty update query
                string updatePersonQuery = "UPDATE Person SET ";
                List<SqlParameter> personParameters = new List<SqlParameter>();

                // Check each field and add to query if it has a value
                if (!string.IsNullOrWhiteSpace(tb_name.Text))
                {
                    updatePersonQuery += "name = @name, ";
                    personParameters.Add(new SqlParameter("@name", tb_name.Text.Trim()));
                }
                if (!string.IsNullOrWhiteSpace(tb_mail.Text))
                {
                    updatePersonQuery += "email = @email, ";
                    personParameters.Add(new SqlParameter("@email", tb_mail.Text.Trim()));
                }
                if (!string.IsNullOrWhiteSpace(tb_telephone.Text))
                {
                    updatePersonQuery += "telephone = @telephone, ";
                    personParameters.Add(new SqlParameter("@telephone", int.Parse(tb_telephone.Text.Trim())));
                }
                if (!string.IsNullOrWhiteSpace(cb_gender.Text))
                {
                    updatePersonQuery += "gender = @gender, ";
                    personParameters.Add(new SqlParameter("@gender", cb_gender.Text == "Male" ? 1 : 0)); // Assuming Male is 1 and Female is 0
                }
                if (!string.IsNullOrWhiteSpace(image_path))
                {
                    updatePersonQuery += "image = @image, ";
                    personParameters.Add(new SqlParameter("@image", image_path));
                }
                if (dateTimePicker1.Value != DateTimePicker.MinimumDateTime)
                {
                    updatePersonQuery += "DOB = @dob, ";
                    personParameters.Add(new SqlParameter("@dob", dateTimePicker1.Value));
                }

                // Remove the last comma and space
                if (updatePersonQuery.EndsWith(", "))
                {
                    updatePersonQuery = updatePersonQuery.Substring(0, updatePersonQuery.Length - 2);
                }

                // Add the WHERE clause
                updatePersonQuery += " WHERE person_id = (SELECT person_id FROM Teacher WHERE teacher_id = @teacher_id)";
                personParameters.Add(new SqlParameter("@teacher_id", teacherId));

                using (SqlCommand cmdPerson = new SqlCommand(updatePersonQuery, connect))
                {
                    cmdPerson.Parameters.AddRange(personParameters.ToArray());
                    cmdPerson.ExecuteNonQuery();
                }

                // Update Student table
                string updateStudentQuery = "UPDATE Teacher SET ";
                List<SqlParameter> studentParameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(tb_salary.Text))
                {
                    updateStudentQuery += "salary = @salary, ";
                    studentParameters.Add(new SqlParameter("@salary", tb_salary.Text.Trim()));
                }
                if (!string.IsNullOrWhiteSpace(cb_major.Text))
                {
                    updateStudentQuery += "major_id = (SELECT major_id FROM Major WHERE major_name = @major_name), ";
                    studentParameters.Add(new SqlParameter("@major_name", cb_major.Text.Trim()));
                }

                // Remove the last comma and space
                if (updateStudentQuery.EndsWith(", "))
                {
                    updateStudentQuery = updateStudentQuery.Substring(0, updateStudentQuery.Length - 2);
                }

                // Add the WHERE clause
                updateStudentQuery += " WHERE teacher_id = @teacher_id";
                studentParameters.Add(new SqlParameter("@teacher_id", teacherId));

                using (SqlCommand cmdStudent = new SqlCommand(updateStudentQuery, connect))
                {
                    cmdStudent.Parameters.AddRange(studentParameters.ToArray());
                    cmdStudent.ExecuteNonQuery();
                }

                

                MessageBox.Show("Information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student information: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void display_infor(string teacher_id)
        {
            if (connect.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectStudent = @"
                    SELECT t.teacher_id, t.salary, p.name, p.email, p.telephone, p.gender, p.DOB, p.image,
                           m.major_name, p.role
                    FROM Teacher t
                    JOIN Person p ON t.person_id = p.person_id
                 
                    JOIN Major m ON t.major_id = m.major_id
                    
                    WHERE t.teacher_id = @teacher_id ";
                    using (SqlCommand cmd = new SqlCommand(selectStudent, connect))
                    {
                        cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string teacher_Id = reader.IsDBNull(reader.GetOrdinal("teacher_id")) ? "null" : reader.GetString(reader.GetOrdinal("teacher_id"));
                            string name = reader.IsDBNull(reader.GetOrdinal("name")) ? "null" : reader.GetString(reader.GetOrdinal("name"));
                            string email = reader.IsDBNull(reader.GetOrdinal("email")) ? "null" : reader.GetString(reader.GetOrdinal("email"));
                            int telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? 0 : reader.GetInt32(reader.GetOrdinal("telephone"));
                            string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? "null" : reader.GetInt32(reader.GetOrdinal("gender")) == 1 ? "Male" : "Female";
                            DateTime dob = reader.IsDBNull(reader.GetOrdinal("DOB")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DOB"));
                            string image = reader.IsDBNull(reader.GetOrdinal("image")) ? "null" : reader.GetString(reader.GetOrdinal("image"));
                            double salary = reader.IsDBNull(reader.GetOrdinal("salary")) ? 0 : reader.GetDouble(reader.GetOrdinal("salary"));
                            string major = reader.IsDBNull(reader.GetOrdinal("major_name")) ? "null" : reader.GetString(reader.GetOrdinal("major_name"));
                           
                       
                            Role role = (Role)(reader.GetInt32(reader.GetOrdinal("role")) - 1);  // Adjusting role based on your implementation

                            

                            tb_name.Text = name;
                            tb_mail.Text = email;
                            tb_salary.Text = salary.ToString();
                            dateTimePicker1.Value = dob;
                            cb_gender.Text = gender;
                            if (image != "null" && File.Exists(image))
                            {
                                image_box.Image = Image.FromFile(image);
                            }
                            else
                            {
                                image_box.Image = null; // Clear PictureBox if no valid image path
                            }
                            cb_major.Text = major;
                           
                            tb_telephone.Text = telephone.ToString();


                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void PopulateComboBox()
        {
            // Queries to fetch semester names, class names, and major names
            
            string query_major = "SELECT major_name FROM Major ORDER BY major_id";


            try
            {
                // Open the connection
                connect.Open();

                

                // Execute the query to fetch major names
                using (SqlCommand command_major = new SqlCommand(query_major, connect))
                using (SqlDataReader reader_major = command_major.ExecuteReader())
                {
                    // Clear existing items in the combo box
                    cb_major.Items.Clear();

                    // Iterate through the results and add each major_name to the combo box
                    while (reader_major.Read())
                    {
                        string majorName = reader_major["major_name"].ToString();
                        cb_major.Items.Add(majorName);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
            finally
            {
                // Close the connection
                connect.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_change_img_Click(object sender, EventArgs e)
        {
            // Open file dialog to choose an image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Get the selected file path and display in PictureBox
                image_path = openFileDialog.FileName;
                image_box.Image = Image.FromFile(image_path);
            }
        }
    }
}
