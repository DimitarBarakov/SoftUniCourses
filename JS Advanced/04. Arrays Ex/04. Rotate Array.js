function solve(input, rotations){
    if(rotations >= input.length){
        rotations%=input.length;
    }
    for(let i = 1; i <= rotations;i++){
        let el = input.pop();
        input.unshift(el);
    }
    console.log(input.join(' '))
}

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
)