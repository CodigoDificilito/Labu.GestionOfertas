using Application.Interfaces.IExperiencia;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class ExperienciaQuery : IExperienciaQuery
    {
        private readonly AppDbContext _context;

        public ExperienciaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Experiencia> GetExperiencia(int experienciaId)
        {
            var experiencia = await _context.Experiencia
                .FirstOrDefaultAsync(e => e.ExperienciaId == experienciaId);

            return experiencia;
        }

        public async Task<List<Experiencia>> GetListExperiencia()
        {
            return await _context.Experiencia
                .ToListAsync();
        }
    }
}
