using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.service.Dto
{
    public class BuyCreateDto
    {
        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public int DistrictId { get; set; }

        public int BloodId { get; set; }

        public string UserId { get; set; }


    }
}
