function addItem() {
    let list  = document.getElementById("items");
    let newItemText = document.getElementsByTagName("input")[0].value;
    let newItem = document.createElement("li");
    newItem.textContent = newItemText;
    let atag = document.createElement('a');
    atag.textContent = " Delete";
    atag.addEventListener("click", function (event){
        event.target.parentElement.remove();
    })
    newItem.append(atag);
    list.append(newItem);
}