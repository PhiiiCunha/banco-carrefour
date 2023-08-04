Para executar a solution, basta apenas pressionar f5 e o swagger abri-ra em seu navegador.
Teremos dois(2) metodos no swagger.

1 metodo - (GET) metodo de consultar o saldo consolidado por dia, onde como parametro passamos o dia que queremos pegar o saldo consolidado

2 metodo - (POST) metodo onde fazemos os lancamentos, passamos um obejto via body onde temos as seguintes propriedades:
Valor - (double)
DataLancamento - (datetime)
TipoLancamento - (char) - onde passamos 'c' para Credito e 'd' para debito

-----------------------------------------------------------------------------------

na Program.cs criei uma lista com alguns lancamentos ja realizados, nao estou utilizando nenhum DB, porem na classe Repository deixei um exemplo de como seria a chamada ao DB para incluir na base as informacoes.

-----------------------------------------------------------------------------------

Como tinha uma prazo curto de entrega, decidi fazer o teste proposto simulando uma conexao, preenchendo uma lista static e consultando dela mesmo.