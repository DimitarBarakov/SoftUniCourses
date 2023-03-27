function addItem() {
    let addBtn = document.querySelectorAll('input[type = "button"]')[0];
    let select = document.getElementsByTagName("select")[0];

    addBtn.addEventListener("click", function (event){
        let newOptionText = event.target.parentElement.getElementsByTagName('input')[0].value;
        let newOptionValue = event.target.parentElement.getElementsByTagName('input')[1].value;
        let newOption = document.createElement('option');
        newOption.value = newOptionValue;
        newOption.text = newOptionText;
        select.append(newOption);
        event.target.parentElement.getElementsByTagName('input')[0].value = '';
        event.target.parentElement.getElementsByTagName('input')[1].value = '';
    })
}