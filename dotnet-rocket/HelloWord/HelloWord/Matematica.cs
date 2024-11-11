namespace HelloWord;

public class Matematica
{
    public (int? resultadoDaOperacao, string autor) OperacaoMatematica(int valor1 = 0, int? valor2 = 0)
    {
        int? resultadoDaOperacao = valor1 + valor2;

        return (resultadoDaOperacao!, "Tiago");
    }
}
