function toggle() {
    let buttonText = document.getElementsByClassName("button")[0].textContent;
    let elementToManipulate = document.getElementById("extra");
    if (buttonText === "More"){
        buttonText = "Less";
        elementToManipulate.style.display = "contents";
    }
    else if(buttonText === "Less"){
        buttonText = "More";
        elementToManipulate.style.display = "none";
    }
    document.getElementsByClassName("button")[0].textContent = buttonText;
}