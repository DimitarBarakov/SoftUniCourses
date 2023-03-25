function search() {
    let listItems = document.getElementsByTagName("li");
    let searchedText = document.getElementsByTagName("input")[0].value;

    for (let item of listItems) {
        item.style.textDecoration = "none";
        item.style.fontWeight = "normal"
    }
    let matchesCount = 0;
    for (let item of listItems) {
        let itemText = item.textContent;
        if (itemText.includes(searchedText)) {
            item.style.textDecoration = "underline";
            item.style.fontWeight = "bold"
            matchesCount++;
        }
    }
    document.getElementsByTagName("input")[0].value = "";
    document.getElementById("result").innerText = `${matchesCount} matches found`
}
