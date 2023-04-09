function solve() {
    let currStopId = 'depot'
    let departBtn = document.getElementById('depart')
    let arriveBtn = document.getElementById('arrive')
    let info = document.getElementsByClassName('info')[0];

        async function depart() {
            try {
                const response = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${currStopId}`)
                const data = await response.json();
                info.textContent = `Next stop ${data.name}`
                departBtn.disabled = true;
                arriveBtn.disabled = false;
            }
            catch (e){
                info.textContent = "Error"
                departBtn.disabled = true;
                arriveBtn.disabled = true;
            }
        }

        async function arrive() {
            try {
                const response = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${currStopId}`)
                const data = await response.json();
                info.textContent = `Arriving at ${data.name}`
                departBtn.disabled = false;
                arriveBtn.disabled = true;
                currStopId = data.next;
            }catch (e){
                info.textContent = "Error"
                departBtn.disabled = true;
                arriveBtn.disabled = true;
            }

        }



    return {
        depart,
        arrive
    };
}

let result = solve();