using Application.DTO;
using Application.DTO.Request;
using Application.DTO.Response;
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

        public async Task<ResponseMessage> CreateOferta(AddOfertaRequest dto)
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

            var result = new AddOfertaResponse
            {
                OfertaId = oferta.OfertaId,
                EmpresaId = oferta.EmpresaId,
                Titulo = oferta.Titulo,
                Descripcion = oferta.Descripcion,
                Salario = oferta.Salario,
                AñosExperiencia = oferta.AñosExperiencia,
                Provincia = oferta.Provincia,
                Ciudad = oferta.Ciudad,
                NivelEstudios = oferta.NivelEstudios,
                Fecha = oferta.Fecha
            };

            return new ResponseMessage(201, result);
        }

        public async Task<ResponseMessage> DeleteOferta(Guid ofertaId)
        {
            if (await _command.RemoveOferta(ofertaId))
            {
                return new ResponseMessage(200, new { result = "La oferta se ha eliminado con exito" });
            }

            return new ResponseMessage(404, new { result = "No existe una Oferta para el ID ingresado" });
        }
    }
}
