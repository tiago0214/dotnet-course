class Cardnewsprof extends HTMLElement {
    constructor(){
        super();

        const shadow = this.attachShadow({mode:'open'})
        shadow.appendChild(this.build())
        shadow.appendChild(this.styles())
    };
    build () {
        const componentRoot = document.createElement('div')
        componentRoot.setAttribute('class','card')

        const cardLeft = document.createElement('div')
        cardLeft.setAttribute("class","card-left")

        const autor = document.createElement('span')
        autor.textContent = 'By '+ (this.getAttribute('autor') || 'Anonymous') //Com essa operação(), eu faço para ele usar o autor caso ele seja definido, caso ele não seja definido, ele usa o anonymous

        const linkTitle = document.createElement('a')
        linkTitle.textContent = this.getAttribute('title')
        linkTitle.href = this.getAttribute('link-title')

        const newsContent = document.createElement('p')
        newsContent.textContent = this.getAttribute('content')

        cardLeft.appendChild(autor)
        cardLeft.appendChild(linkTitle)
        cardLeft.appendChild(newsContent)

        const cardRight = document.createElement('div')
        cardRight.setAttribute("class","card-right")

        const newsImage = document.createElement('img')
        newsImage.src = this.getAttribute("photo") || '/Angular/Aula1/assets/default-profile.png'
        newsImage.alt = "Foto da noticia"
        cardRight.appendChild(newsImage)

        componentRoot.appendChild(cardLeft)
        componentRoot.appendChild(cardRight)

        return componentRoot
    };
    styles () {
        const style = document.createElement("style")
        style.textContent = `
        .card {
            width: 80%;
            display: flex;
            flex-direction: row;
            border: 1px solid black;
            box-shadow: 9px 9px 25px 11px rgba(0,0,0,0.75);
            -webkit-box-shadow: 9px 9px 25px 11px rgba(0,0,0,0.75);
            -moz-box-shadow: 9px 9px 25px 11px rgba(0,0,0,0.75);
            justify-content: space-between;
        
        }
        .card-left {
            display: flex;
            flex-direction: column;
            justify-content: center;
            padding: 10px;
        }
        
        .card-left > span {
            font-weight: 400;
        }
        
        .card-left > a {
            margin-top: 15px;
            font-size: 25px;
            text-decoration: none;
            color: black;
            font-weight: bold;
        }
        
        .card-left > p {
            color: gray;
        }
        
        .card .card-right img {
            width: 310px;
            max-width: 100%;
        }
        `


        return style
    };
}

customElements.define("card-news",Cardnewsprof)

//o textContent: informa que o conteudo interno de determinada coisa. Esta definada com base no que for definido dentro do atributo.