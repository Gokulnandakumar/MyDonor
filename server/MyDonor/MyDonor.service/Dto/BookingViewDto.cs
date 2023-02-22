
namespace MyDonor.service.Dto
{
    public class BookingViewDto
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string time { get; set; }

        public BookingViewDto(string? date, string? Time)
        {
            Date = date;
            time = Time;
        }
    }
}
