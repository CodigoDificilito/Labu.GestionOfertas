using Application.DTO;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaQueryServices
    {
        Task<List<OfertaDTO>> GetOfertas();
        Task<List<OfertaDTO>> GetListOfertaByTitulo(string titulo);
        OfertaDTO GetOfertaById(Guid ofertaId);
    }
}
