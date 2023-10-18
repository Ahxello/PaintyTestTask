using PaintyTestTask.Interfaces;

namespace PaintyTestTask.Entities
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
