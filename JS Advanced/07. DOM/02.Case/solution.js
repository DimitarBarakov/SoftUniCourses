function solve() {
    let textToConvert = document.getElementById("text").value.toLowerCase();
    let res ="";
    let stringCase =  document.getElementById("naming-convention").value;
    let textAsArray = textToConvert.split(' ');

    if (stringCase === 'Pascal Case'){
        for (let i = 0; i < textAsArray.length; i++) {
            let converted =  textAsArray[i].charAt(0).toUpperCase() + textAsArray[i].slice(1);
            res+=converted;
        }
    }
    else if (stringCase === 'Camel Case'){
        res+=textAsArray[0];
        for (let i = 1; i < textAsArray.length; i++) {
            let converted =  textAsArray[i].charAt(0).toUpperCase() + textAsArray[i].slice(1);
            res+=converted;
        }
    }
    else{
        res = "Error!";
    }

    document.getElementById("result").innerText = res;
}