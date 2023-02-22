using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyDonor.WebApp.Controller.User
{
    [Area("User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllerBase : ControllerBase
    {
    }
}
