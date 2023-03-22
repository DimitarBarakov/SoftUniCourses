function solve(numbers){
    let result = [];
    let n = numbers.length/2
    for(let i = 0; i < n; i++){
        let minEl = Math.min(...numbers);
        let maxEl = Math.max(...numbers);
        result.push(minEl);
        result.push(maxEl);
        let minElIndex = numbers.indexOf(minEl);
        numbers.splice(minElIndex,1)
        let maxElIndex = numbers.indexOf(maxEl);
        numbers.splice(maxElIndex,1)
    }
    console.log(result)
}

solve([1,2,3,4,5,])