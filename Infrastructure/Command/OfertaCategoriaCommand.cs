using Application.Interfaces.IOfertaCategoria;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class OfertaCategoriaCommand : IOfertaCategoriaCommand
    {
        private readonly AppDbContext _context;

        public OfertaCategoriaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> InsertOfertaCategoria(OfertaCategoria ofertaCategoria)
        {
            await _context.AddAsync(ofertaCategoria);
            await _context.SaveChangesAsync();

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(ci => ci.CategoriaId == ofertaCategoria.CategoriaId);

            return categoria;
        }

        public async Task<bool> RemoveOfertaCategoria(Guid ofertaId, int categoriaId)
        {
            var ofertaCategoria = _context.OfertaCategoria.SingleOrDefault(oc=>oc.OfertaId==ofertaId && oc.CategoriaId==categoriaId);

            if (ofertaCategoria == null)
            {
                return false;
            }

            ofertaCategoria.Status = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
