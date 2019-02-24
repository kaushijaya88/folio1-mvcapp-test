using StudentManagementSystem.DTO;
using System.Threading.Tasks;

namespace StudentManagementSystem.SERVICE
{
    public interface IStudentManagementService
    {
        Task<StudentTableDto> GetStudentListAsync(int id);

        Task<ResponseDto> UpdateOrEditStudentAsync(StudentDto dto);

        Task<bool> DeleteStudentAsync(int id);
    }
}
