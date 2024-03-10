export class Prodavnica{
    constructor(naziv)
    {
        this.naziv=naziv;
        this.proizvodi=[];
        this.kontejner=null;
    }

    dodajProzivod(proizvod){
        this.proizvodi.push(proizvod);
    }

    crtajProdavnicu(host){
        if(!host)
            throw new Error("Host ne postoji");

        this.kontejner = document.createElement("div");
        this.kontejner.className="formaZaCrtanje";
        host.appendChild(this.kontejner);

        let labela = document.createElement("h2");
        labela.innerHTML=this.naziv;
        labela.classList.add("labela");
        this.kontejner.appendChild(labela);

        let tabela= document.createElement("table");
        tabela.className="tabela";
        this.kontejner.appendChild(tabela);   
        
        this.crtajHeder(tabela);

        this.proizvodi.forEach(p => {
            p.crtajProizvod(tabela);
        });

    }

    crtajHeder(host){

        let nizZag = ["Sifra", "Naziv", "Cena", "Kolicina"];

        let zaglavljeRed = document.createElement("tr");
        zaglavljeRed.className="zaglavlje";
        host.appendChild(zaglavljeRed);

        nizZag.forEach(element => {
            let zaglavlje = document.createElement("th");
            zaglavlje.innerHTML=element;
            zaglavlje.classList.add("zaglavlje");
            zaglavljeRed.appendChild(zaglavlje);
        });
    }
}