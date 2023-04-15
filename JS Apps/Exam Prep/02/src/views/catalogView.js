import { getAllAlbums } from "../api/data.js";
import { html, render } from "../lib.js";
import { getUserData } from "../util.js";



const catalogTemplate = (albums, user) => html`
<section id="catalogPage">
    <h1>All Albums</h1>
    ${albums.length === 0 
    ?html`<p>No Albums in Catalog!</p>`
    :albums.map(a => albumCard(a,user))}
</section>`

export async function showCatalog(ctx){
    const user = getUserData();
    const albums = await getAllAlbums();
    ctx.render(catalogTemplate(albums,user));
}

const albumCard = (album, user) => html`
<div class="card-box">
        <img src=${album.imgUrl}>
        <div>
            <div class="text-center">
                <p class="name">Name: ${album.name}</p>
                <p class="artist">Artist: ${album.artist}</p>
                <p class="genre">Genre: ${album.genre}</p>
                <p class="price">Price: ${album.price}</p>
                <p class="date">Release Date: ${album.releaseDate}</p>
            </div>
            ${user?
            html`<div class="btn-group">
                <a href="/catalog/${album._id}" id="details">Details</a>
            </div>`:""}
            
        </div>
    </div>`