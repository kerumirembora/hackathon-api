﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class GetAllGoalTypesOutputDto
    {
        public List<GoalTypeOutputDto> GoalTypes { get; set; }

        public GetAllGoalTypesOutputDto()
        {
            GoalTypes = new List<GoalTypeOutputDto>();
        }
    }

}
