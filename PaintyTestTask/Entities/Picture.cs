using PaintyTestTask.Interfaces;
using System;

namespace PaintyTestTask.Entities
{
    public class Picture : Entity
    {
        public string Title { get; set; }
        public User Owner { get; set; }
    }
}
