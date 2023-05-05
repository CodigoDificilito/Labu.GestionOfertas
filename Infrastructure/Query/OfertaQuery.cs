using Application.Interfaces.IOferta;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class OfertaQuery : IOfertaQuery
    {
        private readonly AppDbContext _context;

        public OfertaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Oferta>> GetListOfertaByFilters(string? descripcion, int? empresa, int? provincia, int page, string orden)
        {
            var ofertas = _context.Oferta
                .Include(o => o.Experiencia)
                .Include(o => o.NivelEstudio)
                .Include(o => o.OfertaCategoria)
                .ThenInclude(oc => oc.Categoria)
                .AsQueryable();

            if (!string.IsNullOrEmpty(descripcion))
            {
                ofertas = ofertas.Where(o => o.Titulo.Contains(descripcion) || o.Descripcion.Contains(descripcion));
            }

            if (empresa.HasValue)
            {
                ofertas = ofertas.Where(o => o.EmpresaId == empresa);
            }

            if (provincia.HasValue)
            {
                ofertas = ofertas.Where(o => o.ProvinciaId == provincia);
            }

            switch (orden.ToUpper())
            {
                case "ASC":
                    ofertas = ofertas.OrderBy(o => o.Fecha);
                    break;
                case "DESC":
                    ofertas = ofertas.OrderByDescending(o => o.Fecha);
                    break;
            }

            return await ofertas
                .Skip((page - 1) * 10)
                .Take(10)
                .Where(o => o.Status == true)
                .ToListAsync();
        }

        public async Task<Oferta> GetOferta(Guid ofertaId)
        {
            var oferta = await _context.Oferta
                .Include(e => e.Experiencia)
                .Include(ne => ne.NivelEstudio)
                .Include(oc => oc.OfertaCategoria)
                .ThenInclude(c => c.Categoria)
                .FirstOrDefaultAsync(o => o.OfertaId == ofertaId && o.Status == true);

            return oferta;
        }

    }
}
