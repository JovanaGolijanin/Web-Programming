
export class Proizvod {

    constructor(sifra, naziv, cena){
        this.sifra=sifra;
        this.naziv=naziv;
        this._cena=cena;
        this._kolicina = 0;
    }

    get kolicina(){
        return this._kolicina;
    }

    set kolicina(novaKolicina){
        this._kolicina= novaKolicina;
    }

    get cena(){
        if(this.kolicina > 10){
            return this._cena *0.8;
        }
        else if(this.kolicina<3){
            return this._cena*1.5;
        }
        else{
            return this._cena;
        }
        
    }

    set cena(novaCena){
        this._cena = novaCena;
    }


}

const laptop = new Proizvod(123, "Laptop", 13000);
laptop.kolicina=12;
console.log(laptop.cena);
