using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.Services
{
    public class GoalService : IGoalService
    {
        IGoalTypeRepository _goalTypeRepository;

        public GoalService(IGoalTypeRepository goalTypeRepository)
        {
            _goalTypeRepository = goalTypeRepository;
        }

        public List<GoalType> GetGoalTypes()
        {
            return _goalTypeRepository.GetAll().ToList();
        }

    }
}
