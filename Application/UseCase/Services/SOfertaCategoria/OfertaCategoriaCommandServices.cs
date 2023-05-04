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

        public async Task<IList<OfertaCategoriaResponse>> CreateOfertaCategoria(OfertaCategoriaRequest dto)
        {
            var ofertaCategoriasResponse = new List<OfertaCategoriaResponse>();

            foreach (var categoriaId in dto.Categorias)
            {
                var ofertaCategoria = new OfertaCategoria
                {
                    CategoriaId = categoriaId,
                    OfertaId = dto.OfertaId,
                    Status = true
                };

                var categoria = await _command.InsertOfertaCategoria(ofertaCategoria);

                ofertaCategoriasResponse.Add(new OfertaCategoriaResponse
                {
                    CategoriaId = categoria.CategoriaId,
                    Nombre = categoria.Descripcion
                });
            }

            return ofertaCategoriasResponse;
        }

        public async Task<bool> DeleteOfertaCategoria(Guid ofertaId, IList<int> categorias)
        {
            foreach (var categoriaId in categorias)
            {
                if (!await _command.RemoveOfertaCategoria(ofertaId, categoriaId))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
