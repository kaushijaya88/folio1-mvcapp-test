using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.DTO
{
    public class StudentDto : AuditDto
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public int Age { get; set; }

        public double Gpa { get; set; }
    }
}
