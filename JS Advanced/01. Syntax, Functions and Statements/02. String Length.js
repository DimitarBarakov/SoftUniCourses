function lengths(firstString, secondString, thirdString){
    let firstStringLength = firstString.length;
    let secondStringLength = secondString.length;
    let thirdStringLength = thirdString.length;
    let sum = firstStringLength+secondStringLength + thirdStringLength;
    console.log(sum)
    let average = Math.floor(sum/3)
    console.log(average)
}

lengths('chocolate', 'ice cream', 'cake')
lengths('pasta', '5', '22.3')