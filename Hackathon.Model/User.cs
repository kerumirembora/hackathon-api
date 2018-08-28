using System;

namespace Hackathon.Model
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}
