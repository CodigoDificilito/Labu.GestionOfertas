using Application.DTO.Response;
using Application.Interfaces.IClient;
using System.Text.Json;

namespace Application.UseCase.Services.SClient
{
    public class ClientGeorefArApiServices : IClientGeorefArApiServices
    {
        private readonly IClientGeorefArApi _clientGeorefArApi;

        public ClientGeorefArApiServices(IClientGeorefArApi clientGeorefArApi)
        {
            _clientGeorefArApi = clientGeorefArApi;
        }

        public async Task<bool> ValidateCity(int provinciaId, int ciudadId)
        {
            var content = await _clientGeorefArApi.GetAllCities(provinciaId);

            var cities = JsonSerializer.Deserialize<MunicipioAllResponse>(content);

            foreach (var item in cities.municipios)
            {
                if (int.Parse(item.id) == ciudadId)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> ValidateProvince(int provinciaId)
        {
            var content = await _clientGeorefArApi.GetAllProvinces();

            var provincies = JsonSerializer.Deserialize<ProvinciaAllResponse>(content);

            foreach (var item in provincies.provincias)
            {
                if (int.Parse(item.id) == provinciaId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
