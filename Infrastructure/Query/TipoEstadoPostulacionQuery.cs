using Application.Interfaces.ITipoEstadoPostulacion;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class TipoEstadoPostulacionQuery : ITipoEstadoPostulacionQuery
    {
        private readonly AppDbContext _context;

        public TipoEstadoPostulacionQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TipoEstadoPostulacion>> GetListTipoEstadoPostulacion()
        {
            var tiposEstadoPostulacion = await _context.TipoEstadoPostulacion.ToListAsync();

            return tiposEstadoPostulacion;
        }

        public async Task<TipoEstadoPostulacion> GetTipoEstadoPostulacion(int tipoEstadoPostulacionId)
        {
            var tipoEstadoPostulacion = await _context.TipoEstadoPostulacion.FindAsync(tipoEstadoPostulacionId);

            return tipoEstadoPostulacion;
        }
    }
}
