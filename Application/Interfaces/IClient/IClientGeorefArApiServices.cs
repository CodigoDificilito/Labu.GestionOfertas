namespace Application.Interfaces.IClient
{
    public interface IClientGeorefArApiServices
    {
        public Task<bool> ValidateProvince(int provinciaId);

        public Task<bool> ValidateCity(int provinciaId, int ciudadId);
    }
}
