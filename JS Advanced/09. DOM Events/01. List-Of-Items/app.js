function addItem() {
    let list  = document.getElementById("items");
    let newItemText = document.getElementsByTagName("input")[0].value;
    let newItem = document.createElement("li");
    newItem.textContent = newItemText;
    list.append(newItem);
}