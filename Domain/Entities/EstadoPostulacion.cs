using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoEstadoPostulacion
    {
        public int EstadoId { get; set; }
        public string Descripcion { get; set; }

        public Postulacion Postulacion { get; set; }
    }
}
