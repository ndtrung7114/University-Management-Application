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
using System.Drawing;
using System.IO;

namespace coursework.form_usercontrol
{
    public partial class Edit_student : Form
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        private string student_id;
        private string image_path;
        public Edit_student(string student_id)
        {
            InitializeComponent();
            this.student_id = student_id;
            display_infor(student_id);
            PopulateComboBox();
        }

        private void display_infor(string student_id)
        {
            if (connect.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectStudent = @"
                    SELECT s.student_id, p.name, p.email, p.telephone, p.gender, p.DOB, p.image,
                           c.class_name, m.major_name, sn.number_semester, se.name_semester, se.year, p.role
                    FROM Student s
                    JOIN Person p ON s.person_id = p.person_id
                    JOIN Class c ON s.class_id = c.class_id
                    JOIN Major m ON s.major_id = m.major_id
                    JOIN StudentSemesters ss ON s.student_id = ss.student_id
                    JOIN SemesterNumber sn ON ss.number_semester_id = sn.number_semester_id
                    JOIN Semester se ON ss.semester_id = se.semester_id
                    WHERE s.student_id = @student_id AND se.year = (SELECT TOP 1 year FROM Semester ORDER BY year DESC, name_semester DESC)
                    AND se.name_semester = (SELECT TOP 1 name_semester FROM Semester ORDER BY year DESC, name_semester DESC)";
                    using (SqlCommand cmd = new SqlCommand(selectStudent, connect))
                    {
                        cmd.Parameters.AddWithValue("@student_id", student_id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string studentId = reader.IsDBNull(reader.GetOrdinal("student_id")) ? "null" : reader.GetString(reader.GetOrdinal("student_id"));
                            string name = reader.IsDBNull(reader.GetOrdinal("name")) ? "null" : reader.GetString(reader.GetOrdinal("name"));
                            string email = reader.IsDBNull(reader.GetOrdinal("email")) ? "null" : reader.GetString(reader.GetOrdinal("email"));
                            int telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? 0 : reader.GetInt32(reader.GetOrdinal("telephone"));
                            string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? "null" : reader.GetInt32(reader.GetOrdinal("gender")) == 1 ? "Male" : "Female";
                            DateTime dob = reader.IsDBNull(reader.GetOrdinal("DOB")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DOB"));
                            string image = reader.IsDBNull(reader.GetOrdinal("image")) ? "null" : reader.GetString(reader.GetOrdinal("image"));
                            string studentGroup = reader.IsDBNull(reader.GetOrdinal("class_name")) ? "null" : reader.GetString(reader.GetOrdinal("class_name"));
                            string major = reader.IsDBNull(reader.GetOrdinal("major_name")) ? "null" : reader.GetString(reader.GetOrdinal("major_name"));
                            int semester_number = reader.IsDBNull(reader.GetOrdinal("number_semester")) ? 0 : reader.GetInt32(reader.GetOrdinal("number_semester"));
                            /*string semesterName = reader.IsDBNull(reader.GetOrdinal("name_semester")) ? "null" : reader.GetString(reader.GetOrdinal("name_semester"));
                            int year = reader.IsDBNull(reader.GetOrdinal("year")) ? 0 : reader.GetInt32(reader.GetOrdinal("year"));
                            Role role = (Role)(reader.GetInt32(reader.GetOrdinal("role")) - 1); */ // Adjusting role based on your implementation

                            /*Student student = new Student(name, telephone, email, role, gender, dob, image, studentId, studentGroup, major, semesterName);*/
                            
                            tb_name.Text = name;
                            tb_mail.Text = email;
                            cb_class.Text = studentGroup;
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
                            cb_num_semester.Text = semester_number.ToString();
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
            string query_semester = "SELECT number_semester FROM SemesterNumber";
            string query_class = "SELECT class_name FROM Class ORDER BY class_id";
            string query_major = "SELECT major_name FROM Major ORDER BY major_id";
            

            try
            {
                // Open the connection
                connect.Open();

                // Execute the query to fetch semester names
                using (SqlCommand command_semester = new SqlCommand(query_semester, connect))
                using (SqlDataReader reader_semester = command_semester.ExecuteReader())
                {
                    // Clear existing items in the combo box
                    cb_num_semester.Items.Clear();

                    // Iterate through the results and add each name_semester to the combo box
                    while (reader_semester.Read())
                    {
                        string semesterName = reader_semester["number_semester"].ToString();
                        cb_num_semester.Items.Add(semesterName);
                    }
                }

                // Execute the query to fetch class names
                using (SqlCommand command_class = new SqlCommand(query_class, connect))
                using (SqlDataReader reader_class = command_class.ExecuteReader())
                {
                    // Clear existing items in the combo box
                    cb_class.Items.Clear();

                    // Iterate through the results and add each class_name to the combo box
                    while (reader_class.Read())
                    {
                        string className = reader_class["class_name"].ToString();
                        cb_class.Items.Add(className);
                    }
                }

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



        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;

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
                updatePersonQuery += " WHERE person_id = (SELECT person_id FROM Student WHERE student_id = @student_id)";
                personParameters.Add(new SqlParameter("@student_id", student_id));

                using (SqlCommand cmdPerson = new SqlCommand(updatePersonQuery, connect))
                {
                    cmdPerson.Parameters.AddRange(personParameters.ToArray());
                    cmdPerson.ExecuteNonQuery();
                }

                // Update Student table
                string updateStudentQuery = "UPDATE Student SET ";
                List<SqlParameter> studentParameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(cb_class.Text))
                {
                    updateStudentQuery += "class_id = (SELECT class_id FROM Class WHERE class_name = @class_name), ";
                    studentParameters.Add(new SqlParameter("@class_name", cb_class.Text.Trim()));
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
                updateStudentQuery += " WHERE student_id = @student_id";
                studentParameters.Add(new SqlParameter("@student_id", student_id));

                using (SqlCommand cmdStudent = new SqlCommand(updateStudentQuery, connect))
                {
                    cmdStudent.Parameters.AddRange(studentParameters.ToArray());
                    cmdStudent.ExecuteNonQuery();
                }

                // Update StudentSemesters table
                string updateStudentSemesters = "UPDATE StudentSemesters SET ";
                List<SqlParameter> studentSemesterParameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(cb_num_semester.Text))
                {
                    updateStudentSemesters += "number_semester_id = @semester_number ";
                    studentSemesterParameters.Add(new SqlParameter("@semester_number", cb_num_semester.Text.Trim()));
                }

                // Add the WHERE clause
                updateStudentSemesters += "WHERE student_id = @student_id AND semester_id = (SELECT TOP 1 semester_id FROM StudentSemesters ORDER BY semester_id DESC)";
                studentSemesterParameters.Add(new SqlParameter("@student_id", student_id));

                using (SqlCommand cmdStudentSemester = new SqlCommand(updateStudentSemesters, connect))
                {
                    cmdStudentSemester.Parameters.AddRange(studentSemesterParameters.ToArray());
                    cmdStudentSemester.ExecuteNonQuery();
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
