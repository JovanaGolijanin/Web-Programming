document.body.onload
{
    let roditelj = document.querySelector("#roditelj");

    let forma = document.createElement("div");
    forma.className="forma";
    roditelj.appendChild(forma);

    let divZaLabele = document.createElement("div");
    divZaLabele.className="divZaLabele";
    forma.appendChild(divZaLabele);

    let divZaPolja = document.createElement("div");
    divZaPolja.className="divZaPolja";
    forma.appendChild(divZaPolja);

    let Labele = ["Ime", "Prezime", "Index", "Pass", "Datum"];
    let Polja = ["text", "text", "number", "password", "date"];

    let l;
    let p;
    Labele.forEach((element,index) => {

        l=document.createElement("label");
        l.className="labela";
        l.innerHTML=element;
        l.name=element;
        divZaLabele.appendChild(l);

        p = document.createElement("input");
        p.className="polje";
        p.type=Polja[index];
        p.name=element;
        divZaPolja.appendChild(p);

    });

    let divZaRbt =document.createElement("div");
    divZaRbt.className="divZaRbt";
    roditelj.appendChild(divZaRbt);

    let rBtn = ["RI", "US", "TLK", "EK"];

    rBtn.forEach((element, index) => {
        let radioBtn = document.createElement("input");
        radioBtn.type="radio";
        radioBtn.name="biloSta";
        radioBtn.value=element;
        divZaRbt.appendChild(radioBtn);

        let labela = document.createElement("label");
        labela.innerHTML=element;
        divZaRbt.appendChild(labela);

        if(index===0)
            radioBtn.checked=true;

    });


    let divZaCb =document.createElement("div");
    divZaCb.className="divZaCb";
    roditelj.appendChild(divZaCb);

    rBtn.forEach(element => {
        let cb = document.createElement("input");
        cb.type="checkbox";
        cb.value=element;
        divZaCb.appendChild(cb);

        let labela = document.createElement("label");
        labela.innerHTML=element;
        divZaCb.appendChild(labela);
    });

    let opcije = ["AIP", "UUR", "WEB", "OOP"];

    let divZaSelekt = document.createElement("div");
    divZaSelekt.classList.add("divZaSelekt");
    roditelj.appendChild(divZaSelekt);

    let sel = document.createElement("select");
    sel.className="selekt";
    divZaSelekt.appendChild(sel);
    
    opcije.forEach(element => {
        let opcija = document.createElement("option");
        opcija.innerHTML=element;
        opcija.value=element;
        sel.appendChild(opcija);
    });


    let dugme = document.createElement("button");
    dugme.innerHTML="Klikni";
    dugme.classList.add("dugme");
    roditelj.appendChild(dugme);

    dugme.addEventListener("click", oboji);

    function oboji(){
        if(!undefined)
        divZaLabele.className="NovaBoja";

        let polja = document.querySelectorAll(".polje");

        let naziv = "";
        polja.forEach(element => {
            naziv +=`${element.name} ${element.value}`
        });
        
        //alert(naziv);

        let rbt=document.querySelector("input[type='radio']:checked").value;
        console.log(rbt);

        let cb = document.querySelectorAll("input[type='checkbox']:checked");
        cb.forEach(x=>
            {
                console.log(x.value);
            })    
        
        let se = document.querySelector("select");
        console.log(se.selectedIndex);

    }

    

}


