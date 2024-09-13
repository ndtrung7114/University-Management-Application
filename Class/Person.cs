using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace coursework

{
    internal class Person
    {
        private Role role;
        private string name;
        private string email;
        private int telephone;
        private string gender;
        private DateTime dob;
        private string image;

        public string Name { get { return name; } set {  name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int Telephone { get {  return telephone; } set {  telephone = value; } }
        public Role Role { get { return role; } set { role = value; } }

        public string Gender { get { return gender; } set { gender = value; } }
        public DateTime DOB { get { return dob; } set { dob = value; } }
        public string Image { get { return image; } set { image = value; } }

        public Person(string name, int telephone, string email, Role role, string gender, DateTime dob, string image)
        {
            this.name = name;
            this.telephone = telephone;
            this.email = email;
            this.role = role;
            this.gender = gender;
            this.dob = dob;
            this.image = image;
          
           
        }
    }

}
