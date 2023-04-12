import {cats} from "./catSeeder.js"
import {html, render} from "../node_modules/lit-html/lit-html.js";

const root = document.getElementById("allCats");


render(createUl(cats),root)
root.addEventListener("click", toggleStatusCode);
function createUl(cats){
    let list = html`
    <ul>
        ${cats.map(cat=>createLi(cat))}
    </ul>`
    return list;
}
function createLi(cat){
    let imgePath = cat.imageLocation;
    let li = html`<li>
    <img src= "./images/${imgePath}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">Show status code</button>
        <div class="status" style="display: none" id=${cat.id}>
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>`
return li;
}

function toggleStatusCode(e){
    e.preventDefault();
    if(e.target.tagName == "BUTTON"){
        const parent = e.target.parentElement;
        const status = parent.querySelector(".status");
        if(status.style.display === "none"){
            status.style.display = "inline";
            e.target.textContent = "Hide status code";
        }
        else{
            status.style.display = "none";
            e.target.textContent = "Show status code";
        }
    }
}