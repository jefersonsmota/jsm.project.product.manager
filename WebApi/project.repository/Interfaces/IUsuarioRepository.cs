using project.domain.Entities;
using System.Threading.Tasks;

namespace project.repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Autenticacao> login(Usuario usuario);
    }
}
