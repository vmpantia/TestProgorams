using App.Api.Models.Request;
using App.Common.DataAccess;
using App.Common.Models;
using App.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRequestService _request;
        private readonly IUtilityService _utility;
        private readonly AppDBContext _db;
        public DepartmentService(IRepositoryConnection connection, 
                                 IRequestService requestService,
                                 IUtilityService utilityService)
        {
            _db = connection.Context;
            _request = requestService;
            _utility = utilityService;
        }

        #region Public and Async Methods
        public async Task<IEnumerable<Department>> GetDepartmentsAsync(FilterRequest request)
        {
            IQueryable<Department> result;

            switch (request.Type)
            {
                case Constants.FILTER_DEPARTMENT_ID:
                    result = _db.Departments.Where(data => data.DepartmentId.Contains(request.Value));
                    break;
                case Constants.FILTER_DEPARTMENT_NAME:
                    result = _db.Departments.Where(data => data.Name.Contains(request.Value));
                    break;
                case Constants.FILTER_DEPARTMENT_MANAGER:
                    var manager = _db.Employees.Where(data => data.EmployeeId.Contains(request.Value) ||
                                                              data.FirstName.Contains(request.Value) ||
                                                              data.LastName.Contains(request.Value)).FirstOrDefault();

                    var managerInternalId = manager == null ? Guid.Empty : manager.InternalId;

                    result = _db.Departments.Where(data => data.ManagerInternalId.Equals(managerInternalId));
                    break;
                case Constants.FILTER_DEPARTMENT_STATUS:
                    var status = _utility.ConvertStringStatusToInt(request.Value);
                    result = _db.Departments.Where(data => data.Status.Equals(status));
                    break;
                default:
                    result = _db.Departments;
                    break;
            }

            if(request.DateFrom != null || request.DateTo != null)
            {
                result = result.Where(data => data.CreatedDate >= request.DateFrom &&
                                              data.CreatedDate <= request.DateTo);
            }

            return await result.Skip((request.PageNo - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
        }

        public async Task<string> SaveDepartmentAsync(DepartmentRequest request)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var requestDetails = _request.InsertRequest(_db, request); /*Insert Request Details*/
                    switch (request.FunctionID)
                    {
                        case Constants.FUNC_ID_NEW_DEPARTMENT_ADMIN:
                            InsertDepartment(request.department); /*Insert New Department Details*/
                            InsertDepartment_TRN(requestDetails.RequestId, request.department); /*Insert New Department TRN Details*/
                            break;
                        case Constants.FUNC_ID_UPDATE_DEPARTMENT_ADMIN:
                            UpdateDepartment(request.department); /*Update Department Details*/
                            InsertDepartment_TRN(requestDetails.RequestId, request.department); /*Insert Update Department TRN Details*/
                            break;
                    }
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return requestDetails.RequestId;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region Private Methods
        private void InsertDepartment(Department newDepartment)
        {
            newDepartment.InternalId = Guid.NewGuid();
            newDepartment.DepartmentId = GenerateDepartmentId();
            _db.Departments.Add(newDepartment);
        }
        private void UpdateDepartment(Department updatedDepartment)
        {
            var currentDepartment = _db.Departments.Find(updatedDepartment.InternalId);

            //Check if the department is exist
            if (currentDepartment == null)
                throw new Exception(Constants.ERROR_CANT_FIND_DEPARTMENT);

            currentDepartment.Name = updatedDepartment.Name;
            currentDepartment.ManagerInternalId = updatedDepartment.ManagerInternalId;
            currentDepartment.Status = updatedDepartment.Status;
            currentDepartment.ModifiedDate = updatedDepartment.ModifiedDate;
        }
        private void InsertDepartment_TRN(string requestId, Department department)
        {
            var newTrn = new Department_TRN
            {
                RequestId = requestId,
                InternalId = department.InternalId,
                DepartmentId = department.DepartmentId,
                Name = department.Name,
                ManagerInternalId = department.ManagerInternalId,
                Status = department.Status,
                CreatedDate = department.CreatedDate,
                ModifiedDate = department.ModifiedDate
            };
            _db.Add(newTrn);
        }
        private string GenerateDepartmentId()
        {
            var latestDepartmentId = string.Empty;
            var latestDepartment = _db.Departments.OrderByDescending(data => data.DepartmentId)
                                                  .ToList();

            latestDepartmentId = latestDepartment == null || latestDepartment.Count == 0 ? string.Empty : latestDepartment.First().DepartmentId;
            return _utility.GenerateId(latestDepartmentId, IdType.DepartmentId);
        }
        #endregion
    }
}
