window.addEventListener('load', solve);

function solve() {
    let model = document.getElementById("model");
    let year = document.getElementById("year");
    let description = document.getElementById("description");
    let price = document.getElementById("price");

    let furnitureList = document.getElementById("furniture-list");
    let totalPrice = document.getElementsByClassName("total-price")[0]

    let addBtn = document.getElementById("add")
    addBtn.addEventListener("click", function (e){
        e.preventDefault();
        let modelValue = model.value;
        let yearValue = Number(year.value);
        let descriptionValue = description.value;
        let priceValue = Number(price.value).toFixed(2);;

        if (!modelValue || !yearValue || !descriptionValue || !priceValue){
            return;
        }
        if (priceValue <= 0 || yearValue <= 0){
            return;
        }

        let infoRow = document.createElement("tr");
        infoRow.classList.add('info');

        let modelTd = document.createElement("td");
        modelTd.textContent = modelValue;

        let yearTd = document.createElement("td");
        yearTd.textContent = `Year: ${yearValue}`;

        let descriptionTd = document.createElement("td");
        descriptionTd.textContent = `Description: ${descriptionValue}`;

        let priceTd = document.createElement("td");
        priceTd.textContent = priceValue;

        let actionsTd = document.createElement('td');

        let moreInfoRow = document.createElement('tr')
        moreInfoRow.classList.add('hide')
        moreInfoRow.appendChild(yearTd)
        moreInfoRow.appendChild(descriptionTd)

        let moreInfoBtn = document.createElement("button");
        moreInfoBtn.textContent = "More Info"
        moreInfoBtn.classList.add('moreBtn')
        actionsTd.appendChild(moreInfoBtn);
        moreInfoBtn.addEventListener('click',function (e){

            if (moreInfoBtn.textContent === "More Info"){
                moreInfoRow.style.display = 'contents';
                descriptionTd.setAttribute('colspan', '3');
                moreInfoBtn.textContent = "Less Info"
            }
            else{
                moreInfoRow.style.display = 'none';
                moreInfoBtn.textContent = "More Info"
            }
        })

        let buyItBtn = document.createElement("button");
        buyItBtn.textContent = "Buy it"
        buyItBtn.classList.add('buyBtn')
        actionsTd.appendChild(buyItBtn);
        buyItBtn.addEventListener('click', function (){
            let totalPriceValue = Number(totalPrice.textContent);
            totalPriceValue += Number(priceValue);
            totalPrice.innerText = totalPriceValue.toFixed(2);
            furnitureList.removeChild(infoRow)
            furnitureList.removeChild(moreInfoRow)
        })


        infoRow.appendChild(modelTd)
        infoRow.appendChild(priceTd)
        infoRow.appendChild(actionsTd)

        furnitureList.appendChild(infoRow)
        furnitureList.appendChild(moreInfoRow)

        model.value = "";
        year.value = "";
        description.value = "";
        price.value = "";
    })
}
