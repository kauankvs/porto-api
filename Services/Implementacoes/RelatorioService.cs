using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortoAPI.Models;
using PortoAPI.Services.Interfaces;

namespace PortoAPI.Services.Implementacoes
{
    public class RelatorioService : IRelatorioService
    {
        private readonly PortoApiDbContext _context;
        public RelatorioService(PortoApiDbContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, int>> ContarTodasMovimentacoesPorClienteAsync()
        {
            Dictionary<string, int> movimentacoesPorCliente = new Dictionary<string, int>();
            List<Container> containersPorClienteUnico = await _context.Containers.GroupBy(c => c.Cliente).Select(g => g.First()).ToListAsync();
            foreach(var container in containersPorClienteUnico)
            {
                int movimentacoes = await _context.Movimentacaos.AsNoTracking().CountAsync(m => m.Cliente == container.Cliente);
                movimentacoesPorCliente.Add(container.Cliente, movimentacoes);
            }
            return movimentacoesPorCliente;
        }

        public async Task<Dictionary<string, int>> ContarTodasMovimentacoesPorTipoAsync()
        {
            Dictionary<string, int> movimentacoesPorTipo = new Dictionary<string, int>();
            string[] tipos = { "embarque", "descarga", "gate in", "gate out", "reposicionamento", "pesagem", "scanner" };
            foreach(string tipo in tipos)
            {
                int movimentacoes = await _context.Movimentacaos.AsNoTracking().CountAsync(m => m.Tipo == tipo);
                movimentacoesPorTipo.Add(tipo, movimentacoes);
            }
            return movimentacoesPorTipo;
        }

        public async Task<ActionResult<Relatorio>> GerarRelatorioFinalAsync()
        {
            Relatorio relatorio = new Relatorio();
            relatorio.movimentacoesPorCliente = await ContarTodasMovimentacoesPorClienteAsync();
            relatorio.movimentacoesPorTipo = await ContarTodasMovimentacoesPorTipoAsync();
            relatorio.TotalDeExportacoes = await _context.Containers.AsNoTracking().CountAsync(c => c.Categoria == "Exportação");
            relatorio.TotalDeImportacoes = await _context.Containers.AsNoTracking().CountAsync(c => c.Categoria == "Importação");
            return new OkObjectResult(relatorio);
        }
    }
}
