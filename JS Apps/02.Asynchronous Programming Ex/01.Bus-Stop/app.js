async function getInfo() {
    let stopName = document.getElementById('stopName')
    let ul = document.getElementById('buses')

    ul.innerHTML = "";

    let stopIDELement = document.getElementById('stopId');
    let stopID = stopIDELement.value;
    console.log(stopID)
    stopIDELement.value = "";
    try {
        const response = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopID}`)
        const data = await response.json();
        stopName.textContent = data.name;
        Object.entries(data.buses).forEach(([bus, time]) => {
            let li = document.createElement('li')
            li.textContent = `Bus ${bus} arrives in ${time} minutes`
            ul.appendChild(li)
        })
    }
    catch (e){
        stopName.textContent = "Error"
    }
}