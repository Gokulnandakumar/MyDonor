using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.Service.Dto
{
    public class StockViewDto
    {
        public int BloodGroup { get; set; }

        public int Quantity { get; set; }
        public StockViewDto(int quantity, int bloodgroup) 
        {
            this.Quantity = quantity;
            this.BloodGroup = bloodgroup;
        }
    }
}
