using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyDonor.Domain.Models;
using MyDonor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.Service.Services
{

    public class BookingAndBuyingService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public BookingAndBuyingService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signinManager,
            IConfiguration configuration,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _configuration = configuration;
            _db = db;
        }

        public async Task<ServiceResponse<List<BookingViewDto>>> GetBookingsAsync(BookingCreateDto dto)
        {
            var Response = new ServiceResponse<List<BookingViewDto>>();
            var managers = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.BloodId == null && m.DistrictId == dto.DistrictId);
            if (managers == null)
            {
                Response.AddError("Manager", "District does not have manager");
                return Response;
            }

            var bloodbank = _db.BloodBanks.Where(m => m.ManagerId == managers.Id).FirstOrDefault();
            var appointment = _db.Appointments.Where(m => m.BloodBankId == bloodbank.Id && m.Date == dto.Date).ToList().Select(m => new BookingViewDto(m.Date, m.Time)).ToList();

            if (!appointment.Any())
            {
                Response.AddError("appointments", "Appointment is empty");
                return Response;
            }
            Response.Result = appointment;
            return Response;
        }

        public async Task<ServiceResponse<string>> BookingsAsync(BookingCreateDto dto)
        {
            var Response = new ServiceResponse<string>();
            var userbooking = await _db.Appointments.FirstOrDefaultAsync(m => m.CustomerId == dto.userId);

            if (userbooking != null)
            {

                DateTime bookingDate = Convert.ToDateTime(userbooking.Date);
                DateTime futuredate = Convert.ToDateTime(dto.Date);
                int numberOfDays = (int)(bookingDate - futuredate).TotalDays;
                numberOfDays = Math.Abs(numberOfDays);
                if (numberOfDays < 90)
                {
                    Response.AddError("appointment", $"Last booking was {numberOfDays} Days ago.");
                    return Response;
                }
            }
            var managers = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.BloodId == null && m.DistrictId == dto.DistrictId);
            if (managers == null)
            {
                Response.AddError("Manager", "District does not have manager");
                return Response;
            }

            var bloodbank = _db.BloodBanks.Where(m => m.ManagerId == managers.Id).FirstOrDefault();
            if (bloodbank == null)
            {
                Response.AddError("Bloodbank", "bloodbank is not present");
                return Response;
            }
            var bookings = await _db.Appointments.FirstOrDefaultAsync(m => m.BloodBankId == bloodbank.Id && m.Date == dto.Date && m.Time == dto.time);
            if (bookings != null)
            {
                Response.AddError("booking", "booked");
                return Response;
            }
            var appointment = new Appointment
            {
                BloodBankId = bloodbank.Id,
                CustomerId = dto.userId,
                Date = dto.Date,
                Time = dto.time,
                Approved = false
            };
            await _db.Appointments.AddAsync(appointment);
            await _db.SaveChangesAsync();

            Response.Result = "booking and stock updated";
            return Response;
        }

        public async Task<ServiceResponse<BuyViewDto>> BuyingBloodAsync(BuyCreateDto dto)
        {
            var Response = new ServiceResponse<BuyViewDto>();
            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.Id == dto.UserId);
            if (user == null)
            {
                Response.AddError("user", "user does not exist");
                return Response;
            }
            var managers = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.BloodId == null && m.DistrictId == dto.DistrictId);
            if (managers == null)
            {
                Response.AddError("Manager", "manager does not exist");
                return Response;
            }

            var bloodbank = _db.BloodBanks.Where(m => m.ManagerId == managers.Id).FirstOrDefault();
            if (bloodbank == null)
            {
                Response.AddError("BloodBank", "BloodBank does not exist");
                return Response;
            }

            var stock = await _db.Stocks.FirstOrDefaultAsync(m => m.BloodGroupId == dto.BloodId && m.BloodBankId == bloodbank.Id);
            if (stock == null)
            {
                Response.AddError("Stock", "stock does not exist");
                return Response;
            }
            if (stock.Quantity < dto.Quantity)
            {
                Response.AddError("quantity", "quantity not present");
                return Response;
            }

            stock.Quantity -= dto.Quantity;
            var purchase = new Purchase
            {
                Quantity = dto.Quantity,
                CustomerId = dto.UserId,
                BloodId = dto.BloodId,
                DistrictId = dto.DistrictId,
                Date = DateTime.Today
            };
            await _db.AddAsync(purchase);
            _db.SaveChanges();
            if (purchase != null)
            {
                var payment = new Payment
                {
                    PurchaseId = purchase.Id,
                    Amount = dto.Amount,
                    CustomerId = dto.UserId,
                };
                await _db.AddAsync(payment);
            }
            else
            {
                Response.AddError("purchase", "purchase failed");
                return Response;
            }
            _db.SaveChanges();
            Response.Result = new()
            {
                status = "booking sucess"
            };
            return Response;
        }

        public async Task<ServiceResponse<AppointmentViewDto>> GetAppointmentsAsync(string userid)
        {
            var Response = new ServiceResponse<AppointmentViewDto>();
            var appointment = await _db.Appointments.FirstOrDefaultAsync(m => m.CustomerId == userid && m.Approved == false);
            if (appointment == null)
            {
                Response.AddError("Appointment", "appointment does not exist");
                return Response;
            }
            Response.Result = new()
            {
                Date = appointment.Date,
                Time = appointment.Time,
            };
            return Response;
        }

        public async Task<ServiceResponse<string>> DeleteAppointmentAsync(string userid)
        {
            var Response = new ServiceResponse<string>();
            var appointment = await _db.Appointments.FirstOrDefaultAsync(m => m.CustomerId == userid && m.Approved == false);
            if (appointment == null)
            {
                Response.AddError("Appointment", "appointment does not exist");
                return Response;
            }
            _db.Remove(appointment);
            _db.SaveChanges();
            Response.Result= "Deleted";
            return Response;
        }

        public async Task<int> StockAsync(int bloodid, int districtid)
        {
            var managers = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.BloodId == null && m.DistrictId == districtid);
            if (managers == null)
            {
                return 0;
            }

            var bloodbank = _db.BloodBanks.Where(m => m.ManagerId == managers.Id).FirstOrDefault();
            if (bloodbank == null)
            {
                return 0;
            }
            var val = await _db.Stocks.FirstOrDefaultAsync(m => m.BloodGroupId == bloodid && m.BloodBankId == bloodbank.Id);
            if (val != null)
            {
                return val.Quantity;
            }
            return 0;
        }
    }
}
