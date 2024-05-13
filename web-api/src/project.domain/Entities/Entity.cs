using jsm.product.manager.domain.Exceptions;
using jsm.product.manager.domain.Exceptions.BaseValidator;
using System;

namespace jsm.product.manager.domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
        DateTime CreatedDateUtc { get; }
        DateTime? LastUpdateDataUtc { get; }
        bool IsDeleted { get; }
        DateTime? DeleteDateUtc { get; }
    }

    public abstract class Entity : EntityValidator<EntityValidationException>, IEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedDateUtc = DateTime.UtcNow;
            IsDeleted = false;
        }
        public virtual Guid Id { get; private set; }
        public virtual DateTime CreatedDateUtc { get; private set; }
        public virtual DateTime? LastUpdateDataUtc { get; private set; }
        public virtual bool IsDeleted { get; private set; }
        public virtual DateTime? DeleteDateUtc { get; private set; }

        protected void Update()
        {
            LastUpdateDataUtc = DateTime.UtcNow;
        }
    }
}
