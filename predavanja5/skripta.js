const a=4;

const proto =Object.getPrototypeOf(a);

console.log(proto);

function someFunct(){}
console.log(someFunct.prototype);

function Person(ime, prezime){
    this.ime = ime;
    this.prezime=prezime;
    this.print = function(){
        return `Ime: ${this.ime}, Prezime:${this.prezime}`;
    }
}

const p1 = new Person("Marko", "Markovic");
const p2 = new Person("Petar", "Petrovic");
console.log(p1.print());

Person.prototype.getFullName = function(){
    return this.ime + " " + this.prezime;
} 


