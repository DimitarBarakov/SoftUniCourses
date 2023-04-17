import { del } from "../api/api.js";
import { getById } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (pair, user, onDelete) => html`<section id="details">
<div id="details-wrapper">
  <p id="details-title">Shoe Details</p>
  <div id="img-wrapper">
    <img src=${pair.imageUrl} alt="example1" />
  </div>
  <div id="info-wrapper">
    <p>Brand: <span id="details-brand">${pair.brand}</span></p>
    <p>
      Model: <span id="details-model">${pair.model}</span>
    </p>
    <p>Release date: <span id="details-release">${pair.release}</span></p>
    <p>Designer: <span id="details-designer">${pair.designer}</span></p>
    <p>Value: <span id="details-value">${pair.value}</span></p>
  </div>
    ${
        user && user.id === pair._ownerId?html`<div id="action-buttons">
    <a href="/edit/${pair._id}" id="edit-btn">Edit</a>
    <a @click = ${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>
  </div>`:""
    }
</div>
</section>`


export async function showDetails(ctx){
    const id = ctx.params.id;
    const pair = await getById(id)
    const user = await getUserData();
    ctx.render(detailsTemplate(pair, user, onDelete))

    async function onDelete(e){
        e.preventDefault();
        const conf = confirm("Are you sure?")
        if(conf){
            del("/data/shoes/" + id)
            ctx.page.redirect("/dashboard")
        }
        
    }
} 