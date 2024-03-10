class Vozilo{
    constructor(model, tezinaUTonama=1, maxBrzina=100){
        this.TrenutnaBrzina =0;
        this.tezina =tezinaUTonama;
        this.maxBrzina=maxBrzina; //?? 100;
        this.model =model;

    }
    ubrzaj(){
        if(this.TrenutnaBrzina < this.maxBrzina)
            this.TrenutnaBrzina+=10;
        console.log(`Trenutna brzina je: ${this.TrenutnaBrzina}`);
    }
}

class Avion extends Vozilo{
    constructor( model, tezina, maxBrzina){
        super(model, tezina, maxBrzina);
        this.trenutnaVisina=0;
    }
    ubrzaj(){
        super.ubrzaj();
        this.trenutnaVisina +=5;
    }
}

const vozilo1 = new Vozilo("Yugo", 1,150);
const avion1 = new Avion("Boing 737",100, 900 );