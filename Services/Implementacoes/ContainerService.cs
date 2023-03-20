using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortoAPI.DTOs;
using PortoAPI.Models;
using PortoAPI.Services.Interfaces;

namespace PortoAPI.Services.Implementacoes
{
    public class ContainerService: IContainerService
    {
        private readonly PortoApiDbContext _context;
        private readonly INumeroDeContainerService _numeroService;
        public ContainerService(PortoApiDbContext context, INumeroDeContainerService numeroService)
        {
            _context = context;
            _numeroService = numeroService;
        }

        public async Task<ActionResult<Container>> AdicionarContainerAsync(ContainerDTO containerInput)
        {
            var numeroDeSerie = await _numeroService.CriarNumeroDeSerieAsync();
            Container container = new Container()
            {
                Cliente = containerInput.Cliente,
                Status = containerInput.Status,
                Tipo = containerInput.Tipo,
                Categoria = containerInput.Categoria,
                NumeroDeSerie = numeroDeSerie,
            };
            await _context.Containers.AddAsync(container);
            await _context.SaveChangesAsync();
            return new OkObjectResult(container);
        }

        public async Task<ActionResult<Container>> AlterarContainerAsync(string numeroDeSerie, string? status, string? categoria, string? cliente)
        {
            Container? container = await _context.Containers.FirstOrDefaultAsync(c => c.NumeroDeSerie == numeroDeSerie);
            if(container == null)
                return new BadRequestObjectResult(numeroDeSerie);

            if (status != null)
                container.Status = status;

            if (categoria != null)
                container.Categoria = categoria;

            if(cliente != null)
                container.Cliente = cliente;

            await _context.SaveChangesAsync();
            return new OkObjectResult(container);
        }

        public async Task<ActionResult<Container>> ReceberContainerPorNumeroDeSerieAsync(string numeroDeSerie)
        {
            Container? container = await _context.Containers.AsNoTracking().FirstOrDefaultAsync(c => c.NumeroDeSerie == numeroDeSerie);
            if (container == null)
                return new BadRequestObjectResult(numeroDeSerie);

            return new OkObjectResult(container);
        }

        public async Task<ActionResult<List<Container>>> ReceberContainersDeClienteAsync(string cliente)
        {
            List<Container> containers = await _context.Containers.AsNoTracking().Where(c => c.Cliente == cliente).ToListAsync();
            if (containers.IsNullOrEmpty())
                return new NoContentResult();

            return new OkObjectResult(containers);
        }

        public async Task<ActionResult> RemoverContainerAsync(string numeroDeSerie)
        {
            Container? container = await _context.Containers.FirstOrDefaultAsync(c => c.NumeroDeSerie == numeroDeSerie);
            if (container == null)
                return new BadRequestObjectResult(numeroDeSerie);

            _context.Containers.Remove(container);
            await _context.SaveChangesAsync();
            return new AcceptedResult();
        }
    }
}
