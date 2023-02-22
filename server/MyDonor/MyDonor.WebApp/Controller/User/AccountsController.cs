using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDonor.Service.Dto;
using System.Data;
using System.Security.Claims;

namespace MyDonor.WebApp.Controller.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsService _service;

        public AccountsController(AccountsService service)
        {
            _service = service;

        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostLogin(LoginDto dto)
        {
            var result = await _service.LoginAsync(dto);
            if (result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);

            
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProfile()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if( id !=null )
            {
                var user = await _service.GetProfileAsync(id);
                return Ok(user);
            }

            return NotFound(); 
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> EditUser(string id, ProfileEditDto dto)
        {
            var Response = await _service.GetProfileEditAsync(id, dto);
            if(Response.IsValid)
            {
                return BadRequest();
            }
            return Ok(Response.Result);
        }
    }
}
