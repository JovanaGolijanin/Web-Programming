export class FirmaView{
    constructor(firma){
        if(typeof firma ==="undefined")
            throw new Error("Firma ne postoji");
        this.firma=firma;
    }

    crtaj(){
        const nazivFirme = document.createElement("h2");
        nazivFirme.innerHTML = this.firma.naziv;
        document.body.appendChild(nazivFirme);

        // table -> tbody ->
        // tr -> td, td, td (id, ime, plata)
        // tr -> td, td, td

        const tabelaRadnika = document.createElement("table");
        

        this.firma.radnici.forEach((radnik, index) =>{
            const red = document.createElement("tr");
            tabelaRadnika.appendChild(red);

            const radnikId = document.createElement("td");
            radnikId.innerHTML = radnik.id;
            red.appendChild(radnikId);

            const radnikIme = document.createElement("td");
            radnikIme.innerHTML = radnik.ime;
            red.appendChild(radnikIme);

            const radnikPlata = document.createElement("td");
            radnikPlata.innerHTML = radnik.plata;
            red.appendChild(radnikPlata);

            const dugmeSmanjiPlatu = document.createElement("button");
            dugmeSmanjiPlatu.innerHTML = "-";
            dugmeSmanjiPlatu.addEventListener("click", (event) =>{
                radnik.plata -= 10;
                radnikPlata.innerHTML = radnik.plata; 
                sumaPlataRedCelija.innerHTML = this.firma.vratiZbirPlata();
            })
            red.appendChild(dugmeSmanjiPlatu);
            
        });

        const sumaPlataRed = document.createElement("tr");
        tabelaRadnika.appendChild(sumaPlataRed);
        const sumaPlataRedCelija = document.createElement("td");
        sumaPlataRedCelija.colSpan = 4;
        sumaPlataRedCelija.innerHTML = this.firma.vratiZbirPlata();
        sumaPlataRed.appendChild(sumaPlataRedCelija);

        document.body.appendChild(tabelaRadnika);
    }
}