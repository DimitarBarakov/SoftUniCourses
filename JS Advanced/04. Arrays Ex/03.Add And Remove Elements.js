function solve(commands){
    let array = [];
    let initialNumber = 1; 
    for(let i = 0; i < commands.length; i++){
        let currentCommand = commands[i];
        if(currentCommand == 'add'){
            array.push(initialNumber);
        }
        else{
            array.pop();
        }
        initialNumber++;
    }
    console.log(array.length == 0 ? 'Empty': array);
}

solve(['remove', 
'remove', 
'add']
)