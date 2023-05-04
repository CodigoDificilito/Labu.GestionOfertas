namespace Domain.Entities
{
    public class Experiencia
    {
        public int ExperienciaId { get; set; }
        public string Nombre { get; set; }


        public IList<Oferta> Oferta { get; set; }
    }
}
