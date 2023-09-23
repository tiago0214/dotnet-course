class CardNews extends HTMLElement {      //extends : significa que ele vai se comportar igual um elemento HTML
    constructor () {
        super();

        const shadow = this.attachShadow({mode:"open"}) //(mode: open) outra classe possa influenciar nessa. (closed) encapsula.
        shadow.innerHTML= "<h1>Hello Word</h1>"
    }
}
//super: é para invocar o método construtor de quem você está herdando (nesse caso estamos herdando do HTMLElement)
//constructor : é um método construtor da nossa classe em si.

customElements.define('card-news',CardNews)
//estou criando um elemento customizado, e estou definando que ele vai ser utilizado atraves desse seletor(card-news), e CardNews é o metodo construtor dele