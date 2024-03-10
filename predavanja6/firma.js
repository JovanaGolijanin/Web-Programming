export class Firma{
    constructor(naziv, radnici){
        this.naziv=naziv;
        this.radnici=radnici ?? [];
    }
    vratiZbirPlata(){
        return this.radnici
            .map(radnik =>radnik.plata)
            .reduce((acc, plata)=>{
                acc+=plata;
                return acc;
            }, 0);
    }
}