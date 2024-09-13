using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace coursework.form_usercontrol
{
    public partial class Teacher_details : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        public int user_id;
        public Role role;
        private int person_id;
        public int teacher_id;
        public Teacher_details()
        {
            InitializeComponent();
        }

        public void Display_infor(string teacher_id, Role role, bool check = false)
        {

            if (connect.State == ConnectionState.Closed)
            {
                if (role == Role.Teacher || check == true)
                {
                    /*try
                    {*/
                    connect.Open();
                    string selectStudent = @"SELECT t.teacher_id, t.salary, p.name, p.email, p.telephone, p.gender, p.DOB, p.image, sub.subject_name,
                                           c.class_name, m.major_name, se.name_semester, se.year, p.role 
                                           FROM Teacher t 
                                           JOIN Person p ON t.person_id = p.person_id 
                                            
                                           JOIN Major m ON t.major_id = m.major_id 
                                           JOIN TeacherSemester ts ON t.teacher_id = ts.teacher_id 
                                           JOIN Class c ON ts.class_id = c.class_id
                                           JOIN Semester se ON ts.semester_id = se.semester_id 
                                           JOIN Subject sub ON ts.subject_id = sub.subject_id
                                          
                                           
                                           WHERE t.teacher_id = @teacher_id 
                                           and se.year = (SELECT TOP 1 year FROM Semester ORDER BY year DESC, name_semester DESC) 
                                           AND se.name_semester = (SELECT TOP 1 name_semester FROM Semester ORDER BY year DESC, name_semester DESC)";

                    using (SqlCommand cmd = new SqlCommand(selectStudent, connect))
                    {
                        cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string teacherId = reader.IsDBNull(reader.GetOrdinal("teacher_id")) ? "null" : reader.GetString(reader.GetOrdinal("teacher_id"));
                            string name = reader.IsDBNull(reader.GetOrdinal("name")) ? "null" : reader.GetString(reader.GetOrdinal("name"));
                            string email = reader.IsDBNull(reader.GetOrdinal("email")) ? "null" : reader.GetString(reader.GetOrdinal("email"));
                            int telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? 0 : reader.GetInt32(reader.GetOrdinal("telephone"));
                            string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? "null" : reader.GetInt32(reader.GetOrdinal("gender")) == 1 ? "Male" : "Female";
                            DateTime dob = reader.IsDBNull(reader.GetOrdinal("DOB")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DOB"));
                            string image = reader.IsDBNull(reader.GetOrdinal("image")) ? "null" : reader.GetString(reader.GetOrdinal("image"));
                            string studentGroup = reader.IsDBNull(reader.GetOrdinal("class_name")) ? "null" : reader.GetString(reader.GetOrdinal("class_name"));
                            string major = reader.IsDBNull(reader.GetOrdinal("major_name")) ? "null" : reader.GetString(reader.GetOrdinal("major_name"));
                            string semesterName = reader.IsDBNull(reader.GetOrdinal("name_semester")) ? "null" : reader.GetString(reader.GetOrdinal("name_semester"));
                            double salary = reader.IsDBNull(reader.GetOrdinal("salary")) ? 0 : reader.GetDouble(reader.GetOrdinal("salary"));
                            string sub1 = reader.IsDBNull(reader.GetOrdinal("subject_name")) ? "null" : reader.GetString(reader.GetOrdinal("subject_name"));
                       
                            int year = reader.IsDBNull(reader.GetOrdinal("year")) ? 0 : reader.GetInt32(reader.GetOrdinal("year"));

                            Teacher teacher = new Teacher(name, telephone, email, role, gender, dob, image, teacherId, studentGroup, major, semesterName);
                            List<string> currentSubjects = teacher.GetCurrentSubjects();


                            tb_teacher_id.Text = teacherId;
                            tb_name.Text = name;
                            tb_mail.Text = email;
                            tb_gender.Text = gender;
                            tb_telephone.Text = telephone.ToString();
                            tb_dob.Text = dob.ToString();
                            // Load image from file path and display in PictureBox
                            if (image != "null" && File.Exists(image))
                            {
                                image_box.Image = Image.FromFile(image);
                            }
                            else
                            {
                                image_box.Image = null; // Clear PictureBox if no valid image path
                            }
                            tb_salary.Text = salary.ToString();
                            tb_major.Text = major;
                            richTextBox1.Text = string.Join(Environment.NewLine, currentSubjects);



                        }
                    }

                    /*}


                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }*/

                }
                else if (role == Role.Student)
                {
                    MessageBox.Show("You are not teacher.", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("You are not selecting specific teacher, please choose one.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
