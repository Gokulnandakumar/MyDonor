
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDonor.service.Dto
{
    public class BookingCreateDto
    {
        public int DistrictId { get; set; }

        public string Date { get; set; }

        public string? time { get; set; }

        public string userId { get; set; }

    }
}
