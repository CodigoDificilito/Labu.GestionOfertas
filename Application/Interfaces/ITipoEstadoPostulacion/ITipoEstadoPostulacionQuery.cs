using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.ITipoEstadoPostulacion
{
    public interface ITipoEstadoPostulacionQuery
    {
        Task<List<TipoEstadoPostulacion>> GetListTipoEstadoPostulacion();
        Task<TipoEstadoPostulacion> GetTipoEstadoPostulacion(int tipoEstadoPostulacionId);
    }
}
