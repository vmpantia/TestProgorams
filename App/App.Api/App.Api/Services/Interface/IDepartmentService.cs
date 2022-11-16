using App.Api.Models.Request;
using App.Common.Models;

namespace App.Api.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync(FilterRequest request);
        Task<string> SaveDepartmentAsync(DepartmentRequest request);
    }
}