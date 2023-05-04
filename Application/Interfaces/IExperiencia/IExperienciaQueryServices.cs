using Application.DTO.Response;

namespace Application.Interfaces.IExperiencia
{
    public interface IExperienciaQueryServices
    {
        Task<IList<ExperienciaResponse>> GetExperiencias();

        Task<bool> ExperienciaExist(int experienciaId);

        Task<ExperienciaResponse> GetExperienciaById(int experienciaId);
    }
}
