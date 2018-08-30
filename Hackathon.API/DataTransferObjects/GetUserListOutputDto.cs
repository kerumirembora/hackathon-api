using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class GetUserListOutputDto
    {
        public List<UserOutputDto> Users { get; set; }

        public GetUserListOutputDto()
        {
            Users = new List<UserOutputDto>();
        }
    }

}
