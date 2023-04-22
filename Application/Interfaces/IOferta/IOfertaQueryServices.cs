using Application.DTO;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaQueryServices
    {
        Task<List<OfertaDTO>> GetOfertas();
        Task<List<OfertaDTO>> GetListOfertaByTitulo(string titulo);
        Task<List<OfertaDTO>> GetListOfertaByEmpresaId(int empresaId);

        OfertaDTO GetOfertaById(Guid ofertaId);

        Task<bool> ExistOfertaById(Guid ofertaId);
    }
}
