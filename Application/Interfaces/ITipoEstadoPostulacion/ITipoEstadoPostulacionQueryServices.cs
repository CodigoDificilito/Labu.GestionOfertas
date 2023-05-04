using Application.DTO.Response;

namespace Application.Interfaces.ITipoEstadoPostulacion
{
    public interface ITipoEstadoPostulacionQueryServices
    {
        Task<IList<TipoEstadoPostulacionResponse>> GetTiposEstadoPogstulacion();

        Task<TipoEstadoPostulacionResponse> GetTipoEstadoPostulacionById(int id);
    }
}
