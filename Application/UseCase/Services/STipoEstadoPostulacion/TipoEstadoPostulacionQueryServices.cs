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

        public async Task<IList<TipoEstadoPostulacionResponse>> GetTiposEstadoPogstulacion()
        {
            var tiposEstadoPostulacion = await _query.GetListTipoEstadoPostulacion();
            var response = new List<TipoEstadoPostulacionResponse>();

            foreach (var item in tiposEstadoPostulacion)
            {
                response.Add(new TipoEstadoPostulacionResponse()
                {
                    Id = item.TipoEstadoPostulacionId,
                    Descripcion = item.Descripcion
                });
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
