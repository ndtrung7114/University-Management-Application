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

namespace coursework.user_control.admin
{
    public partial class admin_tracking_attendance : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
       
        private int major_id;
        private int semester_id;
        private int subject_id;
        private int class_id;
        private int number_slot;
        public admin_tracking_attendance()
        {
            InitializeComponent();
            load_infor_term();  
        }

        public void load_infor_term()
        {
            try
            {
                

                // Define your SQL query to retrieve semester information
                string query = @"
                    select distinct semester_id, name_semester, year 
                    from Semester
                    ORDER BY year ASC, name_semester ASC";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    

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

        private void LoadClassForSelectedSemester(int semester_id)
        {
            try
            {

                // Define your SQL query to retrieve subjects for the selected semester
                string query = @"
                    select distinct c.class_name 
                    from Student t
                    inner join Class c
                    on t.class_id = c.class_id
                    inner join StudentSemesters ss 
                    on t.student_id = ss.student_id
               
                    WHERE ss.semester_id = @semester_id";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@semester_id", semester_id);

                   

                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear existing items
                    list_class.Items.Clear();

                    // Read each subject from the result set
                    while (reader.Read())
                    {
                        
                        string class_name = reader["class_name"].ToString();
                        list_class.Items.Add($"{class_name}");
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
                        LoadClassForSelectedSemester(semester_id);
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

        private void Load_subject_for_class(int major_id, int semester_id)
        {
            try
            {

                // Define your SQL query to retrieve subjects for the selected semester
                string query = @"
                    select distinct sub.subject_name
                    from Student t
                    inner join Class c
                    on t.class_id = c.class_id
                    inner join StudentSemesters ss 
                    on t.student_id = ss.student_id
                    inner join SemesterSubjects sesub on ss.number_semester_id = sesub.number_semester_id
                    inner join Subject sub on sesub.subject_id = sub.subject_id
                    where ss.semester_id = @semester_id and sub.major_id = @major_id";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@semester_id", semester_id);
                    command.Parameters.AddWithValue("@major_id", major_id);



                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear existing items
                    list_sub.Items.Clear();

                    // Read each subject from the result set
                    while (reader.Read())
                    {

                        string subject_name = reader["subject_name"].ToString();
                        list_sub.Items.Add($"{subject_name}");
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

        private void list_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure there is a selected item
            if (list_class.SelectedIndex != -1)
            {
                // Extract semester information from the selected item
                string selectedclass = list_class.SelectedItem.ToString();
                
                
              

                // Retrieve semester_id from database based on nameSemester and year
                /*try
                {*/
                string query = @"
                        SELECT class_id
                        FROM Class
                        WHERE class_name = @class_name";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@class_name", selectedclass);


                    if (connect.State != ConnectionState.Open) { connect.Open(); }
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        class_id = Convert.ToInt32(result);

                        
                    }
                }

                string query_major = @"
                        select distinct t.major_id 
                        from Student t
                        inner join Class c
                        on t.class_id = c.class_id
                        inner join StudentSemesters ss 
                        on t.student_id = ss.student_id
                        where c.class_id = @class_id and ss.semester_id = @semester_id";

                using (SqlCommand command = new SqlCommand(query_major, connect))
                {
                    command.Parameters.AddWithValue("@class_id", class_id);
                    command.Parameters.AddWithValue("@semester_id", semester_id);


                    if(connect.State != ConnectionState.Open) { connect.Open(); }
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        major_id = Convert.ToInt32(result);
                        Load_subject_for_class(major_id, semester_id);


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

        private void Tracking_attendance_for_subject(int class_id, int semester_id, int subject_id)
        {
            try
            {
                // Define your SQL query to retrieve subjects for the selected semester
                string query = @"
            SELECT 
                t.student_id, 
                p.name, 
                SUM(CASE WHEN a.status = 0 THEN 1 ELSE 0 END) AS Status_Absent,
                SUM(CASE WHEN a.status = 1 THEN 1 ELSE 0 END) AS Status_Present
            FROM 
                Student t
            INNER JOIN 
                Person p ON t.person_id = p.person_id
            INNER JOIN 
                Class c ON t.class_id = c.class_id
            INNER JOIN 
                Attendance a ON t.student_id = a.student_id
            WHERE 
                c.class_id = @class_id AND 
                a.semester_id = @semester_id AND 
                a.subject_id = @subject_id
            GROUP BY 
                t.student_id, 
                p.name;
            ";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@semester_id", semester_id);
                    command.Parameters.AddWithValue("@class_id", class_id);
                    command.Parameters.AddWithValue("@subject_id", subject_id);

                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();

                    // Adding total column and percentage column
                    dt.Columns.Add("Total", typeof(int));
                    dt.Columns.Add("Absent_Percentage", typeof(string)); // Change type to string
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Total"] = number_slot;

                        int statusAbsent = row["Status_Absent"] != DBNull.Value ? Convert.ToInt32(row["Status_Absent"]) : 0;
                        decimal absentPercentage = number_slot > 0 ? (decimal)statusAbsent / number_slot * 100 : 0;
                        row["Absent_Percentage"] = absentPercentage.ToString("0.##") + "%"; // Format as percentage string
                    }

                    dataGridView1.DataSource = dt;

                    // Apply conditional formatting to the Absent_Percentage column
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string absentPercentageStr = row.Cells["Absent_Percentage"].Value?.ToString().TrimEnd('%') ?? "0";
                        if (decimal.TryParse(absentPercentageStr, out decimal absentPercentage))
                        {
                            if (absentPercentage > 15)
                            {
                                row.Cells["Absent_Percentage"].Style.ForeColor = Color.Red;
                            }
                            else
                            {
                                row.Cells["Absent_Percentage"].Style.ForeColor = Color.Green;
                            }
                        }
                        else
                        {
                            row.Cells["Absent_Percentage"].Style.ForeColor = Color.Black; // Default color if parsing fails
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error tracking attendance for subject: {ex.Message}");
            }
            finally
            {
                // Close the connection
                connect.Close();
            }
        }




        private void list_sub_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure there is a selected item
            if (list_sub.SelectedIndex != -1)
            {
                // Extract semester information from the selected item
                string selected_subject = list_sub.SelectedItem.ToString();




                // Retrieve semester_id from database based on nameSemester and year
                /*try
                {*/
                string query = @"
                        SELECT subject_id, number_slot
                        FROM Subject
                        WHERE subject_name = @subject_name";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@subject_name", selected_subject);


                    if (connect.State != ConnectionState.Open) { connect.Open(); }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            subject_id = reader.GetInt32(0); // subject_id is in the first column
                            number_slot = reader.GetInt32(1); // number_slot is in the second column
                        }
                    }
                }
                Tracking_attendance_for_subject(class_id, semester_id, subject_id);


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
    }
}
