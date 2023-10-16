using PaintyTestTask.Interfaces;

namespace PaintyTestTask.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
    }
}
