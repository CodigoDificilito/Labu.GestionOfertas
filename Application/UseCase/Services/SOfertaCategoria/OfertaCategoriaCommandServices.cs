using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IOfertaCategoria;
using Domain.Entities;

namespace Application.UseCase.Services.SOfertaCategoria
{
    public class OfertaCategoriaCommandServices : IOfertaCategoriaCommandServices
    {
        private readonly IOfertaCategoriaCommand _command;

        public OfertaCategoriaCommandServices(IOfertaCategoriaCommand command)
        {
            _command = command;
        }

        public async Task<ResponseMessage> CreateOfertaCategoria(AddOfertaCategoriaRequest dto)
        {
            var ofertaCategoria = new OfertaCategoria
            {
                OfertaId = dto.OfertaId,
                CategoriaId = dto.CategoriaId
            };

            await _command.InsertOfertaCategoria(ofertaCategoria);

            var result = new AddOfertaCategoriaResponse
            {
                OfertaId = ofertaCategoria.OfertaId,
                CategoriaId = ofertaCategoria.CategoriaId
            };

            return new ResponseMessage(201, result);
        }

        public async Task<ResponseMessage> DeleteOfertaCategoria(Guid ofertaId, int categoriaId)
        {
            if (await _command.RemoveOfertaCategoria(ofertaId, categoriaId))
            {
                return new ResponseMessage(200, new { result = "La Categoria se ha eliminado de la Oferta con exito" });
            }

            return new ResponseMessage(404, new { result = "No se encontro una Categoria asociada para el ID ingresado" });
        }
    }
}
