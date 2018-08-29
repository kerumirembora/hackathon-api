using Hackathon.API.DataTransferObjects;
using Hackathon.Model;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.API.Mappers
{
    public static class GoalTypesMappingExtension
    {
        public static GetAllGoalTypesOutputDto ToGetAllGoalTypesOutputDto(this List<GoalType> goalTypes)
        {
            if (goalTypes == null)
                return new GetAllGoalTypesOutputDto();

            return new GetAllGoalTypesOutputDto
            {
                GoalTypes = goalTypes.Select(n => new GoalTypeOutputDto
                {
                    Id = n.Id,
                    Description = n.Description,
                    MetricDescription = n.MetricDescription,
                    Name = n.Name
                }).ToList()
            };


        }
    }
}
