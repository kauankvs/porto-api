using Microsoft.AspNetCore.Mvc;
using PortoAPI.DTOs;
using PortoAPI.Models;

namespace PortoAPI.Services.Interfaces
{
    public interface IMovimentacaoService
    {
        public Task<ActionResult<Movimentacao>> AdicionarMovimentacaoAsync(MovimentacaoDTO movimentacaoInput);
        public Task<ActionResult<Movimentacao>> AlterarTipoDeMovimentacaoAsync(int id, string tipo);
        public Task<ActionResult<Movimentacao>> AlterarDataEHorarioDeMovimentacaoAsync(int id, DateTime inicio, DateTime fim);
        public Task<ActionResult<Movimentacao>> ReceberMovimentacaoPorIdAsync(int id);
        public Task<ActionResult<List<Movimentacao>>> ReceberMovimentacoesPorClienteAsync(string cliente);
        public Task<ActionResult<List<Movimentacao>>> ReceberMovimentacoesPorContainerAsync(string numeroDeContainer);
        public Task<ActionResult> RemoverMovimentacaoAsync(int id);

    }
}
