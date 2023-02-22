namespace MyDonor.service.Services
{
    public class DistrictService
    {
        private readonly ApplicationDbContext _db;

        public DistrictService(ApplicationDbContext db)
        {
            _db = db;
        }
        public  async Task<List<DistrictViewDto>> GetManagerDistrictAsync()
        {
            var district = await _db.ApplicationUsers.Where(m => m.BloodId == null).Select(c => new DistrictViewDto(c.District)).ToListAsync();
            return district;
        }

        public async Task<List<DistrictViewDto>> GetDistrictAsync()
        {
            //var district = await _db.ApplicationUsers.Where(m => m.Roles == "Manager").Select(c => new DistrictViewDto(c.District)).ToListAsync();

            var res = _db.Districts
                .Select(m=> new DistrictViewDto(m));
            return res.ToList();
        }
    }
}
