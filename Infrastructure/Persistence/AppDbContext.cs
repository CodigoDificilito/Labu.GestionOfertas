using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<TipoEstadoPostulacion> TipoEstadoPostulacion { get; set; }
        public DbSet<Oferta> oferta { get; set; }
        public DbSet<OfertaCategoria> OfertaCategoria { get; set; }
        public DbSet<Postulacion> Postulacion { get; set; }

    }
}
