document.body.onload
{
    var roditelj = document.querySelector("#roditelj");

    let nizLabela = ["Ime", "Prezime", "Index", "Pass", "Datum"];
    let nizTipova = ["text", "text", "number", "password", "date"];

    let forma = document.createElement("div");
    forma.className="forma";
    roditelj.appendChild(forma);

    let divZaLabele = document.createElement("div");
    divZaLabele.classList.add("zaLabele");

    forma.appendChild(divZaLabele);

    let divZaPolja = document.createElement("div");
    divZaPolja.classList.add("zaPolja");

    forma.appendChild(divZaPolja);

    let l;
    let p;
    nizLabela.forEach((element, index)=>
    {
        l=document.createElement("label");
        l.innerHTML=element;
        divZaLabele.appendChild(l);

        p=document.createElement("input");
        p.type=nizTipova[index];
        p.className="polja";
        p.name=element;
        divZaPolja.appendChild(p);
    });

    let nizRbt=["Ri", "US", "T", "E"];

    let divZaRbt=document.createElement("div");
    roditelj.appendChild(divZaRbt);
    divZaRbt.className="divZaRbt";

    nizRbt.forEach((el, index)=>{

        l = document.createElement("label");
        l.innerHTML=el;
        divZaRbt.appendChild(l);
        let rbt = document.createElement("input");
        rbt.type="radio";
        rbt.value=el;
        rbt.name="smerovi";//da bi samo jedan mogao da se cekira
        //mora da im se dodeli neko ime tj. name da se podesi bilo na sta
        divZaRbt.appendChild(rbt);

        if(index===0)
            rbt.checked=true;//da prvi bude inicijalno cekiran
        //jer puca ako nije cekirano
    })


    let divZaCB=document.createElement("div");
    roditelj.appendChild(divZaCB);
    divZaCB.className="divZaCB";

    nizRbt.forEach((el, index)=>{

        l = document.createElement("label");
        l.innerHTML=el;
        divZaCB.appendChild(l);

        let rbt = document.createElement("input");
        rbt.type="checkbox";
        rbt.value=el;
        divZaCB.appendChild(rbt);

    })

   
    let selectElement= document.createElement("select");
    roditelj.appendChild(selectElement);

    let predmeti = ["AIP" ,"OOP", "WEB", "UUR"];
    let opcija;
    predmeti.forEach(x=>{
        opcija= document.createElement("option");
        opcija.value=x;
        opcija.innerHTML=x;
        selectElement.appendChild(opcija);
    })



    let dugme = document.createElement("button");
    
    dugme.innerHTML="Klikni me";
    roditelj.appendChild(dugme);

    dugme.addEventListener("click", dogadjaj);

    function dogadjaj(){
        let f = document.querySelector(".forma");
        if(f!=undefined)
        f.className="NovaForma";

        let zaPrikaz= "";
        let polja = document.querySelectorAll(".polja");
        console.log(polja);

        polja.forEach(x=>{
            zaPrikaz+=`${x.name}- ${x.value}`;
        })

        //alert(zaPrikaz);

        let rbt=document.querySelector("input[type='radio']:checked").value;
        console.log(rbt);

        let cb=document.querySelectorAll("input[type='checkbox']:checked");
        cb.forEach(x=>{
            console.log("Checkbox vrednosti "+x.value);
        })
        console.log(cb);


        let op=document.querySelector("select");
        console.log(op.selectedIndex);
         
    }
    
}