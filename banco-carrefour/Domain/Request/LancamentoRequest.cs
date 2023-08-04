
namespace banco_carrefour.Domain.Request
{
    public class LancamentoRequest
    {
        public double Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public char TipoLancamento { get; set; }
    }
}