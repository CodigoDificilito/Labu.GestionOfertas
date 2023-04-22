using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class OfertaDTO
    {
        public int EmpresaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Salario { get; set; }
        public int AñosExperiencia { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string NivelEstudios { get; set; }
    }
}
