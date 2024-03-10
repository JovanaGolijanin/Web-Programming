function makeCounter(){
    let counter =0;

    function increment(){
        counter++;
        console.log(counter);

    }

    function decrement(){
        counter--;
        console.log(counter);
    }

    return {
        inc: increment,
        dec: decrement
    }
}

const counter1 = makeCounter();
const counter2 = makeCounter();
counter1.inc();
counter1.inc();
counter1.inc();
counter1.inc();

counter2.inc();
counter2.inc();

counter1.dec();

