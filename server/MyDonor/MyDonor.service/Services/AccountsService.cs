using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyDonor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace MyDonor.service.Services
{
    public class AccountsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public AccountsService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signinManager,
            IConfiguration configuration,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _configuration = configuration;
            _db = db;
        }

        public async Task<ServiceResponse<RegisterViewDto>> CreateAsync(RegistrationCreateDto dto)
        {
            var Response = new ServiceResponse<RegisterViewDto>();
            var useremail = await _userManager.FindByEmailAsync(dto.email);
            if (useremail != null)
            {
                Response.AddError("Account", "An account with this email exist.");
                return Response;
            }
            var user = new ApplicationUser
            {
                Name = dto.Name,
                Email = dto.email,
                PhoneNumber = dto.Phone,
                Gender = dto.Gender,
                Dob = dto.Dob,
                Address = dto.Address,
                DistrictId = dto.District,
                BloodId = dto.BloodId,
                UserName = Guid.NewGuid().ToString(),
                Verified = false
            };

            var userstatus = await _userManager.CreateAsync(user, dto.Password);
            if (!userstatus.Succeeded)
            {
                Response.AddError("", "Failed to Add User");
                return Response;
            }
            await _userManager.AddToRoleAsync(user, "Customer");
            Response.Result = new RegisterViewDto
            {
                Id = user.Id,
                Name = dto.Name,
                Email = dto.email,
            };
            int status = EmailGenerate(dto.email, dto.Name);
            if (status != 0)
            {
                var otpnumber = new Otp()
                {
                    ApplicationUserId = user.Id,
                    OtpNumber = status
                };
                _db.Add(otpnumber);
                _db.SaveChanges();
            }
            return Response;
        }

        public async Task<bool> CheckOtpValidityAsync(string userid, int otp)
        {
            var userotp = await _db.Otps.FirstOrDefaultAsync(m => m.ApplicationUserId == userid && m.OtpNumber == otp);
            if (userotp == null)
            {
                return false;
            }
            var status = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.Id == userid);
            if (status == null)
            {
                return false;
            }
            status.Verified = true;
            _db.SaveChanges();
            return true;
        }
        public async Task<ServiceResponse<string>> LoginAsync(LoginDto dto)
        {

            var response = new ServiceResponse<string>();
            if(dto.Email == "admin@gmail.com" && dto.Password == "Admin@123")
            {
                response.Result = GenerateTokenForAdmin(dto);
                return response;
            }

            var status = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.Email == dto.Email && m.Verified == true);
            if (status == null)
            {
                response.AddError("user", "email not verified");
            }
            //var user = await _userManager.FindByEmailAsync(dto.Email);
            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(m =>m.Email == dto.Email);
            if (user == null)
            {
                response.AddError(nameof(dto.Email), "An account with this email does not exist.");
                return response;
            }

            var signin = await _signinManager.CheckPasswordSignInAsync(user, dto.Password, true);
            if (signin.Succeeded)
            {
                response.Result = GenerateToken(user);
                return response;
            }

            // If the signin failed, generate error messages.
            if (signin.IsLockedOut)
                response.AddError("", "Account locked.");
            else if (signin.IsNotAllowed)
                response.AddError("", "You are not allowed to signin.");
            else
                response.AddError("", "Invalid email/password.");

            return response;
        }

        public async Task<ProfileViewDto> GetProfileAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return new ProfileViewDto
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Adress = user.Address
            };
        }

        public async Task<ServiceResponse<ProfileEditViewDto>> GetProfileEditAsync(string id, ProfileEditDto dto)
        {
            var Result = new ServiceResponse<ProfileEditViewDto>();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                Result.AddError("edit", "edit unsuccessfull");
                return Result;
            }
            user.Address = dto.Adress;
            user.PhoneNumber = dto.Phone;
            user.Name = dto.Name;

            var profile = await _userManager.UpdateAsync(user);
            if (!profile.Succeeded)
            {
                Result.AddError("user", "edit unsucessfull");
            }

            Result.Result = new ProfileEditViewDto
            {
                Name = user.Name,
                Adress = user.Address,
                Phone = user.PhoneNumber
            };
            return Result;
        }

        public async Task<ServiceResponse<ManagerCreateViewDto>> ManagerCreateAsync(ManagerCreateDto dto)
        {
            var Response = new ServiceResponse<ManagerCreateViewDto>();
            var Manager = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.BloodId == null && m.DistrictId == dto.District);
            if (Manager != null)
            {
                Response.AddError("Manager", "manger exists");
                return Response;
            }

            var ManagerUser = new ApplicationUser
            {
                UserName = Guid.NewGuid().ToString(),
                Email = dto.Email,
                DistrictId = dto.District,
                Verified = true
            };

            var res = await _userManager.CreateAsync(ManagerUser, dto.Password);
            if (!res.Succeeded)
            {
                Response.AddError("", "manager does not created");
            }

            await _userManager.AddToRoleAsync(ManagerUser, "Manager");

            var bloodBank = new BloodBank
            {
                ManagerId = ManagerUser.Id
            };
            await _db.BloodBanks.AddAsync(bloodBank);
            await _db.SaveChangesAsync();

            Response.Result = new()
            {
                Email = ManagerUser.Email
            };
            return Response;
        }

        public async Task<ServiceResponse<string>> UpdateManager(ManagerUpdateDto dto)
        {
            var Response = new ServiceResponse<string>();
            var manager = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.DistrictId == dto.District && m.BloodId == null);
            if( manager == null )
            {
                Response.AddError("manager", "manager does not exist");
                return Response;
            }
            manager.Email = dto.Email;
            _db.SaveChanges();
            Response.Result = "updated sucessfully";
            return Response;
        }
        private string GenerateToken(ApplicationUser user)
        {
            var role = _userManager.GetRolesAsync(user)
                .GetAwaiter()
                .GetResult()
                .First();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, $"{user.Name}"),
                new Claim(ClaimTypes.Role, role),
                new Claim("userrole", role)
            };

            string issuer = _configuration["Jwt:Issuer"];
            string audience = _configuration["Jwt:Audience"];
            string key = _configuration["Jwt:Key"];

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(signingKey, "HS256");

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateTokenForAdmin(LoginDto user)
        {

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, "Admin"),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim("userrole", "Admin")
            };

            string issuer = _configuration["Jwt:Issuer"];
            string audience = _configuration["Jwt:Audience"];
            string key = _configuration["Jwt:Key"];

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(signingKey, "HS256");

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private int EmailGenerate(string email, string name)
        {
            // creating the message in which we store message details
            MimeMessage message = new MimeMessage();

            //details of sender
            message.From.Add(new MailboxAddress("Admin", "mydonorservice@gmail.com"));

            // details of reciever
            message.To.Add(new MailboxAddress(name, email));

            Random Random = new Random();
            var otp = Random.Next(000000, 999999);

            // email subject
            message.Subject = "MyDonor OTP for Registration";

            //body of email
            message.Body = new TextPart("plain")
            {
                Text = @$" Welcome to MyDonor Blood Donating Service.
                OTP for MyDonor website is - {otp}.
                We Are Here To Help You With Any Kind Of Support
                In Case Of Emergency.Feel Free To Contact Us."
            };

            string Email = _configuration["Email:Id"];
            string password = _configuration["Email:Password"];

            // creating a mail client
            SmtpClient client = new SmtpClient();

            try
            {
                // connecting to gmail smtp and using the 465 port and ssl enabled is true.
                client.Connect("smtp.gmail.com", 587);

                // Authenticate sender using email and password.
                client.Authenticate(Email, password);
                client.Send(message);
                return otp;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                // disconnect the client
                client.Disconnect(true);

                // dispose client object
                client.Dispose();
            }
        }
    }
}
