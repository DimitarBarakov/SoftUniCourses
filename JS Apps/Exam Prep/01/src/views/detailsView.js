
import { del } from "../api/api.js";
import { getById } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (pet, user, isOwner, deletePet) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${pet.image}>
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: 0$</h4>
            </div>
            <!-- if there is no registered user, do not display div-->
            ${user?html`
            <div class="actionBtn">
                ${isOwner?html`<a href="#" class="edit">Edit</a>
                <a @click = ${deletePet} href="javascript:void(0)" class="remove">Delete</a>`
                :html`<a href="#" class="donate">Donate</a>`}
            </div>`:""}
        </div>
    </div>
</section>`;



export async function showDetails(ctx){
    async function deletePet(e){
        e.preventDefault();
        await del(`/data/pets/${id}`)
    }

    const id = ctx.params.id;
    const pet = await getById(id);
    const user = await getUserData();
    const isOwner = Boolean(pet._ownerId == user.id)
    ctx.render(detailsTemplate(pet, user, isOwner, deletePet))

    
}