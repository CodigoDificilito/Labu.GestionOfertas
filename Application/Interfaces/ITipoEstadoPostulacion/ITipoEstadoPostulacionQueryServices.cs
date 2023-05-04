using Application.DTO.Response;

namespace Application.Interfaces.ITipoEstadoPostulacion
{
    public interface ITipoEstadoPostulacionQueryServices
    {
        Task<List<TipoEstadoPostulacionResponse>> GetTiposEstadoPogstulacion();

        Task<TipoEstadoPostulacionResponse> GetTipoEstadoPostulacionById(int id);
    }
}
