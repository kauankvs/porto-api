using Microsoft.AspNetCore.Mvc;
using PortoAPI.Models;

namespace PortoAPI.Services.Interfaces
{
    public interface IRelatorioService
    {
        public Task<Dictionary<string, int>> ContarTodasMovimentacoesPorClienteAsync();
        public Task<Dictionary<string, int>> ContarTodasMovimentacoesPorTipoAsync();
        public Task<ActionResult<Relatorio>> GerarRelatorioFinalAsync();

    }
}
