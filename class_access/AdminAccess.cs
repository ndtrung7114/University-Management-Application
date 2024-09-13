using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    internal class AdminAccess
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);

        public List<Admin> GetAdmins()
        {
            List<Admin> admins = new List<Admin>();

            if (connect.State != System.Data.ConnectionState.Open)
            {
                /*try
                {*/
                    connect.Open();
                    string select_admin = @"
                    SELECT a.admin_id, p.name, p.email, p.telephone, p.gender, p.DOB, p.image,
                            a.type_job, p.role
                    FROM Admin a
                    JOIN Person p ON a.person_id = p.person_id
                    
                  
                    WHERE p.was_add = 1
                   ";

                    using (SqlCommand cmd = new SqlCommand(select_admin, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string admin_id = reader.IsDBNull(reader.GetOrdinal("admin_id")) ? "null" : reader.GetString(reader.GetOrdinal("admin_id"));
                            string name = reader.IsDBNull(reader.GetOrdinal("name")) ? "null" : reader.GetString(reader.GetOrdinal("name"));
                            string email = reader.IsDBNull(reader.GetOrdinal("email")) ? "null" : reader.GetString(reader.GetOrdinal("email"));
                            int telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? 0 : reader.GetInt32(reader.GetOrdinal("telephone"));
                            string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? "null" : reader.GetInt32(reader.GetOrdinal("gender")) == 1 ? "Male" : "Female";
                            DateTime dob = reader.IsDBNull(reader.GetOrdinal("DOB")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DOB"));
                            string image = reader.IsDBNull(reader.GetOrdinal("image")) ? "null" : reader.GetString(reader.GetOrdinal("image"));
                            /*string studentGroup = reader.IsDBNull(reader.GetOrdinal("class_name")) ? "null" : reader.GetString(reader.GetOrdinal("class_name"));*/
                            Type_job job_type = reader.IsDBNull(reader.GetOrdinal("type_job")) ? Type_job.Fulltime : (Type_job)reader.GetInt32(reader.GetOrdinal("type_job"));
                            /*string semesterName = reader.IsDBNull(reader.GetOrdinal("name_semester")) ? "null" : reader.GetString(reader.GetOrdinal("name_semester"));
                            int year = reader.IsDBNull(reader.GetOrdinal("year")) ? 0 : reader.GetInt32(reader.GetOrdinal("year"));*/
                            Role role = (Role)(reader.GetInt32(reader.GetOrdinal("role")) - 1);  // Adjusting role based on your implementation

                            Admin admin = new Admin(name, telephone, email, role, gender, dob, image, admin_id, job_type);
                            admins.Add(admin);
                        }
                    }
                /*}
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
                finally
                {
                    connect.Close();
                }*/
            }
            return admins;
        }


        public List<Admin> GetAdmins_wasnt_added()
        {
            List<Admin> admins = new List<Admin>();

            /*try
            {*/
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                string select_admin_wasnt_add = @"
        SELECT a.admin_id, p.name, p.email, p.telephone, p.gender, p.DOB, p.image, p.role
        FROM Admin a
        JOIN Person p ON t.person_id = p.person_id
        WHERE p.was_add = 0";

                using (SqlCommand cmd = new SqlCommand(select_admin_wasnt_add, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string admin_id = reader.IsDBNull(reader.GetOrdinal("admin_id")) ? "null" : reader.GetString(reader.GetOrdinal("admin_id"));
                        string name = reader.IsDBNull(reader.GetOrdinal("name")) ? "null" : reader.GetString(reader.GetOrdinal("name"));
                        string email = reader.IsDBNull(reader.GetOrdinal("email")) ? "null" : reader.GetString(reader.GetOrdinal("email"));
                        int telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? 0 : reader.GetInt32(reader.GetOrdinal("telephone"));
                        string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? "null" : reader.GetInt32(reader.GetOrdinal("gender")) == 1 ? "Male" : "Female";
                        DateTime dob = reader.IsDBNull(reader.GetOrdinal("DOB")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DOB"));
                        string image = reader.IsDBNull(reader.GetOrdinal("image")) ? "null" : reader.GetString(reader.GetOrdinal("image"));
                        /*string studentGroup = reader.IsDBNull(reader.GetOrdinal("class_name")) ? "null" : reader.GetString(reader.GetOrdinal("class_name"));*/
                        Type_job job_type = reader.IsDBNull(reader.GetOrdinal("type_job")) ? Type_job.Fulltime : (Type_job)reader.GetInt32(reader.GetOrdinal("type_job"));
                        /*string semesterName = reader.IsDBNull(reader.GetOrdinal("name_semester")) ? "null" : reader.GetString(reader.GetOrdinal("name_semester"));
                        int year = reader.IsDBNull(reader.GetOrdinal("year")) ? 0 : reader.GetInt32(reader.GetOrdinal("year"));*/
                        Role role = (Role)(reader.GetInt32(reader.GetOrdinal("role")) - 1);  // Adjusting role based on your implementation

                        Admin admin = new Admin(name, telephone, email, role, gender, dob, image, admin_id);
                        admins.Add(admin);
                    }
                }
            /*}
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
            }*/

            return admins;
        }
        public void DeleteAdmin(int person_id)
        {
            /*try
            {*/
            if (connect.State != System.Data.ConnectionState.Open)
            {
                connect.Open();

                // Get student_id from person_id
                string getAdminIdQuery = "SELECT admin_id FROM Admin WHERE person_id = @person";
                string admin_id;
                using (SqlCommand cmd = new SqlCommand(getAdminIdQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@person", person_id);
                    object result = cmd.ExecuteScalar();
                    admin_id = result != null ? result.ToString() : null;
                }

                

                // Delete from Student table
                string deletePersonQuery = "DELETE FROM Person WHERE person_id = @person";
                using (SqlCommand cmd = new SqlCommand(deletePersonQuery, connect))
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
        public int GetPersonIdFromAdminId(string admin_id)
        {
            int personId = 0;
            string query = "SELECT person_id FROM Admin a  WHERE a.admin_id = @admin_id;";

            try
            {
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@teacher_id", admin_id);

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
