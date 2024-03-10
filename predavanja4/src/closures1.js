function spoljna(){
    const poruka = "pozdrav iz spoljne";

    return function unutrasnja(msg){
        console.log(poruka + ", " + msg);
    }

}

const fja = spoljna(); //pokazivac na unutrasnju f-ju
fja("nova poruka");
console.log(fja);