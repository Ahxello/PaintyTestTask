using PaintyTestTask.Data.Enum;
using PaintyTestTask.Interfaces;
using System;

namespace PaintyTestTask.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public ICollection<Friend> Friends { get; }

        private List<Picture> _pictures = new List<Picture>();
        public IReadOnlyCollection<Picture> Pictures => _pictures.AsReadOnly();
    }
}
