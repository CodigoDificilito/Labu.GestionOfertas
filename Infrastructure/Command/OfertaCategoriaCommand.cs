using Application.Interfaces.IOfertaCategoria;
using Domain.Entities;
using Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class OfertaCategoriaCommand : IOfertaCategoriaCommand
    {
        private readonly AppDbContext _context;

        public OfertaCategoriaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertOfertaCategoria(OfertaCategoria ofertaCategoria)
        {
            await _context.AddAsync(ofertaCategoria);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveOfertaCategoria(Guid ofertaId, int categoriaId)
        {
            var ofertaCategoria = _context.OfertaCategoria.SingleOrDefault(oc=>oc.OfertaId==ofertaId && oc.CategoriaId==categoriaId);

            if (ofertaCategoria == null)
            {
                return false;
            }
            _context.Remove(ofertaCategoria);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
