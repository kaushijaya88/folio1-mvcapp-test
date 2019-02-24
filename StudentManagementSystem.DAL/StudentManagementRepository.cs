using Dapper;
using StudentManagementSystem.DAL.Extensions;
using StudentManagementSystem.DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static StudentManagementSystem.DTO.UtilityEnumDto;

namespace StudentManagementSystem.DAL
{
    internal class StudentManagementRepository : RepositoryBase, IStudentManagementRepository
    {
        #region Constructor Injection
        /// <summary>
        /// use Abstract features in RepositoryBase
        /// </summary>
        /// <param name="transaction"></param>
        public StudentManagementRepository(IDbTransaction transaction)
            : base(transaction)
        {

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Get the students list
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public async Task<List<StudentDto>> GetStudentListAsync(int classId)
        {
            IDbConnection connection = Connection;
            string sql = string.Format("SELECT Id, FirstName, LastName, Age, Gpa, ClassId FROM StudentManagement where ClassId = {0}",classId);
            var data = await connection.QueryAsync<StudentDto>(sql, null, transaction: Transaction);
            return data == null ? new List<StudentDto>() : data.ToList();
        }

        /// <summary>
        /// Get only id and lastname fields from students
        /// </summary>
        /// <returns></returns>
        public async Task<List<StudentDto>> GetStudentLastNameAsync()
        {
            IDbConnection connection = Connection;
            string sql = string.Format("SELECT Id, LastName FROM StudentManagement");
            var data = await connection.QueryAsync<StudentDto>(sql, null, transaction: Transaction);
            return data == null ? new List<StudentDto>() : data.ToList();
        }

        /// <summary>
        /// Update the student details
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateStudentAsync(StudentDto dto)
        {
            IDbConnection connection = Connection;
            dto.UpdateModifiedAuditFields();
            string sql = string.Format("UPDATE StudentManagement SET FirstName = '{0}', LastName = '{1}', Age = {2}, Gpa = {3}, LastUpdatedDate = '{4}' Where Id = {5}",
                dto.FirstName, dto.LastName, dto.Age,dto.Gpa, dto.LastUpdatedDate, dto.Id);
            int rows = await connection.ExecuteAsync(sql, null, transaction: Transaction);
            return new ResponseDto() { ResponseCode = ResponseCode.SUCCESS };
        }

        /// <summary>
        /// Add the student to list
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResponseDto> AddStudentAsync(StudentDto dto)
        {
            IDbConnection connection = Connection;
            dto.UpdateCreatedAuditFields();
            string sql = string.Format("insert into StudentManagement (FirstName, LastName, Age, Gpa,ClassId, CreatedDate) values ('{0}', '{1}', {2}, {3},{4}, '{5}')",
                dto.FirstName, dto.LastName, dto.Age, dto.Gpa,dto.ClassId, dto.CreatedDate);
            var data = await connection.ExecuteAsync(sql, null, transaction: Transaction);
            return new ResponseDto() { ResponseCode = ResponseCode.SUCCESS };
        }

        /// <summary>
        /// Delete the student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteStudentAsync(int id)
        {
            IDbConnection connection = Connection;
            string sql = string.Format("DELETE FROM StudentManagement where Id = {0}", id);
            int rows = await connection.ExecuteAsync(sql, null, transaction: Transaction);
            return true;
        }

        #endregion
    }
}
