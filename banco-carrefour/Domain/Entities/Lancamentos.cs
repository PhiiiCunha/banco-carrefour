
namespace banco_carrefour.Domain.Entities
{
    public static class ListaLancamentos
    {
        public static List<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();
    }

    public class Lancamento
    {
        public double Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public char TipoLancamento { get; set; }
    }
}