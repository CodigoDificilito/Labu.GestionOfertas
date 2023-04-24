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

        public Task<List<Oferta>> GetListOfertaByEmpresa(int id)
        {
            var ofertas = _context.Oferta.Where(o => o.EmpresaId == id)
               .ToListAsync();

            return ofertas;
        }

        public async Task<List<Oferta>> GetListOfertaByTitulo(string titulo)
        {
            var ofertas = await _context.Oferta
                .Where(o => o.Titulo.Contains(titulo))
                .ToListAsync();

            return ofertas;
        }

        public async Task<Oferta> GetOferta(Guid ofertaId)
        {
            var oferta = await _context.Oferta.FindAsync(ofertaId);

            return oferta;
        }

    }
}
