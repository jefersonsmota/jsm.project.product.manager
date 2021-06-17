using System;

namespace project.application.Commands.Response.Produto
{
    public class ProdutoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string ImagemUrl { get; set; }
    }
}
