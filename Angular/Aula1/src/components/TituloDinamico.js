class TituloDinamico extends HTMLElement {
    constructor() {
        super();

        const shadow = this.attachShadow({mode:'open'})

        //base do componente----------------------------------
        const componentRoot = document.createElement('h1')
        componentRoot.textContent = 'Tiago'

        //estilazação-----------------------------------------
        const style = document.createElement('style')
        style.textContent = `
            h1 {
                color: red;
            }
        `
        //enviar para a shadow--------------------------------
        shadow.appendChild(componentRoot)
        shadow.appendChild(style)
    }
}
//lembrar que tudo oque eu criar separado, ou seja, fora do shadow. Eu preciso anexar ele a nossa shadow. 
//por isso no cardNews, eu não precisei. Porque eu fiz direto na shadow.

//eu posso criar mais de um elemento dinamico.

customElements.define("titulo-dinamico",TituloDinamico)



//lembrar que é a mesma coisa que eu estivesse criando as tags(elementos)
//eu utilizei o template string no style, para ficar mais facil, poderia usar '' ou "", de mesmo jeito dos outros.
//lembrar que eu posso colocar a minha tag <style> no meu documento HTML e estilar por lá. Aqui é como se fosse a mesma coisa