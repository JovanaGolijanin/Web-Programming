export class Brojac{

    constructor(vrednost){
        this.vrednost=vrednost;
        this.kontejner = null;
    }

    crtaj(host){
        if(!host)
            throw Error("Roditeljski element nije nadjen");
        let dg = document.createElement("button");
        dg.className="dugme";
        dg.innerHTML = this.vrednost;
        this.kontejner=dg;
        host.appendChild(dg);


        dg.onclick=(ev)=>
        {
            this.smanji(dg);
        }

    }

    smanji(dugmence){
        this.vrednost--;
        dugmence.innerHTML=this.vrednost;
        if(this.vrednost===0)
            dugmence.className="NovaBoja";
    }

    
}
