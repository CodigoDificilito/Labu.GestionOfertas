using Application.Interfaces.IOfertaCategoria;

namespace Application.UseCase.Services.SOfertaCategoria
{
    public class OfertaCategoriaQueryServices : IOfertaCategoriaQueryServices
    {
        private readonly IOfertaCategoriaQuery _query;

        public OfertaCategoriaQueryServices(IOfertaCategoriaQuery query)
        {
            _query = query;
        }

        public async Task<bool> OfertaCategoriaExistInOfertaId(Guid ofertaId, IList<int> lista)
        {
           return await _query.ExistOfertaCategoriaByOfertaId(ofertaId, lista);
        }
    }
}
