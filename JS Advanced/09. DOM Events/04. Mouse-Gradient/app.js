function attachGradientEvents() {
    let gradient = document.getElementById("gradient");
    let res = document.getElementById("result");
    gradient.addEventListener("mousemove", function (event){
        res.innerText = Math.trunc(event.offsetX / (event.target.offsetWidth / 100)) + '%';
    })
}