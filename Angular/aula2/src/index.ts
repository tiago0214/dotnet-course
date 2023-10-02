//declaração de variaveis

//tipos primitivos
let ligado:boolean = false;
let numero:number = 1;
let numeroDecimanl:number = 1.9;
let texto:string = "texto";


//tipos especiais
let nulo:null = null;
let indefindo:undefined= undefined;
//eu não consigo mais alterar os valores da varieis , elas vão ser sempre null e undefined.

//tipos abrangentes: any, void.

let retorno:void 
//ela não tem como retornar nada, o retorno e sempre vazio.(posso ter uma função com essa caracteristicas)

let retornoView:any= "Aceita adcionar qualquer coisa."

//criação de objetos

//sem previsibilidade: posso colocar qualquer coisa dentro dele.
let produto: object = {
    name:"Tiago",
    cidade: "Palmeiras",
    idade: 29,
};

//objeto , todo tipado. Com previsibilidade.
type ProdutoLoja = {
    nome : string;
    preco: number;
    unidades: number;
};
//então aqui, na criação do meu objeto, eu falo a estrutura que o meu objeto tem que respeitar.
//exemplo.
let meuProduto:ProdutoLoja = {
    nome:"tênis",
    preco: 20.10,
    unidades : 1,
}

//duas maneiras de declarar um array de string.
let dados: string[] = ["Teste","camisa","Sapato"]
let dados2: Array<string> = ["Teste","camisa","Sapato"]

//array, de dois tipos.
let info: (string|number)[] = ["tiago",29] //aqui eu posso declarar em qualquer ordem.

//tuplas: são vetores de multitype, mas ela tem o lugar certo para cada coisa.
let boleto:[string,number,number] = ["agua", 290, 71875230]

//metodos de arrays de JS funcionam todos aqui no TS.
info.map(()=>{});

//datas.

let aniversario:Date = new Date("8/16/2023 14:30")
console.log(aniversario.toString()) //toString() fica melhor de visualizar a data.

//funções

// Posso tipar os meus parametros e o retorno da minha função. e se o retorno da minha função é de um tipo(ex:number) só consigo guardar em uma variável que seja do mesmo tipo

//senão tipar o retorno da função, ele vai pegar de maneira implicita, pelo oque a gente esta passando no retorno.

function addNumber (x:number,y:number):number {
    return x + y
}

let soma:number = addNumber(2,3)

//funções de varios tipos

function callToPhone (phone:(number|string)) {
    return phone
}
//pode ser com explicitação do retorno ou não, posso usar o "any" também
function callTooPhone (phone:(number|string)) :number | string {
    return phone
}

//funções assincronas
//eu sempre preciso especificar o tipo da que a promisse vai retornar. E sempre preciso especificar que é uma promisse.
async function dataBase (id:number): Promise<string> {
    return "Tiago"
}


//interfaces (type x interface)

type robot1 = {
    id: number;
    name: string;
}
const bot:robot1 = {
    id: 1,
    name: "megaman"
}
interface robot2 {
    id:number | string; //posso fazer isso tambem no type
    name:string;
}
//os dois ai em cima vão funcionar igual

//interface: é como se fosse um contrato, e quem herdar esse contrato tem que respeitar.

//outra coisa, type geralmente usado: para tipar os tipos de uma variavel.
//interface, geralmente usado para quando for a respeito de classes.


//posso colocar uma propriedade readonly, ou seja, eu não posso mais mudar o valor da minha propriedade.
type robot3 = {
    readonly id: number;
    name: string;
}
interface robot5 {
    readonly id:number | string;
    name:string;
}

const bot2:robot5 = {
    id:1,
    name:"Coisa"
}
// bot2.id = 2; Não posso fazer isso: por causa do readonly
bot2.name = "dois" 
// se não tivesse essa propriedade, eu poderia mudar o valor das minhas variaveis criadas, com base no type e interface.
