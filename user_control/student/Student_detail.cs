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
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using System.IO;

namespace coursework.form_usercontrol
{
    public partial class Student_detail : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        public int user_id;
        public Role role;
        private int person_id;
        public string student_id;
        public Student_detail()
        {
            InitializeComponent();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        public void Display_infor(string stu_id, Role role, bool check = false)
        {

            if (connect.State == ConnectionState.Closed)
            {
                if (role == Role.Student || check == true)
                {
                    /*try
                    {*/
                        connect.Open();
                        string selectStudent = "SELECT s.student_id, p.name, p.email, p.telephone, p.gender, p.DOB, p.image, " +
                                               "c.class_name, m.major_name, se.name_semester, se.year, p.role " +
                                               "FROM Student s " +
                                               "JOIN Person p ON s.person_id = p.person_id " +
                                               "JOIN Class c ON s.class_id = c.class_id " +
                                               "JOIN Major m ON s.major_id = m.major_id " +
                                               "JOIN StudentSemesters ss ON s.student_id = ss.student_id " +
                                               "JOIN Semester se ON ss.semester_id = se.semester_id " +
                                               "WHERE s.student_id = @student_id " +
                                               "and se.year = (SELECT TOP 1 year FROM Semester ORDER BY year DESC, name_semester DESC) " +
                                               "AND se.name_semester = (SELECT TOP 1 name_semester FROM Semester ORDER BY year DESC, name_semester DESC)";

                        using (SqlCommand cmd = new SqlCommand(selectStudent, connect))
                        {
                            cmd.Parameters.AddWithValue("@student_id", stu_id);
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
                                string semesterName = reader.IsDBNull(reader.GetOrdinal("name_semester")) ? "null" : reader.GetString(reader.GetOrdinal("name_semester"));
                                int year = reader.IsDBNull(reader.GetOrdinal("year")) ? 0 : reader.GetInt32(reader.GetOrdinal("year"));
                                
                                Student student = new Student(name, telephone, email, role, gender, dob, image, studentId, studentGroup, major, semesterName);
                                List<string> currentSubjects = student.GetCurrentSubjects(year);
                                var ( previousSubjects, year_pre_sem, name_pre_sem) = student.GetPreviousSubjects();

                                
                                tb_student_id.Text = studentId;
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
                                tb_class.Text = studentGroup;
                                tb_year_cur_sem.Text = year.ToString();
                                tb_major.Text = major;
                                tb_cur_sem.Text= semesterName;
                                tb_cur_sub.Text = string.Join(", ", currentSubjects);
                                tb_year_pre_sem.Text = year_pre_sem.ToString();
                                tb_pre_sem.Text = name_pre_sem;
                                tb_pre_sub.Text= string.Join(", ", previousSubjects);


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
                else if (role == Role.Teacher)
                {
                    MessageBox.Show("You are not student.", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("You are not selecting specific student, please choose one.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }


        

        private void Student_detail_Load(object sender, EventArgs e)
        {

        }

        private void btn_change_pass_Click(object sender, EventArgs e)
        {


        }
    }
    
}
