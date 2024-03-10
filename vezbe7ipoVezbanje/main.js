let dg = document.getElementById("idbtn");

dg.onclick = (ev) =>
{
    alert("Zdravo!");
};

console.log("Joksi pametnica mala");

let parametar;
console.log(parametar);
parametar= 5;

let naziv = `Broj ${parametar}`;
console.log(naziv);


let br2 = kvadrat(10);
console.log(br2);

function kvadrat(broj)
{
    let stepen = broj*broj;
    return stepen;
}
let br = kvadrat(7);
console.log(br);

//funkcionalni izraz

let FE = function(broj)
{
    let stepen = broj*broj;
    return stepen;
}
let rez = FE(8);
console.log(rez);

//alert("Joksi je super pametna");

//let vr = prompt("Unesite vrednost za ispis: ");
//console.log(`Unesli ste: ${vr}`);

let niz = ["Joksi", "MalaJoksi", "..itd"];

niz.unshift("Kraljica");
niz.push("bff 4ever");
console.log(niz.pop());

    niz.forEach(x => {
        console.log(x);
    });

    niz.forEach(function (x){
        console.log(x);
    });

console.log(niz.shift());

let h1 = document.querySelector("h1");

h1.style.color="red";

let h2 = document.getElementById("drugi");
h2.style.backgroundColor = "violet";

let naslov = document.getElementsByTagName("h1");
naslov[0].style.color="black";

let tr = document.getElementsByClassName("treca");
tr[0].style.backgroundColor = "pink";

/* let sel = document.querySelector("li");
sel.style.backgroundColor="deeppink"; */

let sel2 = document.querySelectorAll("li");
sel2[0].style.backgroundColor="deeppink";

function fun(){
    let prom = document.getElementById("cetri");
    prom.style.backgroundColor = "purple";
}

window.setTimeout(fun, 700);
    
let blok =document.createElement("div");
blok.innerHTML="Kliknite na dugme.";
document.body.appendChild(blok);

let dugme = document.createElement("input");
dugme.type = "button";
dugme.value = "Dugme";
dugme.onclick = klik;// definišemo event handler
document.body.appendChild(dugme);

function klik() {
    blok.innerHTML = "Kliknuto!";   // da li je ovde vidljiva promenljiva blok i zašto?
}

console.log(lambdaParametar =>
    {
        teloLambdaFje = lambdaParametar++;
    });