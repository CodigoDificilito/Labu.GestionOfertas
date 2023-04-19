using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Oferta
    {
        public Guid OfertaId { get; set; }
        public int EmpresaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Salario { get; set; }
        public int AñosExperiencia { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string NivelEstudios { get; set; }
        public DateTime Fecha { get; set; }


        public IList<OfertaCategoria> OfertaCategoria { get; set; }
        public IList<Postulacion> Postulacion { get; set; }
    }
}
