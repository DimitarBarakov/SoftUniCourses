function solve(numbers){
    console.log(agg(numbers,x=>x))
    console.log(agg(numbers,x=>1/x))
    console.log(agg(numbers,x=>x.toString()))

    function agg(numbers,func){
        let res = numbers[0];
        for(let i = 1; i<numbers.length; i++){
            res+=func(numbers[i])
        }
        return res;
    }
}
solve([1,2,3])