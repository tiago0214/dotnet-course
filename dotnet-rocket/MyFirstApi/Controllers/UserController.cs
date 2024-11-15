using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]//indica para o ASP.NET que é uma classe especial. Para ele usar os métodos dessa classe.
public class UserController : ControllerBase // herança aqui, somente para usar as funções já prontos
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Get(int id)
    {
        var response = new Response
        {
            Age = 30,
            Name = "Tiago"
        };

        return Ok(response);
    }

}

// preciso sempre usar o IActionResult, porque o retorno do meu método é uma interface, lembre-se no C# eu sempre preciso especificar o retorno
// por isso eu preciso colocar o IActionResult, porque o retorno do meu método é do ASP.NET. Eu consigo ter acesso a esse método por causa da herança


//lembre-se, eu estou passando algumas informações para que o ASP.NET termine de criar o meu servidor
// testar , colocar um console.write antes do retorno do objeto

// claro que não vai dar em nada porque o ASP.NET já montou o meu servidor e outra, ele usa os métodos dele para devolver a resposta para o cliente
// o que eu acho que realmente é valido é o retorno do método, porque se eu precisa-se retornar da minha própria função vinculado, acho
// que teria mais dificuldade porque eu estaria querendo usar um metodo da minha classe que eu nem estou instanciado. o ASP.NET montou tudo
// mas eu não fiz nada, não tenho certeza se ele conseguiria pegar o valor do retorno da minha função que tem o atributo atraves de reflection
// por isso que o retorno de uma função de algum endpoint precisa ser o metodo que vem de dentro do ASP.NET

//lembre-se compilar o seu programa, ele não vai executar o programa, ele somente vai traduzir para a linguagem de maquina
// quando eu uso atributos, eu consigo recuperar as classes com esses atributos em tempo de execução, ou seja, eu consigo invocar os código assembly
// que foi gerado, e em tempo de execução eu checo onde esta os atributos e as classes que tem aqueles atributos, como também eu consigo executar metodos
// que tem os atributos que eu quiser. Ou seja, eu consigo praticamente fazer tudo. Porque o meu código que vai checar os atributos vai ser executado
// somente quando eu executar o programa, ou seja, todos os atributos já foram definidos nas classes, porque o meu programa foi compilado com os atributos.

// Não se esqueça, eu utilizo os metodos prontos para retorno por exemplo o Ok(), somente porque ele monta tudo para mim, por exemplo o header
// e toda transmição de dado e conversão para JSON e outras coisas, eu consigo fazer tudo na mão. Mas ai eu vou ter que escrever tudo. O retorno do metodo Ok,
// é somente para facilitar. Porque eu somente retorno o body da resposta.

// O que me pegou , foi o fato de eu estar definindo classes e não executando nada. Estou deixando parada. Mas na real é porque o ASP.NET esta fazendo
//tudo para mim. Ele esta usando reflection, porque ele é uma lib. Para pegar as minhas classes e execução dos meus métodos.