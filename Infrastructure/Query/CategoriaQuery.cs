using Application.Interfaces.ICategoria;
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
    public class CategoriaQuery : ICategoriaQuery
    {
        private readonly AppDbContext _context;

        public CategoriaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> GetCategoria(int categoriaId)
        {
            var categoria = await _context.Categoria.FindAsync(categoriaId);

            return categoria;
        }

        public async Task<List<Categoria>> GetListCategoria()
        {
            var categorias = await _context.Categoria.ToListAsync();

            return categorias;
        }
    }
}
