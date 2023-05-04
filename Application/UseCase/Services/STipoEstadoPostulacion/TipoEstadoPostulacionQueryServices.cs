using Application.DTO.Response;
using Application.Interfaces.ITipoEstadoPostulacion;

namespace Application.UseCase.Services.STipoEstadoPostulacion
{
    public class TipoEstadoPostulacionQueryServices : ITipoEstadoPostulacionQueryServices
    {
        private readonly ITipoEstadoPostulacionQuery _query;

        public TipoEstadoPostulacionQueryServices(ITipoEstadoPostulacionQuery query)
        {
            _query = query;
        }

        public async Task<List<TipoEstadoPostulacionResponse>> GetTiposEstadoPogstulacion()
        {
            var tiposEstadoPostulacion = await _query.GetListTipoEstadoPostulacion();
            var response = new List<TipoEstadoPostulacionResponse>();

            foreach (var c in tiposEstadoPostulacion)
            {
                var dto = new TipoEstadoPostulacionResponse()
                {
                    Id = c.TipoEstadoPostulacionId,
                    Descripcion = c.Descripcion
                };
                response.Add(dto);
            }
            return response;
        }

        public async Task<TipoEstadoPostulacionResponse> GetTipoEstadoPostulacionById(int id)
        {
            var tipoEstadoPostulacion = await _query.GetTipoEstadoPostulacion(id);

            if (tipoEstadoPostulacion == null)
            {
                return null;
            }

            return new TipoEstadoPostulacionResponse
            {
                Id = tipoEstadoPostulacion.TipoEstadoPostulacionId,
                Descripcion = tipoEstadoPostulacion.Descripcion
            };
        }
    }
}
