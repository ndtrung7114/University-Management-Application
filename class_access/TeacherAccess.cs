using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    internal class TeacherAccess
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            if (connect.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectTeacher = @"
                    SELECT t.teacher_id, p.name, p.email, p.telephone, p.gender, p.DOB, p.image,
                           /*c.class_name,*/ m.major_name, /*, se.name_semester, se.year,*/ p.role
                    FROM Teacher t
                    JOIN Person p ON t.person_id = p.person_id
                    
                    JOIN Major m ON t.major_id = m.major_id
                    /*JOIN TeacherSemester ts ON t.teacher_id = ts.teacher_id
                    JOIN Class c ON ts.class_id = c.class_id
                    JOIN Semester se ON ts.semester_id = se.semester_id*/
                    WHERE p.was_add = 1
                    /*AND se.year = (SELECT TOP 1 year FROM Semester ORDER BY year DESC, name_semester DESC)
                    AND se.name_semester = (SELECT TOP 1 name_semester FROM Semester ORDER BY year DESC, name_semester DESC)*/";

                    using (SqlCommand cmd = new SqlCommand(selectTeacher, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string teacherID = reader.IsDBNull(reader.GetOrdinal("teacher_id")) ? "null" : reader.GetString(reader.GetOrdinal("teacher_id"));
                            string name = reader.IsDBNull(reader.GetOrdinal("name")) ? "null" : reader.GetString(reader.GetOrdinal("name"));
                            string email = reader.IsDBNull(reader.GetOrdinal("email")) ? "null" : reader.GetString(reader.GetOrdinal("email"));
                            int telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? 0 : reader.GetInt32(reader.GetOrdinal("telephone"));
                            string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? "null" : reader.GetInt32(reader.GetOrdinal("gender")) == 1 ? "Male" : "Female";
                            DateTime dob = reader.IsDBNull(reader.GetOrdinal("DOB")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DOB"));
                            string image = reader.IsDBNull(reader.GetOrdinal("image")) ? "null" : reader.GetString(reader.GetOrdinal("image"));
                            /*string studentGroup = reader.IsDBNull(reader.GetOrdinal("class_name")) ? "null" : reader.GetString(reader.GetOrdinal("class_name"));*/
                            string major = reader.IsDBNull(reader.GetOrdinal("major_name")) ? "null" : reader.GetString(reader.GetOrdinal("major_name"));
                            /*string semesterName = reader.IsDBNull(reader.GetOrdinal("name_semester")) ? "null" : reader.GetString(reader.GetOrdinal("name_semester"));
                            int year = reader.IsDBNull(reader.GetOrdinal("year")) ? 0 : reader.GetInt32(reader.GetOrdinal("year"));*/
                            Role role = (Role)(reader.GetInt32(reader.GetOrdinal("role")) - 1);  // Adjusting role based on your implementation

                            Teacher teacher = new Teacher(name, telephone, email, role, gender, dob, image, teacherID, "" , major);
                            teachers.Add(teacher);
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
            return teachers;
        }


        public List<Teacher> GetTeachers_wasnt_added()
        {
            List<Teacher> teachers = new List<Teacher>();

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                string selectTeacher_wasnt_add = @"
        SELECT t.teacher_id, p.name, p.email, p.telephone, p.gender, p.DOB, p.image, p.role
        FROM Teacher t
        JOIN Person p ON t.person_id = p.person_id
        WHERE p.was_add = 0";

                using (SqlCommand cmd = new SqlCommand(selectTeacher_wasnt_add, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string teacher_id = reader.IsDBNull(reader.GetOrdinal("teacher_id")) ? "null" : reader.GetString(reader.GetOrdinal("teacher_id"));
                        string name = reader.IsDBNull(reader.GetOrdinal("name")) ? "null" : reader.GetString(reader.GetOrdinal("name"));
                        string email = reader.IsDBNull(reader.GetOrdinal("email")) ? "null" : reader.GetString(reader.GetOrdinal("email"));
                        int telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? 0 : reader.GetInt32(reader.GetOrdinal("telephone"));
                        string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? "null" : reader.GetInt32(reader.GetOrdinal("gender")) == 1 ? "Male" : "Female";
                        DateTime dob = reader.IsDBNull(reader.GetOrdinal("DOB")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DOB"));
                        string image = reader.IsDBNull(reader.GetOrdinal("image")) ? "null" : reader.GetString(reader.GetOrdinal("image"));

                        Role role = (Role)(reader.GetInt32(reader.GetOrdinal("role")) - 1);  // Adjusting role based on your implementation

                        Teacher teacher = new Teacher(name, telephone, email, role, gender, dob, image, teacher_id);
                        teachers.Add(teacher);
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

            return teachers;
        }

        public void DeleteTeacher(int person_id)
        {
            /*try
            {*/
            if (connect.State != System.Data.ConnectionState.Open)
            {
                connect.Open();

                // Get student_id from person_id
                string getTeacherIdQuery = "SELECT teacher_id FROM Teacher WHERE person_id = @person";
                string teacher_id;
                using (SqlCommand cmd = new SqlCommand(getTeacherIdQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@person", person_id);
                    object result = cmd.ExecuteScalar();
                    teacher_id = result != null ? result.ToString() : null;
                }

                // Delete from StudentSemesters table first
                string deleteStudentSemestersQuery = "DELETE FROM TeacherSemester WHERE teacher_id = @teacher_id";
                using (SqlCommand cmd = new SqlCommand(deleteStudentSemestersQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
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
        public int GetPersonIdFromTeacherId(string teacher_id)
        {
            int personId = 0;
            string query = "SELECT person_id FROM Teacher t  WHERE t.teacher_id = @teacher_id;";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@teacher_id", teacher_id);

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
