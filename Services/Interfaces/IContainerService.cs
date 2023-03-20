using Microsoft.AspNetCore.Mvc;
using PortoAPI.DTOs;
using PortoAPI.Models;

namespace PortoAPI.Services.Interfaces
{
    public interface IContainerService
    {
        public Task<ActionResult<Container>> AdicionarContainerAsync(ContainerDTO containerInput);
        public Task<ActionResult<Container>> AlterarContainerAsync(string numeroDeSerie, string? status, string? categoria, string? cliente);
        public Task<ActionResult> RemoverContainerAsync(string numeroDeSerie);
        public Task<ActionResult<Container>> ReceberContainerPorNumeroDeSerieAsync(string numeroDeSerie);
        public Task<ActionResult<List<Container>>> ReceberContainersDeClienteAsync(string cliente);
    }
}
