using Application.DTO;
using Application.DTO.Response;

namespace Application.Interfaces.IOferta
{
    public interface ICategoriaQueryServices
    {
        Task<List<CategoriaDTO>> GetOfertas();

        Task<ResponseMessage> GetCategoriaById(int categoriaId);

    }
}
