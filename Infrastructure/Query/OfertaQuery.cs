using Application.DTO;
using Application.Interfaces.IOferta;
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
    public class OfertaQuery : IOfertaQuery
    {
        private readonly AppDbContext _context;

        public OfertaQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistOferta(Guid ofertaId)
        {
            var oferta = await _context.Oferta.FirstOrDefaultAsync(o => o.OfertaId == ofertaId);

            if (oferta == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Oferta>> GetListOferta()
        {
            var ofertas = _context.Oferta.ToList();

            return await Task.FromResult(ofertas);
        }

        public Task<List<Oferta>> GetListOfertaByEmpresa(int id)
        {
            var ofertas = _context.Oferta.Where(o => o.EmpresaId == id)
               .ToListAsync();

            return ofertas;
        }

        public async Task<List<Oferta>> GetListOfertaByTitulo(string titulo)
        {
            var ofertas = _context.Oferta
                .Where(o => o.Titulo.Contains(titulo))
                .ToList();

            return ofertas;
        }

        public Oferta GetOferta(Guid ofertaId)
        {
            var oferta = _context.Oferta.Find(ofertaId);

            return oferta;
        }

    }
}
