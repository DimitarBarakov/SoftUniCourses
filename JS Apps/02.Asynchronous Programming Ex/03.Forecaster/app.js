async function attachEvents() {
    let btn = document.getElementById('submit')
    let location = document.querySelector("input[type = text]").value;
    //let location = input.value;
    
    const response =await fetch(`http://localhost:3030/jsonstore/forecaster/locations`)
    const data = await response.json();
    
    btn.addEventListener("click", function (){
        console.log(data)
        /*let locationsNames = data.map(loc=>loc.name);
        console.log(locationsNames)*/
        console.log(location)
        //console.log(input)
        let currLocation = data.find(loc => loc.name === location)
        console.log(currLocation)
    })


}

attachEvents();