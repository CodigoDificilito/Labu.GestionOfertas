namespace Domain.Entities
{
    public class NivelEstudio
    {
        public int NivelEstudioId { get; set; }
        public string Nombre { get; set; }

        public IList<Oferta> Oferta { get; set; }
    }
}
