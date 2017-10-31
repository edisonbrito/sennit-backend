using FluentValidator;

namespace Sennit.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public int Id { get; private set; }
    }
}
