using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.Service.Dto
{
    public class ManagerCreateDto
    {
        public int District { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? ManagerId { get; set; }
    }
}
