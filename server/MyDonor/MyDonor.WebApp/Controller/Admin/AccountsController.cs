using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDonor.service.Services;
using MyDonor.Service.Dto;

namespace MyDonor.WebApp.Controller.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsService _service;

        private readonly FeedbackService _feedback;

        public AccountsController(AccountsService service, FeedbackService feeddback)
        {
            _service = service;
            _feedback = feeddback;
        }

        [HttpPost("Manager")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ManagerAsync(ManagerCreateDto dto)
        {
            var manager = await _service.ManagerCreateAsync(dto);
            if( manager.IsValid)
            {
                return BadRequest(manager.Errors);
            }
            return Ok(manager);
        }

        [HttpGet("Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FeedbackView()
        {
            var result = _feedback.FeedbacksAsync();
            if( result == null )
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("ManagerUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ManagerUpdate(ManagerUpdateDto dto)
        {
            var result = await _service.UpdateManager(dto);
            if( result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
