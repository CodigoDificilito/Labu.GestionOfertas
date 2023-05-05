namespace Application.Interfaces.IOfertaCategoria
{
    public interface IOfertaCategoriaQuery
    {
        Task<bool> ExistOfertaCategoriaByOfertaId(Guid ofertaId, IList<int> lista);
    }
}
