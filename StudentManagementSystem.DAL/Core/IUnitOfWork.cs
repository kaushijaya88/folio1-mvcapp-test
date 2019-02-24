using System;

namespace StudentManagementSystem.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IClassManagementRepository ClassManagementRepository { get; }

        IStudentManagementRepository StudentManagementRepository { get; }

        void Commit();
    }
}
