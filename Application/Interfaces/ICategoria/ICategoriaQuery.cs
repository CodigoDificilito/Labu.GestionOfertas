using Domain.Entities;

namespace Application.Interfaces.ICategoria
{
    public interface ICategoriaQuery
    {
        Task<List<Categoria>> GetListCategoria();
        Task<Categoria> GetCategoria(int categoriaId);
    }
}
