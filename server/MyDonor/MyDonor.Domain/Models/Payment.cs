
namespace MyDonor.Domain.Models
{
    public  class Payment
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string CustomerId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Purchase))]
        public int PurchaseId { get; set; }

        public Purchase Purchase { get; set; }

        [Range(7,2)]
        public Decimal Amount { get; set; }
    }
}
