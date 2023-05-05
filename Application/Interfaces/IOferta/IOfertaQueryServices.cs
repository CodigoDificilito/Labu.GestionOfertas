using Application.DTO.Response;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaQueryServices
    {
        Task<OfertaResponse> GetOfertaById(Guid ofertaId);

        Task<IList<OfertaResponse>> GetListOfertaByQuerys(string? descripcion, int? empresa, int? provincia, int page, string fecha);
    }
}
