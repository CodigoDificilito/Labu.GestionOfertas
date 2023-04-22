using Application.DTO;
using Application.DTO.Request;
using Application.Interfaces.IOferta;
using Domain.Entities;

namespace Application.UseCase.Services.SOferta
{
    public class OfertaCommandServices : IOfertaCommandServices
    {
        private readonly IOfertaCommand _command;

        public OfertaCommandServices(IOfertaCommand command)
        {
            _command = command;
        }

        public async Task CreateOferta(AddOfertaRequest dto)
        {
            var oferta = new Oferta
            {
                OfertaId = Guid.NewGuid(),
                EmpresaId = dto.EmpresaId,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Salario = dto.Salario,
                AñosExperiencia = dto.AñosExperiencia,
                Provincia = dto.Provincia,
                Ciudad = dto.Ciudad,
                NivelEstudios = dto.NivelEstudios,
                Fecha = DateTime.Now
            };

            await _command.InsertOferta(oferta);
        }

        public async Task DeleteOferta(Guid ofertaId)
        {
            await _command.RemoveOferta(ofertaId);
        }
    }
}
