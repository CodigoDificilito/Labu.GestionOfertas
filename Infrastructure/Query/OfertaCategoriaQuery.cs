using Application.Interfaces.IOfertaCategoria;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class OfertaCategoriaQuery : IOfertaCategoriaQuery
    {
        private readonly AppDbContext _context;

        public OfertaCategoriaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistOfertaCategoriaByOfertaId(Guid ofertaId, IList<int> lista)
        {
            var ofertasCategoria = await _context.OfertaCategoria
                .Include(oc=>oc.Categoria)
                .Where(oc => oc.OfertaId == ofertaId)
                .ToListAsync();

            foreach (var item in ofertasCategoria)
            {
                if (!lista.Contains(item.CategoriaId))
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}
