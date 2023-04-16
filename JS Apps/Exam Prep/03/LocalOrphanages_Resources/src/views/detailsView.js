import { del } from "../api/api.js";
import { getById } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (post, user, onDelete) => html`
<section id="details-page">
    <h1 class="title">Post Details</h1>

    <div id="container">
        <div id="details">
            <div class="image-wrapper">
                <img src=${post.imageUrl} alt="Material Image" class="post-image">
            </div>
            <div class="info">
                <h2 class="title post-title">${post.title}</h2>
                <p class="post-description">Description: ${post.description}</p>
                <p class="post-address">Address: ${post.address}</p>
                <p class="post-number">Phone number: ${post.phone}</p>
                <p class="donate-Item">Donate Materials: 0</p>
                ${user?html`<div class="btns">
                    ${user.id === post._ownerId?html`
                    <a href="/edit/${post._id}" class="edit-btn btn">Edit</a>
                    <a @click = ${onDelete} href="javascript:void(0)" class="delete-btn btn">Delete</a>`:html`
                    <a href="#" class="donate-btn btn">Donate</a>`}
                </div>`:""}
            </div>
        </div>
    </div>
</section>`

export async function showDetails(ctx){
    const id = ctx.params.id;
    const post = await getById(id);
    const user = getUserData();
    ctx.render(detailsTemplate(post, user, onDelete))

    async function onDelete(e){
        e.preventDefault();
        const toDelete = confirm("Are you sure??")
        if(toDelete){
            del("/data/posts/" + id)
            ctx.page.redirect("/")
        } 
    }
}