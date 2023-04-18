import { del } from "../api/api.js";
import { getById } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (post, user, onDelete) => html`
<section id="details">
<div id="details-wrapper">
<img id="details-img" src=${post.imageUrl} alt="example1" />
      <p id="details-title">${post.title}</p>
      <p id="details-category">
        Category: <span id="categories">${post.category}</span>
      </p>
      <p id="details-salary">
        Salary: <span id="salary-number">${post.salary}</span>
      </p>
      <div id="info-wrapper">
        <div id="details-description">
          <h4>Description</h4>
          <span
            >${post.description}</span
          >
        </div>
        <div id="details-requirements">
          <h4>Requirements</h4>
          <span
            >${post.requirements}</span
          >
        </div>
      </div>
      <p>Applications: <strong id="applications">1</strong></p>
  <div id="action-buttons">
    ${user?html`
      ${user.id === post._ownerId?html`<a href="/edit/${post._id}" id="edit-btn">Edit</a>
      <a @click = ${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>`:
    html`<a href="" id="apply-btn">Apply</a>`
    }
    `:""}
    </div>
</div>
</section>`


export async function showDetails(ctx){
    const id = ctx.params.id;
    const post = await getById(id)
    const user = await getUserData();
    ctx.render(detailsTemplate(post, user, onDelete))

    async function onDelete(e){
        e.preventDefault();
        const conf = confirm("Are you sure?")
        if(conf){
            del("/data/offers/" + id)
            ctx.page.redirect("/dashboard")
        }
        
    }
} 