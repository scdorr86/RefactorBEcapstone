using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using RefactorBEcapstone.List.Requests;
using RefactorBEcapstone.List.Responses;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Service;
using System.Formats.Asn1;

namespace RefactorBEcapstone.Controllers
{
    [Route("api/v1/[controller]")]
    public class ListController : BaseController
    {
        private readonly IListService _listService;
        private readonly ILogger _logger;
        private readonly UserManager<AppUser> _userManager;

        public ListController(IListService listService, ILogger logger, UserManager<AppUser> userManager)
        {
            _listService = listService;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ListResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<bool>), 500)]

        public async Task<IActionResult> CreateList([FromBody] CreateListRequest listRequest)
        {
            try
            {
                var result = await _listService.CreateChristmasList(listRequest);
                return Ok(ApiResponse<ListResponse>.SuccessResponse(result, "List was created successfully"));
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ApiResponse<bool>.Unknown("List was not created, please try again"));
            }
        }
    }
}
