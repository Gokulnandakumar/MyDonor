
using MyDonor.Domain.Models;
using System.Data;

namespace MyDonor.service.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Seeding Roles

            var roles = new IdentityRole[]
            {
                new IdentityRole
                {
                  Id = "e2a85572-7b8c-4a95-a862-c557c3b2e869",
                  ConcurrencyStamp = "e2a85572-7b8c-4a95-a862-c557c3b2e869",
                  Name = "Admin",
                  NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                  Id = "e2a85572-7b8c-4a95-a862-c557c3b2e870",
                  ConcurrencyStamp = "e2a85572-7b8c-4a95-a862-c557c3b2e870",
                  Name = "Customer",
                  NormalizedName = "CUSTOMER"
                },
                new IdentityRole()
                {
                  Id = "e2a85572-7b8c-4a95-a862-c557c3b2e871",
                  ConcurrencyStamp = "e2a85572-7b8c-4a95-a862-c557c3b2e871",
                  Name = "Manager",
                  NormalizedName = "MANAGER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            #endregion

            #region Blood Groups

            var bloodgroup = new BloodGroup[]
            {
            new BloodGroup()
            {
                Id= 1,
                Name="A+"
            },
             new BloodGroup()
            {
                Id= 2,
                Name="A-"
            },
              new BloodGroup()
            {
                Id= 3,
                Name="B+"
            },
               new BloodGroup()
            {
                Id= 4,
                Name="AB+"
            },
                new BloodGroup()
            {
                Id= 5,
                Name="AB-"
            },
               new BloodGroup()
            {
                Id= 6,
                Name="B-"
            },
                new BloodGroup()
            {
                Id= 7,
                Name="O+"
            },
                 new BloodGroup()
            {
                Id= 8,
                Name="O-"
            },
            };
            builder.Entity<BloodGroup>().HasData(bloodgroup);
            #endregion

            #region Seeding Districts

            var District = new District[]
            {
                new()
                {
                    Id = 1,
                    Name = "Trivandrum"
                },
                new()
                {
                    Id = 2,
                    Name = "Kollam"
                },
                new()
                {
                    Id = 3,
                    Name = "Pathanamthitta"
                },
                new()
                {
                    Id = 4,
                    Name = "Kottayam"
                },
                new()
                {
                    Id = 5,
                    Name = "Ernakulam"
                },
                new()
                {
                    Id = 6,
                    Name = "Idukki"
                },
                new()
                {
                    Id = 7,
                    Name = "Alappuzha"
                },
                new()
                {
                    Id = 8,
                    Name = "Thrissur"
                },
                new()
                {
                    Id = 9,
                    Name = "Palakkad"
                },
                new()
                {
                    Id = 10,
                    Name = "Calicut"
                },
                new()
                {
                    Id = 11,
                    Name = "Wayanad"
                },
                new()
                {
                    Id = 12,
                    Name = "Kannur"
                },
                new()
                {
                    Id = 13,
                    Name = "Malappuram"
                },
                new()
                {
                    Id = 14,
                    Name = "Kasargod"
                }
            };
            builder.Entity<District>().HasData(District);

            #endregion

            builder.Entity<ApplicationUser>()
                .HasMany(m => m.Purchases)
                .WithOne(m => m.ApplicationUser)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<BloodGroup>()
                .HasMany(m => m.ApplicationUsers)
                .WithOne(m => m.BloodGroup)
                .OnDelete(DeleteBehavior.SetNull);
        }


        public DbSet<BloodGroup> BloodGroups { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<BloodBank> BloodBanks { get; set;}

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Purchase> Purchases { get; set;}

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Otp> Otps { get; set; }
    }
}
