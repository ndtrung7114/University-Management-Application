using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace coursework.user_control.student
{
    public partial class Curiculum : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        private string user_id;
        private int major_id;

        public Curiculum()
        {
            InitializeComponent();
        }

        public void Load_curriculum(string user_id, Role role)
        {
            try
            {
                connect.Open();
                this.user_id = user_id;

                string majorIdQuery = "";
                if (role == Role.Student)
                {
                    majorIdQuery = @"
                        SELECT s.major_id
                        FROM Student s
                        WHERE s.student_id = @user_id";
                }
                else if (role == Role.Teacher)
                {
                    majorIdQuery = @"
                        SELECT t.major_id
                        FROM Teacher t
                        WHERE t.teacher_id = @user_id";
                }

                using (SqlCommand majorIdCommand = new SqlCommand(majorIdQuery, connect))
                {
                    majorIdCommand.Parameters.AddWithValue("@user_id", user_id);
                    object result = majorIdCommand.ExecuteScalar();
                    if (result != null)
                    {
                        major_id = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Major ID not found for the given user ID.");
                        return;
                    }
                }

                string curriculumQuery = @"
                    SELECT sub.subject_name, senum.number_semester
                    FROM SemesterNumber senum 
                    JOIN SemesterSubjects sesub ON senum.number_semester_id = sesub.number_semester_id
                    JOIN Subject sub ON sesub.subject_id = sub.subject_id
                    WHERE sub.major_id = @major_id";

                using (SqlCommand curriculumCommand = new SqlCommand(curriculumQuery, connect))
                {
                    curriculumCommand.Parameters.AddWithValue("@major_id", major_id);

                    using (SqlDataReader reader = curriculumCommand.ExecuteReader())
                    {
                        DataTable curriculumTable = new DataTable();
                        curriculumTable.Load(reader);
                        FillDataGridView(curriculumTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading curriculum: {ex.Message}");
            }
            finally
            {
                connect.Close();
            }
        }

        private void FillDataGridView(DataTable curriculumTable)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow row in curriculumTable.Rows)
            {
                dataGridView1.Rows.Add(row["number_semester"], row["subject_name"]);
            }
        }
    }
}
