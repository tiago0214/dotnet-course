using System.Text;

namespace HelloWord;

public class Program
{
    enum NivelDeDificuldade
    {
        Baixo = 10,
        Medio = 20,
        Alto = 30
    }

    public static void Main()
    {

        NivelDeDificuldade monstro = NivelDeDificuldade.Baixo;

        int monstroNumber = (int)monstro;

        Console.WriteLine(monstro.GetType());
        Console.WriteLine(monstroNumber);




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
}