namespace Application.DTO.Response
{
    public class AddOfertaResponse
    {
        public Guid OfertaId { get; set; }
        public int EmpresaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Salario { get; set; }
        public int ExperineciaId { get; set; }
        public int ProvinciaId { get; set; }
        public int CiudadId { get; set; }
        public int NivelEstudioId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
