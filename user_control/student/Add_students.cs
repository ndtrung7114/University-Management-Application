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

namespace coursework.form_usercontrol
{
    public partial class Add_students : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        public string user_id;
        public Role role;
        private int person_id;
        private string student_id;
        private int semester_id;
        private int class_id;
        private int major_id;
        private string image_path;

        public Add_students()
        {
            InitializeComponent();
            PopulateComboBox();
            panel2.Visible = false;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        public void DisplayAllStudents(string user_id, Role role)
        {
            try
            {
                this.user_id = user_id;
                this.role = role;
                StudentDataAccess dataAccess = new StudentDataAccess();
                List<Student> students = dataAccess.GetStudents_wasnt_added();
                textBox1.Text = students.Count.ToString();

                if (students != null && students.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = students;
                    dataGridView1.Columns.Clear();

                    AddOrUpdateColumn("Student_id", "Student ID");
                    AddOrUpdateColumn("Name", "Name");
                    AddOrUpdateColumn("Email", "Email");
                    AddOrUpdateColumn("Telephone", "Telephone");
                    AddOrUpdateColumn("DOB", "Birth");
                    AddOrUpdateColumn("Gender", "Gender");
                    AddOrUpdateColumn("Image", "Image");

                    
                    

                    AddActionColumn();

                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("No students found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying students: " + ex.Message);
            }
        }

        private void AddOrUpdateColumn(string columnName, string headerText, bool isHidden = false)
        {
            if (dataGridView1.Columns[columnName] == null)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn
                {
                    Name = columnName,
                    HeaderText = headerText,
                    DataPropertyName = columnName
                };
                if (isHidden)
                {
                    column.Visible = false;
                }
                dataGridView1.Columns.Add(column);
            }
            else
            {
                dataGridView1.Columns[columnName].HeaderText = headerText;
                if (isHidden)
                {
                    dataGridView1.Columns[columnName].Visible = false;
                }
            }
        }
        private void AddActionColumn()
        {
            if (dataGridView1.Columns["Accept"] == null)
            {
                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                {
                    Name = "Accept",
                    HeaderText = "Action",
                    Text = "Accept",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(actionColumn);
            }
        }
        
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Accept"].Index && e.RowIndex >= 0)
            {
                panel2.Visible = true;
                // Retrieve the student_id from the selected row
                student_id = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Student_id"].Value);

                tb_student_id.Text = student_id;
                tb_name.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                tb_mail.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                tb_telephone.Text = dataGridView1.Rows[e.RowIndex].Cells["Telephone"].Value.ToString();
                string dobValue = dataGridView1.Rows[e.RowIndex].Cells["DOB"].Value.ToString();
                DateTime dob;
                if (DateTime.TryParse(dobValue, out dob) && dob >= dateTimePicker1.MinDate && dob <= dateTimePicker1.MaxDate)
                {
                    dateTimePicker1.Value = dob;
                }
                else
                {
                    // Set to a default value or handle the invalid date case
                    dateTimePicker1.Value = DateTime.Today; // or any other default date
                }


                try
                {
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT person_id FROM Student WHERE student_id = @Student_id", connect))
                    {
                        cmd.Parameters.AddWithValue("@Student_id", student_id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                person_id = reader.GetInt32(0);
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error get information person_id: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_name.Text) || string.IsNullOrWhiteSpace(tb_mail.Text) || string.IsNullOrWhiteSpace(tb_telephone.Text) 
                 || string.IsNullOrWhiteSpace(cb_gender.Text) || string.IsNullOrWhiteSpace(tb_student_id.Text) ||
                string.IsNullOrWhiteSpace(cb_class.Text) || string.IsNullOrWhiteSpace(cb_major.Text) || string.IsNullOrWhiteSpace(cb_semester.Text))
            {
                MessageBox.Show("Please fill in all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /*try
            {*/
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // Get class_id
                using (SqlCommand cmd_class = new SqlCommand("SELECT class_id FROM Class WHERE class_name = @class_name", connect))
                {
                    cmd_class.Parameters.AddWithValue("@class_name", cb_class.Text);
                    using (SqlDataReader reader = cmd_class.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            class_id = reader.GetInt32(0);
                        }
                    }
                }

                // Get major_id
                using (SqlCommand cmd_major = new SqlCommand("SELECT major_id FROM Major WHERE major_name = @major_name", connect))
                {
                    cmd_major.Parameters.AddWithValue("@major_name", cb_major.Text);
                    using (SqlDataReader reader = cmd_major.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            major_id = reader.GetInt32(0);
                        }
                    }
                }

                // Update Person table
                using (SqlCommand cmd = new SqlCommand("UPDATE Person SET name = @Name, email = @Email, telephone = @Telephone, dob = @dob, gender = @gender, image = @image, was_add = 1 WHERE person_id = @Person_id", connect))
                {
                    int gender = cb_gender.SelectedItem.ToString() == "Male" ? 1 : 0;
                    cmd.Parameters.AddWithValue("@Name", tb_name.Text);
                    cmd.Parameters.AddWithValue("@Email", tb_mail.Text);
                    cmd.Parameters.AddWithValue("@Telephone", tb_telephone.Text);
                    cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime(dateTimePicker1.Value));
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@image", image_path);
                    cmd.Parameters.AddWithValue("@Person_id", person_id);
                    cmd.ExecuteNonQuery();
                }

                // Update Student table
                using (SqlCommand cmd = new SqlCommand("UPDATE Student SET student_id = @student_id, class_id = @class_id, major_id = @major_id WHERE person_id = @Person_id", connect))
                {
                cmd.Parameters.AddWithValue("@student_id", tb_student_id.Text);
                cmd.Parameters.AddWithValue("@class_id", class_id);
                    cmd.Parameters.AddWithValue("@major_id", major_id);
                    cmd.Parameters.AddWithValue("@Person_id", person_id);
                    cmd.ExecuteNonQuery();
                }

                // Insert into StudentSemesters table
                semester_id = receive_semester_id_current();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO StudentSemesters (student_id, semester_id, number_semester_id) VALUES (@student_id, @semester_id, @number_semester_id)", connect))
                {
                    cmd.Parameters.AddWithValue("@student_id", tb_student_id.Text);
                    cmd.Parameters.AddWithValue("@semester_id", semester_id);
                    cmd.Parameters.AddWithValue("@number_semester_id", Convert.ToInt32(cb_semester.Text));
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the text boxes
                tb_name.Clear();
                tb_student_id.Clear();
                tb_mail.Clear();
                tb_telephone.Clear();
              
                image.Image = null;

                // Hide panel2
                panel2.Visible = false;

                // Refresh the DataGridView
                DisplayAllStudents(user_id, role);
            /*}
            catch (Exception ex)
            {
                MessageBox.Show("Error adding information: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }*/
        }

        private void PopulateComboBox()
        {
            // Queries to fetch semester names, class names, and major names
            string query_semester = "SELECT number_semester FROM SemesterNumber";
            string query_class = "SELECT class_name FROM Class ORDER BY class_id";
            string query_major = "SELECT major_name FROM Major ORDER BY major_id";
            string query_semester_name = "select name_semester, year from Semester";

            try
            {
                // Open the connection
                connect.Open();

                // Execute the query to fetch semester names
                using (SqlCommand command_semester = new SqlCommand(query_semester, connect))
                using (SqlDataReader reader_semester = command_semester.ExecuteReader())
                {
                    // Clear existing items in the combo box
                    cb_semester.Items.Clear();

                    // Iterate through the results and add each name_semester to the combo box
                    while (reader_semester.Read())
                    {
                        string semesterName = reader_semester["number_semester"].ToString();
                        cb_semester.Items.Add(semesterName);
                    }
                }

                // Execute the query to fetch class names
                using (SqlCommand command_class = new SqlCommand(query_class, connect))
                using (SqlDataReader reader_class = command_class.ExecuteReader())
                {
                    // Clear existing items in the combo box
                    cb_class.Items.Clear();

                    // Iterate through the results and add each class_name to the combo box
                    while (reader_class.Read())
                    {
                        string className = reader_class["class_name"].ToString();
                        cb_class.Items.Add(className);
                    }
                }

                // Execute the query to fetch major names
                using (SqlCommand command_major = new SqlCommand(query_major, connect))
                using (SqlDataReader reader_major = command_major.ExecuteReader())
                {
                    // Clear existing items in the combo box
                    cb_major.Items.Clear();

                    // Iterate through the results and add each major_name to the combo box
                    while (reader_major.Read())
                    {
                        string majorName = reader_major["major_name"].ToString();
                        cb_major.Items.Add(majorName);
                    }
                }
                using (SqlCommand command_semester_name = new SqlCommand(query_semester_name, connect))
                using (SqlDataReader reader_semester_name = command_semester_name.ExecuteReader())
                {
                    // Clear existing items in the combo box
                    cb_semester_name.Items.Clear();

                    // Iterate through the results and add each major_name to the combo box
                    while (reader_semester_name.Read())
                    {
                        string SemesterName = reader_semester_name["name_semester"].ToString();
                        string year = reader_semester_name["year"].ToString();
                        cb_semester_name.Items.Add($"{ SemesterName} - { year}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
            finally
            {
                // Close the connection
                connect.Close();
            }
        }

        private int receive_semester_id_current()
        {
            // Get the selected value from the combo box
            if (cb_semester_name.SelectedItem == null)
            {
                MessageBox.Show("Please select a semester.");
                return -1; // Indicate no selection
            }

            string selectedSemester = cb_semester_name.SelectedItem.ToString();
            string[] parts = selectedSemester.Split(new string[] { " - " }, StringSplitOptions.None);
            if (parts.Length != 2)
            {
                MessageBox.Show("Invalid semester format.");
                return -1; // Indicate invalid format
            }

            string name_semester = parts[0];
            if (!int.TryParse(parts[1], out int year))
            {
                MessageBox.Show("Invalid year format.");
                return -1; // Indicate invalid year
            }

            string sql = @"
        SELECT semester_id 
        FROM Semester 
        WHERE year = @year 
        AND name_semester = @name_semester";

            try
            {
                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@name_semester", name_semester);

                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("No current semester found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching current semester ID: " + ex.Message);
                return -1; // Indicate an error
            }
           
        }

        private void browse_image_Click(object sender, EventArgs e)
        {
            // Open file dialog to choose an image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                // Get the selected file path and display in PictureBox
                image_path = openFileDialog.FileName;
                image.Image = Image.FromFile(image_path);
            }

        }
    }
}
