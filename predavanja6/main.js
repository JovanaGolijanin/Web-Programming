import { Firma } from "./firma.js"; 
import { FirmaView } from "./firma.view.js";
import { Radnik } from "./radnik.js";

const radnici = [];
radnici.push(new Radnik(1, "Milan", 200));
radnici.push(new Radnik(2, "Ana", 500));
radnici.push(new Radnik(3, "Laza", 240));
radnici.push(new Radnik(4, "Marko", 640));
radnici.push(new Radnik(5, "Jana", 300));
radnici.push(new Radnik(6, "Ivana", 120));

const firma = new Firma("Firmica", radnici);
console.log("%c" + firma.vratiZbirPlata(), "background-color:red; color:white;font-size:30px");

const firmaView = new FirmaView(firma);
firmaView.crtaj();