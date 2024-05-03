using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RefactorBEcapstone.Gift.Requests;
using RefactorBEcapstone.Gift.Responses;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Service;
using System.Net.Mime;

namespace RefactorBEcapstone.Controllers
{
    [Route("api/v1/[controller]")]
    public class GiftController : BaseController
    {
        private readonly IGiftService _giftService;
        private readonly ILogger _logger;
        private readonly UserManager<AppUser> _userManager;

        public GiftController(IGiftService giftservice,  ILogger<GiftController> logger, UserManager<AppUser> userManager)
        {
            _giftService = giftservice;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet("gifts")]
        [ProducesResponseType(typeof(ApiResponse<List<GiftResponse>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>),500)]

        public async Task<IActionResult> GetAllGifts()
        {
            try
            {
                var result = await _giftService.GetAllGifts();
                return Ok(ApiResponse<List<GiftResponse>>.SuccessResponse(result, "Success"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("Could not return Gifts. Please try again"));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<GiftResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>),500)]

        public async Task<IActionResult> CreateGift([FromBody] GiftRequest request)
        {
            try
            {
                var result = await _giftService.CreateGift(request);
                return Ok(ApiResponse<GiftResponse>.SuccessResponse(result, "Gift was created successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("Gift could not be created."));
            }
        }
    }
}
