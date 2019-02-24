using StudentManagementSystem.DAL;
using StudentManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.SERVICE
{
    public class ClassManagementService : IClassManagementService
    {
        private readonly IUnitOfWork unitofWork = null;

        #region Constructor Injection

        public ClassManagementService(ConnectionStringsDto connection) : this(new UnitOfWork(connection)) { }

        public ClassManagementService(IUnitOfWork _uow)
        {
            unitofWork = _uow;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get class list
        /// </summary>
        /// <returns></returns>
        public async Task<ClassTableDto> GetClassListAsync()
        {
            List<ClassDto> classList = new List<ClassDto>();
            try
            {
                classList = await unitofWork.ClassManagementRepository.GetClassListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                unitofWork.Dispose();
            }
            return new ClassTableDto() { Data = classList };
        }

        /// <summary>
        /// Update or add class
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateOrEditClassAsync(ClassDto dto)
        {
            var value = false;
            try
            { 
                if (dto.Id == 0)
                    value = await unitofWork.ClassManagementRepository.AddClassAsync(dto);
                else
                    value = await unitofWork.ClassManagementRepository.UpdateClassAsync(dto);
                unitofWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                unitofWork.Dispose();
            }
            return value;
        }

        /// <summary>
        /// Delete class
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteClassAsync(int id)
        {
            var value = false;
            try
            {
                value = await unitofWork.ClassManagementRepository.DeleteClassAsync(id);
                unitofWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                unitofWork.Dispose();
            }
            return value;
        }
        #endregion
    }
}
