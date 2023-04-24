using Application.DTO.Response;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaQueryServices
    {
        Task<ResponseMessage> GetListOfertaByTitulo(string titulo);
        Task<ResponseMessage> GetListOfertaByEmpresaId(int empresaId);
        Task<ResponseMessage> GetOfertaById(Guid ofertaId);
    }
}
