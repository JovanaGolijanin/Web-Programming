import { Prodavnica } from "./prodavnica.js";
import { Proizvod } from "./proizvod.js";

let prodavnica = new Prodavnica("Maxi");

let proizvod= new Proizvod("hleb", 123, 65, 100, prodavnica);
prodavnica.dodajProizvod(proizvod);
prodavnica.dodajProizvod(new Proizvod("mleko", 234, 87,40, prodavnica));
prodavnica.dodajProizvod(new Proizvod("jogurt", 235, 99,34, prodavnica));

prodavnica.crtaj(document.body);


let prodavnica2 = new Prodavnica("Lidl");

prodavnica2.dodajProizvod(new Proizvod("hleb2", 2234, 87,40));
prodavnica2.dodajProizvod(new Proizvod("mleko2", 2234, 87,40));
prodavnica2.dodajProizvod(new Proizvod("jogurt2", 2235, 99,34));

prodavnica2.crtaj(document.body);