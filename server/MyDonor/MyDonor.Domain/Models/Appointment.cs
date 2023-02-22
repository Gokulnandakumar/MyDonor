
namespace MyDonor.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int? BloodBankId { get; set; }
        public BloodBank? BloodBank { get; set; }


        [ForeignKey(nameof(ApplicationUser))]
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public bool Approved { get; set; }
    }

}
