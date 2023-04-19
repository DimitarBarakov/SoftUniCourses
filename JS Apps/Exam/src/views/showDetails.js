import { del } from "../api/api.js";
import { getById } from "../api/data.js";
import { html, nothing } from "../lib.js";
import { getUserData } from "../util.js";

const details = (song, user, onDelete) => html`
<section id="details">
<div id="details-wrapper">
<p id="details-title">Album Details</p>
      <div id="img-wrapper">
        <img src=${song.imageUrl} alt="example1" />
      </div>
      <div id="info-wrapper">
        <p><strong>Band:</strong><span id="details-singer">${song.singer}</span></p>
        <p>
          <strong>Album name:</strong><span id="details-album">${song.album}</span>
        </p>
        <p><strong>Release date:</strong><span id="details-release">${song.release}</span></p>
        <p><strong>Label:</strong><span id="details-label">${song.label}</span></p>
        <p><strong>Sales:</strong><span id="details-sales">${song.sales}</span></p>
      </div>
      <div id="likes">Likes: <span id="likes-count">0</span></div>
  <div id="action-buttons">
      ${user.id === song._ownerId?html`
      <a href="/edit/${song._id}" id="edit-btn">Edit</a>
      <a @click = ${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>`:
    nothing
    }
    </div>
</div>
</section>`


export async function showDetailsView(ctx){
    const id = ctx.params.id;
    const song = await getById(id)
    const user = await getUserData();
    ctx.render(details(song, user, onDelete))

    async function onDelete(e){
        e.preventDefault();
        const conf = confirm("Siguren li si?")
        if(conf){
            del("/data/albums/" + id)
            ctx.page.redirect("/dashboard")
        }
        
    }
} 