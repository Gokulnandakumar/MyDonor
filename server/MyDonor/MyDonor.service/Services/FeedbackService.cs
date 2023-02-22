using MyDonor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.service.Services
{
    public class FeedbackService
    {
        private readonly ApplicationDbContext _db;

        public FeedbackService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceResponse<FeedbackViewDto>> FeedbackAsync(string id, FeedbackCreateDto dto)
        {
            var Response = new ServiceResponse<FeedbackViewDto>();
            var user = await _db.ApplicationUsers.FindAsync(id);
            if (user == null)
            {
                Response.AddError("user", "user does not exist");
                return Response;
            }
            var feedback = new Feedback
            {
                ApplicationUserId = id,
                Content = dto.Content,
                Name = user.Name
            };
            _db.Feedbacks.Add(feedback);
            await _db.SaveChangesAsync();

            Response.Result = new FeedbackViewDto
            {
                Id = feedback.Id,
                Content = feedback.Content,
                Name = user.Name
            };
            return Response;
        }

        public ServiceResponse<List<AdminFeedbackViewDto>> FeedbacksAsync()
        {
            var Response = new ServiceResponse<List<AdminFeedbackViewDto>>();
            Response.Result = _db.Feedbacks.Select(m => new AdminFeedbackViewDto(m.Content,m.Name)).ToList();
            return Response;
        }

        public async Task<ServiceResponse<List<TotalCustomerViewDto>>> TotalCustomerView()
        {
            var Response = new ServiceResponse<List<TotalCustomerViewDto>>();
            Response.Result = await _db.ApplicationUsers.Where(m=> m.BloodId != null).Select(m => new TotalCustomerViewDto(m.Name,m.Email)).ToListAsync();
            return Response;
        }
    }
}
