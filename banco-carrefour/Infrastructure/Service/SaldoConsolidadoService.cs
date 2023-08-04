using banco_carrefour.Domain.Response;
using banco_carrefour.Infrastructure.Repository.Interface;
using banco_carrefour.Infrastructure.Service.Interface;

namespace banco_carrefour.Infrastructure.Service
{
    public class SaldoConsolidadoService : ISaldoConsolidadoService
    {
        private readonly ILancamentosRepository _lancamentosRepository;

        public SaldoConsolidadoService(ILancamentosRepository lancamentosRepository)
        {
            _lancamentosRepository = lancamentosRepository;
        }

        public async Task<SaldoResponse> ObtemSaldoConsolidado(DateTime data)
        {
            var lancamentos = await _lancamentosRepository.ObtemLancamentosPorDia(data);

            if (lancamentos == null || !lancamentos.Any())
                return new SaldoResponse { DataSaldoConsolidado = data, SaldoConsolidado = 0 };

            var debito = lancamentos.Where(w => w.TipoLancamento == 'd').Select(x => x.Valor).Sum();
            var credito = lancamentos.Where(w => w.TipoLancamento == 'c').Select(x => x.Valor).Sum();

            return new SaldoResponse { DataSaldoConsolidado = data, SaldoConsolidado = debito - credito };
        }
    }
}