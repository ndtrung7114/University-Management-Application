using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    public enum Type_job
    {
        Fulltime,
        Parttime
        
    }
    internal class Admin : Person
    {
        private SqlConnection connect = new SqlConnection(DatabaseConfig.ConnectionString);
        // Private fields
        
        private string admin_id;
        private Type_job? type_job;
        private float? salary;
        private float? working_hour;

        // Public properties with getters and setters
        

        

        public string Admin_id
        {
            get { return admin_id; }
            set { admin_id = value; }
        }

        public Type_job? Type_job
        {
            get { return type_job; }
            set { type_job = value; }
        }

        public float? Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public float? Working_hour
        {
            get => working_hour; set { working_hour = value; }
        }

        // Constructor to initialize properties
        public Admin(string name, int telephone, string email, Role role, string gender, DateTime dob, string image, string admin_id, Type_job? type_job = null, float? salary = null, float? working_hour = null)
            : base(name, telephone, email, role, gender, dob, image)
        {
            Admin_id = admin_id;
            Type_job = type_job;
            Salary = salary;
            Working_hour = working_hour;
            
        }
    }
}
