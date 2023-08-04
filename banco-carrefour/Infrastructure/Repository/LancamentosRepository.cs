using banco_carrefour.Domain;
using banco_carrefour.Domain.Entities;
using banco_carrefour.Domain.Request;
using banco_carrefour.Infrastructure.Repository.Interface;
using System.Text;

namespace banco_carrefour.Infrastructure.Repository
{
    public class LancamentosRepository : ILancamentosRepository
    {
        public async Task<IEnumerable<Lancamento>> ObtemLancamentosPorDia(DateTime data)
        {
            /*
             Esta classe seria a minha comunicacao com o banco de dados, onde eu faria um select na tabela retornaria os dados pegaria o saldo consolidado

             Segue Exemplo de Como seria a Query e a chamada para o banco de dados

                    try
                    {
                        var query = new StringBuilder();

                        query.Append("SELECT Valor, DataLancamento, TipoLancamento ");
                        query.Append("FROM lancamentos ");
                        query.Append("WHERE DataLancamento >= @Data AND DataLancamento <= @Data ");

                        var connection = new SqliteConnection("connection string");

                        return await connection.QueryAsync<Lancamento>(query.ToString(), new { Data = data });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
             */

            return ListaLancamentos.Lancamentos.Where(w => w.DataLancamento.Date == data.Date);
        }

        public async Task<bool> InserirLancamento(LancamentoRequest request)
        {
            /*
             Esta classe seria a minha comunicacao com o banco de dados, onde eu faria um insert na tabela de lancamentos

             Segue Exemplo de Como seria a inclusao e a chamada para o banco de dados

                    try
                    {
                        var query = new StringBuilder();

                        query.Append("INSERT INTO lancamentos ");
                        query.Append("(Valor, ");
                        query.Append("DataLancamento, ");
                        query.Append("TipoLancamento ");
                        query.Append(") VAUES (");
                        query.Append("(@Valor, ");
                        query.Append("@DataLancamento, ");
                        query.Append("@TipoLancamento )");

                        var connection = new SqliteConnection("connection string");

                        var idMovimento = await connection.QueryFirstOrDefaultAsync<string>(query.ToString(), request, commandType: CommandType.Text);

                        return new Resultado { Codigo = 200, Mensagem = null, Retorno = idMovimento };
                    }
                    catch (Exception ex)
                    {
                        return new Resultado { Codigo = 999, Retorno = null, Mensagem = ex.Message };
                    }
             */

            try
            {
                ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = request.Valor, TipoLancamento = request.TipoLancamento, DataLancamento = request.DataLancamento });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}