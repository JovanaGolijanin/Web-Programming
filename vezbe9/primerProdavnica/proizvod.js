export class Proizvod{
    constructor(naziv, sifra, cena, kolicina, prodavnica){
        this.naziv=naziv;
        this.sifra=sifra;
        this.cena=cena;
        this.kolicina=kolicina;
        this.prodavnica=prodavnica;
        this.container =null;
    }

    crtajProizvod(host){

        let red = document.createElement("tr");
        host.appendChild(red);
        this.container=red;

        let el=document.createElement("td");
        el.innerHTML=this.sifra;
        red.appendChild(el);
        
        el=document.createElement("td");
        el.innerHTML=this.naziv;
        red.appendChild(el);

        el=document.createElement("td");
        el.innerHTML=this.cena;
        red.appendChild(el);

        el=document.createElement("td");
        el.innerHTML=this.kolicina;
        el.className="kolicina";
        red.appendChild(el);
        
        let dugme = document.createElement("button");
        dugme.innerHTML="+";
        dugme.onclick=(ev)=>{
            this.promeniKolicinu("+");
        }
        red.appendChild(dugme);

        dugme = document.createElement("button");
        dugme.innerHTML="-";
        dugme.onclick=(ev)=>{
            this.promeniKolicinu("-");
        }
        red.appendChild(dugme);

        dugme = document.createElement("button");
        dugme.innerHTML="Obrisi";
        dugme.onclick= (ev)=>{
            this.obrisi();

        }
        red.appendChild(dugme);

    }

    obrisi(){
        let roditelj= this.container.parentNode;
        roditelj.removeChild(this.container);

        this.prodavnica.proizvodi = this.prodavnica.proizvodi.filter(p=>
            p.naziv!=this.naziv && p.sifra!==this.sifra);
            console.log(this.prodavnica.proizvodi);

        
    }

    promeniKolicinu(smer){
        if(smer =="+")
            this.kolicina++;
        else
            this.kolicina--;

        let kol=this.container.querySelector(".kolicina");
        console.log(kol);
        kol.innerHTML=this.kolicina;
    }
}