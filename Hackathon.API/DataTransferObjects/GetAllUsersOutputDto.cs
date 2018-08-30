using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class GetAllUsersOutputDto
    {
        public List<UserOutputDto> Users { get; set; }

        public GetAllUsersOutputDto()
        {
            Users = new List<UserOutputDto>();
        }
    }

    public class UserOutputDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
