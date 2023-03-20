using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortoAPI.DTOs;
using PortoAPI.Models;
using PortoAPI.Services.Interfaces;

namespace PortoAPI.Services.Implementacoes
{
    public class MovimentacaoService: IMovimentacaoService
    {
        private readonly PortoApiDbContext _context;
        public MovimentacaoService(PortoApiDbContext context)
            => _context = context;

        public async Task<ActionResult<Movimentacao>> AdicionarMovimentacaoAsync(MovimentacaoDTO movimentacaoInput)
        {
            Container? container = await _context.Containers.AsNoTracking().FirstOrDefaultAsync(c => c.NumeroDeSerie == movimentacaoInput.NumeroDeContainer);
            if (container == null)
                return new BadRequestObjectResult(movimentacaoInput.NumeroDeContainer);

            Movimentacao movimentacao = new Movimentacao()
            {
                NumeroDeContainer = movimentacaoInput.NumeroDeContainer,
                Tipo = movimentacaoInput.Tipo,
                Inicio = movimentacaoInput.Inicio,
                Fim = movimentacaoInput.Fim,
                Cliente = container.Cliente,
            };
            await _context.Movimentacaos.AddAsync(movimentacao);
            await _context.SaveChangesAsync();
            return new OkObjectResult(movimentacao);
        }

        public async Task<ActionResult<Movimentacao>> AlterarDataEHorarioDeMovimentacaoAsync(int id, DateTime inicio, DateTime fim)
        {
            Movimentacao? movimentacao = await _context.Movimentacaos.FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
                return new BadRequestObjectResult(id);

            movimentacao.Inicio = inicio;
            movimentacao.Fim = fim;
            await _context.SaveChangesAsync();
            return new OkObjectResult(movimentacao);
        }

        public async Task<ActionResult<Movimentacao>> AlterarTipoDeMovimentacaoAsync(int id, string tipo)
        {
            Movimentacao? movimentacao = await _context.Movimentacaos.FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
                return new BadRequestObjectResult(id);

            movimentacao.Tipo = tipo;
            await _context.SaveChangesAsync();
            return new OkObjectResult(movimentacao);
        }

        public async Task<ActionResult<Movimentacao>> ReceberMovimentacaoPorIdAsync(int id)
        {
            Movimentacao? movimentacao = await _context.Movimentacaos.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
                return new BadRequestObjectResult(id);

            return new OkObjectResult(movimentacao);

        }

        public async Task<ActionResult<List<Movimentacao>>> ReceberMovimentacoesPorClienteAsync(string cliente)
        {
            List<Movimentacao>? movimentacoesPorCliente = await _context.Movimentacaos.AsNoTracking().Where(m => m.Cliente == cliente).ToListAsync();
            if (movimentacoesPorCliente.IsNullOrEmpty())
                return new NoContentResult();

            return new OkObjectResult(movimentacoesPorCliente);
        }

        public async Task<ActionResult<List<Movimentacao>>> ReceberMovimentacoesPorContainerAsync(string numeroDeContainer)
        {
            List<Movimentacao>? movimentacoesPorContainer = await _context.Movimentacaos.AsNoTracking().Where(m => m.NumeroDeContainer == numeroDeContainer).ToListAsync();
            if (movimentacoesPorContainer.IsNullOrEmpty())
                return new NoContentResult();

            return new OkObjectResult(movimentacoesPorContainer);
        }

        public async Task<ActionResult> RemoverMovimentacaoAsync(int id)
        {
            Movimentacao? movimentacao = await _context.Movimentacaos.FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
                return new BadRequestObjectResult(id);

            _context.Movimentacaos.Remove(movimentacao);
            await _context.SaveChangesAsync();
            return new AcceptedResult();
        }
    }
}
