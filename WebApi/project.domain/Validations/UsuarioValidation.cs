using FluentValidation;
using project.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.domain.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        protected void ValidateUsername()
        {
            RuleFor(n => n.Username)
                .NotNull()
                .NotEmpty().WithMessage("Username is require")
                .Length(2, 150).WithMessage("The username must have between 2 and 50 characters");
        }

        protected void ValidatePassword()
        {
            RuleFor(n => n.Password)
               .NotNull()
               .Length(8, 16).WithMessage("The password must have between 8 and 16 characters");
        }
    }
}
