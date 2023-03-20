function sumOfNumbers(startAsString, endAsString){
    let start = Number(startAsString)
    let end = Number(endAsString)
    let sum = 0;
    for(let i = start; i <= end;i++){
        sum+=i;
    }
    console.log(sum)
}

sumOfNumbers('1','5')