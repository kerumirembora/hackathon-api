﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{

    public class UserOutputDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}