using App.Api.Models.Request;
using App.Api.Services;
using App.Common.Models;
using App.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _department;
        private readonly IUtilityService _utility;
        public DepartmentController(IDepartmentService departmentService, IUtilityService utilityService)
        {
            _department = departmentService;
            _utility = utilityService;
        }
        [HttpPost("GetDepartment")]
        public async Task<IActionResult> GetDepartmentsAsync(FilterRequest request)
        {
            try
            {
                if (!_utility.IsRequestValid(request))
                    throw new Exception(Constants.ERROR_REQUEST_NOT_VALID);

                var result = await _department.GetDepartmentsAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveDepartment")]
        public async Task<IActionResult> SaveDepartmentAsync(DepartmentRequest request)
        {
            try
            {
                if (!_utility.IsRequestValid(request))
                    throw new Exception(Constants.ERROR_REQUEST_NOT_VALID);

                var result = await _department.SaveDepartmentAsync(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
