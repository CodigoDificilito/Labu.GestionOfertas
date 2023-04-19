using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }

        public IList<OfertaCategoria> OfertaCategoria { get; set; }
    }
}
