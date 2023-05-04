namespace Application.DTO.Request
{
    public class OfertaCategoriaRequest
    {
        public Guid OfertaId { get; set; }
        public IList<int> Categorias { get; set; }
    }
}
