window.addEventListener("load", solve);
function solve(){
    let productType = document.getElementById("type-product");
    let description = document.getElementById("description");
    let clientName = document.getElementById('client-name');
    let clientPhone = document.getElementById('client-phone');

    let receivedOrders = document.getElementById("received-orders")
    let completedOrders = document.getElementById("completed-orders")

    let clearBtn = document.getElementsByClassName("clear-btn")[0];
    let sendBtn = document.getElementsByTagName("button")[0];
    sendBtn.addEventListener('click',function (){
        if (!clientName.value || !clientPhone.value || !description.value){
            return;
        }
        let div = document.createElement('div');
        div.classList.add('container')
        let h2 = document.createElement('h2');
        h2.textContent = `Product type for repair: ${productType.value}`
        let h3 = document.createElement('h3');
        h3.textContent = `Client information: ${clientName.value}, ${clientPhone.value}`
        let h4 = document.createElement('h4');
        h4.textContent = `Description of the problem: ${description.value}`
        let startBtn = document.createElement('button');
        startBtn.classList.add("start-btn");
        startBtn.textContent = "Start repair"
        let finishBtn = document.createElement('button');
        finishBtn.classList.add("finish-btn");
        finishBtn.textContent = "Finish repair"
        finishBtn.disabled = true;

        div.appendChild(h2)
        div.appendChild(h3)
        div.appendChild(h4)
        div.appendChild(startBtn)
        div.appendChild(finishBtn);

        receivedOrders.appendChild(div);

        startBtn.addEventListener('click',function (){
            startBtn.disabled = true;
            finishBtn.disabled = false;
        })
        finishBtn.addEventListener('click',function (){
            div.removeChild(startBtn);
            div.removeChild(finishBtn);
            completedOrders.appendChild(div);
            receivedOrders.removeChild(div);
        })

        clearBtn.addEventListener('click',function (){
            completedOrders.childNodes.forEach(child=>{
                if (child.tagName === 'DIV'){
                    completedOrders.removeChild(child);
                }
            })
        })
    })

}