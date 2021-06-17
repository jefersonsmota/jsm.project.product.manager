using System;

namespace project.application.Commands.Request.Produto
{
    public class AtualizarProdutoRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string  ImagemURL { get; set; }
    }
}
