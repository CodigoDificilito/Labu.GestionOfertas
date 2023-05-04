using Application.Interfaces.INivelEstudio;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class NivelEstudioQuery : INivelEstudioQuery
    {
        private readonly AppDbContext _context;

        public NivelEstudioQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NivelEstudio>> GetListNivelEstudio()
        {
            return await _context.NivelEstudio
                .ToListAsync();
        }

        public async Task<NivelEstudio> GetNivelEstudio(int id)
        {
            var nivelEstudio = await _context.NivelEstudio
                .FirstOrDefaultAsync(ne => ne.NivelEstudioId == id);
            
            return nivelEstudio;
        }
    }
}
