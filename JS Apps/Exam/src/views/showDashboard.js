import { getAllAlbums } from "../api/data.js";
import { html } from "../lib.js";

const dashboard = (songs,songView) => html`
<section id="dashboard">
  <h2>Albums</h2>
    ${
        songs.length === 0?html`
        <h2>There are no albums added yet.</h2>`
        :html`
        <ul class="card-wrapper">
            ${songs.map(songView)}
        </ul>`
    }
</section>`

export async function showDashboardView(ctx){
    const songs = await getAllAlbums();
    ctx.render(dashboard(songs,songView));
}

const songView = (song) => html`
<li class="card">
  <img src=${song.imageUrl} alt="travis" />
  <p>
    <strong>Singer/Band: </strong><span class="singer">${song.singer}</span>
  </p>
  <p>
    <strong>Album name: </strong><span class="album">${song.album}</span>
  </p>
  <p><strong>Sales:</strong><span class="sales">${song.sales}</span></p>
  <a class="details-btn" href="/details/${song._id}">Details</a>
</li>`;