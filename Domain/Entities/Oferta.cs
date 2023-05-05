namespace Domain.Entities
{
    public class Oferta
    {
        public Guid OfertaId { get; set; }
        public int EmpresaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Salario { get; set; }
        public int ExperienciaId { get; set; }
        public int ProvinciaId { get; set; }
        public int CuidadId { get; set; }
        public int NivelEstudioId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Status { get; set; }


        public NivelEstudio NivelEstudio { get; set; }
        public Experiencia Experiencia { get; set; }
        public IList<OfertaCategoria> OfertaCategoria { get; set; }
        public IList<Postulacion> Postulacion { get; set; }
    }
}
