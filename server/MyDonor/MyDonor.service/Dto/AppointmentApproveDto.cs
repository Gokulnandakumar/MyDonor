using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.Service.Dto
{
    public class AppointmentApproveDto
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public AppointmentApproveDto(int id, string date, string time)
        {
            Id = id;
            Date = date;
            Time = time;
        }
    }
}
