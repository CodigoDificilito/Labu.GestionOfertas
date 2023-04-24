using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request
{
    public class AddOfertaCategoriaRequest
    {
        public Guid OfertaId { get; set; }
        public int CategoriaId { get; set; }
    }
}
