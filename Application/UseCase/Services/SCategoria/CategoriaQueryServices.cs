using Application.DTO;
using Application.DTO.Response;
using Application.Interfaces.ICategoria;
using Application.Interfaces.IOferta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Services.SCategoria
{
    public class CategoriaQueryServices : ICategoriaQueryServices
    {
        private readonly ICategoriaQuery _query;

        public CategoriaQueryServices(ICategoriaQuery query)
        {
            _query = query;
        }

        public async Task<ResponseMessage> GetCategoriaById(int categoriaId)
        {
            var categoria = await _query.GetCategoria(categoriaId);

            if (categoria != null)
            {
                return new ResponseMessage(200, new CategoriaDTO()
                {
                    Descripcion = categoria.Descripcion
                });
            }

            return new ResponseMessage(404, new {result = "La categoria no fue encontrada o no existe."});
        }

        public async Task<List<CategoriaDTO>> GetOfertas()
        {
            var categorias = await _query.GetListCategoria();
            var categoriasDTO = new List<CategoriaDTO>();

            foreach (var c in categorias)
            {
                var categoriaDTO = new CategoriaDTO()
                {
                    Descripcion = c.Descripcion
                };
                categoriasDTO.Add(categoriaDTO);
            }

            return categoriasDTO;
        }
    }
}
