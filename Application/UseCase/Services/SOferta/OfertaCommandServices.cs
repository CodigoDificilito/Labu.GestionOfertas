using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IOferta;
using Application.Interfaces.IOfertaCategoria;
using Domain.Entities;

namespace Application.UseCase.Services.SOferta
{
    public class OfertaCommandServices : IOfertaCommandServices
    {
        private readonly IOfertaCommand _ofertaCommand;
        private readonly IOfertaCategoriaCommandServices _ofertaCategoriaCommandServices;
        public OfertaCommandServices(IOfertaCommand command, IOfertaCategoriaCommandServices ofertaCategoriaCommandServices)
        {
            _ofertaCommand = command;
            _ofertaCategoriaCommandServices = ofertaCategoriaCommandServices;
        }

        public async Task<OfertaResponse> CreateOferta(OfertaRequest dto)
        {

            var oferta = new Oferta
            {
                OfertaId = Guid.NewGuid(),
                EmpresaId = dto.EmpresaId,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Salario = dto.Salario,
                ExperienciaId = dto.ExperienciaId,
                ProvinciaId = dto.ProvinciaId,
                CuidadId = dto.CiudadId,
                NivelEstudioId = dto.NivelEstudiosId,
                Fecha = DateTime.Now,
                Status = true
            };

            oferta = await _ofertaCommand.InsertOferta(oferta);

            var ofertaCategoriaRequest = new OfertaCategoriaRequest
            {
                OfertaId = oferta.OfertaId,
                Categorias = dto.Categorias
            };

            var ofertaCategoriasResponse = await _ofertaCategoriaCommandServices.CreateOfertaCategoria(ofertaCategoriaRequest);


            return new OfertaResponse
            {
                OfertaId = oferta.OfertaId,
                EmpresaId = oferta.EmpresaId,
                Titulo = oferta.Titulo,
                Descripcion = oferta.Descripcion,
                Salario = oferta.Salario,
                Experiencia = new ExperienciaResponse
                {
                    Id = oferta.Experiencia.ExperienciaId,
                    Nombre = oferta.Experiencia.Nombre
                },
                ProvinciaId = oferta.ProvinciaId,
                CiudadId = oferta.CuidadId,
                NivelEstudio = new NivelEstudioResponse
                {
                    Id = oferta.NivelEstudio.NivelEstudioId,
                    Nombre = oferta.NivelEstudio.Nombre
                },
                Fecha = oferta.Fecha.ToString(),
                Categorias = ofertaCategoriasResponse
            };
        }

        public async Task<OfertaResponse> DeleteOferta(Guid ofertaId)
        {
            var oferta = await _ofertaCommand.RemoveOferta(ofertaId);

            if (oferta==null)
            {
                return null;
            }

            return new OfertaResponse
            {
                OfertaId = oferta.OfertaId,
                EmpresaId = oferta.EmpresaId,
                Titulo = oferta.Titulo,
                Descripcion = oferta.Descripcion,
                Salario = oferta.Salario,
                Experiencia = new ExperienciaResponse
                {
                    Id = oferta.Experiencia.ExperienciaId,
                    Nombre = oferta.Experiencia.Nombre
                },
                ProvinciaId = oferta.ProvinciaId,
                CiudadId = oferta.CuidadId,
                NivelEstudio = new NivelEstudioResponse
                {
                    Id = oferta.NivelEstudio.NivelEstudioId,
                    Nombre = oferta.NivelEstudio.Nombre
                },
                Fecha = oferta.Fecha.ToString(),
                Categorias = oferta.OfertaCategoria.Select(oc => new OfertaCategoriaResponse
                {
                    CategoriaId = oc.Categoria.CategoriaId,
                    Nombre = oc.Categoria.Descripcion
                }).ToList()
            };
        }
    }
}
