using MyDonor.Domain.Models;
using MyDonor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.Service.Services
{
    public class ManagerService
    {
        private readonly ApplicationDbContext _db;

        public ManagerService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceResponse<List<StockViewDto>>> GetStocks(string managerid)
        {
            var Response = new ServiceResponse<List<StockViewDto>>();
            var bloodbank = _db.BloodBanks.Where(m => m.ManagerId == managerid).FirstOrDefault();
            if (bloodbank == null)
            {
                Response.AddError("Bloodbank", "bloodbank is not present");
                return Response;
            }

            Response.Result = _db.Stocks.Where(m => m.BloodBankId == bloodbank.Id).Select(m =>new StockViewDto(m.Quantity,m.BloodGroupId)).ToList();

            return Response;
        }

        public async Task<ServiceResponse<List<CustomerViewDto>>> GetCustomers(string managerid)
        {
            var Response = new ServiceResponse<List<CustomerViewDto>>();
            var manager = _db.ApplicationUsers.Where(m => m.Id == managerid).FirstOrDefault();
            if (manager == null)
            {
                Response.AddError("Manager", "Manager is not present");
                return Response;
            }

            Response.Result = _db.ApplicationUsers.Where(m =>m.BloodId != null).Select(m => new CustomerViewDto(m.Name,m.PhoneNumber,m.BloodId)).ToList();

            return Response;
        }

        public async Task<ServiceResponse<string>> ValidateCustomerAppointments(int appointmentid)
        {
            var Response = new ServiceResponse<string>();
            var appointment = _db.Appointments.Where(m => m.Id == appointmentid && m.Approved == false).FirstOrDefault();
            if (appointment == null)
            {
                Response.AddError("Appointment", "appointment is not present");
                return Response;
            }

            var customer = _db.ApplicationUsers.Where(m => m.Id == appointment.CustomerId).FirstOrDefault();
            if (customer == null)
            {
                Response.AddError("customer", "customer is not present");
                return Response;
            }
            var stocks = await _db.Stocks.FirstOrDefaultAsync(m => m.BloodBankId == appointment.BloodBankId && m.BloodGroupId == customer.BloodId);
            if (stocks == null)
            {
                var stock = new Stock
                {
                    BloodGroupId = customer.BloodId ??= 0,
                    Quantity = 1,
                    BloodBankId = appointment.BloodBankId ??=0,
                };
                await _db.Stocks.AddAsync(stock);
            }
            if (stocks?.Quantity >= 0)
            {
                stocks.Quantity = stocks.Quantity + 1;
            }
            appointment.Approved = true;
            _db.SaveChanges();
            Response.Result = "sucess";
            return Response;
        }

       public async Task<ServiceResponse<List<AppointmentApproveDto>>> GetCustomerAppointments(string managerid)
        {
            var Response = new ServiceResponse<List<AppointmentApproveDto>>();
            var Bloodbank = _db.BloodBanks.Where(m => m.ManagerId == managerid).FirstOrDefault();   
            if (Bloodbank == null)
            {
                Response.AddError("bloodbank", "bloodbank does not exist");
                return Response;
            }
            Response.Result = await _db.Appointments.Where(m => m.BloodBankId == Bloodbank.Id && m.Approved == false).Select(m => new AppointmentApproveDto(m.Id, m.Date,m.Time)).ToListAsync();
            return Response;
        }

        public async Task<ServiceResponse<List<ManagerBookingViewDto>>> GetCustomerBookings(string managerid)
        {
            var Response = new ServiceResponse<List<ManagerBookingViewDto>>();
            var manager = _db.ApplicationUsers.Where(m => m.Id == managerid).FirstOrDefault();
            if (manager == null)
            {
                Response.AddError("manager", "manager does not exist");
                return Response;
            }
            Response.Result = await _db.Purchases.Where(m => m.DistrictId == manager.DistrictId).Select(m => new ManagerBookingViewDto(m.Date, m.Quantity)).ToListAsync();
            return Response;
        }
    }
}
