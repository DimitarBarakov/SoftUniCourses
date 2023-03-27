function attachEventsListeners() {
    let btns = Array.from(document.querySelectorAll("input[type = button]"));
    for (let btn of btns) {
        btn.addEventListener('click',function (event){
            let valueToConvert = event.target.parentElement.querySelectorAll("input[type = text]")[0].value;
            let unit = event.target.id;
            switch (unit){
                case 'hoursBtn': valueToConvert/=24; break;
                case 'minutesBtn':valueToConvert/=1440; break;
                case 'secondsBtn':valueToConvert/=86400; break;
            }
            convert(valueToConvert);
        })
    }
    function convert(value){
        let inputs = Array.from(document.querySelectorAll("input[type = text]"));
        inputs[0].value = value;
        inputs[1].value = value*24;
        inputs[2].value = value*1440;
        inputs[3].value = value*86400;
    }
}