using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortoAPI.DTOs;
using PortoAPI.Models;
using PortoAPI.Services.Interfaces;

namespace PortoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IContainerService _service;
        public ContainerController(IContainerService service)
            => _service = service;

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Container>> AdicionarContainerAsync(ContainerDTO containerInput)
            => await _service.AdicionarContainerAsync(containerInput);

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult<Container>> AlterarContainerAsync(string numeroDeSerie, string? status, string? categoria, string? cliente)
            => await _service.AlterarContainerAsync(numeroDeSerie, status, categoria, cliente);

        [HttpDelete]
        [Route("remover")]
        public async Task<ActionResult> RemoverContainerAsync(string numeroDeSerie)
            => await _service.RemoverContainerAsync(numeroDeSerie);

        [HttpGet]
        [Route("receber/numero")]
        public async Task<ActionResult<Container>> ReceberContainerPorNumeroDeSerieAsync(string numeroDeSerie)
            => await _service.ReceberContainerPorNumeroDeSerieAsync(numeroDeSerie);

        [HttpGet]
        [Route("receber/clientes")]
        public async Task<ActionResult<List<Container>>> ReceberContainersDeClienteAsync(string cliente)
            => await _service.ReceberContainersDeClienteAsync(cliente);
    }
}
