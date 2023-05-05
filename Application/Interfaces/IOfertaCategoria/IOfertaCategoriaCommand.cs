using Domain.Entities;

namespace Application.Interfaces.IOfertaCategoria
{
    public interface IOfertaCategoriaCommand
    {
        public Task<Categoria> InsertOfertaCategoria(OfertaCategoria ofertaCategoria);
        public Task<bool> RemoveOfertaCategoria(Guid ofertaId, int categoriaId);
    }
}
