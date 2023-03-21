function solve(num){
    let numAsString = num.toString()
    let areEqual = true
     for (let i = 1; i < numAsString.length; i++) {
         if(numAsString[i] != numAsString[i - 1]){
            areEqual = false
            break
         }
     }
     console.log(areEqual)
}
solve(1212)