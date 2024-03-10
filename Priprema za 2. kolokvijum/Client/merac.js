export class Merac {
    constructor(host, id, naziv, interval, boja, granicaOd, granicaDo,
        trenutnaVrednost, minimalnaIzmerenaVrednost,
        maksimalnaIzmerenaVrednost, prosecnaIzmerenaVrednost) {
        this.id = id;
        this.naziv = naziv;
        this.interval = interval;
        this.boja = boja;
        this.granicaOd = granicaOd;
        this.granicaDo = granicaDo;
        this.vrednost = trenutnaVrednost;
        this.min = minimalnaIzmerenaVrednost;
        this.max = maksimalnaIzmerenaVrednost;
        this.prosek = prosecnaIzmerenaVrednost;

        this.host = host;

        if (this.naziv === "" || this.naziv == null || this.naziv == undefined) {
            const h1 = document.createElement("h1");
            h1.textContent = "Desila se greška pri komunikaciji sa serverom...";
            this.host.appendChild(h1);
        }
    }

    crtaj() {
        // Kontejner grada
        const grad = document.createElement("div");
        grad.classList.add("grad");
        this.gradContainer = grad;
        this.host.appendChild(grad);

        // Kontejner za podatke o gradu
        const podaci = document.createElement("div");
        podaci.classList.add("podaci-o-gradu");
        this.gradContainer.appendChild(podaci);

        // Naziv grada
        const naziv = document.createElement("h3");
        naziv.classList.add("naziv-grada");
        naziv.textContent = this.naziv;
        podaci.appendChild(naziv);

        // Input polje sa dugmetom
        const polje = document.createElement("input");
        polje.type = "number";
        polje.value = this.vrednost;
        podaci.appendChild(polje);

        const dugme = document.createElement("input");
        dugme.type = "button";
        dugme.value = "Upiši";
        podaci.appendChild(dugme);

        // Dodavanje podataka o minimalnoj, maksimalnoj i prosečnoj temperaturi
        const minMax = document.createElement("div");
        minMax.classList.add("min-max");
        podaci.appendChild(minMax);

        const max = document.createElement("label");
        max.textContent = "Max izmerena vrednost:";
        minMax.appendChild(max);

        const max2 = document.createElement("label");
        max2.classList.add("max-vrednost");
        max2.textContent = this.max;
        minMax.appendChild(max2);

        const min = document.createElement("label");
        min.textContent = "Min izmerena vrednost:";
        minMax.appendChild(min);

        const min2 = document.createElement("label");
        min2.classList.add("min-vrednost");
        min2.textContent = this.min;
        minMax.appendChild(min2);

        const prosek = document.createElement("label");
        prosek.textContent = "Prosečna izmerena vrednost:";
        minMax.appendChild(prosek);

        const prosek2 = document.createElement("label");
        prosek2.classList.add("prosecna-vrednost");
        prosek2.textContent = this.prosek;
        minMax.appendChild(prosek2);

        // Kontejner za prikazivanje termometra
        const term = document.createElement("div");
        term.classList.add("termometar");
        this.gradContainer.appendChild(term);

        // Div za podeoke
        const divPodeoci = document.createElement("div");
        divPodeoci.classList.add("div-podeoci");
        term.appendChild(divPodeoci);

        // Div za stub
        const divStub = document.createElement("div");
        divStub.classList.add("div-stub");
        term.appendChild(divStub);

        // Prikaz stuba
        const stub = document.createElement("div");
        stub.classList.add("stub");
        stub.style.backgroundColor = this.boja;

        const brLabela = (this.granicaDo - this.granicaOd) / this.interval + 1;
        const brLabelaDoTrenutnog = (this.vrednost - this.granicaOd) / this.interval + 1;

        const visinaLabele = Math.round(400 / brLabela);

        // Izražavamo visinu stuba u px, tako da računamo koliko jedan stepen ima px
        const visinaJednogStepena = visinaLabele / this.interval;
        // A onda računamo visinu, od minimalne temperature do trenutne vrednosti
        // Takođe moramo da uračunamo i border-e (1px svaki) do trenutne vrednosti
        const h = (this.vrednost - this.granicaOd + this.interval) * visinaJednogStepena + brLabelaDoTrenutnog;

        stub.style.height = `${h}px`;
        divStub.appendChild(stub);

        for (let i = this.granicaOd; i <= this.granicaDo; i += this.interval) {
            const p = document.createElement("label");
            p.classList.add("podeok");
            p.style.height = `${visinaLabele}px`;
            p.textContent = i;
            divPodeoci.appendChild(p);
        }

        dugme.onclick = () => this.upisiNovuTemperaturu(polje.value);
    }

    async upisiNovuTemperaturu(novaTemperatura) {
        if (this.granicaOd > novaTemperatura || this.granicaDo < novaTemperatura) {
            alert("Temperatura je prevelika ili premala.");
            return;
        }
        if (novaTemperatura == null || novaTemperatura == undefined) {
            alert("Podatak o temperaturi je pogrešan!");
            return;
        }

        const p = await fetch(`https://localhost:5001/Merac/IzmeniMerac/${this.id}/${novaTemperatura}`, {
            method: "PUT"
        });

        if (!p.ok) {
            alert("Upit nije uspeo!");
            return;
        }

        const data = await p.json();
        this.min = data.minimalnaIzmerenaVrednost;
        this.max = data.maksimalnaIzmerenaVrednost;
        this.prosek = data.prosecnaIzmerenaVrednost;
        this.vrednost = novaTemperatura;

        this.gradContainer.querySelector(".max-vrednost").textContent = this.max;
        this.gradContainer.querySelector(".min-vrednost").textContent = this.min;
        this.gradContainer.querySelector(".prosecna-vrednost").textContent = this.prosek;

        const el = this.gradContainer.querySelector(".stub");

        const proc = ((this.vrednost - this.granicaOd) / (this.granicaDo - this.granicaOd) * 100);
        el.style.height = `${proc}%`;
    }
}
