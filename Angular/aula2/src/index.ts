type hero = {
    name: string;
    vulgo: string;
};

function printaObjetos (pessoa:hero) {
    console.log(pessoa)
}

printaObjetos({
    name: "Bruce Wayne",
    vulgo: "Batman",
})