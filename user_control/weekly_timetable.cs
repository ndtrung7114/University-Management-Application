using System;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace coursework.user_control
{
    public partial class weekly_timetable : UserControl
    {
        private Timer timer;
        private bool userSelectedWeek = false;
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        private string user_id;
        private Role role;

        public weekly_timetable()
        {
            InitializeComponent();
            PopulateTimeColumn();
            dataGridView1.RowTemplate.Height = 150;

            // Initialize and start the timer
            timer = new Timer
            {
                Interval = 60000 // Check every minute
            };
            timer.Tick += Timer_Tick;
            timer.Start();



        }
        public void Initialize(string userId, Role role)
        {
            this.user_id = userId;
            this.role = role;
            PopulateYearComboBox();
            PopulateWeekComboBox();
            SelectCurrentWeek();
        }

        private void PopulateYearComboBox()
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - 5; year <= currentYear + 5; year++)
            {
                cb_year.Items.Add(year);
            }
            cb_year.SelectedItem = currentYear;
        }

        private void PopulateTimeColumn()
        {
            dataGridView1.Rows.Clear();
            DateTime time = new DateTime(2000, 1, 1, 7, 30, 0);
            for (int i = 0; i < 8; i++)
            {
                dataGridView1.Rows.Add(time.ToString("HH:mm"));
                time = time.AddHours(2);
            }
        }

        private void PopulateWeekComboBox()
        {
            cb_week.Items.Clear();
            if (cb_year.SelectedItem != null)
            {
                int year = (int)cb_year.SelectedItem;
                DateTime date = new DateTime(year, 1, 1);
                while (date.Year == year)
                {
                    DateTime weekStart = GetWeekStartDate(date);
                    DateTime weekEnd = weekStart.AddDays(6);
                    string weekRange = $"{weekStart:MM/dd} to {weekEnd:MM/dd}";
                    cb_week.Items.Add(weekRange);
                    date = date.AddDays(7);
                }
            }
        }

        private void SelectCurrentWeek()
        {
            if (!userSelectedWeek)
            {
                DateTime now = DateTime.Now;
                int currentYear = now.Year;

                if ((int)cb_year.SelectedItem != currentYear)
                {
                    cb_year.SelectedItem = currentYear;
                    PopulateWeekComboBox();
                }

                DateTime currentWeekStart = GetWeekStartDate(now);
                string currentWeekRange = $"{currentWeekStart:MM/dd} to {currentWeekStart.AddDays(6):MM/dd}";

                int index = cb_week.Items.IndexOf(currentWeekRange);
                if (index != -1)
                {
                    cb_week.SelectedIndex = index;
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SelectCurrentWeek();
        }

        private void UpdateDataGridViewHeaders()
        {
            if (cb_year.SelectedItem != null && cb_week.SelectedItem != null)
            {
                string selectedWeekRange = cb_week.SelectedItem.ToString();
                DateTime weekStart = DateTime.ParseExact(selectedWeekRange.Substring(0, 5), "MM/dd", CultureInfo.InvariantCulture);
                weekStart = weekStart.AddYears((int)cb_year.SelectedItem - weekStart.Year);

                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    DateTime currentDay = weekStart.AddDays(i - 1);
                    dataGridView1.Columns[i].HeaderText = currentDay.ToString("ddd (MM/dd)");
                }
            }
        }

        private DateTime GetWeekStartDate(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private void cb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            userSelectedWeek = false;
            PopulateWeekComboBox();
            SelectWeekForSelectedYear();
        }

        public void cb_week_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleWeekChange();
        }
        public void HandleWeekChange(string user_id = null)
        {
            userSelectedWeek = true;
            UpdateDataGridViewHeaders();
            if (!string.IsNullOrEmpty(this.user_id))
            {
                UpdateTimetable(this.user_id);
            }
        }
        private void SelectWeekForSelectedYear()
        {
            if (cb_year.SelectedItem != null)
            {
                int selectedYear = (int)cb_year.SelectedItem;
                DateTime now = DateTime.Now;
                DateTime dateInSelectedYear = new DateTime(selectedYear, now.Month, now.Day);
                DateTime weekStart = GetWeekStartDate(dateInSelectedYear);
                string weekRange = $"{weekStart:MM/dd} to {weekStart.AddDays(6):MM/dd}";

                int index = cb_week.Items.IndexOf(weekRange);
                if (index != -1)
                {
                    cb_week.SelectedIndex = index;
                }
                else
                {
                    // If the exact week is not found, select the first week of the year
                    cb_week.SelectedIndex = 0;
                }
            }
        }



        public void UpdateTimetable(string user_id)
        {
            this.user_id = user_id;
            if (cb_year.SelectedItem != null && cb_week.SelectedItem != null)
            {
                string selectedWeekRange = cb_week.SelectedItem.ToString();
                DateTime weekStart = DateTime.ParseExact(selectedWeekRange.Substring(0, 5), "MM/dd", CultureInfo.InvariantCulture);
                weekStart = weekStart.AddYears((int)cb_year.SelectedItem - weekStart.Year);
                DateTime weekEnd = weekStart.AddDays(6);

                // Clear the DataGridView
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        dataGridView1[i, j].Value = null;
                    }
                }

                string query;
                if (role == Role.Student)
                {
                    query = @"
                SELECT a.attendance_date, a.time, s.subject_name, a.room, p.name
                FROM Attendance a
                JOIN Subject s ON a.subject_id = s.subject_id
                JOIN Teacher t ON a.teacher_id = t.teacher_id
                JOIN Person p ON t.person_id = p.person_id
                WHERE a.student_id = @user_id AND a.attendance_date BETWEEN @weekStart AND @weekEnd
                ORDER BY a.attendance_date, a.time";
                }
                else if (role == Role.Teacher)
                {
                    query = @"
                SELECT distinct a.attendance_date, a.time, s.subject_name, a.room, c.class_name
                FROM Attendance a
                JOIN Subject s ON a.subject_id = s.subject_id


                JOIN TeacherSemester ts ON a.teacher_id = ts.teacher_id
                JOIN Class c ON ts.class_id = c.class_id
                WHERE a.teacher_id = @user_id AND a.attendance_date BETWEEN @weekStart AND @weekEnd
                ORDER BY a.attendance_date, a.time";
                }
                else
                {
                    MessageBox.Show("Invalid role");
                    return;
                }

                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@user_id", user_id);
                command.Parameters.AddWithValue("@weekStart", weekStart.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@weekEnd", weekEnd.ToString("yyyy-MM-dd"));

                try
                {
                    if (connect.State == ConnectionState.Closed) { connect.Open(); }
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime attendanceDate = reader.GetDateTime(0);
                        TimeSpan attendanceTime = reader.GetTimeSpan(1);
                        string subjectName = reader.GetString(2);
                        string room = reader.GetString(3);
                        string lastColumn = reader.GetString(4); // This will be teacher name for students, class name for teachers

                        int columnIndex = -1;
                        for (int i = 1; i < dataGridView1.Columns.Count; i++)
                        {
                            if (dataGridView1.Columns[i].HeaderText.Contains(attendanceDate.ToString("MM/dd")))
                            {
                                columnIndex = i;
                                break;
                            }
                        }

                        int rowIndex = -1;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Value != null)
                            {
                                TimeSpan cellTime = TimeSpan.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                                if (attendanceTime >= cellTime && attendanceTime < cellTime.Add(TimeSpan.FromHours(2)))
                                {
                                    rowIndex = i;
                                    break;
                                }
                            }
                        }

                        if (columnIndex != -1 && rowIndex != -1)
                        {
                            dataGridView1[columnIndex, rowIndex].Value = $"{subjectName}\n{room}\n{lastColumn}";
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading timetable: {ex.Message}");
                }
                finally
                {
                    connect.Close();
                }
            }
        }



    }
}
