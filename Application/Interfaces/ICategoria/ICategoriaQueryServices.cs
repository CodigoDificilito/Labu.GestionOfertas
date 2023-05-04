using Application.DTO.Response;

namespace Application.Interfaces.IOferta
{
    public interface ICategoriaQueryServices
    {
        Task<List<CategoriaResponse>> GetOfertas();

        Task<bool> CategoriasExist(IList<int> categorias);

        Task<CategoriaResponse> GetCategoriaById(int categoriaId);

    }
}
