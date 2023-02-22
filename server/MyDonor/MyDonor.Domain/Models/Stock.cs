
namespace MyDonor.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int BloodGroupId { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(BloodBank))]
        public int BloodBankId { get; set; }

        public BloodBank BloodBank { get; set; }

    }
}
