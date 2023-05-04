using Application.Interfaces.ICategoria;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class CategoriaQuery : ICategoriaQuery
    {
        private readonly AppDbContext _context;

        public CategoriaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> GetCategoria(int categoriaId)
        {
            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(c => c.CategoriaId == categoriaId);

            return categoria;
        }

        public async Task<List<Categoria>> GetListCategoria()
        {
            return await _context.Categoria
                .ToListAsync();
        }
    }
}
