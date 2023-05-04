namespace Application.DTO.Response
{
    public class OfertaResponse
    {
        public Guid OfertaId { get; set; }
        public int EmpresaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Salario { get; set; }
        public ExperienciaResponse Experiencia { get; set; }
        public int ProvinciaId { get; set; }
        public int CiudadId { get; set; }
        public NivelEstudioResponse NivelEstudio { get; set; }

        public string Fecha { get; set; }

        public IList<OfertaCategoriaResponse> Categorias { get; set; }
    }
}
