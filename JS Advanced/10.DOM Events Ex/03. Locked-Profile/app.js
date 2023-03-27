function lockedProfile() {
    let btns = Array.from(document.getElementsByTagName('button'));
    console.log(btns)
    for (let btn of btns) {
        btn.addEventListener("click", function (event){
            let radioBtn = event.target.parentElement.querySelectorAll('input[type = "radio"]')[1];
            if (radioBtn.checked){
                event.target.parentElement.getElementsByTagName('div')[0].style.display = 'contents';
                event.target.textContent = "Hide it";
            }
            /*btn.addEventListener("click", function (event){
                let radioBtn = event.target.parentElement.querySelectorAll('input[type = "radio"]')[1];
                if (radioBtn.checked){
                    event.target.parentElement.getElementsByTagName('div')[0].style.display = 'none';
                    event.target.textContent = "Show more";
                }
            })*/
        })

    }
}