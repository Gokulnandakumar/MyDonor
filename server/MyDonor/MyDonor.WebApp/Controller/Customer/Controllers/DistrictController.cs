
using Microsoft.AspNetCore.Mvc;

namespace MyDonor.WebApp.Controller.Customer.Controllers
{
    public class DistrictController : CustomersController
    {
        private readonly DistrictService _service;

        public DistrictController(DistrictService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetDistrict()
        {
            var result = await _service.GetManagerDistrictAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("registration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetNotRegisteredDistrict()
        {
            var result = await _service.GetDistrictAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
