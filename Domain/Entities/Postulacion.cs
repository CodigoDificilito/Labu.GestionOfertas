using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Postulacion
    {
        public int PostulacionId { get; set; }
        public int TipoEstadoPostulacionId { get; set; }
        public int AspiranteId { get; set; }
        public Guid OfertaId { get; set; }
        public DateTime Fecha { get; set; }

        public Oferta Oferta { get; set; }
        public TipoEstadoPostulacion TipoEstadoPostulacion { get; set; }
    }
}
