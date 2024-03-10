export class Klub{
    constructor(naziv, police){
        this.naziv=naziv;
        this.police=police;
        this.kontejner=null;
    }
crtajKlub(host){
    if(!host)
        throw new Error("Host ne postoji!");

    let glavnaForma = document.createElement("div");
    glavnaForma.classList.add("glavnaForma");
    this.kontejner=glavnaForma;
    host.appendChild(this.kontejner);

    let forma = document.createElement("div");
    forma.classList.add("forma");
    this.kontejner.appendChild(forma);
    
    let divZaCb = document.createElement("div");
    divZaCb.classList.add("divZaCb");
    forma.appendChild(divZaCb);

    let cb = document.createElement("input");
    cb.type="checkbox";
    divZaCb.appendChild(cb);

    let labela = document.createElement("label");
    labela.classList.add("labela");
    labela.innerHTML="Drama";
    divZaCb.appendChild(labela);

    ///
    divZaCb = document.createElement("div");
    divZaCb.classList.add("divZaCb");
    forma.appendChild(divZaCb);

    cb = document.createElement("input");
    cb.type="checkbox";
    divZaCb.appendChild(cb);

    labela = document.createElement("label");
    labela.classList.add("labela");
    labela.innerHTML="Naucna fantastika";
    divZaCb.appendChild(labela);

    //
    divZaCb = document.createElement("div");
    divZaCb.classList.add("divZaCb");
    forma.appendChild(divZaCb);

    cb = document.createElement("input");
    cb.type="checkbox";
    divZaCb.appendChild(cb);

    labela = document.createElement("label");
    labela.classList.add("labela");
    labela.innerHTML="Komedija";
    divZaCb.appendChild(labela);

    //
    divZaCb = document.createElement("div");
    divZaCb.classList.add("divZaCb");
    forma.appendChild(divZaCb);

    cb = document.createElement("input");
    cb.type="checkbox";
    divZaCb.appendChild(cb);

    labela = document.createElement("label");
    labela.classList.add("labela");
    labela.innerHTML="Triler";
    divZaCb.appendChild(labela);

    //
    labela = document.createElement("label");
    labela.classList.add("labela");
    labela.innerHTML="Broj DVD-ova:";
    forma.appendChild(labela);

    let polje = document.createElement("input");
    forma.appendChild(polje);


    //
    let dugme = document.createElement("button");
    dugme.innerHTML="Dodaj na policu";
    forma.appendChild(dugme);

    ///

    let forma2 = document.createElement("div");
    forma2.classList.add("forma2");
    this.kontejner.appendChild(forma2);

    let velikiDiv = document.createElement("div");
    velikiDiv.classList.add("velikiDiv");
    forma2.appendChild(velikiDiv);

    let divZaNaziv = document.createElement("div");
    divZaNaziv.classList.add("divZaNaziv");
    velikiDiv.appendChild(divZaNaziv);

    let lab = document.createElement("label");
    lab.innerHTML="Drama";
    divZaNaziv.appendChild(lab);

    let divZaDivove = document.createElement("div");
    divZaDivove.classList.add("divZaDivove");
    velikiDiv.appendChild(divZaDivove);

    let divMali = document.createElement("div");
    divMali.classList.add("divMali");
    divZaDivove.appendChild(divMali);

    divMali = document.createElement("div");
    divMali.classList.add("divMali");
    divZaDivove.appendChild(divMali);

    divMali = document.createElement("div");
    divMali.classList.add("divMali");
    divZaDivove.appendChild(divMali);

    //

    velikiDiv = document.createElement("div");
    velikiDiv.classList.add("velikiDiv");
    forma2.appendChild(velikiDiv);

    divZaNaziv = document.createElement("div");
    divZaNaziv.classList.add("divZaNaziv");
    velikiDiv.appendChild(divZaNaziv);

    lab = document.createElement("label");
    lab.innerHTML="Naucna fantastika";
    divZaNaziv.appendChild(lab);

    divZaDivove = document.createElement("div");
    divZaDivove.classList.add("divZaDivove");
    velikiDiv.appendChild(divZaDivove);

    divMali = document.createElement("div");
    divMali.classList.add("divMali");
    divZaDivove.appendChild(divMali);

    divMali = document.createElement("div");
    divMali.classList.add("divMali");
    divZaDivove.appendChild(divMali);

    divMali = document.createElement("div");
    divMali.classList.add("divMali");
    divZaDivove.appendChild(divMali);

    divMali = document.createElement("div");
    divMali.classList.add("divMali");
    divZaDivove.appendChild(divMali);

    
}

}