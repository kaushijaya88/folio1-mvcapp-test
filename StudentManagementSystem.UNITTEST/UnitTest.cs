using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementSystem.DTO;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.UNITTEST
{
    /// <summary>
    /// associated with validation logic for adding last name of student or updating last name
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod_WhenAddingStudentCheckLastNameExists()
        {
            var list = GetStudentList();
            StudentDto dto = new StudentDto() { Id = 0, LastName = "Jayamini" };

            if (dto.Id == 0)
                CollectionAssert.DoesNotContain(list.Select(x => x.LastName.ToUpper()).ToList(), dto.LastName.ToUpper());
        }

        [TestMethod]
        public void TestMethod_TestMethod_WhenAddingStudentCheckLastNameNotExists()
        {
            var list = GetStudentList();
            StudentDto dto = new StudentDto() { Id = 0, LastName = "Saman" };

            if (dto.Id == 0)
                CollectionAssert.DoesNotContain(list.Select(x => x.LastName.ToUpper()).ToList(), dto.LastName.ToUpper());
        }

        [TestMethod]
        public void TestMethod_WhenUpdatingStudentCheckLastNameExists()
        {
            var list = GetStudentList();
            StudentDto dto = new StudentDto() { Id = 3, LastName = "Jayamini" };

            var student = list.Where(s => s.LastName == dto.LastName).FirstOrDefault();

            if (student != null)
                Assert.Equals(dto.Id, student.Id);
        }

        [TestMethod]
        public void TestMethod_WhenUpdatingStudentCheckLastNameNotExists()
        {
            var list = GetStudentList();
            StudentDto dto = new StudentDto() { Id = 3, LastName = "Rahal" };

            var student = list.Where(s => s.LastName == dto.LastName).FirstOrDefault();

            if (student != null)
                Assert.Equals(dto.Id, student.Id);
        }

        [TestMethod]
        public void TestMethod_WhenUpdatingStudentCheckLastAndNull()
        {
            var list = GetStudentList();
            StudentDto dto = new StudentDto() { Id = 3, LastName = "Chiatri" };

            var student = list.Where(s => s.LastName == dto.LastName).FirstOrDefault();
            Assert.IsNotNull(student);
        }

        private List<StudentDto> GetStudentList()
        {
            List<StudentDto> students = new List<StudentDto>();
            students.Add(new StudentDto() {Id=1, FirstName = "Saman", LastName = "Shane" });
            students.Add(new StudentDto() {Id=2, FirstName = "Chamara", LastName = "Perera" });
            students.Add(new StudentDto() {Id=3, FirstName = "Kaushalya", LastName = "Jayamini" });
            students.Add(new StudentDto() {Id=4, FirstName = "Kolitha", LastName = "Katulanda" });
            return students;
        }
    }
}
