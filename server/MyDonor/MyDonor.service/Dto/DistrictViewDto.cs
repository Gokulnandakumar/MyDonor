
namespace MyDonor.service.Dto
{
    public class DistrictViewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DistrictViewDto(District d)
        {
            Id = d.Id;
            Name = d.Name;
        }
    }
}
