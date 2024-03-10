export class Proizvod {

    constructor(sifra, naziv, cena, kolicina, prodavnica)
    {
        this.sifra=sifra,
        this.naziv=naziv,
        this.cena=cena,
        this.kolicina=kolicina,
        this.prodavnica=prodavnica
        this.kontejner=null

    }

    crtajProizvod(host){
        if(!host)
            throw new Error("Host ne postoji!");

        let red = document.createElement("tr");
        red.className="prozivod";

        this.kontejner = red;
        host.appendChild(this.kontejner);

        let d = document.createElement("td");
        d.innerHTML=this.sifra;
        red.appendChild(d);

        d = document.createElement("td");
        d.innerHTML=this.naziv;
        red.appendChild(d);

        d = document.createElement("td");
        d.innerHTML=this.cena;
        red.appendChild(d);

        let d2 = document.createElement("td");
        d2.innerHTML=this.kolicina;
        d2.className="kolicina";
        d2.id="kolicina";
        red.appendChild(d2);

        let dugme = document.createElement("button");
        dugme.innerHTML="+";
        dugme.classList.add("povecaj");
        red.appendChild(dugme);
        dugme.onclick = () =>{
            this.promeniKolicinu(dugme);
        }

        let dugme2 = document.createElement("button");
        dugme2.innerHTML="-";
        dugme2.classList.add("smanji");
        red.appendChild(dugme2);
        dugme2.onclick = () =>{
            this.promeniKolicinu(dugme2);
        }

        let dugme3 = document.createElement("button");
        dugme3.innerHTML="Obrisi";
        dugme3.classList.add("obrisi");
        red.appendChild(dugme3);

        dugme3.onclick = () =>{
            this.obrisi();
        }

    }

    promeniKolicinu(dugme){

        if(dugme.className==="povecaj"){
            this.kolicina++;
        }
        else if(dugme.className==="smanji"){
            this.kolicina--;
        }

        let kol=this.kontejner.querySelector(".kolicina");
        console.log(kol);
        kol.innerHTML=this.kolicina;
        
    }

    obrisi(){
        let roditelj= this.kontejner.parentNode;
        roditelj.removeChild(this.kontejner);

        this.prodavnica.proizvodi = this.prodavnica.proizvodi.filter((p) => 
        p.naziv !== this.naziv && p.sifra !== this.sifra);
        console.log(this.prodavnica.proizvodi);
    }
}