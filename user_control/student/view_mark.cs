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

namespace coursework.user_control.student
{
    public partial class view_mark : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        private string student_id_mark;
        private int major_id;
        private int subject_id;
        private int semester_id;
        public view_mark()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.AllowUserToAddRows = false;
            panel4.Visible = false;
        }
        public void load_infor_term(string student_id)
        {
            try
            {
                this.student_id_mark = student_id;

                // Define your SQL query to retrieve semester information
                string query = @"
                    SELECT se.name_semester, se.year, se.semester_id, ss.number_semester_id, s.major_id
                    FROM Student s
                    JOIN StudentSemesters ss ON s.student_id = ss.student_id
                    JOIN Semester se ON ss.semester_id = se.semester_id
                    WHERE s.student_id = @student_id
                    ORDER BY year ASC, name_semester ASC";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@student_id", student_id);

                    // Open the connection
                    connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear existing items
                    list_term.Items.Clear();

                    // Read each row from the result set
                    while (reader.Read())
                    {
                        string nameSemester = reader["name_semester"].ToString();
                        string year = reader["year"].ToString();
                        int semester_id = Convert.ToInt32(reader["semester_id"]);
                        int number_semester_id = Convert.ToInt32(reader["number_semester_id"]);
                        major_id = Convert.ToInt32(reader["major_id"]);

                        // Append the formatted information to ListBox
                        list_term.Items.Add($"{nameSemester} {year}");
                    }

                    // Close the reader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading term information: {ex.Message}");
            }
            finally
            {
                connect.Close();
            }
        }

        private void LoadSubjectsForSelectedSemester(int semester_id, int major_id)
        {
            try
            {

                // Define your SQL query to retrieve subjects for the selected semester
                string query = @"
                    SELECT subj.subject_name
                    FROM StudentSemesters ss
                    JOIN Student s ON ss.student_id = s.student_id
                    JOIN SemesterSubjects sesub ON ss.number_semester_id = sesub.number_semester_id
                    JOIN Subject subj ON sesub.subject_id = subj.subject_id
                    WHERE ss.semester_id = @semester_id AND s.student_id = @student_id AND subj.major_id = @major_id";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@semester_id", semester_id);
                    command.Parameters.AddWithValue("@major_id", major_id);
                    command.Parameters.AddWithValue("@student_id", student_id_mark);

                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear existing items
                    list_subject.Items.Clear();

                    // Read each subject from the result set
                    while (reader.Read())
                    {
                        string subjectName = reader["subject_name"].ToString();
                        list_subject.Items.Add(subjectName);
                    }

                    // Close the reader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects for semester: {ex.Message}");
            }
            finally
            {
                // Close the connection
                connect.Close();
            }
        }

        private void list_term_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure there is a selected item
            if (list_term.SelectedIndex != -1)
            {
                // Extract semester information from the selected item
                string selectedTerm = list_term.SelectedItem.ToString();
                string[] termParts = selectedTerm.Split(' ');
                string nameSemester = termParts[0];
                string year = termParts[1];

                // Retrieve semester_id from database based on nameSemester and year
                /*try
                {*/
                string query = @"
                        SELECT se.semester_id
                        FROM Semester se
                        WHERE se.name_semester = @nameSemester AND se.year = @year";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@nameSemester", nameSemester);
                    command.Parameters.AddWithValue("@year", year);

                    connect.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        semester_id = Convert.ToInt32(result);

                        // Load subjects for the selected semester
                        LoadSubjectsForSelectedSemester(semester_id, major_id);
                    }
                }
                /*}
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving semester information: {ex.Message}");
                }
                finally
                {
                    connect.Close();
                }*/
            }

        }

        private void list_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel4.Visible = true;
            if (list_subject.SelectedIndex != -1)
            {


                // Extract the class information from the selected item
                string selectedItem = list_subject.SelectedItem.ToString();
                // Assuming the format is "Class name - Subject name"
                string[] parts = selectedItem.Split(new string[] { " - " }, StringSplitOptions.None);

                if (parts.Length >= 1)
                {
                    
                    string subject_name = parts[0];

                    // Retrieve class_id from database based on class_name
                    /*try
                    {*/
                    string query = @"
                    SELECT subject_id
                    FROM Subject
                    WHERE subject_name = @subject_name";


                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.AddWithValue("@subject_name", subject_name);

                        if (connect.State == ConnectionState.Closed) { connect.Open(); }
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            subject_id = Convert.ToInt32(result);
                            LoadGrades(subject_id, semester_id);



                        }
                        else
                        {
                            MessageBox.Show("Class ID not found.");
                        }
                    }
                    
                    /*}
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving class information: {ex.Message}");
                    }
                    finally
                    {
                        connect.Close();
                    }*/
                }
                else
                {
                    MessageBox.Show("Invalid class format.");
                }
            }

        }

        private void LoadGrades(int subject_id, int semester_id)
        {
            // Create a new Student object using GetStudentById method
            Student student = GetStudentById(student_id_mark); // Ensure student_id_mark is defined in your class or method scope

            if (student == null)
            {
                MessageBox.Show("Student not found.");
                return;
            }

            student.View_grade(dataGridView1, lb_average, lb_status, student_id_mark, semester_id, subject_id);

        }

        private Student GetStudentById(string student_id)
        {
            Student student = null;
            string query = @"
        SELECT p.name, p.telephone, p.email, p.role, p.gender, p.dob, p.image, s.student_id
        FROM Student s
        JOIN Person p ON s.person_id = p.person_id
        WHERE s.student_id = @student_id";

            using (SqlCommand command = new SqlCommand(query, connect))
            {
                command.Parameters.AddWithValue("@student_id", student_id);

               
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        int telephone = Convert.ToInt32(reader["telephone"]);
                        string email = reader["email"].ToString();
                        Role role = (Role)Enum.Parse(typeof(Role), reader["role"].ToString());
                        string gender = reader["gender"].ToString();
                        DateTime dob = Convert.ToDateTime(reader["dob"]);
                        string image = reader["image"].ToString();
                        string student_id_value = reader["student_id"].ToString();
                        


                        student = new Student(name, telephone, email, role, gender, dob, image, student_id_value);
                    }
                }
                connect.Close();
            }

            return student;
        }




    }
}
