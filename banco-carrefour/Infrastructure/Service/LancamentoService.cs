using banco_carrefour.Domain.Request;
using banco_carrefour.Infrastructure.Repository.Interface;
using banco_carrefour.Infrastructure.Service.Interface;

namespace banco_carrefour.Infrastructure.Service
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentosRepository _lancamentosRepository;

        public LancamentoService(ILancamentosRepository lancamentosRepository)
        {
            _lancamentosRepository = lancamentosRepository;
        }

        public async Task<bool> IncluirLancamento(LancamentoRequest request)
        {
            return await _lancamentosRepository.InserirLancamento(request);
        }
    }
}
