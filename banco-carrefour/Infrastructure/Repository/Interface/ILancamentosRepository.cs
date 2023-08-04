using banco_carrefour.Domain.Entities;
using banco_carrefour.Domain.Request;

namespace banco_carrefour.Infrastructure.Repository.Interface
{
    public interface ILancamentosRepository
    {
        Task<IEnumerable<Lancamento>> ObtemLancamentosPorDia(DateTime data);
        Task<bool> InserirLancamento(LancamentoRequest request);
    }
}