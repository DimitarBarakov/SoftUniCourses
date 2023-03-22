function solve(input, step){
    let result = [];
    for(let i = 0; i < input.length; i+=step){
        result.push(input[i])
    }
    console.log(result)
}
solve(['1', 
'2',
'3', 
'4', 
'5'], 
6
)