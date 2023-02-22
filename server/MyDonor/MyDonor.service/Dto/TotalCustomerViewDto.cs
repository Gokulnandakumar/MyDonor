using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.Service.Dto
{
    public class TotalCustomerViewDto
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public TotalCustomerViewDto(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
