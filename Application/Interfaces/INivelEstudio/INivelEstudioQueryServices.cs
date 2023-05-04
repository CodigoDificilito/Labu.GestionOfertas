using Application.DTO.Response;

namespace Application.Interfaces.INivelEstudio
{
    public interface INivelEstudioQueryServices
    {
        Task<IList<NivelEstudioResponse>> GetNivelesDeEstudio();

        Task<bool> NivelEstudioExist(int id);

        Task<NivelEstudioResponse> GetNivelEstudioById(int id);
    }
}
