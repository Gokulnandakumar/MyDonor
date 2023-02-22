
namespace MyDonor.Domain.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Content { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string Name { get; set; }
    }
}
