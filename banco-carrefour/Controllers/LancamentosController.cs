using banco_carrefour.Domain.Request;
using banco_carrefour.Infrastructure.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace banco_carrefour.Controllers
{
    [ApiController]
    [Route("api/lancamentos")]
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentoService _lancamentoService;
        private readonly ISaldoConsolidadoService _saldoConsolidadoService;

        public LancamentosController(ILancamentoService lancamentoService, ISaldoConsolidadoService saldoConsolidadoService)
        {
            _lancamentoService = lancamentoService;
            _saldoConsolidadoService = saldoConsolidadoService;
        }

        [HttpGet]
        [Route("ObterSaldoConsolidado")]
        public async Task<IActionResult> ObterSaldoConsolidado(DateTime data)
        {
            var retorno = await _saldoConsolidadoService.ObtemSaldoConsolidado(data);

            return Ok(retorno);
        }

        [HttpPost]
        [Route("IncluirLancamento")]
        public async Task<IActionResult> IncluirLancamento([FromBody] LancamentoRequest request)
        {
            var retorno = await _lancamentoService.IncluirLancamento(request);

            return Ok(retorno);
        }
    }
}