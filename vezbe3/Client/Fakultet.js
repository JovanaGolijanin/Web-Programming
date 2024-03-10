import { Student } from "./Student.js";

export class Fakultet{
    constructor(listaPredmeta, listaRokova){
        this.listaPredmeta=listaPredmeta;
        this.listaRokova=listaRokova;
        this.kontejner=null;
    }

    crtaj(host){
        this.kont=document.createElement("div");
        this.kont.className="GlavniKontejner";
        host.appendChild(this.kont);

        let kontForma = document.createElement("div");
        kontForma.className="Forma";
        this.kont.appendChild(kontForma);

        

        this.crtajFormu(kontForma);
        this.crtajPrikaz(this.kont);
    }

    crtajPrikaz(host){

        let kontPrikaz = document.createElement("div");
        kontPrikaz.className="Prikaz";
        host.appendChild(kontPrikaz);

        var tabela = document.createElement("table");
        tabela.className="tabela";
        kontPrikaz.appendChild(tabela);

        var tabelaHead= document.createElement("thead");
        tabela.appendChild(tabelaHead);

        var tr = document.createElement("tr");
        tabelaHead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className="TabelaPodaci";
        tabela.appendChild(tabelaBody);

        let th;
        var zag=["Index", "Ime", "Prezime", "Predmet","Ispitni rok", "Ocena"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            tr.appendChild(th);
        })
    }

    crtajRed(host){
        let red = document.createElement("div");
        red.className="red";
        host.appendChild(red);
        return red;

    }

    crtajFormu(host){

        let red = this.crtajRed(host);

        let l = document.createElement("label");
        l.innerHTML="Ispit";
        red.appendChild(l);

        let se = document.createElement("select");
        red.appendChild(se);

        let op;
        this.listaPredmeta.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML=p.naziv;
            op.value = p.id;
            se.appendChild(op);
        })

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Rok";
        red.appendChild(l);

        let cbbox = document.createElement("div");
        cbbox.className="cbbox";
        red.appendChild(cbbox);

        let cbboxLevi = document.createElement("div");
        cbboxLevi.className="cbboxLevi";
        cbbox.appendChild(cbboxLevi);

        let cbboxDesni = document.createElement("div");
        cbboxDesni.className="cbboxDesni";
        cbbox.appendChild(cbboxDesni);

        let cb;
        let cbDiv;
        this.listaRokova.forEach((r,index)=>{

            cbDiv = document.createElement("div");

            cb = document.createElement("input");
            cb.type="checkbox";
            cb.value=r.id;
            cbDiv.appendChild(cb);

            l = document.createElement("label");
            l.innerHTML=r.naziv;
            cbDiv.appendChild(l);

            if(index%2==0){
                cbboxLevi.appendChild(cbDiv);

            }
            else{
                cbboxDesni.appendChild(cbDiv);
            }
        })

        red = this.crtajRed(host);

        let btnNadji = document.createElement("button");
        btnNadji.onclick=(ev)=>this.nadjiStudente();
        btnNadji.innerHTML="Nadji";
        red.appendChild(btnNadji);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Indeks";
        red.appendChild(l);
        var brojIndeksa = document.createElement("input");//text box
        brojIndeksa.type="number";
        brojIndeksa.className="BrojIndeksa";
        red.appendChild(brojIndeksa);

        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Ocena";
        red.appendChild(l);
        var poljeOcena = document.createElement("input");//text box
        poljeOcena.type="number";
        poljeOcena.className="Ocena";
        red.appendChild(poljeOcena);

        red = this.crtajRed(host);
        let btnUpisi = document.createElement("button");
        btnUpisi.onclick=(ev)=>this.upisi(brojIndeksa.value,poljeOcena.value );
        btnUpisi.innerHTML="Upisi";
        red.appendChild(btnUpisi);



    }

    upisi(brojIndeksa, ocena){
        if(brojIndeksa===null || brojIndeksa===undefined || brojIndeksa===""){
            alert("Unesite broj indeksa");
            return;
        }
        if(ocena===""){
            alert("Unesite ocenu");
            return;
        }
        else{
            let ocenaPars= parseInt(ocena);
            if(ocena <5 || ocena > 10){
                alert("Uneta je neispravna vrednost za ocenu");
                return;
            }
        }   

        let rokovi = this.kont.querySelectorAll("input[type='checkbox']:checked");
        if(rokovi===null || rokovi.length!=1){
            alert("Morate izabrati samo jedan rok");
            return;
        }

        let optionEl = this.kont.querySelector("select");
        var ispitID = optionEl.options[optionEl.selectedIndex].value;

        console.log("ocena" + ocena);
        console.log("indeks" + brojIndeksa);
        console.log("ispit" + ispitID);
        console.log("rok" + rokovi[0].value);
        
        fetch("http://localhost:5038/Ispit/DodajPolozeniIspit/"+brojIndeksa+"/"+ispitID
        +"/"+ rokovi[0].value + "/" +ocena,
        {
            method:"POST"
        }).then(s=>{
            if(s.ok){
                var teloTabele = this.obrisiPrethodniSadrzaj();
                s.json().then(data=>{
                    console.log(data);
                    data.forEach(st =>{
                        const student = new Student(st.index, st.ime, st.prezime, st.predmet, st.ispitniRok, st.ocena);
                        student.crtaj(teloTabele);
                    })
                })
            }
        })
    }

    nadjiStudente(){
        let optionEl = this.kont.querySelector("select");
        var ispitID=optionEl.options[optionEl.selectedIndex].value;
        console.log(ispitID);

        //console.log(this.kont.querySelector('option:checked').value);

        let rokovi = this.kont.querySelectorAll("input[type='checkbox']:checked");
        console.log(rokovi);
        if(rokovi===null){
            alert("Izaberite rok");
            return;
        }

        let nizRokova="";
        let rokoviIDs=[];
        for(let i=0;i<rokovi.length;i++){
            nizRokova = nizRokova.concat(rokovi[i].value, "a");
            rokoviIDs.push(parseInt(rokovi[i].value));
        }
        console.log(nizRokova);

        //this.ucitajStudente(ispitID, nizRokova)
        this.ucitajStudenteFromBody(ispitID,rokoviIDs );

    }
    ucitajStudente(ispitID, nizRokova){
        fetch("http://localhost:5038/Student/StudentiPretraga/"+nizRokova+"/" + ispitID,
        {
            method: "GET"
        }).then(s=>{
            if(s.ok){
                    var teloTabele= this.obrisiPrethodniSadrzaj()
                s.json().then(data=>{
                    data.forEach(s=>{
                        let st = new Student(s.index, s.ime, s.prezime, s.predmet, s.rok, s.ocena);
                        st.crtaj(teloTabele);

                    })
                })
            }
        })
    }

    ucitajStudenteFromBody(ispitID, rokIds){
        fetch("http://localhost:5038/Student/StudentiPretragaFromBody/" + ispitID,
        {
            method: "PUT",
            headers:{
                "Content-Type":"application/json"
            },
            body:JSON.stringify(rokIds)

        }).then(s=>{
            if(s.ok){
                    var teloTabele= this.obrisiPrethodniSadrzaj()
                s.json().then(data=>{
                    data.forEach(s=>{
                        let st = new Student(s.index, s.ime, s.prezime, s.predmet, s.rok, s.ocena);
                        st.crtaj(teloTabele);

                    })
                })
            }
        })
    }


    obrisiPrethodniSadrzaj(){
        var teloTabele = document.querySelector(".TabelaPodaci");
        var roditelj = teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele = document.createElement("tbody");
        teloTabele.className="TabelaPodaci";
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }
}