namespace project.application.Commands.Request.Produto
{
    public class ProdutoFiltroRequest
    {
        public string Nome { get; set; }
        public decimal MinValor { get; set; }
        public decimal MaxValor { get; set; }

        public int Page { get; set; }
        public int Qtd { get; set; }
    }
}
