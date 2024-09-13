using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace coursework
{
    internal class StudentDataAccess
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            if (connect.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectStudent = @"
                    SELECT s.student_id, p.name, p.email, p.telephone, p.gender, p.DOB, p.image,
                           c.class_name, m.major_name, se.name_semester, se.year, p.role
                    FROM Student s
                    JOIN Person p ON s.person_id = p.person_id
                    JOIN Class c ON s.class_id = c.class_id
                    JOIN Major m ON s.major_id = m.major_id
                    JOIN StudentSemesters ss ON s.student_id = ss.student_id
                    JOIN Semester se ON ss.semester_id = se.semester_id
                    WHERE p.was_add = 1
                    AND se.year = (SELECT TOP 1 year FROM Semester ORDER BY year DESC, name_semester DESC)
                    AND se.name_semester = (SELECT TOP 1 name_semester FROM Semester ORDER BY year DESC, name_semester DESC)";

                    using (SqlCommand cmd = new SqlCommand(selectStudent, connect))
                    {
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
                            Role role = (Role)(reader.GetInt32(reader.GetOrdinal("role")) - 1);  // Adjusting role based on your implementation

                            Student student = new Student(name, telephone, email, role, gender, dob, image, studentId, studentGroup, major, semesterName);
                            students.Add(student);
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
            return students;
        }


        public List<Student> GetStudents_wasnt_added()
        {
            List<Student> students = new List<Student>();

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                string selectStudent_wasnt_add = @"
        SELECT s.student_id, p.name, p.email, p.telephone, p.gender, p.DOB, p.image, p.role
        FROM Student s
        JOIN Person p ON s.person_id = p.person_id
        WHERE p.was_add = 0";

                using (SqlCommand cmd = new SqlCommand(selectStudent_wasnt_add, connect))
                {
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

                        Role role = (Role)(reader.GetInt32(reader.GetOrdinal("role")) - 1);  // Adjusting role based on your implementation

                        Student student = new Student(name, telephone, email, role, gender, dob, image, studentId);
                        students.Add(student);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }

            return students;
        }

        public void DeleteStudent(int person_id)
        {
            /*try
            {*/
                if (connect.State != System.Data.ConnectionState.Open)
                {
                    connect.Open();

                // Get student_id from person_id
                string getStudentIdQuery = "SELECT student_id FROM Student WHERE person_id = @person";
                string student_id;
                using (SqlCommand cmd = new SqlCommand(getStudentIdQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@person", person_id);
                    object result = cmd.ExecuteScalar();
                    student_id = result != null ? result.ToString() : null;
                }

                // Delete from StudentSemesters table first
                string deleteStudentSemestersQuery = "DELETE FROM StudentSemesters WHERE student_id = @student";
                using (SqlCommand cmd = new SqlCommand(deleteStudentSemestersQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@student", student_id);
                    cmd.ExecuteNonQuery();
                }

                // Delete from Student table
                string deleteStudentQuery = "DELETE FROM Person WHERE person_id = @person";
                    using (SqlCommand cmd = new SqlCommand(deleteStudentQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@person", person_id);
                        cmd.ExecuteNonQuery();
                    }

                    
                }
            /*}
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting student: " + ex.Message);
                throw; // Rethrow the exception or handle as necessary
            }
            finally
            {
                connect.Close();
            }*/
        }
        public int GetPersonIdFromStudentId(string student_id)
        {
            int personId = 0;
            string query = "SELECT p.person_id FROM Student s INNER JOIN Person p ON p.person_id = s.person_id WHERE s.student_id = @student_id;";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@student_id", student_id);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        personId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving person ID: " + ex.Message);
                throw; // Rethrow the exception or handle as necessary
            }
            finally
            {
                connect.Close();
            }

            return personId;
        }

    }
}
