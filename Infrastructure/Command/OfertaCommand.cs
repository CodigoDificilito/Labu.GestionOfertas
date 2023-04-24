using Application.Interfaces.IOferta;
using Domain.Entities;
using Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class OfertaCommand : IOfertaCommand
    {
        private readonly AppDbContext _context;

        public OfertaCommand(AppDbContext context)
        {
            _context = context;
        }
        public async Task InsertOferta(Oferta oferta)
        {
            _context.Add(oferta);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveOferta(Guid ofertaId)
        {
            var oferta = await _context.Oferta.FindAsync(ofertaId);

            if (oferta == null)
            {
                return false;
            }
            _context.Remove(oferta);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
