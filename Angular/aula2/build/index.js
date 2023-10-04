"use strict";
//declaração de variaveis
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
//tipos primitivos
let ligado = false;
let numero = 1;
let numeroDecimanl = 1.9;
let texto = "texto";
//tipos especiais
let nulo = null;
let indefindo = undefined;
//eu não consigo mais alterar os valores da varieis , elas vão ser sempre null e undefined.
//tipos abrangentes: any, void.
let retorno;
//ela não tem como retornar nada, o retorno e sempre vazio.(posso ter uma função com essa caracteristicas)
let retornoView = "Aceita adcionar qualquer coisa.";
//criação de objetos
//sem previsibilidade: posso colocar qualquer coisa dentro dele.
let produto = {
    name: "Tiago",
    cidade: "Palmeiras",
    idade: 29,
};
//então aqui, na criação do meu objeto, eu falo a estrutura que o meu objeto tem que respeitar.
//exemplo.
let meuProduto = {
    nome: "tênis",
    preco: 20.10,
    unidades: 1,
};
//duas maneiras de declarar um array de string.
let dados = ["Teste", "camisa", "Sapato"];
let dados2 = ["Teste", "camisa", "Sapato"];
//array, de dois tipos.
let info = ["tiago", 29]; //aqui eu posso declarar em qualquer ordem.
//tuplas: são vetores de multitype, mas ela tem o lugar certo para cada coisa.
let boleto = ["agua", 290, 71875230];
//metodos de arrays de JS funcionam todos aqui no TS.
info.map(() => { });
//datas.
let aniversario = new Date("8/16/2023 14:30");
console.log(aniversario.toString()); //toString() fica melhor de visualizar a data.
//funções
// Posso tipar os meus parametros e o retorno da minha função. e se o retorno da minha função é de um tipo(ex:number) só consigo guardar em uma variável que seja do mesmo tipo
//senão tipar o retorno da função, ele vai pegar de maneira implicita, pelo oque a gente esta passando no retorno.
function addNumber(x, y) {
    return x + y;
}
let soma = addNumber(2, 3);
//funções de varios tipos
function callToPhone(phone) {
    return phone;
}
//pode ser com explicitação do retorno ou não, posso usar o "any" também
function callTooPhone(phone) {
    return phone;
}
//funções assincronas
//eu sempre preciso especificar o tipo da que a promisse vai retornar. E sempre preciso especificar que é uma promisse.
function dataBase(id) {
    return __awaiter(this, void 0, void 0, function* () {
        return "Tiago";
    });
}
const bot = {
    id: 1,
    name: "megaman"
};
const bot2 = {
    id: 1,
    name: "Coisa",
    sayHello() { return ""; }
};
// bot2.id = 2; Não posso fazer isso: por causa do readonly
bot2.name = "dois";
// se não tivesse essa propriedade, eu poderia mudar o valor das minhas variaveis criadas, com base no type e interface.
//criar uma class
class Pessoa {
    constructor(id, name) {
        this.id = id,
            this.name = name;
    }
    sayHello() {
        return `Olá ${this.name}`;
    }
}
const p = new Pessoa(1, "Megaman");
console.log(p.sayHello());
//classes
class character {
    attack() {
        console.log(`Atacou`);
    }
    constructor(name, stregth, skill) {
        this.name = name;
        this.stregth = stregth;
        this.skill = skill;
    }
}
// ? quer dizer que pode ter ou não a propriedade.
//retorno:void (quer dizer que ele não exibir nada para outras funções)
const p1 = new character("Tiago", 29, 100);
console.log(p1);
//data modifiers : é quem pode acessar um determinado dado da classe.
class magician extends character {
    constructor(name, stregth, skill, magicianPoints) {
        super(name, stregth, skill);
        this.magicianPoints = magicianPoints;
    }
}
const p3 = new magician("Mago", 2, 40, 100);
console.log(p3);
//extends : é para herdar : vou precisar do super()
//o metodo super() é para invocar o construtor da minha classe pai.
//classe Pai = superclass
//classe filha = subclass
