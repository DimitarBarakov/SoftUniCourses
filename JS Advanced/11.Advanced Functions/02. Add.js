function solution(number){
    let num = number;
    return function (n){
        num = number;
        return num += n
    }
}
let add5 = solution(5);

console.log(add5(2));

console.log(add5(3));