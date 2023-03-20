using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortoAPI.DTOs;
using PortoAPI.Models;
using PortoAPI.Services.Interfaces;

namespace PortoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacaoService _service;
        public MovimentacaoController(IMovimentacaoService service)
            => _service = service;

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Movimentacao>> AdicionarMovimentacaoAsync(MovimentacaoDTO movimentacaoInput)
            => await _service.AdicionarMovimentacaoAsync(movimentacaoInput);

        [HttpPut]
        [Route("alterar/tipo")]
        public async Task<ActionResult<Movimentacao>> AlterarTipoDeMovimentacaoAsync(int id, string tipo)
            => await _service.AlterarTipoDeMovimentacaoAsync(id, tipo);

        [HttpPut]
        [Route("alterar/data")]
        public async Task<ActionResult<Movimentacao>> AlterarDataEHorarioDeMovimentacaoAsync(int id, DateTime inicio, DateTime fim)
            => await _service.AlterarDataEHorarioDeMovimentacaoAsync(id, inicio, fim);

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Movimentacao>> ReceberMovimentacaoPorIdAsync([FromRoute] int id)
            => await _service.ReceberMovimentacaoPorIdAsync(id);

        [HttpGet]
        [Route("receber/clientes")]
        public async Task<ActionResult<List<Movimentacao>>> ReceberMovimentacoesPorClienteAsync(string cliente)
            => await _service.ReceberMovimentacoesPorClienteAsync(cliente);

        [HttpGet]
        [Route("receber/container")]
        public async Task<ActionResult<List<Movimentacao>>> ReceberMovimentacoesPorContainerAsync(string numeroDeContainer)
            => await _service.ReceberMovimentacoesPorContainerAsync(numeroDeContainer);

        [HttpDelete]
        [Route("remover")]
        public async Task<ActionResult> RemoverMovimentacaoAsync(int id)
            => await _service.RemoverMovimentacaoAsync(id);
    }
}
