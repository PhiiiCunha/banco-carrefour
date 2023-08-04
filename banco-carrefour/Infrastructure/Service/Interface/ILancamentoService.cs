using banco_carrefour.Domain.Request;

namespace banco_carrefour.Infrastructure.Service.Interface
{
    public interface ILancamentoService
    {
        Task<bool> IncluirLancamento(LancamentoRequest request);
    }
}
