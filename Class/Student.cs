using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace coursework
{
    internal class Student : Person
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        // Private fields
        private List<string> _currentSubjects;
        private List<string> _previousSubjects;
        private string _student_id;
        private string student_group;
        private string major;
        private string semester;

        // Public properties with getters and setters
        public List<string> CurrentSubjects
        {
            get { return _currentSubjects; }
            set { _currentSubjects = value; }
        }

        public List<string> PreviousSubjects
        {
            get { return _previousSubjects; }
            set { _previousSubjects = value; }
        }

        public string CurrentSubjectsDisplay => string.Join(", ", CurrentSubjects);
        public string PreviousSubjectsDisplay => string.Join(", ", PreviousSubjects);

        public string Student_id
        {
            get { return _student_id; }
            set { _student_id = value; }
        }

        public string StudentGroup
        {
            get { return student_group; }
            set { student_group = value; }
        }

        public string Semester
        {
            get { return semester; }
            set { semester = value; }
        }
        public string Major
        {
            get => major; set { major = value; }
        }

        // Constructor to initialize properties
        public Student(string name, int telephone, string email, Role role, string gender, DateTime dob, string image, string student_id, string studentGroup=null, string major = null, string semester = null)
            : base(name, telephone, email, role, gender, dob, image)
        {
           
            Student_id = student_id;
            student_group = studentGroup;
            Semester = semester;
            Major = major;
        }

        // Method to fetch current subjects for a student
        public List<string> GetCurrentSubjects(int year)
        {
            List<string> subjects = new List<string>();

            string selectSubjects = @"
                SELECT sub.subject_name
                FROM Student s
                JOIN StudentSemesters ss ON s.student_id = ss.student_id
                JOIN Semester se ON ss.semester_id = se.semester_id
               
                JOIN SemesterSubjects sesub ON ss.number_semester_id = sesub.number_semester_id
                JOIN Subject sub ON sesub.subject_id = sub.subject_id
                JOIN Major ma on sub.major_id = ma.major_id
                where s.student_id = @studentId and ma.major_name = @major_name
                and se.year = (SELECT TOP 1 year FROM Semester ORDER BY year DESC, name_semester DESC) " +
                                               "AND se.name_semester = (SELECT TOP 1 name_semester FROM Semester ORDER BY year DESC, name_semester DESC)";

            using (SqlCommand cmd = new SqlCommand(selectSubjects, connect))
            {
                cmd.Parameters.AddWithValue("@studentId", this.Student_id);
                cmd.Parameters.AddWithValue("@major_name", this.Major);
                

                connect.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(reader.GetString(reader.GetOrdinal("subject_name")));
                    }
                }
                connect.Close();
            }

            return subjects;
        }

        public Tuple<List<string>, int, string> GetPreviousSubjects()
        {
            List<string> subjects = new List<string>();
            int year = 0;
            string name_semester = "";

            string selectSubjects = @"
            SELECT sub.subject_name, se.year, se.name_semester
                FROM Student s
                JOIN StudentSemesters ss ON s.student_id = ss.student_id
                JOIN Semester se ON ss.semester_id = se.semester_id
               
                JOIN SemesterSubjects sesub ON ss.number_semester_id = sesub.number_semester_id
                JOIN Subject sub ON sesub.subject_id = sub.subject_id
                JOIN Major ma on sub.major_id = ma.major_id
            where s.student_id = @studentId and ma.major_name = @major_name
            AND se.year = (SELECT year FROM Semester ORDER BY year DESC, name_semester DESC OFFSET 1 ROW FETCH NEXT 1 ROW ONLY)
            AND se.name_semester = (SELECT name_semester FROM Semester ORDER BY year DESC, name_semester DESC OFFSET 1 ROW FETCH NEXT 1 ROW ONLY)
";

            using (SqlCommand cmd = new SqlCommand(selectSubjects, connect))
            {
                cmd.Parameters.AddWithValue("@studentId", this.Student_id);
                cmd.Parameters.AddWithValue("@major_name", this.Major);


                connect.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(reader.GetString(reader.GetOrdinal("subject_name")));
                        year = reader.IsDBNull(reader.GetOrdinal("year")) ? 0 : reader.GetInt32(reader.GetOrdinal("year"));
                        name_semester = reader.IsDBNull(reader.GetOrdinal("name_semester")) ? "null" : reader.GetString(reader.GetOrdinal("name_semester"));
                    }
                }
                connect.Close();
            }

            return Tuple.Create(subjects, year, name_semester);
        }

        public void Increment_Semester_Number()
        {

        }

        public void View_grade(DataGridView dataGridView1, Label lb_average, Label lb_status, string student_id, int semester_id, int subject_id)
        {
            try
            {
                string query = @"SELECT grade_middle, grade_final 
                                 FROM Grades 
                                 WHERE student_id = @student_id AND subject_id = @subject_id and semester_id = @semester_id";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@student_id", student_id);
                    command.Parameters.AddWithValue("@subject_id", subject_id);
                    command.Parameters.AddWithValue("@semester_id", semester_id);

                    connect.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    reader.Close();

                    dataGridView1.Rows.Clear();

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];

                        dataGridView1.Rows.Add("Middle", 50, row["grade_middle"], "");
                        dataGridView1.Rows.Add("Final", 50, row["grade_final"], "");

                        double? grade_middle = row["grade_middle"] != DBNull.Value ? (double?)Convert.ToDouble(row["grade_middle"]) : null;
                        double? grade_final = row["grade_final"] != DBNull.Value ? (double?)Convert.ToDouble(row["grade_final"]) : null;

                        UpdateAverageAndStatus(lb_average, lb_status, grade_middle, grade_final);
                    }
                    else
                    {
                        dataGridView1.Rows.Add("Middle", 50, null, "");
                        dataGridView1.Rows.Add("Final", 50, null, "");

                        UpdateAverageAndStatus(lb_average, lb_status, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading grades: {ex.Message}");
            }
            finally
            {
                connect.Close();
            }
        }

        private void UpdateAverageAndStatus(Label lb_average, Label lb_status, double? grade_middle, double? grade_final)
        {
            if (grade_middle.HasValue && grade_final.HasValue)
            {
                double average = (grade_middle.Value + grade_final.Value) / 2.0;
                lb_average.Text = average.ToString("0.0");

                if (average >= 4.0)
                {
                    lb_status.Text = "Passed";
                    lb_status.ForeColor = Color.Green;
                }
                else
                {
                    lb_status.Text = "Not Pass";
                    lb_status.ForeColor = Color.Red;
                }
            }
            else
            {
                lb_average.Text = "NOT YET";
                lb_status.Text = "NOT YET";
                lb_status.ForeColor = Color.Red;
            }
        }

    }
}
