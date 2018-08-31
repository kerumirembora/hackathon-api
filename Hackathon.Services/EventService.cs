using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class EventService : IEventService
    {
        IEventRepository _eventRepository;
        IGoalSubscriberRepository _goalSubscriberRepository;
        
        public EventService(IEventRepository eventRepository, IGoalSubscriberRepository goalSubscriberRepository)
        {
            _eventRepository = eventRepository;
            _goalSubscriberRepository = goalSubscriberRepository;
        }

        public async Task AddEventToAllUserSubscribers(int userGoalId, string eventDescription)
        {
            var subscribers = _goalSubscriberRepository.GetAllByUserGoal(userGoalId);
            foreach(var subscriber in subscribers)
            {
                if (subscriber.Events == null)
                    subscriber.Events = new List<Event>();

                subscriber.Events.Add(new Event {
                    CreationDate = DateTime.Now,
                    Description = eventDescription                    
                });

                await _goalSubscriberRepository.Update(subscriber.Id, subscriber);
            }
        }
    }
}
