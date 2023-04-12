import {html, render} from "../node_modules/lit-html/lit-html.js"
import { repeat } from "../node_modules/lit-html/directives/repeat.js"

const root = document.getElementById("root");
const form = document.querySelector("form");
form.addEventListener("submit", onSubmit);

function onSubmit(e){
    e.preventDefault();
    const formData = new FormData(form)
    const data = Object.fromEntries(formData);
    const towns = data.split(", ")
    renderList(towns);
}
function renderList(towns){
    const list = createList(towns);
    render(list, root)
}
function createList(data){
    const ul = html`
        <ul>
            ${data.map(d => html`<li>${d}</li>`)}
        </ul>
    `
    return ul;
}