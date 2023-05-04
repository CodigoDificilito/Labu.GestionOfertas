using Application.DTO.Response;
using Application.Interfaces.ICategoria;
using Application.Interfaces.IOferta;

namespace Application.UseCase.Services.SCategoria
{
    public class CategoriaQueryServices : ICategoriaQueryServices
    {
        private readonly ICategoriaQuery _query;

        public CategoriaQueryServices(ICategoriaQuery query)
        {
            _query = query;
        }

        public async Task<bool> CategoriasExist(IList<int> categorias)
        {
            foreach (var id in categorias)
            {
                if (await _query.GetCategoria(id)==null)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<CategoriaResponse> GetCategoriaById(int categoriaId)
        {
            var categoria = await _query.GetCategoria(categoriaId);

            if (categoria == null)
            {
                return null;
            }

            return new CategoriaResponse
            {
                Id = categoria.CategoriaId,
                Descripcion = categoria.Descripcion
            };
        }

        public async Task<List<CategoriaResponse>> GetOfertas()
        {
            var categorias = await _query.GetListCategoria();
            var categoriasResponse = new List<CategoriaResponse>();

            foreach (var item in categorias)
            {
                categoriasResponse.Add(new CategoriaResponse()
                {
                    Id = item.CategoriaId,
                    Descripcion = item.Descripcion
                });
                
            }

            return categoriasResponse;
        }
    }
}
