using Application.DTO;
using Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ITipoEstadoPostulacion
{
    public interface ITipoEstadoPostulacionQueryServices
    {
        Task<List<TipoEstadoPostulacionDTO>> GetTiposEstadoPogstulacion();

        Task<ResponseMessage> GetTipoEstadoPostulacionById(int id);
    }
}
