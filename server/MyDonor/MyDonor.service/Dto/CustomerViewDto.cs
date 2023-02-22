using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.Service.Dto
{
    public class CustomerViewDto
    {
        public string Name{ get; set; }

        public string PhoneNumber { get; set; }

        public int? Blood { get; set; }

        public CustomerViewDto(string name, string phone, int? bloodid)
        {
            Name = name;
            PhoneNumber = phone;
            Blood = bloodid;
        }
    }
}
