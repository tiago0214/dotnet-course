"use strict";
//declaração de variaveis
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
function addNumber(x, y) {
    return x + y;
}
let soma = addNumber(2, 3);
console.log(soma);
