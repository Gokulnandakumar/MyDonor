
namespace MyDonor.service.Dto
{
    public class RegistrationCreateDto
    {
        public string Name { get; set; }
        public string email { get; set; }
        public int District { get; set; }
        public int BloodId { get; set; }
        public string Phone { get; set; }
        public DateTime Dob { get; set; }
        public Genders Gender { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
