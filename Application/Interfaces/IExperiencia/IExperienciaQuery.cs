using Domain.Entities;

namespace Application.Interfaces.IExperiencia
{
    public interface IExperienciaQuery
    {
        Task<List<Experiencia>> GetListExperiencia();
        Task<Experiencia> GetExperiencia(int experienciaId);
    }
}
