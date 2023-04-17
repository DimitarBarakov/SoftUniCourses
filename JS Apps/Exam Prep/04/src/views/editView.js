import { put } from "../api/api.js";
import { getById } from "../api/data.js";
import { html } from "../lib.js";

const editTemplate = (post, onEdit) => html`<section id="edit">
<div class="form">
  <h2>Edit item</h2>
  <form @submit = ${onEdit} class="edit-form">
    <input
      type="text"
      name="brand"
      id="shoe-brand"
      placeholder="Brand"
      .value = ${post.brand}
    />
    <input
      type="text"
      name="model"
      id="shoe-model"
      placeholder="Model"
      .value = ${post.model}
    />
    <input
      type="text"
      name="imageUrl"
      id="shoe-img"
      placeholder="Image url"
      .value = ${post.imageUrl}
    />
    <input
      type="text"
      name="release"
      id="shoe-release"
      placeholder="Release date"
      .value = ${post.release}
    />
    <input
      type="text"
      name="designer"
      id="shoe-designer"
      placeholder="Designer"
      .value = ${post.designer}
    />
    <input
      type="text"
      name="value"
      id="shoe-value"
      placeholder="Value"
      .value = ${post.value}
    />

    <button type="submit">post</button>
  </form>
</div>
</section>`

export async function showEdit(ctx){
    const id = ctx.params.id;
    const post = await getById(id)
    ctx.render(editTemplate(post, onEdit));
    async function onEdit(e){
        e.preventDefault();
        const formData = new FormData(e.target);
        const {brand, model, imageUrl, release, designer, value} = Object.fromEntries(formData);

        if(!brand || !model || !imageUrl || !release || !designer || !value){
            return alert("All fields are required!!!")
        }
        await put('/data/shoes/' + id, {brand, model, imageUrl, release, designer, value});
        ctx.page.redirect('/dashboard')
    }
}