using Domain.Entities;

namespace Application.Interfaces.ICategoria
{
    public interface ICategoriaQuery
    {
        Task<IList<Categoria>> GetListCategoria();
        Task<Categoria> GetCategoria(int categoriaId);
    }
}
