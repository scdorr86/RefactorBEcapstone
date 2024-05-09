﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RefactorBEcapstone.Giftee.Requests;
using RefactorBEcapstone.Giftee.Responses;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Service;

namespace RefactorBEcapstone.Controllers
{
    [Route("api/v1/[controller]")]
    public class GifteeController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IGifteeService _gifteeService;
        private readonly UserManager<AppUser> _userManager;

        public GifteeController(IGifteeService gifteeservice, ILogger<GifteeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _gifteeService = gifteeservice;
            _userManager = userManager;
        }

        [HttpGet("giftees")]
        [ProducesResponseType(typeof(ApiResponse<List<GifteeResponse>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>), 500)]

        public async Task<IActionResult> GetAllGiftees()
        {
            try
            {
                var result = await _gifteeService.GetAllGiftees();
                return Ok(ApiResponse<List<GifteeResponse>>.SuccessResponse(result, "Success. All Giftees"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("Could not retrieve giftees, please try again."));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<GifteeResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>), 500)]

        public async Task<IActionResult> CreateGiftee([FromBody] GifteeRequest gifteeRequest)
        {
            try
            {
                var newGiftee = await _gifteeService.CreateGiftee(gifteeRequest);
                return Ok(ApiResponse<GifteeResponse>.SuccessResponse(newGiftee, "Giftee was successfully created"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("Could not create new giftee, please try again."));
            }
        }
    }
}
