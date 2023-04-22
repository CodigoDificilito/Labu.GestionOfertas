using Application.DTO;
using Application.Interfaces.IOferta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Services.SOferta
{
    public class OfertaQueryServices : IOfertaQueryServices
    {
        private readonly IOfertaQuery _query;

        public OfertaQueryServices(IOfertaQuery query)
        {
            _query = query;
        }

        public async Task<List<OfertaDTO>> GetListOfertaByTitulo(string titulo)
        {
            var ofertas = await _query.GetListOfertaByTitulo(titulo);
            var ofertasDTO = new List<OfertaDTO>();

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

            return ofertasDTO;
        }

        public async Task<List<OfertaDTO>> GetOfertas()
        {
            var ofertas = await _query.GetListOferta();
            var ofertasDTO = new List<OfertaDTO>();

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

            return ofertasDTO;
        }

        public OfertaDTO GetOfertaById(Guid ofertaId)
        {
            var oferta = _query.GetOferta(ofertaId);

            var ofertaDTO = new OfertaDTO()
            {
                EmpresaId = oferta.EmpresaId,
                Titulo = oferta.Titulo,
                Descripcion = oferta.Descripcion,
                Salario = oferta.Salario,
                AñosExperiencia = oferta.AñosExperiencia,
                Provincia = oferta.Provincia,
                Ciudad = oferta.Ciudad,
                NivelEstudios = oferta.NivelEstudios
            };

            return ofertaDTO;
        }

        public async Task<bool> ExistOfertaById(Guid ofertaId)
        {
            return await _query.ExistOferta(ofertaId);
        }

        public async Task<List<OfertaDTO>> GetListOfertaByEmpresaId(int empresaId)
        {
            var ofertas = await _query.GetListOfertaByEmpresa(empresaId);
            var ofertasDTO = new List<OfertaDTO>();

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

            return ofertasDTO;
        }
    }
}
