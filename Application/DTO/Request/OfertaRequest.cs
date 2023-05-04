namespace Application.DTO.Request
{
    public class OfertaRequest
    {
        public int EmpresaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Salario { get; set; }
        public int ExperienciaId { get; set; }
        public int ProvinciaId { get; set; }
        public int CiudadId { get; set; }
        public int NivelEstudiosId { get; set; }

        public IList<int> Categorias { get; set; }
    }
}
