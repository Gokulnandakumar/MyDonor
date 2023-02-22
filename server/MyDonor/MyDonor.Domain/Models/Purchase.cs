
namespace MyDonor.Domain.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string? CustomerId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(BloodGroup))]
        public int BloodId { get; set; }
        public BloodGroup BloodGroup { get; set; }

        [ForeignKey(nameof(District))]
        public int? DistrictId { get; set; }

        public District? District { get; set; }
    }
}
