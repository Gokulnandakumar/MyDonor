
namespace MyDonor.Domain.Models
{
    public class BloodBank
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string ManagerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
