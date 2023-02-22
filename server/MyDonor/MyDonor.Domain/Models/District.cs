
namespace MyDonor.Domain.Models
{
    public class District
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}
