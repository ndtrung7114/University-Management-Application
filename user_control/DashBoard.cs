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

namespace coursework
{
    
    public partial class DashBoard : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        public string user_id;
        public DashBoard()
        {
            InitializeComponent();
            display_total_admin();
            display_total_student();
            display_total_teacher();
      
              
        }
        public void InitializeDashboard(string user_id, Role role)
        {
            // Initialize dashboard content based on user_id and role
            this.user_id = user_id;
            // Use role enum to adjust dashboard content based on user role
            switch (role)
            {
                case Role.Admin:
                    // Configure dashboard for admin
                    break;
                case Role.Teacher:
                    // Configure dashboard for teacher
                    break;
                case Role.Student:
                    // Configure dashboard for student
                    break;
                default:
                    break;
            }

            // Load data or perform actions based on user_id and role
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Example: Load and display user-specific data or perform actions
            textBox1.Text = "Welcome, User #" + user_id.ToString();
            // Populate other controls as needed
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        public void display_total_admin()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT COUNT(admin_id) FROM Admin";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            lb_admin.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void display_total_teacher()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT COUNT(teacher_id) FROM Teacher ";
                        

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                       
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            lb_teacher.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void display_total_student()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT COUNT(student_id) FROM  Student s INNER JOIN  Person p on s.person_id = p.person_id WHERE p.was_add = 1 ";
                        ;

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            lb_student.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }





}
