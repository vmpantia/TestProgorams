using App.Api.Models.Request;
using App.Api.Services;
using App.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _position;
        private readonly IUtilityService _utility;
        public PositionController(IPositionService positionService,
                                    IUtilityService utilityService)
        {
            _position = positionService;
            _utility = utilityService;
        }

        [HttpPost("SavePosition")]
        public async Task<IActionResult> SavePositionAsync(PositionRequest request)
        {
            try
            {
                if (!_utility.IsRequestValid(request))
                    throw new Exception(Constants.ERROR_REQUEST_NOT_VALID);

                var result = await _position.SavePositionAsync(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
