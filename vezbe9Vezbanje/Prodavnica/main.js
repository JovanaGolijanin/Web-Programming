import { Prodavnica } from "./prodavnica.js";
import { Proizvod } from "./proizvod.js";

let prodavnica1 = new Prodavnica("Maxi");

let proizvod1 = new Proizvod("123", "hleb", "65", "104", prodavnica1);
let proizvod2 = new Proizvod("234", "mleko", "87", "37", prodavnica1);
let proizvod3 = new Proizvod("235", "jogurt", "99", "34", prodavnica1);

prodavnica1.dodajProzivod(proizvod1);
prodavnica1.dodajProzivod(proizvod2);
prodavnica1.dodajProzivod(proizvod3);

prodavnica1.crtajProdavnicu(document.body);


let prodavnica2 = new Prodavnica("Lidl");

let proizvod21 = new Proizvod("2123", "hleb", "87", "40", prodavnica1);
let proizvod22 = new Proizvod("2234", "mleko", "87", "40", prodavnica1);
let proizvod23 = new Proizvod("2235", "jogurt", "99", "34", prodavnica1);

prodavnica2.dodajProzivod(proizvod21);
prodavnica2.dodajProzivod(proizvod22);
prodavnica2.dodajProzivod(proizvod23);

prodavnica2.crtajProdavnicu(document.body);