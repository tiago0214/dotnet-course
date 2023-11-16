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
//console.log(aniversario.toString()) //toString() fica melhor de visualizar a data.

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
//classes é como se fosse um molde.


//posso colocar uma propriedade readonly, ou seja, eu não posso mais mudar o valor da minha propriedade.
type robot3 = {
    readonly id: number;
    name: string;
}
interface robot5 {
    readonly id:number | string;
    name:string;
    sayHello():string
}

const bot2:robot5 = {
    id:1,
    name:"Coisa",
    sayHello(){return ""}
}
// bot2.id = 2; Não posso fazer isso: por causa do readonly
bot2.name = "dois" 
// se não tivesse essa propriedade, eu poderia mudar o valor das minhas variaveis criadas, com base no type e interface.

//criar uma class

class Pessoa implements robot5 {
    id: string | number;
    name: string;

    constructor(id:string|number, name:string) {
        this.id = id,
        this.name = name
    }
    sayHello(): string {
        return `Olá ${this.name}`
    }
}

const p = new Pessoa(1,"Megaman")

//console.log(p.sayHello())

//classes

class character {
    name?: string;
    stregth?: number;
    skill:number;

    attack():void{
        console.log(`Atacou`)
    }

    constructor(name:string,stregth:number,skill:number){
        this.name=name;
        this.stregth= stregth;
        this.skill = skill;
    }
}
// ? quer dizer que pode ter ou não a propriedade.
//retorno:void (quer dizer que ele não exibir nada para outras funções)

const p1 = new character("Tiago",29,100)

//console.log(p1)

//data modifiers : é quem pode acessar um determinado dado da classe.

class magician extends character {
    magicianPoints: number;

    constructor(name:string, stregth:number,skill:number,magicianPoints:number){
        super(name,stregth,skill)
        this.magicianPoints = magicianPoints
    }


}
const p3 = new magician("Mago",2,40,100)

//console.log(p3)

//extends : é para herdar : vou precisar do super()
//o metodo super() é para invocar o construtor da minha classe pai.
//classe Pai = superclass
//classe filha = subclass

//mesmo se eu tivesse definido os atributos como privited, eu poderia acessa-los , por meio do construtor. super() 

//concatenar dois array. (generics)

function concatenar (...itens:any[]):any[] {
    return new Array().concat(...itens)
}

const numArray = concatenar([1,5],[3])
numArray.push('Olá')
//console.log(numArray)
//essa parte do código esta quebrada. porque eu consigo dar .push('asdasd') porque esta com o retorno de any, eu posso fazer qualquer coisa
//so que eu posso arrumar, colocando na função um retorno generico, e eu delimito qual é o retorno que eu quero na minha variavel.

function concatenar2<T> (...inte:T[]):T[]{
    return new Array().concat(...inte);
}

const num = concatenar2<number[]>([2,3],[6])
//console.log(num)
//agora, dentro da minha variavel, só vai caber numeros, e se eu tentar fazer .push('asda') da erro.

//decorators

function teste (target:any) {
    console.log(target)
}

// const a: string = "Alou você, decoretors na area "
//@teste
class func {}
//decorators: Não funciona em tudo. Acredito que somente em class

//fazer mais decoretors,uteis.



function apiVersion (version:string) {
    return (target:any) => {
        Object.assign(target.prototype, {__version: version})
    }
    //facotory, uma função que vai retornar outra função.
}
//propriedade injetada pelo decorators
@apiVersion("1.30")
class apii {}

const prot = new apii();
console.log(prot.__version)

//atribute  decoretors : coloca em cima de uma propriedade


function miniLength (length:number) {
    return (target:any , key:string) => {   
         let _value = target[key]

         const getter = ()=> "[play]" + _value
         const setter = (value:string) => {
            if (value.length < length) {
                throw new Error(`Valor mínimo ${length}`);
            }else {
                _value = value;
            }
            }
                Object.defineProperty(target,key,{
                get:getter,
                set:setter,
                })
         
    }
}
class API {
    @miniLength(20)
    name:string;
    
    constructor(name:string){
        this.name = name;
    }
}
const AP = new API("prs")
console.log(AP.name)

//se atentar aqui, que eu estou subistituindo os metodos que estão por baixo dos panos, quando eu tento ler e definir um valor dentro de uma propriedade.
//lembrar dar propriedades(chaves), key(valor)
//estou fazendo uma coisa totalmente nova, eu poderia colocar para dizer algo, toda vez que a propriedade for lida.



