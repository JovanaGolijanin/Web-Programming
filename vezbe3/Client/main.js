import { Fakultet } from "./Fakultet.js";
import { Predmet } from "./Predmet.js";
import {Rok} from "./Rok.js";

var listaPredmeta =[];

fetch("http://localhost:5038/Predmet/PreuzmiPredmete/")
.then(p=>{
    p.json().then(predmeti =>{
        predmeti.forEach(predmet=>{
            //console.log(predmet);
            var p = new Predmet(predmet.id, predmet.naziv);
            listaPredmeta.push(p);
        });
        
    })
})
console.log(listaPredmeta);

var listaRokova=[];

fetch("http://localhost:5038/Ispit/IspitniRokovi")
.then(p=>{
    p.json().then(rokovi =>{
        rokovi.forEach(rok=>{
            var r = new Rok(rok.id, rok.naziv);
            listaRokova.push(r);
        })
        var f = new Fakultet(listaPredmeta, listaRokova);
        f.crtaj(document.body);
    })
}) 
console.log(listaRokova);

