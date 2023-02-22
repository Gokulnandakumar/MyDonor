using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDonor.Service.Services;

namespace MyDonor.WebApp.Controller.Customer.Controllers
{
    public class CustomerBuyAndBookingsController : CustomersController
    {
        private readonly BookingAndBuyingService _service;

        public CustomerBuyAndBookingsController(BookingAndBuyingService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("Customer/BookingDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BookingDetailsAsync(BookingCreateDto dto)
        {
            var result = await _service.GetBookingsAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //[Authorize(Roles = "Customer")]
        [HttpPost("Customer/Booking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BookingAsync(BookingCreateDto dto)
        {
            var result = await _service.BookingsAsync(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("Customer/Buying")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> BuyingAsync(BuyCreateDto dto)
        {
            var result = await _service.BuyingBloodAsync(dto);
            if (result.IsValid)
            {
                return NotFound(result.Errors);
            }
            return Ok(result);
        }

        [HttpGet("appointment/{userid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> AppointmentDetails(string userid)
        {
            var result = await _service.GetAppointmentsAsync(userid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{userid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> AppointmentDelete(string userid) 
        {
            var result = await _service.DeleteAppointmentAsync(userid);
            if (result.IsValid)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("{bloodid}/{districtid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetStockAsync(int bloodid, int districtid)
        {
            var result = await _service.StockAsync(bloodid, districtid);
            if( result <= 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
