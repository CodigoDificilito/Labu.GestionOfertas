using Application.Interfaces.IOfertaCategoria;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class OfertaCategoriaQuery : IOfertaCategoriaQuery
    {
        private readonly AppDbContext _context;

        public OfertaCategoriaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OfertaCategoria>> GetListOfertaCategoriaByOfertaId(Guid ofertaId)
        {
            var ofertasCategoria = await _context.OfertaCategoria
                .Include(oc=>oc.Categoria)
                .Where(oc => oc.OfertaId == ofertaId)
                .ToListAsync();

            return ofertasCategoria;
        }
    }
}
