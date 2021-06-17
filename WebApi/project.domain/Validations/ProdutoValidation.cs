using FluentValidation;
using project.domain.Entities;

namespace project.domain.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    { 
        protected void ValidateName()
        {
            RuleFor(n => n.Nome)
                .NotNull()
                .NotEmpty().WithMessage("Product name is require")
                .Length(2, 150).WithMessage("The product name must have between 2 and 150 characters");    
        }

        protected void ValidateValue()
        {
            RuleFor(n => n.Valor)
               .NotNull()
               .GreaterThanOrEqualTo(0).WithMessage("Product value is required");
        }

        protected void ValidateImageUrl()
        {
            RuleFor(n => n.ImagemURL)
               .NotNull()
               .NotEmpty().WithMessage("Product Image URL is require")
               .MinimumLength(10).WithMessage("The product Image URL must have min 10 characters");
        }
    }
}
