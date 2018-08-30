using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class EventOutputDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }

}
