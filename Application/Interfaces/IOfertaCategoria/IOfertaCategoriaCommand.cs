using Domain.Entities;

namespace Application.Interfaces.IOfertaCategoria
{
    public interface IOfertaCategoriaCommand
    {
        public Task InsertOfertaCategoria(OfertaCategoria ofertaCategoria);
        public Task<bool> RemoveOfertaCategoria(Guid ofertaId, int categoriaId);
    }
}
