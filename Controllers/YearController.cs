using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using RefactorBEcapstone.List.Responses;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Service;
using RefactorBEcapstone.Year.Requests;
using RefactorBEcapstone.Year.Responses;

namespace RefactorBEcapstone.Controllers
{
    [Route("api/v1/[controller]")]
    public class YearController : BaseController
    {
        private readonly IChristmasYearService _christmasYearService;
        private readonly ILogger<YearController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public YearController(IChristmasYearService christmasYearService, ILogger<YearController> logger, UserManager<AppUser> userManager)
        {
            _christmasYearService = christmasYearService;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<YearResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>), 500)]

        public async Task<IActionResult> CreateYear([FromBody] CreateYearRequest yearRequest)
        {
            try
            {
                var result = await _christmasYearService.CreateChristmasYear(yearRequest);
                return Ok(ApiResponse<YearResponse>.SuccessResponse(result, "Year was created successfully"));

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("Could not create christmas year. please try again."));
            }
        }

        [HttpGet("Years")]
        [ProducesResponseType(typeof(ApiResponse<List<YearResponse>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>), 500)]

        public async Task<IActionResult> GetYears()
        {
            try
            {
                var result = await _christmasYearService.GetAllYears();
                return Ok(ApiResponse<List<YearResponse>>.SuccessResponse(result, "Success"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("Could not return Years. Please try again"));
            }
        }

        [HttpGet("{yearId}")]
        [ProducesResponseType(typeof(ApiResponse<YearResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>), 500)]

        public async Task<IActionResult> GetYearById(int yearId)
        {
            if (yearId <=0) { return BadRequest(ApiResponse<bool>.BadRequest("Invalid Year Id.")); }

            try
            {
                var result = await _christmasYearService.GetYearById(yearId);
                return Ok(ApiResponse<YearResponse>.SuccessResponse(result, "Success."));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("Could not retrieve Christmas Year."));
            }
        }

        [HttpPatch("update/{yearId}")]
        [ProducesResponseType(typeof(ApiResponse<YearResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>), 500)]

        public async Task<IActionResult> UpdateYear([FromRoute]int yearId, [FromBody]UpdateYearRequest updateYearRequest)
        {
            if (updateYearRequest == null || yearId <= 0) { return BadRequest(ApiResponse<bool>.BadRequest("Invalid Year Id or Year does not exist.")); }

            try
            {
                var result = await _christmasYearService.UpdateYear(yearId, updateYearRequest);
                return Ok(ApiResponse<YearResponse>.SuccessResponse(result, "Christmas Year was updated."));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("Could not update Christmas Year, please try again."));
            }
        }

        [HttpDelete("{yearId}")]
        [ProducesResponseType(typeof(ApiResponse<YearResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>), 500)]

        public async Task<IActionResult> SoftDeleteYear(int yearId)
        {
            if (yearId <= 0 || yearId == 0) return BadRequest(ApiResponse<bool>.BadRequest("Invalid Year Id. Please Try Again."));
            
            try
            {
                var result = await _christmasYearService.SoftDeleteYear(yearId);
                return Ok(ApiResponse<YearResponse>.SuccessResponse(result, "Success."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("Christmas Year could not be deleted. Please try again."));
            }
        }
    }
}
