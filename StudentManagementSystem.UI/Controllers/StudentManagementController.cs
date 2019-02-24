using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentManagementSystem.DTO;
using StudentManagementSystem.SERVICE;
using System.Threading.Tasks;

namespace StudentManagementSystem.UI.Controllers
{
    public class StudentManagementController : Controller
    {
        #region Private Properties
        private readonly IStudentManagementService studentManagementService = null;
        private readonly IOptions<ConnectionStringsDto> _serviceSettings;
        #endregion

        #region Constructor Injection
        public StudentManagementController(IOptions<ConnectionStringsDto> settings)
        {
            _serviceSettings = settings;
            studentManagementService = new StudentManagementService(settings.Value);
        } 
        #endregion

        #region public methods

        public async Task<ActionResult> GetStudentListAsync(int id)
        {
            var list = await studentManagementService.GetStudentListAsync(id);
            return Json(list);
        }

        public async Task<ActionResult> UpdateOrAddStudentAsync(StudentDto dto)
        {
            ResponseDto value = await studentManagementService.UpdateOrEditStudentAsync(dto);
            return Json(value);
        }

        public async Task<ActionResult> DeleteClassAsync(int id)
        {
            bool value = await studentManagementService.DeleteStudentAsync(id);
            return Json(value);
        }

        #endregion
    }
}
