using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.DTO
{
    public class ClassDto : AuditDto
    {
        public int Id { get; set; }

        public string ClassName { get; set; }

        public string Location { get; set; }

        public string TeacherName { get; set; }
    }
}
