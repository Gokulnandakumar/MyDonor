using Microsoft.AspNetCore.Mvc;

namespace MyDonor.WebApp.Controller.Customer.Controllers
{
    public class FeedbacksController: CustomersController
    {
        private readonly FeedbackService _service;

        public FeedbacksController(FeedbackService service)
        {
            _service = service;
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> FeedbackCreateAsync(string id, FeedbackCreateDto dto)
        {
            var result = await _service.FeedbackAsync(id, dto);
            return Ok(result);
        }

        [HttpGet("customers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> TotalCustomersAsync()
        {
            var result = await _service.TotalCustomerView();
            if(result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
