using FluentValidation.Results;
using System;

namespace project.domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public ValidationResult Validation { get; protected set; }

        public abstract bool IsValid();
    }
}
