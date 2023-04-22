using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaCommand
    {
        public Task InsertOferta(Oferta oferta);
        public Task RemoveOferta(Guid ofertaId);

    }
}
