using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.ITipoEstadoPostulacion
{
    public interface ITipoEstadoPostulacionQuery
    {
        Task<IList<TipoEstadoPostulacion>> GetListTipoEstadoPostulacion();
        Task<TipoEstadoPostulacion> GetTipoEstadoPostulacion(int tipoEstadoPostulacionId);
    }
}
