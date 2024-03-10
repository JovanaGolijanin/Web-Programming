function createFunctionsArray(){

let a = 4;

    const functArray = [];
    for(let i = 0; i<5;i++){
        functArray[i] = function(){
            a++;
            console.log(a);
            return a;

        }
    }
    return functArray;
}

const funcs = createFunctionsArray();
funcs[0]();
funcs[0]();
funcs[1]();