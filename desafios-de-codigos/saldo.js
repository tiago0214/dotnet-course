let valorFinal = 5000;
let taxaDeJuros = 0.08;
let periodo = 5;

function compostos (valorInicial, taxaJuros, periodo){
    let valor = valorInicial ;
    
    for(i=0; i < periodo; i++ ){
        valor += (valor*taxaJuros) 
    }
    console.log('Valor final do investimento: R$', valor.toFixed(2));
}

compostos(valorFinal,taxaDeJuros, periodo)