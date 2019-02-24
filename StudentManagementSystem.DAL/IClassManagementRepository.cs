using StudentManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DAL
{
    public interface IClassManagementRepository
    {
        Task<List<ClassDto>> GetClassListAsync();

        Task<bool> UpdateClassAsync(ClassDto dto);

        Task<bool> AddClassAsync(ClassDto dto);

        Task<bool> DeleteClassAsync(int id);
    }
}
