using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDonor.Service.Dto
{
    public class AdminFeedbackViewDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }

        public AdminFeedbackViewDto(string content, string name)
        {
            Content = content;
            Name = name;
        }
    }
}
