using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    internal class Teacher : Person
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        // Private fields
        
        private string teacher_id;
        private float salary;
        private string student_group;
        private string major;
        private List<string> currentSubjects;
       
        private string semester;

        // Public properties with getters and setters
        public List<string> CurrentSubjects
        {
            get { return currentSubjects; }
            set { currentSubjects = value; }
        }



        public string Teacher_id
        {
            get { return teacher_id; }
            set { teacher_id = value; }
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
        public Teacher(string name, int telephone, string email, Role role, string gender, DateTime dob, string image, string teacher_id, string studentGroup = null, string major = null, string semester = null)
            : base(name, telephone, email, role, gender, dob, image)
        {

            Teacher_id = teacher_id;
            student_group = studentGroup;
            Semester = semester;
            Major = major;
        }

        public List<string> GetCurrentSubjects()
        {
            List<string> subjects = new List<string>();
            string select_subject = @"SELECT  sub.subject_name,
                                           c.class_name, m.major_name, se.name_semester, se.year
                                           FROM Teacher t 
                                           
                                            
                                           JOIN Major m ON t.major_id = m.major_id 
                                           JOIN TeacherSemester ts ON t.teacher_id = ts.teacher_id 
                                           JOIN Class c ON ts.class_id = c.class_id
                                           JOIN Semester se ON ts.semester_id = se.semester_id 
                                           JOIN Subject sub ON ts.subject_id = sub.subject_id
                                          
                                           
                                           WHERE t.teacher_id = @teacher_id 
                                           and se.year = (SELECT TOP 1 year FROM Semester ORDER BY year DESC, name_semester DESC) 
                                           AND se.name_semester = (SELECT TOP 1 name_semester FROM Semester ORDER BY year DESC, name_semester DESC)";

            using (SqlCommand cmd = new SqlCommand(select_subject, connect))
            {
                cmd.Parameters.AddWithValue("@teacher_id", this.teacher_id);
               


                connect.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string subjectName = reader["subject_name"].ToString();
                        string className = reader["class_name"].ToString();
                        string nameSemester = reader["name_semester"].ToString();
                        string year = reader["year"].ToString();

                        string subjectInfo = $"Class: {className} - Subject: {subjectName} - Semester: {nameSemester} - Year: {year}";
                        subjects.Add(subjectInfo);

                    }
                }
                connect.Close();
            }

            return subjects;
        }

        public void take_attendance(string student_id, int subject_id, int slot_number, int semester_id, int status)
        {
            string query = @"
            UPDATE Attendance 
            SET status = @status 
            WHERE student_id = @student_id 
              AND subject_id = @subject_id 
              AND slot_number = @slot_number 
              AND semester_id = @semester_id";

            using (SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@student_id", student_id);
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.Parameters.AddWithValue("@slot_number", slot_number);
                cmd.Parameters.AddWithValue("@semester_id", semester_id);

                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }


        public void Mark(string student_id, int subject_id, int semester_id, double? grade_middle, double? grade_final)
        {
            string query = @"
        MERGE Grades AS target
        USING (VALUES (@student_id, @subject_id, @semester_id)) AS source (student_id, subject_id, semester_id)
        ON target.student_id = source.student_id 
           AND target.subject_id = source.subject_id 
           AND target.semester_id = source.semester_id
        WHEN MATCHED THEN 
            UPDATE SET grade_middle = COALESCE(@grade_middle, grade_middle),
                       grade_final = COALESCE(@grade_final, grade_final)
        WHEN NOT MATCHED THEN
        INSERT (student_id, subject_id, semester_id, grade_middle, grade_final)
        VALUES (source.student_id, source.subject_id, source.semester_id, @grade_middle, @grade_final);";

            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }

            using (SqlCommand command = new SqlCommand(query, connect))
            {
                // Add parameters
                command.Parameters.Add("@student_id", SqlDbType.VarChar).Value = student_id;
                command.Parameters.Add("@subject_id", SqlDbType.Int).Value = subject_id;
                command.Parameters.Add("@semester_id", SqlDbType.Int).Value = semester_id;

                if (grade_middle.HasValue)
                    command.Parameters.Add("@grade_middle", SqlDbType.Float).Value = grade_middle.Value;
                else
                    command.Parameters.Add("@grade_middle", SqlDbType.Float).Value = DBNull.Value;

                if (grade_final.HasValue)
                    command.Parameters.Add("@grade_final", SqlDbType.Float).Value = grade_final.Value;
                else
                    command.Parameters.Add("@grade_final", SqlDbType.Float).Value = DBNull.Value;

                // Execute the command
                command.ExecuteNonQuery();
            }
        }




    }
}
