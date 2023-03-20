using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortoAPI.Models;
using PortoAPI.Services.Interfaces;

namespace PortoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _service;
        public RelatorioController(IRelatorioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Relatorio>> GerarRelatorioFinalAsync()
            => await _service.GerarRelatorioFinalAsync();
    }
}
