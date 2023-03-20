namespace PortoAPI.Services.Interfaces
{
    public interface INumeroDeContainerService
    {
        public Task<bool> ChecarSeNumeroDeSerieExisteAsync(string numeroDeSerie);

        public Task<string> CriarNumeroDeSerieAsync();
    }
}
