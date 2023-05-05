using Application.DTO.Response;
using Application.Interfaces.IExperiencia;

namespace Application.UseCase.Services.SExperiencia
{
    public class ExperienciaQueryServices : IExperienciaQueryServices
    {
        private readonly IExperienciaQuery _query;

        public ExperienciaQueryServices(IExperienciaQuery query)
        {
            _query = query;
        }

        public async Task<bool> ExperienciaExist(int experienciaId)
        {
            if (await _query.GetExperiencia(experienciaId) == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ExperienciaResponse> GetExperienciaById(int experienciaId)
        {
            var experiencia = await _query.GetExperiencia(experienciaId);

            if (experiencia == null)
            {
                return null;
            }

            return new ExperienciaResponse
            {
                Id = experiencia.ExperienciaId,
                Nombre = experiencia.Nombre
            };
        }

        public async Task<IList<ExperienciaResponse>> GetExperiencias()
        {
            var experiencias = await _query.GetListExperiencia();
            var response = new List<ExperienciaResponse>();

            foreach (var item in experiencias)
            {
                response.Add(new ExperienciaResponse
                {
                    Id = item.ExperienciaId,
                    Nombre = item.Nombre
                });
            }
            return response;
        }
    }
}
