using Application.DTO.Response;

namespace Application.Interfaces.IOferta
{
    public interface ICategoriaQueryServices
    {
        Task<IList<CategoriaResponse>> GetOfertas();

        Task<bool> CategoriasExist(IList<int> categorias);

        Task<CategoriaResponse> GetCategoriaById(int categoriaId);

    }
}
