using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace coursework.user_control.report
{
    public enum Type_attendance
    {
        Absent,
        Present,
        Future
    }

    public partial class Attendance_report : UserControl
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);

        private string student_id_report;
        private int major_id;

        public Attendance_report()
        {
            InitializeComponent();
            report_slot.CellFormatting += report_slot_CellFormatting; // Add the CellFormatting event handler
        }

        public void load_infor_term(string student_id)
        {
            try
            {
                this.student_id_report = student_id;

                string query = @"
                    SELECT se.name_semester, se.year, se.semester_id, ss.number_semester_id, s.major_id
                    FROM Student s
                    JOIN StudentSemesters ss ON s.student_id = ss.student_id
                    JOIN Semester se ON ss.semester_id = se.semester_id
                    WHERE s.student_id = @student_id
                    ORDER BY year ASC, name_semester ASC";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@student_id", student_id);
                    connect.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    list_term_box.Items.Clear();

                    while (reader.Read())
                    {
                        string nameSemester = reader["name_semester"].ToString();
                        string year = reader["year"].ToString();
                        major_id = Convert.ToInt32(reader["major_id"]);

                        list_term_box.Items.Add($"{nameSemester} {year}");
                    }

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

        private void LoadSubjectsForSelectedSemester(int semester_id, int major_id)
        {
            try
            {
                string query = @"
                    SELECT subj.subject_name
                    FROM StudentSemesters ss
                    JOIN Student s ON ss.student_id = s.student_id
                    JOIN SemesterSubjects sesub ON ss.number_semester_id = sesub.number_semester_id
                    JOIN Subject subj ON sesub.subject_id = subj.subject_id
                    WHERE ss.semester_id = @semester_id AND s.student_id = @student_id AND subj.major_id = @major_id";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@semester_id", semester_id);
                    command.Parameters.AddWithValue("@major_id", major_id);
                    command.Parameters.AddWithValue("@student_id", student_id_report);

                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    list_subject_box.Items.Clear();

                    while (reader.Read())
                    {
                        string subjectName = reader["subject_name"].ToString();
                        list_subject_box.Items.Add(subjectName);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects for semester: {ex.Message}");
            }
            finally
            {
                connect.Close();
            }
        }

        private void list_term_box_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (list_term_box.SelectedIndex != -1)
            {
                string selectedTerm = list_term_box.SelectedItem.ToString();
                string[] termParts = selectedTerm.Split(' ');
                string nameSemester = termParts[0];
                string year = termParts[1];

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
                        int semester_id = Convert.ToInt32(result);
                        LoadSubjectsForSelectedSemester(semester_id, major_id);
                    }
                }
                connect.Close();
            }
        }

        private void Load_slot_for_subject(int subject_id, string student_id, int number_slot)
        {
            /*try
            {*/
            string query = @"
            SELECT a.attendance_date AS Date, a.slot_number AS Slot, p.name AS Teacher, c.class_name AS Class, a.status AS Status
            FROM student t
            JOIN Class c ON t.class_id = c.class_id
            JOIN Attendance a ON t.student_id = a.student_id
            JOIN Teacher te ON a.teacher_id = te.teacher_id
            JOIN Person p ON te.person_id = p.person_id
            WHERE a.student_id = @student_id AND a.subject_id = @subject_id";

            using (SqlCommand command = new SqlCommand(query, connect))
            {
                command.Parameters.AddWithValue("@student_id", student_id);
                command.Parameters.AddWithValue("@subject_id", subject_id);

                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                reader.Close();

                // Add StatusText column to represent status as text
                dataTable.Columns.Add("StatusText", typeof(string));
                foreach (DataRow row in dataTable.Rows)
                {
                    int statusValue = Convert.ToInt32(row["Status"]);
                    row["StatusText"] = ((Type_attendance)statusValue).ToString();
                }

                // Remove the original Status column
                dataTable.Columns.Remove("Status");

                // Calculate total absences
                int totalAbsences = dataTable.AsEnumerable().Count(row => row.Field<string>("StatusText") == Type_attendance.Absent.ToString());
                decimal absencePercentage = number_slot > 0 ? (decimal)totalAbsences / number_slot * 100 : 0;

                // Round the percentage to the nearest whole number
                int roundedPercentage = (int)Math.Round(absencePercentage);

                // Set the label text
                lb_absent.Text = $"Absent: {roundedPercentage}% on {number_slot} slot";

                report_slot.DataSource = dataTable;
            }
            /*}
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving slot information: {ex.Message}");
            }
            finally
            {
                connect.Close();
            }*/
        }

        private void list_subject_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_subject_box.SelectedIndex != -1)
            {
                string selectedSubject = list_subject_box.SelectedItem.ToString();
                string query = @"
            SELECT sub.subject_id, sub.number_slot
            FROM Subject sub
            WHERE sub.subject_name = @name_subject";
                int subject_id = 0;
                int number_slot = 0;
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@name_subject", selectedSubject);
                    if (connect.State == ConnectionState.Closed) { connect.Open(); }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            subject_id = reader.GetInt32(0);
                            number_slot = reader.GetInt32(1);
                        }
                    }
                    connect.Close();
                }
                if (subject_id != 0)
                {
                    Load_slot_for_subject(subject_id, student_id_report, number_slot);
                }
            }
        }

        private void report_slot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (report_slot.Columns[e.ColumnIndex].Name == "StatusText" && e.Value != null)
            {
                string statusText = e.Value.ToString();

                switch (statusText)
                {
                    case "Absent":
                        e.CellStyle.ForeColor = Color.Red;
                        break;
                    case "Present":
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case "Future":
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    default:
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }
    }
}
