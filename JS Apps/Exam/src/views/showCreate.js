import { post } from "../api/api.js";
import { html } from "../lib.js";

const create = (onCreate) => html`
<section id="create">
    <div class="form">
      <h2>Add Album</h2>
      <form @submit = ${onCreate} class="create-form">
        <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
        <input type="text" name="album" id="album-album" placeholder="Album" />
        <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
        <input type="text" name="release" id="album-release" placeholder="Release date" />
        <input type="text" name="label" id="album-label" placeholder="Label" />
        <input type="text" name="sales" id="album-sales" placeholder="Sales" />

        <button type="submit">post</button>
      </form>
    </div>
  </section>`

export function showCreateView(ctx){
    ctx.render(create(onCreate));
    async function onCreate(e){
        e.preventDefault();
        const formData = new FormData(e.target);
        const {singer, album, imageUrl, release, label, sales} = Object.fromEntries(formData);

        if(!singer || !album || !imageUrl || !release || !label || !sales){
            return alert("Wsichi poleta sa zadyljitelni!!")
        }
        await post('/data/albums', {singer, album, imageUrl, release, label, sales});
        ctx.page.redirect('/dashboard')
    }
} 