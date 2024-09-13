using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Runtime.CompilerServices;
using coursework.form_usercontrol;
using System.Drawing;
using System.IO;
using System.Data;

using System.Data.SqlClient;


namespace coursework
{
    public partial class All_Student : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        public string user_id;
        public Role role;
        private List<Student> students;
        public All_Student()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.OwningColumn.Name == "Edit")
                {
                    // Handle edit logic for student with specific ID
                    string studentId = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Student_id"].Value);
                    bool check = true;
                    
                    
                    Edit_student edit = new Edit_student(studentId);
                    edit.Show();
                   
                    
                  
                  
                    
                    // Implement your edit functionality here (open edit form, etc.)
                }
                else if (cell.OwningColumn.Name == "Delete")
                {
                    // Handle delete logic for student with specific ID
                    string studentId = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Student_id"].Value);
                    DialogResult result = MessageBox.Show("Are you sure you want to delete student with ID " + studentId + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        /*try
                        {*/
                            // Perform deletion
                            StudentDataAccess dataAccess = new StudentDataAccess();
                            int person_id = dataAccess.GetPersonIdFromStudentId(studentId);
                            dataAccess.DeleteStudent(person_id);

                            // Optionally refresh the grid after deletion
                            DisplayAllStudents(user_id, role); // This assumes you have a method to refresh the grid
                        /*}
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }*/
                    }
                    // Implement your delete functionality here (confirmation dialog, data access)
                }
            }
        }

        public void DisplayAllStudents(string user_id, Role role)
        {
            /*try
            {*/
                this.user_id = user_id;
                this.role = role;
                
            StudentDataAccess dataAccess = new StudentDataAccess();
                List<Student> students = dataAccess.GetStudents();

                if (students != null && students.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = false ;
                dataGridView1.DataSource = students;
                    dataGridView1.RowTemplate.Height = 100;
                dataGridView1.Columns.Clear();
                    
                    
                    AddOrUpdateColumn("Student_id", "Student ID");
                    AddOrUpdateColumn("Name", "Name");
                    AddOrUpdateColumn("Email", "Email");
                    AddOrUpdateColumn("Telephone", "Telephone");
                    AddOrUpdateColumn("DOB", "Birth");
                    AddOrUpdateColumn("Gender", "Gender");
                    AddOrUpdateImageColumn("Image", "Image");

                    AddOrUpdateColumn("StudentGroup", "Class");
                    AddOrUpdateColumn("Major", "Major");
                    AddOrUpdateColumn("Semester", "Semester");
                    
                    AddOrUpdateColumn("Year", "Year");
                    SetColumnValues();




                    AddActionColumn( );
                }
                else
                {
                    MessageBox.Show("No students found.");
                }
            /*}
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying students: " + ex.Message);
            }*/
        }

        private void AddOrUpdateColumn(string columnName, string headerText)
        {
            if (dataGridView1.Columns[columnName] == null)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = columnName,
                    HeaderText = headerText,
                    DataPropertyName = columnName
                });
            }
            else
            {
                dataGridView1.Columns[columnName].HeaderText = headerText;
                
            }
        }
        private void AddOrUpdateImageColumn(string columnName, string headerText)
        {
            if (dataGridView1.Columns[columnName] == null)
            {
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                {
                    Name = columnName,
                    HeaderText = headerText,
                    DataPropertyName = columnName,
                    ImageLayout = DataGridViewImageCellLayout.Zoom, // Adjust layout as needed
                    Width = 50,

                   
                    // Adjust widh as needed
                };
                dataGridView1.Columns.Add(imageColumn);
            }
            else
            {
                dataGridView1.Columns[columnName].HeaderText = headerText;
            }
        }
        public void SetColumnValues()
        {
            string columnName = "Year";
            int predefinedYear = 2024; // Example predefined value

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[columnName].Value = predefinedYear;
            }
        }


        private void AddActionColumn()
        {
            if (role == Role.Admin)
            {
                if (dataGridView1.Columns["Edit"] == null)
                {
                    DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        HeaderText = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(editColumn);
                }

                if (dataGridView1.Columns["Delete"] == null)
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(deleteColumn);
                }
            }

            dataGridView1.CellFormatting += (s, e) =>
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit" || dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (role == Role.Admin)
                    {
                        e.Value = dataGridView1.Columns[e.ColumnIndex].Name; // Show "Edit" or "Delete" for Admin
                    }
                    else
                    {
                        e.Value = null; // Hide buttons for non-Admin roles
                    }
                }
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
        dataGridView1.Columns[e.ColumnIndex].Name == "Image")
                {
                    string imagePath = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        Image image;
                        if (File.Exists(imagePath))
                        {
                            image = Image.FromFile(imagePath); // Load image from file path
                        }
                        else
                        {
                            // Handle case where image file doesn't exist
                            image = null;
                        }
                        e.Value = image;
                    }
                    else
                    {
                        e.Value = null; // Handle empty image path scenario
                    }
                }
            };
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void All_Student_Load(object sender, EventArgs e)
        {
            
        }

        private void search_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string cm1 = @"
                    SELECT s.student_id, p.name, p.email, p.telephone, p.gender, p.DOB, p.image,
                           c.class_name, m.major_name, se.name_semester, se.year, p.role
                    FROM Student s
                    JOIN Person p ON s.person_id = p.person_id
                    JOIN Class c ON s.class_id = c.class_id
                    JOIN Major m ON s.major_id = m.major_id
                    JOIN StudentSemesters ss ON s.student_id = ss.student_id
                    JOIN Semester se ON ss.semester_id = se.semester_id
                    WHERE p.was_add = 1
                    AND p.name LIKE @searchText
                    AND se.year = (SELECT TOP 1 year FROM Semester ORDER BY year DESC, name_semester DESC)
                    AND se.name_semester = (SELECT TOP 1 name_semester FROM Semester ORDER BY year DESC, name_semester DESC);";

                using (SqlCommand cmd1 = new SqlCommand(cm1, connect))
                {
                    cmd1.Parameters.AddWithValue("@searchText", "%" + search_textbox.Text + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd1))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

    }
}
