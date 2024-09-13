using System;
using System.Collections;
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
    public partial class admin_curriculum : UserControl
    {
        private int major_id;
        private string image_path;
        private int class_id;
        private int semester_id;
        private int subject_id;
        private int major_id_student;
        private int number_slot;
        private string teacher_id;


        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        public admin_curriculum()
        {
            InitializeComponent();
            PopulateComboBox();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowTemplate.Height = 50;
            LoadTeacherSemesterData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadTeacherSemesterData()
        {
            string query = @"
        SELECT ts.teacher_id, p.image, p.name, c.class_name, s.name_semester, s.year, sub.subject_name, m.major_name
        FROM TeacherSemester ts
        JOIN Teacher t ON ts.teacher_id = t.teacher_id
        JOIN Person p ON t.person_id = p.person_id
        JOIN Class c ON ts.class_id = c.class_id
        JOIN Semester s ON ts.semester_id = s.semester_id
        JOIN Subject sub ON ts.subject_id = sub.subject_id
        JOIN Major m ON sub.major_id = m.major_id";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear(); // Clear existing rows

                        while (reader.Read())
                        {
                            string teacherId = reader["teacher_id"].ToString();
                            string imagePath = reader["image"].ToString();
                            string name = reader["name"].ToString();
                            string className = reader["class_name"].ToString();
                            string semesterName = reader["name_semester"].ToString();
                            string year = reader["year"].ToString();
                            string subjectName = reader["subject_name"].ToString();
                            string majorName = reader["major_name"].ToString();

                            Image resizedImage = null;
                            if (!string.IsNullOrEmpty(imagePath))
                            {
                                resizedImage = ResizeImage(Image.FromFile(imagePath), 50, 50);
                            }

                            int rowIndex = dataGridView1.Rows.Add();
                            DataGridViewRow newRow = dataGridView1.Rows[rowIndex];

                            newRow.Cells["Teacher_id"].Value = teacherId;
                            newRow.Cells["image"].Value = resizedImage;
                            newRow.Cells["name_teacher"].Value = name;
                            newRow.Cells["class_name"].Value = className;
                            newRow.Cells["semester"].Value = semesterName;
                            newRow.Cells["year"].Value = year;
                            newRow.Cells["subject"].Value = subjectName;
                            newRow.Cells["major"].Value = majorName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string query_image = "SELECT   p.image FROM Teacher t join Person p on t.person_id = p.person_id where t.teacher_id = @teacher_id";
            string query_class_id = "select class_id from Class where class_name = @class_name";
            string query_semester_id = "select semester_id from Semester where name_semester = @name_semester and year = @year";
            string query_subject = "select subject_id from Subject where subject_name = @subject_name";
            using (SqlCommand command = new SqlCommand(query_image, connect))
            {
                command.Parameters.AddWithValue("@teacher_id", cb_teacher_id.Text);


                if (connect.State == ConnectionState.Closed) { connect.Open(); }
                object result = command.ExecuteScalar();

                if (result != null)
                {
                     image_path = Convert.ToString(result);

                    
                }
            }
            Image resizedImage = null;
            if (!string.IsNullOrEmpty(image_path))
            {
                resizedImage = ResizeImage(Image.FromFile(image_path), 50, 50);
            }
            // Retrieve class ID
            int class_id = 0;
            using (SqlCommand command = new SqlCommand(query_class_id, connect))
            {
                command.Parameters.AddWithValue("@class_name", cb_class.Text);

                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                object result = command.ExecuteScalar();
                connect.Close();

                if (result != null)
                {
                    class_id = Convert.ToInt32(result);
                }
            }

            // Retrieve semester ID
            int semester_id = 0;
            using (SqlCommand command = new SqlCommand(query_semester_id, connect))
            {
                command.Parameters.AddWithValue("@name_semester", cb_semester.Text);
                command.Parameters.AddWithValue("@year", cb_year.Text);

                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                object result = command.ExecuteScalar();
                connect.Close();

                if (result != null)
                {
                    semester_id = Convert.ToInt32(result);
                }
            }

            // Retrieve subject ID
            int subject_id = 0;
            using (SqlCommand command = new SqlCommand(query_subject, connect))
            {
                command.Parameters.AddWithValue("@subject_name", list_subject.SelectedItem.ToString());

                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                object result = command.ExecuteScalar();
                connect.Close();

                if (result != null)
                {
                    subject_id = Convert.ToInt32(result);
                }
            }
            insert_teacher_semester(cb_teacher_id.Text, class_id, semester_id, subject_id);

            int rowIndex = dataGridView1.Rows.Add();
            DataGridViewRow newRow = dataGridView1.Rows[rowIndex];

            newRow.Cells["Teacher_id"].Value = cb_teacher_id.Text;
            newRow.Cells["image"].Value = resizedImage; // Set the resized image
            newRow.Cells["name_teacher"].Value = cb_name.Text;
            newRow.Cells["class_name"].Value = cb_class.Text;
            newRow.Cells["semester"].Value = cb_semester.Text;
            newRow.Cells["year"].Value = cb_year.Text;
            newRow.Cells["subject"].Value = list_subject.SelectedItem.ToString();
            newRow.Cells["major"].Value = cb_major.Text;

            

        }

        private void insert_teacher_semester(string teacher_id, int class_id, int semester_id, int subject_id)
        {
            string query = "INSERT INTO TeacherSemester (teacher_id, class_id, semester_id, subject_id) VALUES (@teacher_id, @class_id, @semester_id, @subject_id)";

            using (SqlCommand command = new SqlCommand(query, connect))
            {
                command.Parameters.AddWithValue("@teacher_id", teacher_id);
                command.Parameters.AddWithValue("@class_id", class_id);
                command.Parameters.AddWithValue("@semester_id", semester_id);
                command.Parameters.AddWithValue("@subject_id", subject_id);

                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("TeacherSemester record inserted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting TeacherSemester record: " + ex.Message);
                }
                finally
                {
                    connect.Close();
                }
            }

        }
        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

            private void cb_major_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure there is a selected item
            if (cb_major.SelectedIndex != -1)
            {
                // Extract semester information from the selected item
                string selected_major = cb_major.SelectedItem.ToString();
               

                // Retrieve semester_id from database based on nameSemester and year
                /*try
                {*/
                string query = @"
                        SELECT major_id
                        FROM Major
                        WHERE major_name = @major_name";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@major_name", selected_major);


                    if (connect.State == ConnectionState.Closed) { connect.Open(); }
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        major_id = Convert.ToInt32(result);

                        // Load subjects for the selected semester
                        Load_subject_for_major(major_id);
                        
                    }
                    connect.Close();
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

        private void Load_subject_for_major(int major_id)
        {
            try
            {

                // Define your SQL query to retrieve subjects for the selected semester
                string query = @"
                    SELECT subject_name
                    FROM Subject
                   
               
                    WHERE major_id = @major_id";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@major_id", major_id);

                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear existing items
                    list_subject.Items.Clear();

                    // Read each subject from the result set
                    while (reader.Read())
                    {
                        string subjectName = reader["subject_name"].ToString();
                       
                        list_subject.Items.Add($"{subjectName}");
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

        private void PopulateComboBox()
        {
            // Queries to fetch semester names, class names, and major names
            string query_teacher = "SELECT t.teacher_id, p.name, p.image FROM Teacher t join Person p on t.person_id = p.person_id";
            string query_class = "SELECT class_name FROM Class ORDER BY class_id";
            string query_major = "SELECT major_name FROM Major ORDER BY major_id";
            string query_semester_name = "select distinct year, name_semester  from Semester";
            string query_year = "select distinct year  from Semester";

            try
            {
                // Open the connection
                connect.Open();

                // Execute the query to fetch semester names
                using (SqlCommand command_teacher = new SqlCommand(query_teacher, connect))
                using (SqlDataReader reader_teacher = command_teacher.ExecuteReader())
                {
                    // Clear existing items in the combo box
                    cb_teacher_id.Items.Clear();
                    cb_name.Items.Clear();

                    // Iterate through the results and add each name_semester to the combo box
                    while (reader_teacher.Read())
                    {
                        string name = reader_teacher["name"].ToString();
                        string teacher_id = reader_teacher["teacher_id"].ToString();
                        cb_teacher_id.Items.Add(teacher_id);
                        cb_name.Items.Add(name);
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
                        list_class.Items.Add(className);
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
                    cb_semester.Items.Clear();

                    // Iterate through the results and add each major_name to the combo box
                    while (reader_semester_name.Read())
                    {
                        string SemesterName = reader_semester_name["name_semester"].ToString();
                   
                        cb_semester.Items.Add($"{SemesterName}");
                      
                    }
                }

                using (SqlCommand command_semester_year = new SqlCommand(query_year, connect))
                using (SqlDataReader reader_semester_year = command_semester_year.ExecuteReader())
                {
                    // Clear existing items in the combo box
                    cb_year.Items.Clear();

                    // Iterate through the results and add each major_name to the combo box
                    while (reader_semester_year.Read())
                    {
                        
                        string year = reader_semester_year["year"].ToString();
                      
                        cb_year.Items.Add(year);
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

        //Student

        

        private void list_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_class.SelectedIndex != -1)
            {
                // Extract class information from the selected item
                string selected_class = list_class.SelectedItem.ToString();
                string name_class = selected_class;

                try
                {
                    string query_class_id = @"
                SELECT class_id
                FROM Class
                WHERE class_name = @class_name";
                    if (connect.State == ConnectionState.Closed) { connect.Open(); }

                    using (SqlCommand command = new SqlCommand(query_class_id, connect))
                    {
                        command.Parameters.AddWithValue("@class_name", name_class);

                        if (connect.State == ConnectionState.Closed) { connect.Open(); }
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            class_id = Convert.ToInt32(result);

                            // Load semester for the selected class
                            Load_semester_for_class(class_id);
                        }
                    }

                    string query_major_id_student = @"
                SELECT DISTINCT s.major_id 
                FROM Student s
                WHERE s.class_id = @class_id";
                    connect.Open();
                    using (SqlCommand command_1 = new SqlCommand(query_major_id_student, connect))
                    {
                        command_1.Parameters.AddWithValue("@class_id", class_id);

                        object result_1 = command_1.ExecuteScalar();
                        if (result_1 != null)
                        {
                            major_id_student = Convert.ToInt32(result_1);
                        }
                    }

                   
                }


                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving class information: {ex.Message}");
                }
                finally
                {
                    if (connect.State == ConnectionState.Open) { connect.Close(); }
                }
            }
        }

        private void Load_semester_for_class(int class_id)
        {
            try
            {
                string query = @"select distinct se.name_semester 
                from Student s
                join StudentSemesters ss on s.student_id = ss.student_id
                join Class c on s.class_id = c.class_id
                join Semester se on ss.semester_id = se.semester_id
                where c.class_id = @class_id";
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@class_id", class_id);
                  
                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();
                    // Clear existing items
                    list_semester.Items.Clear();

                    // Read each subject from the result set
                    while (reader.Read())
                    {
                        string name_semester = reader["name_semester"].ToString();
                  

                        list_semester.Items.Add(name_semester);
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

        private void list_semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_semester.SelectedIndex != -1)
            {
                // Extract semester information from the selected item
                string selected_semester = list_semester.SelectedItem.ToString();

                string name_semester = selected_semester;


                // Retrieve semester_id from database based on nameSemester and year
                /*try
                {*/
                string query = @"
                        SELECT semester_id
                        FROM Semester
                        WHERE name_semester = @name_semester";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@name_semester", name_semester);


                    if (connect.State == ConnectionState.Closed) { connect.Open(); }
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        semester_id = Convert.ToInt32(result);

                        // Load subjects for the selected semester
                        Load_subject_for_semester(semester_id);
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

        private void Load_subject_for_semester(int semester_id)
        {
            try
            {
                string query = @"select distinct sub.subject_name
                from Student s

                join StudentSemesters ss on s.student_id = ss.student_id
                join Class c on s.class_id = c.class_id
                join Semester se on ss.semester_id = se.semester_id
                join SemesterSubjects sesub on ss.number_semester_id = sesub.number_semester_id
                join Subject sub on sesub.subject_id = sub.subject_id
                where c.class_id = @class_id and se.semester_id = @semester_id and sub.major_id = @major_id";
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@class_id", class_id);
                    command.Parameters.AddWithValue("@semester_id", semester_id);
                    command.Parameters.AddWithValue("@major_id", major_id_student);

                    // Open the connection
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    // Execute the command and read the results
                    SqlDataReader reader = command.ExecuteReader();
                    // Clear existing items
                    list_subject_class.Items.Clear();

                    // Read each subject from the result set
                    while (reader.Read())
                    {
                        string name_subject = reader["subject_name"].ToString();
                        

                        list_subject_class.Items.Add(name_subject);
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

        private void list_subject_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_subject_class.SelectedIndex != -1)
            {
                
                // Extract semester information from the selected item
                string selected_subject = list_subject_class.SelectedItem.ToString();

                string name_subject = selected_subject;


                // Retrieve semester_id from database based on nameSemester and year
                /*try
                {*/
                string query = @"
                        SELECT subject_id, number_slot
                        FROM Subject
                        WHERE subject_name = @subject_name";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@subject_name", name_subject);

                    if (connect.State == ConnectionState.Closed) { connect.Open(); }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int subject_id = reader.GetInt32(0);
                            int number_slot = reader.GetInt32(1);

                            // Use the retrieved subject_id and number_slot as needed
                            // For example, assign them to class-level variables or call other methods
                            this.subject_id = subject_id;
                            this.number_slot = number_slot;
                            

                            
                        }
                    }
                }

                string query_teacher_id = @"
                        SELECT teacher_id
                        FROM TeacherSemester
                        WHERE class_id = @class_id and subject_id = @subject_id and semester_id = @semester_id";

                using (SqlCommand command = new SqlCommand(query_teacher_id, connect))
                {
                    command.Parameters.AddWithValue("@class_id", class_id);
                    command.Parameters.AddWithValue("@subject_id", subject_id);
                    command.Parameters.AddWithValue("@semester_id", semester_id);

                    if (connect.State == ConnectionState.Closed) { connect.Open(); }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string teacher_id = reader.GetString(0);
                            

                            // Use the retrieved subject_id and number_slot as needed
                            // For example, assign them to class-level variables or call other methods
                            this.teacher_id = teacher_id;
                           


                        }
                        else
                        {
                            // Handle the case where no teacher_id is found
                            MessageBox.Show("No teacher found for this class, subject, and semester combination.");
                            return; // Exit the method if no teacher is found
                        }
                    }
                }
                load_slot_to_datagridview(number_slot, subject_id, teacher_id, semester_id);
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

        private void load_slot_to_datagridview(int number_slot, int subject_id, string teacher_id, int semester_id)
        {
            dataGridView2.Rows.Clear(); // Clear existing rows
            for (int i = 1; i <= number_slot; i++)
            {
                string query = @"
SELECT TOP 1 attendance_date, time, room
FROM Attendance
WHERE subject_id = @subject_id
AND teacher_id = @teacher_id
AND semester_id = @semester_id
AND slot_number = @slot_number";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@subject_id", subject_id);
                    command.Parameters.AddWithValue("@teacher_id", teacher_id);
                    command.Parameters.AddWithValue("@semester_id", semester_id);
                    command.Parameters.AddWithValue("@slot_number", i);

                    if (connect.State == ConnectionState.Closed) { connect.Open(); }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int rowIndex = dataGridView2.Rows.Add();
                        DataGridViewRow newRow = dataGridView2.Rows[rowIndex];

                        if (reader.Read())
                        {
                            DateTime? attendanceDate = reader.IsDBNull(0) ? (DateTime?)null : reader.GetDateTime(0);
                            TimeSpan? time = reader.IsDBNull(1) ? (TimeSpan?)null : reader.GetTimeSpan(1);
                            string room = reader.IsDBNull(2) ? "not set" : reader.GetString(2);

                            newRow.Cells["slot_number"].Value = i;
                            newRow.Cells["date"].Value = attendanceDate.HasValue ? attendanceDate.Value.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd");
                            newRow.Cells["time"].Value = time.HasValue ? time.Value.ToString(@"hh\:mm") : "07:30";
                            newRow.Cells["room"].Value = room;
                        }
                        else
                        {
                            // No existing data, set default values
                            newRow.Cells["slot_number"].Value = i;
                            newRow.Cells["date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                            newRow.Cells["time"].Value = "07:30"; // Default time
                            newRow.Cells["room"].Value = "not set";
                        }
                    }
                }
            }
        }


        private void btn_set_Click(object sender, EventArgs e)
        {
            List<string> studentIds = GetStudentIds(); // This function fetches and returns the list of student IDs.
            int subjectId = this.subject_id; // Assuming this.subject_id is already set.
            string teacherId = this.teacher_id; // Assuming this.teacher_id is already set.
            int semesterId = this.semester_id; // Assuming this.semester_id is already set.

            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }

            foreach (string studentId in studentIds)
            {
                for (int i = 0; i < 10; i++)
                {
                    string attendanceDate = dataGridView2.Rows[i].Cells["date"].Value.ToString();
                    int slotNumber = Convert.ToInt32(dataGridView2.Rows[i].Cells["slot_number"].Value);
                    string time = dataGridView2.Rows[i].Cells["time"].Value.ToString();
                    string room = dataGridView2.Rows[i].Cells["room"].Value.ToString();

                    string query = @"
IF EXISTS (
    SELECT 1 
    FROM Attendance 
    WHERE student_id = @student_id 
    AND subject_id = @subject_id 
    AND slot_number = @slot_number 
    AND teacher_id = @teacher_id 
    AND semester_id = @semester_id
)
BEGIN
    UPDATE Attendance 
    SET attendance_date = @attendance_date, time = @time, room = @room 
    WHERE student_id = @student_id 
    AND subject_id = @subject_id 
    AND slot_number = @slot_number 
    AND teacher_id = @teacher_id 
    AND semester_id = @semester_id
END
ELSE
BEGIN
    INSERT INTO Attendance (student_id, subject_id, attendance_date, slot_number, time, room, status, teacher_id, semester_id)
    VALUES (@student_id, @subject_id, @attendance_date, @slot_number, @time, @room, @status, @teacher_id, @semester_id)
END";

                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.AddWithValue("@student_id", studentId);
                        command.Parameters.AddWithValue("@subject_id", subjectId);
                        command.Parameters.AddWithValue("@attendance_date", attendanceDate);
                        command.Parameters.AddWithValue("@slot_number", slotNumber);
                        command.Parameters.AddWithValue("@time", time);
                        command.Parameters.AddWithValue("@room", room);
                        command.Parameters.AddWithValue("@status", 2); // Set default status as "Absent"
                        command.Parameters.AddWithValue("@teacher_id", teacherId);
                        command.Parameters.AddWithValue("@semester_id", semesterId);

                        command.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Attendance records have been successfully processed.");

            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }



        private List<string> GetStudentIds()
        {
            List<string> studentIds = new List<string>();
            string query_student = "SELECT student_id FROM Student WHERE class_id = @class_id";

            using (SqlCommand command = new SqlCommand(query_student, connect))
            {
                command.Parameters.AddWithValue("@class_id", class_id);

                if (connect.State == ConnectionState.Closed) { connect.Open(); }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string student_id = reader.GetString(0);
                        studentIds.Add(student_id);
                    }
                }
            }

            return studentIds;
        }
    }
}
