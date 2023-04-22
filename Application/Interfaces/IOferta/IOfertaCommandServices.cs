using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaCommandServices
    {
        public Task<ResponseMessage> CreateOferta(AddOfertaRequest dto);
        public Task<ResponseMessage> DeleteOferta(Guid ofertaId);

    }
}
