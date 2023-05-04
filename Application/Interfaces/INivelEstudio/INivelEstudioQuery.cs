using Domain.Entities;

namespace Application.Interfaces.INivelEstudio
{
    public interface INivelEstudioQuery
    {
        Task<List<NivelEstudio>> GetListNivelEstudio();
        Task<NivelEstudio> GetNivelEstudio(int id);
    }
}
