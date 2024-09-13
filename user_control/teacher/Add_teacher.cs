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

namespace coursework.form_usercontrol
{
    public partial class Add_teacher : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        public string user_id;
        public Role role;
        private int person_id;
        private string teacher_id;
        private int semester_id;
       
        private int major_id;
        private string image_path;
        public Add_teacher()
        {
            InitializeComponent();
            PopulateComboBox();
            panel2.Visible = false;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_name.Text) || string.IsNullOrWhiteSpace(tb_mail.Text) || string.IsNullOrWhiteSpace(tb_telephone.Text) ||
                string.IsNullOrWhiteSpace(dateTimePicker1.Value.ToString()) || string.IsNullOrWhiteSpace(cb_gender.Text)
                || string.IsNullOrWhiteSpace(cb_major.Text) || string.IsNullOrEmpty(tb_teacher_id.Text) ) 
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
            using (SqlCommand cmd = new SqlCommand("UPDATE Teacher SET teacher_id = @teacher_id, major_id = @major_id, salary = @salary WHERE person_id = @Person_id", connect))
            {
                cmd.Parameters.AddWithValue("@teacher_id", tb_teacher_id.Text);
                cmd.Parameters.AddWithValue("@salary", tb_salary.Text);
                cmd.Parameters.AddWithValue("@major_id", major_id);
                cmd.Parameters.AddWithValue("@Person_id", person_id);
                cmd.ExecuteNonQuery();
            }

            

            MessageBox.Show("Information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the text boxes
            tb_name.Clear();
            tb_mail.Clear();
            tb_telephone.Clear();
            tb_teacher_id.Clear();
            image.Image = null;

            // Hide panel2
            panel2.Visible = false;

            // Refresh the DataGridView
            DisplayAllTeachers(user_id, role);
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

        public void DisplayAllTeachers(string user_id, Role role)
        {
            try
            {
                this.user_id = user_id;
                this.role = role;
                TeacherAccess dataAccess = new TeacherAccess();
                List<Teacher> teachers = dataAccess.GetTeachers_wasnt_added();
                tb_teacher_id.Text = teachers.Count.ToString();

                if (teachers != null && teachers.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = teachers;
                    dataGridView1.Columns.Clear();

                    AddOrUpdateColumn("Teacher_id", "Teacher ID");
                    AddOrUpdateColumn("Name", "Name");
                    AddOrUpdateColumn("Email", "Email");
                    AddOrUpdateColumn("Telephone", "Telephone");
                    AddOrUpdateColumn("DOB", "Birth");
                    AddOrUpdateColumn("Gender", "Gender");
                    AddOrUpdateColumn("Image", "Image");
                    AddOrUpdateColumn("Salary", "Salary");




                    AddActionColumn();

                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("No teachers found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying teachers: " + ex.Message);
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
                teacher_id = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Teacher_id"].Value);
                
                tb_teacher_id.Text = teacher_id;
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

                    using (SqlCommand cmd = new SqlCommand("SELECT person_id FROM Teacher WHERE teacher_id = @teacher_id", connect))
                    {
                        cmd.Parameters.AddWithValue("@teacher_id", teacher_id);

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

        private void PopulateComboBox()
        {
            // Queries to fetch semester names, class names, and major names
           
           
            string query_major = "SELECT major_name FROM Major ORDER BY major_id";
           

            try
            {
                // Open the connection
                connect.Open();

                

              

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

        

        

        private void browse_image_Click_1(object sender, EventArgs e)
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
