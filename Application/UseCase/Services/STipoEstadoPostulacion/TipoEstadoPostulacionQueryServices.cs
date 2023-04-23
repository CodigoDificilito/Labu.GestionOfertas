using Application.DTO;
using Application.DTO.Response;
using Application.Interfaces.ITipoEstadoPostulacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Services.STipoEstadoPostulacion
{
    public class TipoEstadoPostulacionQueryServices : ITipoEstadoPostulacionQueryServices
    {
        private readonly ITipoEstadoPostulacionQuery _query;

        public TipoEstadoPostulacionQueryServices(ITipoEstadoPostulacionQuery query)
        {
            _query = query;
        }

        public async Task<List<TipoEstadoPostulacionDTO>> GetTiposEstadoPogstulacion()
        {
            var tiposEstadoPostulacion = await _query.GetListTipoEstadoPostulacion();
            var tiposEstadoPostulacionDTO = new List<TipoEstadoPostulacionDTO>();

            foreach (var c in tiposEstadoPostulacion)
            {
                var tipoEstadoPostulacionDTO = new TipoEstadoPostulacionDTO()
                {
                    Descripcion = c.Descripcion
                };
                tiposEstadoPostulacionDTO.Add(tipoEstadoPostulacionDTO);
            }

            return tiposEstadoPostulacionDTO;
        }

        public async Task<ResponseMessage> GetTipoEstadoPostulacionById(int id)
        {
            var tipoEstadoPostulacion = await _query.GetTipoEstadoPostulacion(id);

            if (tipoEstadoPostulacion != null)
            {
                return new ResponseMessage(200, new TipoEstadoPostulacionDTO()
                {
                    Descripcion = tipoEstadoPostulacion.Descripcion
                });
            }

            return new ResponseMessage(404, new { result = "La Tipo de estado no fue encontrado o no existe." });
        }
    }
}
