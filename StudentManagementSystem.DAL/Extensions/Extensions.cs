using System;
using System.Reflection;

namespace StudentManagementSystem.DAL.Extensions
{
    public static class Extensions
    {
        public static void UpdateModifiedAuditFields<T>(this T dto)
        {
            Type t = dto.GetType();
            PropertyInfo lastUpdatedDate = t.GetProperty("LastUpdatedDate");
            lastUpdatedDate.SetValue(dto, DateTime.UtcNow);
        }

        public static void UpdateCreatedAuditFields<T>(this T dto)
        {
            Type t = dto.GetType();
            PropertyInfo createdDate = t.GetProperty("CreatedDate");
            createdDate.SetValue(dto, DateTime.UtcNow);
        }
    }
}
