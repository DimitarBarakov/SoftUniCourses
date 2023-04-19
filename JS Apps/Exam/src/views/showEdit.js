import { put } from "../api/api.js";
import { getById } from "../api/data.js";
import { html } from "../lib.js";

const edit = (song, onEdit) => html`
  <section id="edit">
    <div class="form">
      <h2>Edit Album</h2>
      <form @submit = ${onEdit} class="edit-form">
        <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" .value = ${song.singer} />
        <input type="text" name="album" id="album-album" placeholder="Album" .value = ${song.album} />
        <input type="text" name="imageUrl" id="album-img" placeholder="Image url" .value = ${song.imageUrl} />
        <input type="text" name="release" id="album-release" placeholder="Release date" .value = ${song.release} />
        <input type="text" name="label" id="album-label" placeholder="Label" .value = ${song.label} />
        <input type="text" name="sales" id="album-sales" placeholder="Sales" .value = ${song.sales} />

        <button type="submit">post</button>
      </form>
    </div>
  </section>`

export async function showEditView(ctx){
    const id = ctx.params.id;
    const song = await getById(id)
    ctx.render(edit(song, onEdit));
    async function onEdit(e){
        e.preventDefault();
        const formData = new FormData(e.target);
        const {singer, album, imageUrl, release, label, sales} = Object.fromEntries(formData);

        if(!singer || !album || !imageUrl || !release || !label || !sales){
            return alert("Wsichi poleta sa zadyljitelni!!!")
        }
        await put('/data/albums/' + id, {singer, album, imageUrl, release, label, sales});
        ctx.page.redirect('/dashboard')
    }
}