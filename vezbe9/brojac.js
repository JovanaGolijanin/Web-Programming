export class Brojac{

    constructor(vrednost){
        this.vrednost=vrednost;
        this.kontejner=null;//sve sto se crta ovde se crta
    }

    crtaj(host){
        if(!host)
            throw new Error("Roditeljski element ne postoji");
        let dugme = document.createElement("button");
        dugme.classList.add("brojac");//dugme.className ="brojac";
        dugme.innerHTML=this.vrednost;
        this.kontejner=dugme;
        host.appendChild(dugme);
        dugme.onclick=(ev)=>{
            this.smanji(dugme);
        }
    
    }

    smanji(dugme){
        this.vrednost--;
        dugme.innerHTML=this.vrednost;
        if(this.vrednost===0)
            dugme.classList.add("boja");
        //let dugme = document.querySelector("button");
        //varijanta 1
        /* console.log(this.kontejner);
        this.kontejner.innerHTML=this.vrednost; */
    }

}