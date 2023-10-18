using PaintyTestTask.Interfaces;
using System;

namespace PaintyTestTask.Entities
{
    public class Picture : Entity
    {
        public User Owner { get; set; }
        public string Path { get; set; }
    }
}
