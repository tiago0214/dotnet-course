const pokeApi = {}

function convertPokeApiDetailPokemon (pokeDetail) {
    const pokemon = new Pokemon()
    pokemon.number = pokeDetail.order
    pokemon.name = pokeDetail.name

    const types = pokeDetail.types.map( (typeSlot) => typeSlot.type.name) //não esquercer do return implicito
    const [type] = types //pegando sempre o primeiro retorno de valor


    pokemon.types = types
    pokemon.type = type
    pokemon.photo = pokeDetail.sprites.other.dream_world.front_default
    return pokemon
}

pokeApi.getPokemon = (pokemonAtual) => {

    return fetch(pokemonAtual.url)
            .then((convert) => convert.json())
            .then (convertPokeApiDetailPokemon) 

}

pokeApi.getPokemons = (offset = 0, limit = 5) => {
    const url = `https://pokeapi.co/api/v2/pokemon/?offset=${offset}&limit=${limit}`

    return fetch(url)
            .then((response) => response.json())
            .then((jsonBody) => jsonBody.results)
            .then((pokemons) => pokemons.map(pokeApi.getPokemon))
            .then((detailRequest) => Promise.all(detailRequest)) 
            .then ((resposta) => resposta)

}