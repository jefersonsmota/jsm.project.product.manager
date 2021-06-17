using AutoMapper;
using project.application.Commands.Request.Produto;
using project.application.Commands.Request.Usuario;
using project.application.Commands.Response.Produto;
using project.domain.Entities;

namespace project.application.Common.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.ShouldUseConstructor = ci => true;

            this.CreateMap<AtualizarProdutoRequest, Produto>()
                .ConstructUsing(p => new Produto(p.Nome, p.Valor, p.ImagemURL));

            this.CreateMap<CriarProdutoRequest, Produto>()
                .ConstructUsing(p => new Produto(p.Nome, p.Valor, p.ImagemURL));

            this.CreateMap<Produto, ProdutoResponse>()
                .ConstructUsing(p => new ProdutoResponse() { 
                    Id = p.Id, 
                    ImagemUrl = p.ImagemURL,
                    Nome = p.Nome,
                    Valor = p.Valor
                });

            this.CreateMap<LoginRequest, Usuario>()
                .ConstructUsing(l => new Usuario(l.Username, l.Password));
        }
    }
}
