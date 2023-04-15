import { getById } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";
import { del } from "../api/api.js";

const detailsTemplate = (album, user, onDelete)=>html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src=${album.imgUrl}>
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${album.name}</h1>
                <h3>Artist: ${album.artist}</h3>
                <h4>Genre: ${album.genre}</h4>
                <h4>Price:${album.price}</h4>
                <h4>Date: ${album.releaseDate}</h4>
                <p>${album.description}</p>
            </div>
            ${user && user.id == album._ownerId?html`<div class="actionBtn">
                <a href="/edit/${album._id}" class="edit">Edit</a>
                <a @click = ${onDelete} href="javascript:void(0)" class="remove">Delete</a>
            </div>`:""}
        </div>
    </div>
</section>`

export async function showDetails(ctx){
    const id = ctx.params.id;
    const album = await getById(id);
    const user = getUserData();
    ctx.render(detailsTemplate(album, user, onDelete));

    async function onDelete(e){
        e.preventDefault();
        const toDelete = confirm("Are you sure!!")
        if(toDelete){
            del('/data/albums/' + id);
            ctx.page.redirect('/catalog')
        }
    }
}