using banco_carrefour.Domain.Response;

namespace banco_carrefour.Infrastructure.Service.Interface
{
    public interface ISaldoConsolidadoService
    {
        Task<SaldoResponse> ObtemSaldoConsolidado(DateTime data);
    }
}
