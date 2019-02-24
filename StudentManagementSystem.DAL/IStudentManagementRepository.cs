using StudentManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DAL
{
    public interface IStudentManagementRepository
    {
        Task<List<StudentDto>> GetStudentListAsync(int classId);

        Task<ResponseDto> UpdateStudentAsync(StudentDto dto);

        Task<ResponseDto> AddStudentAsync(StudentDto dto);

        Task<bool> DeleteStudentAsync(int id);

        Task<List<StudentDto>> GetStudentLastNameAsync();
    }
}
