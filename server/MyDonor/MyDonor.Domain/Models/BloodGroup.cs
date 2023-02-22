namespace MyDonor.Domain.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class BloodGroup
    {
        public int Id { get; set; }

        [StringLength(3)]
        public string Name { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}
