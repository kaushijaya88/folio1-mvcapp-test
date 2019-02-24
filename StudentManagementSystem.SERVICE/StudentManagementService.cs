using StudentManagementSystem.DAL;
using StudentManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StudentManagementSystem.DTO.UtilityEnumDto;

namespace StudentManagementSystem.SERVICE
{
    public class StudentManagementService : IStudentManagementService
    {
        #region Private Properties
        private readonly IUnitOfWork unitofWork = null;

        private const string duplicateLastNameErrorMessage = "Last Name already exists"; 
        #endregion

        #region Constructor Injection

        public StudentManagementService(ConnectionStringsDto connection) : this(new UnitOfWork(connection)) { }

        public StudentManagementService(IUnitOfWork _uow)
        {
            unitofWork = _uow;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get student list
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public async Task<StudentTableDto> GetStudentListAsync(int classId)
        {
            List<StudentDto> studentList = new List<StudentDto>();
            try
            {
                studentList = await unitofWork.StudentManagementRepository.GetStudentListAsync(classId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                unitofWork.Dispose();
            }
            return new StudentTableDto() { Data = studentList };
        }

        /// <summary>
        /// Update or edit student
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateOrEditStudentAsync(StudentDto dto)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var lastNamesList = await unitofWork.StudentManagementRepository.GetStudentLastNameAsync();
                bool value = validateLastNameIfExists(dto, lastNamesList);
                if (value)
                {
                    response = new ResponseDto() { ResponseCode = ResponseCode.FAILED, ErrorMessage = duplicateLastNameErrorMessage };
                }
                else
                {
                    response = dto.Id == 0 ? await unitofWork.StudentManagementRepository.AddStudentAsync(dto) :
                       await unitofWork.StudentManagementRepository.UpdateStudentAsync(dto);
                }
                unitofWork.Commit();
            }
            catch (Exception ex)
            {
                return new ResponseDto() { ResponseCode = ResponseCode.FAILED, ErrorMessage = ex.Message };
            }
            finally
            {
                unitofWork.Dispose();
            }
            return response;
        }

        /// <summary>
        /// Delete student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var value = false;
            try
            {
                value = await unitofWork.StudentManagementRepository.DeleteStudentAsync(id);
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

        #region Private Methods

        /// <summary>
        /// logic to check surnames/lastnames must be unique across classes
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="students"></param>
        /// <returns></returns>
        private bool validateLastNameIfExists(StudentDto dto, List<StudentDto> students)
        {
            bool value = false;

            if (dto.Id == 0)
            {
                int count = students.Where(n => n.LastName.ToUpper() == dto.LastName.ToUpper()).Count();
                value = count > 0;
            }
            else
            {
                StudentDto item = students.Where(n => n.LastName.ToUpper() == dto.LastName.ToUpper()).FirstOrDefault();
                value = item == null ? false : item.Id != dto.Id;
            }
            return value;
        }

        #endregion
    }
}
