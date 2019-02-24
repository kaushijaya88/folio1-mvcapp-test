using StudentManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.SERVICE
{
    public interface IClassManagementService
    {
        Task<ClassTableDto> GetClassListAsync();

        Task<bool> UpdateOrEditClassAsync(ClassDto dto);

        Task<bool> DeleteClassAsync(int id);
    }
}
