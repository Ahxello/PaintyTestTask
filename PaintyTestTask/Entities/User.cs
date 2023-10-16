using PaintyTestTask.Interfaces;
using System;

namespace PaintyTestTask.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        private List<Picture> _pictures = new List<Picture>();
        public IReadOnlyCollection<Picture> Pictures => _pictures.AsReadOnly();
    }
}
