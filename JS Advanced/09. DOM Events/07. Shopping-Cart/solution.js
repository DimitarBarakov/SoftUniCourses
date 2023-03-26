function solve() {
    let btns = document.getElementsByClassName("add-product");
    let totalPrice = 0;
    let list = [];
    for (const btn of btns) {
        btn.addEventListener("click",function (event){
            let productElement = event.target.parentElement.parentElement;
            let name = productElement.querySelectorAll('.product-title')[0].textContent;
            let price = productElement.querySelectorAll('.product-line-price')[0].textContent;
            totalPrice+=Number(price);
            list.push(name);
            document.getElementsByTagName("textarea")[0].textContent+=`Added ${name} for ${price} to the cart.\n`;
        })
    }
    let checkoutBtn = document.getElementsByClassName('checkout')[0];
    checkoutBtn.addEventListener('click',function (event){

        document.getElementsByTagName("textarea")[0].textContent += `You bought ${list.join(", ")} for ${totalPrice.toFixed(2)}.`;
        for (let btn of btns) {
            btn.disabled = true;
        }
    })
}