using Dapper;
using StudentManagementSystem.DAL.Extensions;
using StudentManagementSystem.DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.DAL
{
    internal class ClassManagementRepository : RepositoryBase, IClassManagementRepository
    {
        #region Constructor Injection
       /// <summary>
       /// Use abstract featured from repo base
       /// </summary>
       /// <param name="transaction"></param>
        public ClassManagementRepository(IDbTransaction transaction)
            : base(transaction)
        {

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Get the list of classes
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClassDto>> GetClassListAsync()
        {
            IDbConnection connection = Connection;
            string sql = string.Format("SELECT Id, ClassName, Location, TeacherName FROM ClassManagement");
            var data = await connection.QueryAsync<ClassDto>(sql, null, transaction: Transaction);
            return data == null ? new List<ClassDto>() : data.ToList();
        }

        /// <summary>
        /// Update the class details
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateClassAsync(ClassDto dto)
        {
            IDbConnection connection = Connection;
            dto.UpdateModifiedAuditFields();
            string sql = string.Format("UPDATE ClassManagement SET ClassName = '{0}', Location = '{1}', TeacherName = '{2}', LastUpdatedDate = '{3}' Where Id = {4}",
                dto.ClassName, dto.Location, dto.TeacherName,dto.LastUpdatedDate, dto.Id);
            int rows = await connection.ExecuteAsync(sql, null, transaction: Transaction);
            return true;
        }

        /// <summary>
        /// Add class to list
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddClassAsync(ClassDto dto)
        {
            IDbConnection connection = Connection;
            dto.UpdateCreatedAuditFields();
            string sql = string.Format("insert into ClassManagement (ClassName, Location, TeacherName, CreatedDate) values ('{0}', '{1}', '{2}', '{3}')", 
                dto.ClassName, dto.Location, dto.TeacherName, dto.CreatedDate);
            var data = await connection.ExecuteAsync(sql, null, transaction: Transaction);
            return true;
        }

        /// <summary>
        /// Delete the class from list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteClassAsync(int id)
        {
            IDbConnection connection = Connection;
            var data = new DynamicParameters();
            data.Add("@Id", id);
            int rows = await connection.ExecuteAsync("dbo.sp_deleteclass", data, transaction: Transaction,commandType: CommandType.StoredProcedure);
            return true;
        }

        #endregion
    }
}
