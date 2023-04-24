using Application.DTO;
using Application.DTO.Response;
using Application.Interfaces.IOferta;

namespace Application.UseCase.Services.SOferta
{
    public class OfertaQueryServices : IOfertaQueryServices
    {
        private readonly IOfertaQuery _query;

        public OfertaQueryServices(IOfertaQuery query)
        {
            _query = query;
        }

        public async Task<ResponseMessage> GetListOfertaByTitulo(string titulo)
        {
            var ofertas = await _query.GetListOfertaByTitulo(titulo);
            var ofertasDTO = new List<OfertaDTO>();

            if (ofertas.Count==0)
            {
                return new ResponseMessage(204, new { result = "No existen ofertas con el titulo ingresado." });
            }

            foreach (var c in ofertas)
            {
                var ofertaDTO = new OfertaDTO()
                {
                    EmpresaId = c.EmpresaId,
                    Titulo = c.Titulo,
                    Descripcion = c.Descripcion,
                    Salario = c.Salario,
                    AñosExperiencia = c.AñosExperiencia,
                    Provincia = c.Provincia,
                    Ciudad = c.Ciudad,
                    NivelEstudios = c.NivelEstudios
                };
                ofertasDTO.Add(ofertaDTO);
            }

            return new ResponseMessage(200, ofertasDTO);
        }
        public async Task<ResponseMessage> GetOfertaById(Guid ofertaId)
        {
            var oferta = await _query.GetOferta(ofertaId);

            if (oferta==null)
            {
                return new ResponseMessage(404, new { request = "Oferta no encontrada." });
            }

            return new ResponseMessage(200, new OfertaDTO()
            {
                EmpresaId = oferta.EmpresaId,
                Titulo = oferta.Titulo,
                Descripcion = oferta.Descripcion,
                Salario = oferta.Salario,
                AñosExperiencia = oferta.AñosExperiencia,
                Provincia = oferta.Provincia,
                Ciudad = oferta.Ciudad,
                NivelEstudios = oferta.NivelEstudios
            });
        }

        public async Task<ResponseMessage> GetListOfertaByEmpresaId(int empresaId)
        {
            var ofertas = await _query.GetListOfertaByEmpresa(empresaId);
            var ofertasDTO = new List<OfertaDTO>();

            if (ofertas.Count==0)
            {
                return new ResponseMessage(204, new { result = "La Empresa con el ID ingresado no tiene Ofertas." });
            }

            foreach (var c in ofertas)
            {
                var ofertaDTO = new OfertaDTO()
                {
                    EmpresaId = c.EmpresaId,
                    Titulo = c.Titulo,
                    Descripcion = c.Descripcion,
                    Salario = c.Salario,
                    AñosExperiencia = c.AñosExperiencia,
                    Provincia = c.Provincia,
                    Ciudad = c.Ciudad,
                    NivelEstudios = c.NivelEstudios
                };
                ofertasDTO.Add(ofertaDTO);
            }

            return new ResponseMessage(200, ofertasDTO);
        }
    }
}
