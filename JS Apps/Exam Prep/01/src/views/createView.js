import { post } from "../api/api.js";
import { html } from "../lib.js";

const createTemplate = (create) => html`
<section id="createPage">
    <form @submit = ${create} class="createForm">
        <img src="./images/cat-create.jpg">
        <div>
            <h2>Create PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" placeholder="Max">
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" placeholder="Shiba Inu">
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" placeholder="2 years">
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" placeholder="5kg">
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" placeholder="./image/dog.jpeg">
            </div>
            <button class="btn" type="submit">Create Pet</button>
        </div>
    </form>
</section>
`

export function showCreate(ctx){
    function create(e){
        e.preventDefault();
        const formData = new FormData(e.target);
        const {name, breed, age, weight, image} = Object.fromEntries(formData);
        if(!name||!breed||!age||!weight||!image){
            return alert("All fields are required!!!")
        }
        post('/data/pets', {name, breed, age, weight, image})
        ctx.page.redirect('/');
    }

    ctx.render(createTemplate(create))
}