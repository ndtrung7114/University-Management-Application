using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework.user_control.teacher
{
    public partial class set_mark : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        private string teacher_id_report;
        private int major_id;
        private int semester_id;
        private int subject_id;
        private int class_id;
        

        public set_mark()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.AllowUserToAddRows = false;
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
                    list_term.Items.Clear();

                    // Read each row from the result set
                    while (reader.Read())
                    {
                        string nameSemester = reader["name_semester"].ToString();
                        string year = reader["year"].ToString();


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
                    list_class.Items.Clear();

                    // Read each subject from the result set
                    while (reader.Read())
                    {
                        string subjectName = reader["subject_name"].ToString();
                        string class_name = reader["class_name"].ToString();
                        list_class.Items.Add($"{class_name} - {subjectName}");
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



        private void list_term_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void Load_student_for_class(int class_id, int subject_id)
        {
            try
            {
                string query = @"
            SELECT p.image, p.name, s.student_id, g.grade_middle, g.grade_final
            FROM Student s
            JOIN Person p ON s.person_id = p.person_id
            LEFT JOIN Grades g ON s.student_id = g.student_id AND g.subject_id = @subject_id
            WHERE s.class_id = @class_id";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@class_id", class_id);
                    command.Parameters.AddWithValue("@subject_id", subject_id);

                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    reader.Close();

                    // Ensure columns are added to DataGridView if not already added
                    if (dataGridView1.Columns.Count == 0)
                    {
                        dataGridView1.Columns.Add("student_id", "Student ID");
                        dataGridView1.Columns.Add("name", "Name");

                        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                        {
                            Name = "image",
                            HeaderText = "Image",
                            Width = 100 // Adjust width as needed
                        };
                        dataGridView1.Columns.Add(imageColumn);

                        dataGridView1.Columns.Add("grade_middle", "Grade Middle");
                        dataGridView1.Columns.Add("grade_final", "Grade Final");

                        // Set row height for better image visibility
                        dataGridView1.RowTemplate.Height = 100; // Adjust height as needed
                    }

                    // Clear existing rows
                    dataGridView1.Rows.Clear();

                    // Populate DataGridView with data
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow newRow = dataGridView1.Rows[rowIndex];

                        newRow.Cells["student_id"].Value = row["student_id"];
                        newRow.Cells["name"].Value = row["name"];
                        newRow.Cells["grade_middle"].Value = row["grade_middle"] != DBNull.Value ? row["grade_middle"] : null;
                        newRow.Cells["grade_final"].Value = row["grade_final"] != DBNull.Value ? row["grade_final"] : null;

                        // Load and display the image
                        if (row["image"] != DBNull.Value)
                        {
                            // Assuming image path or URL is stored in the database
                            string imagePath = row["image"].ToString();
                            if (File.Exists(imagePath)) // Check if file exists
                            {
                                using (Image img = Image.FromFile(imagePath))
                                {
                                    newRow.Cells["image"].Value = ResizeImage(img, 100, 100); // Resize as needed
                                }
                            }
                            else
                            {
                                // Handle case where image file is not found
                                newRow.Cells["image"].Value = null; // Or set a placeholder image
                            }
                        }
                        else
                        {
                            newRow.Cells["image"].Value = null; // Or set a placeholder image
                        }
                    }
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






        private void list_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the report_slot DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            // Ensure there is a selected item
            if (list_class.SelectedIndex != -1)
            {


                // Extract the class information from the selected item
                string selectedItem = list_class.SelectedItem.ToString();
                // Assuming the format is "Class name - Subject name"
                string[] parts = selectedItem.Split(new string[] { " - " }, StringSplitOptions.None);

                if (parts.Length >= 1)
                {
                    string class_name = parts[0];
                    string subject_name = parts[1];

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

                            if (connect.State == ConnectionState.Closed) { connect.Open(); }
                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                class_id = Convert.ToInt32(result);

                                Load_student_for_class(class_id, subject_id);


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

        private void btn_grade_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new Teacher object
                Teacher teacher = GetTeacherById(teacher_id_report);

                // Iterate through all rows in the DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Retrieve student information from the row
                    string student_id = row.Cells["student_id"].Value?.ToString();
                    double? grade_middle = null;
                    double? grade_final = null;

                    if (row.Cells["grade_middle"].Value != null && row.Cells["grade_middle"].Value != DBNull.Value)
                        grade_middle = Convert.ToDouble(row.Cells["grade_middle"].Value);

                    if (row.Cells["grade_final"].Value != null && row.Cells["grade_final"].Value != DBNull.Value)
                        grade_final = Convert.ToDouble(row.Cells["grade_final"].Value);

                    // Check if either grade_middle or grade_final has a value
                    if (student_id != null && (grade_middle.HasValue || grade_final.HasValue))
                    {
                        // Call the Mark function with non-null values, default to 0 if null
                        teacher.Mark(student_id, subject_id, semester_id, grade_middle, grade_final);
                    }
                }

                MessageBox.Show("Grades successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating grades: {ex.Message}");
            }
        }


        // Method to create a Teacher object by teacher_id
        private Teacher GetTeacherById(string teacher_id)
        {
            Teacher teacher = null;
            string query = @"
        SELECT p.name, p.telephone, p.email, p.role, p.gender, p.dob, p.image, t.teacher_id, t.salary, t.major_id
        FROM Teacher t
        JOIN Person p ON t.person_id = p.person_id
        WHERE t.teacher_id = @teacher_id";

            using (SqlCommand command = new SqlCommand(query, connect))
            {
                command.Parameters.AddWithValue("@teacher_id", teacher_id);

                connect.Open();
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
                        string teacher_id_value = reader["teacher_id"].ToString();
                        string studentGroup = null; // Adjust if needed
                        string major = reader["major_id"].ToString();
                        

                        teacher = new Teacher(name, telephone, email, role, gender, dob, image, teacher_id_value, studentGroup, major);
                    }
                }
                connect.Close();
            }

            return teacher;
        }
    }
}
