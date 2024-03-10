export class Prodavnica
{
    constructor(naziv, lokacija, meni, zalihe){
        this.naziv=naziv;
        this.lokacija=lokacija;
        this.meni=meni;
        this.zalihe=zalihe;
        this.kontejner = null;
    }

    crtajProdavnicu(host){
        if(!host)
            throw new Error("Host nije pronadjen!");

        let forma = document.createElement("div");
        forma.classList.add("GlavnaForma");
        this.kontejner=forma;
        host.appendChild(this.kontejner);
        
        let labela1 = document.createElement("h3");
        labela1.classList.add("naslov");
        labela1.innerHTML="Brza hrana - 001";
        this.kontejner.appendChild(labela1);

        let div = document.createElement("div");
        div.classList.add("div");
        this.kontejner.appendChild(div);

        let formaPorucivanje = document.createElement("div");
        formaPorucivanje.classList.add("formaPorucivanje");
        div.appendChild(formaPorucivanje);

        let labela = document.createElement("label");
        labela.classList.add("labela");
        labela.innerHTML="PORUCIVANJE";
        formaPorucivanje.appendChild(labela);

        let divZaProizvod = document.createElement("div");
        divZaProizvod.classList.add("divZaProizvod");
        formaPorucivanje.appendChild(divZaProizvod);

        labela = document.createElement("label");
        labela.classList.add("labela");
        labela.innerHTML="Proizvod";
        divZaProizvod.appendChild(labela);

        let se = document.createElement("select");
        se.classList.add("selekcija");
        divZaProizvod.appendChild(se);

        let op = document.createElement("option");
        op.innerHTML="Pica";
        se.appendChild(op);

        let divZaKolicinu = document.createElement("div");
        divZaKolicinu.classList.add("divZaKolicinu");
        formaPorucivanje.appendChild(divZaKolicinu);

        labela = document.createElement("label");
        labela.classList.add("labela");
        labela.innerHTML="Kolicina";
        divZaKolicinu.appendChild(labela);

        let unos = document.createElement("input");
        unos.type="input";
        divZaKolicinu.appendChild(unos);

        let divZaDugme = document.createElement("div");
        divZaDugme.classList.add("divZaDugme");
        formaPorucivanje.appendChild(divZaDugme);

        let dugme = document.createElement("button");
        dugme.innerHTML="Poruči";
        divZaDugme.appendChild(dugme);


        let formaNabavka = document.createElement("div");
        formaNabavka.classList.add("formaNabavka");
        div.appendChild(formaNabavka);

        labela = document.createElement("label");
        labela.classList.add("labela");
        labela.innerHTML="Nabavka";
        formaNabavka.appendChild(labela);

        let divZaCb = document.createElement("div");
        divZaCb.classList.add("divZaCb");
        formaNabavka.appendChild(divZaCb);

        let cb = document.createElement("input");
        cb.type="checkbox";
        divZaCb.appendChild(cb);
        
        labela = document.createElement("label");
        labela.innerHTML="200gr sunka";
        divZaCb.appendChild(labela);

        cb = document.createElement("input");
        cb.type="checkbox";
        divZaCb.appendChild(cb);
        
        labela = document.createElement("label");
        labela.innerHTML="500gr brasna";
        divZaCb.appendChild(labela);

       /*  cb = document.createElement("input");
        cb.type="checkbox";
        divZaCb.appendChild(cb);
        
        labela = document.createElement("label");
        labela.innerHTML="100gr kackavalja";
        divZaCb.appendChild(labela);

        cb = document.createElement("input");
        cb.type="checkbox";
        divZaCb.appendChild(cb);
        
        labela = document.createElement("label");
        labela.innerHTML="1200gr krompira";
        divZaCb.appendChild(labela); */

        let divZaDugme2 = document.createElement("div");
        divZaDugme2.classList.add("divZaDugme2");
        formaNabavka.appendChild(divZaDugme2);

        let dugme2 = document.createElement("button");
        dugme2.innerHTML="Dostavi";
        divZaDugme2.appendChild(dugme2);
        
        
    }
}