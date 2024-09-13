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
    public partial class Add_admin : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        public string user_id;
        public Role role;
        private int person_id;
        private string admin_id;
        public Add_admin()
        {
            InitializeComponent();
            panel2.Visible = false;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }
        public void DisplayAllAdmins(string user_id, Role role)
        {
            try
            {
                this.user_id = user_id;
                this.role = role;
                AdminAccess dataAccess = new AdminAccess();
                List<Admin> admins = dataAccess.GetAdmins_wasnt_added();
                tb_admin_count.Text = admins.Count.ToString();

                if (admins != null && admins.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = admins;
                    dataGridView1.Columns.Clear();

                    AddOrUpdateColumn("Admin_id", "Admin ID");
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
                    MessageBox.Show("No admins found.");
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
                admin_id = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Teacher_id"].Value);

                tb_admin_id.Text = admin_id;
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
                        cmd.Parameters.AddWithValue("@teacher_id", admin_id);

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
    }
}
