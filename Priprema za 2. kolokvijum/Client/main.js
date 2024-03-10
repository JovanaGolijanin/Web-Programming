import { Merac } from "./merac.js";

const host = document.body;

const sm = await fetch("https://localhost:5001/Merac/PreuzmiSveMerace");
const data = await sm.json();

for (let m of data) {
    const merac = new Merac(host, m.id, m.naziv, m.interval, m.boja, m.granicaOd, m.granicaDo,
        m.trenutnaVrednost, m.minimalnaIzmerenaVrednost,
        m.maksimalnaIzmerenaVrednost, m.prosecnaIzmerenaVrednost);

    merac.crtaj();
}