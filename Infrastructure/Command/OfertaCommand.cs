using Application.Interfaces.IOferta;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class OfertaCommand : IOfertaCommand
    {
        private readonly AppDbContext _context;

        public OfertaCommand(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Oferta> InsertOferta(Oferta oferta)
        {
            await _context.AddAsync(oferta);
            await _context.SaveChangesAsync();

            var ofertaWithPlusData = await _context.Oferta
                .Include(e => e.Experiencia)
                .Include(ne => ne.NivelEstudio)
                .FirstOrDefaultAsync(o => o.OfertaId==oferta.OfertaId);

            return ofertaWithPlusData;
        }

        public async Task<Oferta> RemoveOferta(Guid ofertaId)
        {
            var oferta = await _context.Oferta
                .Include(o => o.Experiencia)
                .Include(o => o.NivelEstudio)
                .Include(o => o.OfertaCategoria)
                .ThenInclude(oc => oc.Categoria)
                .FirstOrDefaultAsync(o => o.OfertaId == ofertaId && o.Status == true);

            if (oferta != null)
            {
                oferta.Status = false;
                await _context.SaveChangesAsync();
            }
            
            return oferta;
        }
    }
}
