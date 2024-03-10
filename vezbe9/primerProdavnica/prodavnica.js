export class Prodavnica{
    constructor(naziv) {
        this.proizvodi=[];
        this.naziv=naziv;
        this.container=null;
    }

    dodajProizvod(proizvod){
        this.proizvodi.push(proizvod);
    }

    crtaj(host){
        if(!host)
            throw new Error("Host ne postoji");

        this.container=document.createElement("div");
        this.container.className= "GlavnaForma";
        host.appendChild(this.container);

        let labNaziv=document.createElement("h2");
        labNaziv.innerHTML=this.naziv;
        this.container.appendChild(labNaziv);

        let tabela = document.createElement("table");
        this.container.appendChild(tabela);


        this.crtajHeder(tabela);
        this.proizvodi.forEach(p=>{
            p.crtajProizvod(tabela);
        })

    }

    crtajHeder(host){
        //Naziv, cena, kolicina, sifra
        let red = document.createElement("tr");
        host.appendChild(red);

        let nizNaziva = ["Sifra", "Naziv", "Cena", "Kolicina"];
        
        let h;
        nizNaziva.forEach(naziv=>{
            h = document.createElement("th");
            h.innerHTML=naziv;
            red.appendChild(h);
        })
        

    }


}