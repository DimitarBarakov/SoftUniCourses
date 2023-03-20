function printSquare(size = 5){
    let line = '*'.repeat(size);
    for(let i = 0;i<size;i++){
        // for(let j = 0;j<size;j++){
        //     line+='* '
        // }
        console.log(line)
        // line = '';
    }
}
printSquare()