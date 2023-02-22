using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.Service.Dto
{
    public class ManagerBookingViewDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Quantity { get; set; }

        public ManagerBookingViewDto(DateTime date, int quantity)
        {
            Date = date;
            Quantity = quantity;
        }
    }
}
