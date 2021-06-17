using project.domain.Validations;

namespace project.domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public string ImagemURL { get; private set; }

        public Produto(string nome, decimal valor, string imagemUrl)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.ImagemURL = imagemUrl;

            this.Validation = new ProdutoValidation().Validate(this);
        }

        protected Produto() { }


        public override bool IsValid()
        {
            return Validation.IsValid;
        }
    }
}
