using System.Text;

namespace HelloWord;

public class Program
{
    public static void Main()
    {
        Dictionary<string,string> dic = new Dictionary<string,string>();
        dic.Add("k1", "valor 1");
        dic.Add("k2", "valor 2");
        dic.Add("k3", "valor 3");
        
        foreach (KeyValuePair<string,string> key in dic)
        {
            Console.WriteLine(key);
        }
    }

    //int numero = 10;

    //string resultado = numero switch
    //{
    //    7 => "Tiago",
    //    8 => "Shara",
    //    9 => "Camille",
    //    _ => "Desconhecido"
    //};

    //Console.WriteLine(resultado);

    //var carro = new Carro { 
    //    Cor = Cor.Cinza,
    //    Modelo = "Lamborghini",
    //    LancadoEm = new DateOnly(2020,02,10)
    //};

    //carro.NomeDoModelo();

    //var matematica = new Matematica();

    //(int? resultado,string autor) = matematica.OperacaoMatematica(valor2:null);

    //Console.WriteLine(resultado);
    //Console.WriteLine(autor);

    //int? idade = 30;

    //bool minhaIdade = idade.HasValue;

    //Console.WriteLine(idade);



    //NivelDeDificuldade monstro = NivelDeDificuldade.Baixo;

    //int monstroNumber = (int)monstro;

    //Console.WriteLine(monstro);
    //Console.WriteLine(monstroNumber);


    //string t = "alo";
    //String t1 = new String("texto");

    //StringBuilder stringBuild = new StringBuilder();
    //stringBuild.Append(t);
    //stringBuild.Append(t1);

    //Console.WriteLine(stringBuild.ToString());

    //string texto = "Esse texto {0} {1} não sei";

    //string resultado = string.Format(texto, "Tem algo,", "que");

    //Console.WriteLine(resultado); 
}

enum NivelDeDificuldade
{
    Baixo = 10,
    Medio = 20,
    Alto = 30
}