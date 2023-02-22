
namespace MyDonor.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }
        public District District { get; set; }

        public DateTime? Dob { get; set; }

        public Genders? Gender { get; set; }

        [ForeignKey(nameof(BloodGroup))]
        public int? BloodId { get; set; }
        public BloodGroup? BloodGroup { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public bool Verified { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
