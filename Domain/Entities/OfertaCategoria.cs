using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OfertaCategoria
    {
        public int OfertaCategoriaId { get; set; }
        public Guid OfertaId { get; set; }
        public int CategoriaId { get; set; }


        public Oferta Oferta { get; set; }
        public Categoria Categoria { get; set; }
    }
}
