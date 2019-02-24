using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentManagementSystem.DTO;
using StudentManagementSystem.SERVICE;
using System.Threading.Tasks;

namespace StudentManagementSystem.UI.Controllers
{
    public class ClassManagementController : Controller
    {
        #region Private Properties
        private readonly IClassManagementService classManagementService = null;
        private readonly IOptions<ConnectionStringsDto> _connectionSettings;
        #endregion

        #region Constructor Injection
        public ClassManagementController(IOptions<ConnectionStringsDto> settings)
        {
            _connectionSettings = settings;
            classManagementService = new ClassManagementService(settings.Value);
        } 
        #endregion

        #region public methods

        /// <summary>
        /// Get the list of classes
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetClassListAsync()
        {
            var list = await classManagementService.GetClassListAsync();
            return Json(list);
        }

        /// <summary>
        /// Update or add the class
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateOrAddClassAsync(ClassDto  dto)
        {
            bool value = await classManagementService.UpdateOrEditClassAsync(dto);
            return Json(value);
        }

        /// <summary>
        /// Delete the class
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteClassAsync(int id)
        {
            bool value = await classManagementService.DeleteClassAsync(id);
            return Json(value);
        } 

        #endregion
    }
}
