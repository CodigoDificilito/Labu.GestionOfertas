using Application.DTO.Response;
using Application.Interfaces.INivelEstudio;

namespace Application.UseCase.Services.SNivelEstudio
{
    public class NivelEstudioQueryServices : INivelEstudioQueryServices
    {
        private readonly INivelEstudioQuery _query;

        public NivelEstudioQueryServices(INivelEstudioQuery query)
        {
            _query = query;
        }

        public async Task<IList<NivelEstudioResponse>> GetNivelesDeEstudio()
        {
            var niveles = await _query.GetListNivelEstudio();
            var response = new List<NivelEstudioResponse>();

            foreach (var item in niveles)
            {
                response.Add(new NivelEstudioResponse
                {
                    Id = item.NivelEstudioId,
                    Nombre = item.Nombre
                });
            }
            return response;
        }

        public async Task<NivelEstudioResponse> GetNivelEstudioById(int id)
        {
            var response = await _query.GetNivelEstudio(id);

            if (response == null)
            {
                return null;
            }
            return new NivelEstudioResponse
            {
                Id = response.NivelEstudioId,
                Nombre = response.Nombre
            };
        }

        public async Task<bool> NivelEstudioExist(int id)
        {
            if (await _query.GetNivelEstudio(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}
