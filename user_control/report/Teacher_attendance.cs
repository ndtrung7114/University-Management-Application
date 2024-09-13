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

namespace coursework.user_control.report
{
    public partial class Teacher_attendance : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        private string teacher_id_report;
        private int major_id;
        private int semester_id;
        private int subject_id;
        private int class_id;
        private int slot_number;
        public Teacher_attendance()
        {
            InitializeComponent();
            report_slot.AllowUserToAddRows = false;
            report_slot.RowTemplate.Height = 50;
        }

        public void load_infor_term(string teacher_id)
        {
            try
            {
                this.teacher_id_report = teacher_id;

                // Define your SQL query to retrieve semester information
                string query = @"
                    SELECT distinct se.name_semester, se.year, se.semester_id, t.major_id
                    FROM TeacherSemester ts
                    JOIN Teacher t ON ts.teacher_id = t.teacher_id
                    JOIN Semester se ON ts.semester_id = se.semester_id
                    WHERE ts.teacher_id = @teacher_id
                    ORDER BY year ASC, name_semester ASC";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@teacher_id", teacher_id);

                    // Open the connection
                    connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear existing items
                    list_term_box.Items.Clear();

                    // Read each row from the result set
                    while (reader.Read())
                    {
                        string nameSemester = reader["name_semester"].ToString();
                        string year = reader["year"].ToString();
                        
                        
                        major_id = Convert.ToInt32(reader["major_id"]);

                        // Append the formatted information to ListBox
                        list_term_box.Items.Add($"{nameSemester} {year}");
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
                    SELECT c.class_name, sub.subject_name
                    FROM TeacherSemester ts
                    JOIN Class c ON ts.class_id = c.class_id
                    JOIN Subject sub on ts.subject_id = sub.subject_id
               
                    WHERE ts.semester_id = @semester_id AND ts.teacher_id = @teacher_id";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@semester_id", semester_id);
                
                    command.Parameters.AddWithValue("@teacher_id", teacher_id_report);

                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear existing items
                    list_class_box.Items.Clear();

                    // Read each subject from the result set
                    while (reader.Read())
                    {
                        string subjectName = reader["subject_name"].ToString();
                        string class_name = reader["class_name"].ToString();
                        list_class_box.Items.Add($"{class_name} - {subjectName}");
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


        private void list_term_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure there is a selected item
            if (list_term_box.SelectedIndex != -1)
            {
                // Extract semester information from the selected item
                string selectedTerm = list_term_box.SelectedItem.ToString();
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
        private Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void Load_slot_for_class(int subject_id, int semester_id)
        {
            try
            {
                string query = @"select distinct slot_number, attendance_date
                                from Attendance
                                
                                where subject_id = @subject_id and semester_id = @semester_id";
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@subject_id", subject_id);
                    command.Parameters.AddWithValue("@semester_id", semester_id);
                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();
                    // Clear existing items
                    list_slot.Items.Clear();

                    // Read each subject from the result set
                    while (reader.Read())
                    {
                        string slot_name = reader["slot_number"].ToString();
                        DateTime date = (DateTime)reader["attendance_date"]; // Retrieve as DateTime
                        string formattedDate = date.ToString("yyyy-MM-dd"); // Format the date

                        list_slot.Items.Add($"Slot - {slot_name} - ({formattedDate})");
                    }

                    // Close the reader
                    reader.Close();






                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving student for class information: {ex.Message}");
            }
            finally
            {
                connect.Close();
            }
        }



        private void list_class_box_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Clear the report_slot DataGridView
            report_slot.DataSource = null;
            report_slot.Rows.Clear();
            // Ensure there is a selected item
            if (list_class_box.SelectedIndex != -1)
            {
                
                
                // Extract the class information from the selected item
                string selectedItem = list_class_box.SelectedItem.ToString();
                // Assuming the format is "Class name - Subject name"
                string[] parts = selectedItem.Split(new string[] { " - " }, StringSplitOptions.None);

                if (parts.Length >= 1)
                {
                    string class_name = parts[0];
                    string subject_name = parts[1];

                    // Retrieve class_id from database based on class_name
                    try
                    {
                        string query = @"
                    SELECT subject_id
                    FROM Subject
                    WHERE subject_name = @subject_name";


                        using (SqlCommand command = new SqlCommand(query, connect))
                        {
                            command.Parameters.AddWithValue("@subject_name", subject_name);

                            connect.Open();
                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                 subject_id = Convert.ToInt32(result);
                                

                                // Load students for the selected class
                                Load_slot_for_class(subject_id, semester_id);
                            }
                            else
                            {
                                MessageBox.Show("Class ID not found.");
                            }
                        }
                        string query_class = @"
                    SELECT class_id
                    FROM Class
                    WHERE class_name = @class_name";

                        using (SqlCommand command = new SqlCommand(query_class, connect))
                        {
                            command.Parameters.AddWithValue("@class_name", class_name);

                            connect.Open();
                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                 class_id = Convert.ToInt32(result);

                                
                            }
                            else
                            {
                                MessageBox.Show("Class ID not found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving class information: {ex.Message}");
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid class format.");
                }
            }
        }

        private void Load_student_for_slot(int class_id)
        {
            try
            {
                string query = @"select p.image, p.name, s.student_id
                                from Student s
                                Join Person p on s.person_id = p.person_id
                                where s.class_id = @class_id";
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@class_id", class_id);

                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    reader.Close();

                    // Add an additional column for images and status
                    dataTable.Columns.Add("ImageColumn", typeof(Image));
                    dataTable.Columns.Add("Status", typeof(bool)); // Changed to bool

                    // Convert image data to Image object
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Assuming image path is stored in the database
                        string imagePath = row["image"].ToString();
                        if (!string.IsNullOrEmpty(imagePath))
                        {
                            row["ImageColumn"] = ResizeImage(Image.FromFile(imagePath), 50, 50);

                        }


                        // Initialize the checkbox column to false
                        row["Status"] = false;
                        // Check the Attendance table for each student
                        string attendanceQuery = @"SELECT status 
                                           FROM Attendance 
                                           WHERE student_id = @student_id 
                                           AND subject_id = @subject_id 
                                           AND semester_id = @semester_id 
                                           AND slot_number = @slot_number";

                        using (SqlCommand attendanceCommand = new SqlCommand(attendanceQuery, connect))
                        {
                            attendanceCommand.Parameters.AddWithValue("@student_id", row["student_id"]);
                            attendanceCommand.Parameters.AddWithValue("@subject_id", subject_id);
                            attendanceCommand.Parameters.AddWithValue("@semester_id", semester_id);
                            attendanceCommand.Parameters.AddWithValue("@slot_number", slot_number);

                            object statusResult = attendanceCommand.ExecuteScalar();
                            if (statusResult != null && Convert.ToInt32(statusResult) == 1)
                            {
                                row["Status"] = true;
                            }
                        }
                    }

                    report_slot.DataSource = dataTable;

                    // Hide original image column
                    report_slot.Columns["image"].Visible = false;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving student for class information: {ex.Message}");
            }
            finally
            {
                connect.Close();
            }
        }



        

        private void list_slot_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure there is a selected item
            if (list_slot.SelectedIndex != -1)
            {
                string selected_slot = list_slot.SelectedItem.ToString();
                // Assuming the format is "Class name - Subject name"
                string[] parts = selected_slot.Split(new string[] { " - " }, StringSplitOptions.None);
                slot_number = Convert.ToInt32(parts[1]);


                // Retrieve class_id from database based on class_name
                try
                    {

                    Load_student_for_slot(class_id);
                            
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving class information: {ex.Message}");
                    }
                    finally
                    {
                        connect.Close();
                    }
                
            }
        }

        private void btn_sumbit_Click(object sender, EventArgs e)
        {
            // List to store selected users
            List<string> selectedUsers = new List<string>();

            // Iterate through the rows of the report_slot DataGridView
            foreach (DataGridViewRow row in report_slot.Rows)
            {
                // Determine the status value
                int status = Convert.ToBoolean(row.Cells["Status"].Value) ? 1 : 0;

                // Assuming you want to collect student_id
                string studentId = row.Cells["student_id"].Value.ToString();

                // Fetch teacher details from the database
                string teacherQuery = @"
        SELECT t.teacher_id, t.salary, t.major_id, 
               p.name, p.telephone, p.email, p.role, p.gender, p.DOB, p.image 
        FROM Teacher t
        JOIN Person p ON t.person_id = p.person_id
        WHERE t.teacher_id = @teacher_id";

                Teacher teacher = null;

                using (SqlCommand cmd = new SqlCommand(teacherQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@teacher_id", teacher_id_report);

                    connect.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Extract person details
                            string name = reader["name"].ToString();
                            int telephone = Convert.ToInt32(reader["telephone"]);
                            string email = reader["email"].ToString();
                            Role role = (Role)Enum.Parse(typeof(Role), reader["role"].ToString());
                            string gender = reader["gender"].ToString();
                            DateTime dob = Convert.ToDateTime(reader["DOB"]);
                            string image = reader["image"].ToString();

                            // Extract teacher details
                            string teacher_id = reader["teacher_id"].ToString();
                            string major = reader["major_id"].ToString();

                            // Create the Teacher object
                            teacher = new Teacher(name, telephone, email, role, gender, dob, image, teacher_id, major: major);
                        }
                    }
                    connect.Close();
                }

                // Take attendance if teacher object was successfully created
                if (teacher != null)
                {
                    teacher.take_attendance(studentId, subject_id, slot_number, semester_id, status);
                }
            }

            MessageBox.Show($"Submit Successfully");
        }


    }
}
