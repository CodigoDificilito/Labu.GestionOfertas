namespace Application.Interfaces.IOfertaCategoria
{
    public interface IOfertaCategoriaQueryServices
    {
        Task<bool> OfertaCategoriaExistInOfertaId(Guid ofertaId, IList<int> lista);
    }
}
