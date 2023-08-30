function calculadora () {
    const operacao = prompt('1 = soma \n 2 = subtração \n 3 = multiplicação \n 4 = divisão ')

    const n1 = Number(prompt('Digite um numero:'))
    const n2 = Number(prompt('Digite outro numero:'))
    let resultado;

    function somar () {
        resultado = n1+n2
        console.log(`${n1} + ${n2} : ${resultado}`)
    }

    if (operacao ==1){
        somar()
    }else if (operacao == 2){
        subtacao()
    }else if (operacao == 3) {
        multiplicao()
    } else if( operacao == 4){
        divisao()
    }

}

calculadora()