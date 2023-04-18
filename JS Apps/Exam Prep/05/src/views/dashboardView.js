import { getAllPosts } from "../api/data.js";
import { html } from "../lib.js";

const dashboardTemplate = (posts,postCard) => html`
  <section id="dashboard">
  <h2>Job Offers</h2>
    ${
        posts.length === 0?html`<h2>No offers yet.</h2>`
        :html`
            ${posts.map(postCard)}`
    }
  </section>`

export async function showDashboard(ctx){
    const posts = await getAllPosts();
    ctx.render(dashboardTemplate(posts,postCard));
}

const postCard = (post) => html`
<div class="offer">
      <img src=${post.imageUrl} alt="./images/example3.png" />
      <p>
        <strong>Title: </strong
        ><span class="title">${post.title}</span>
      </p>
      <p><strong>Salary:</strong><span class="salary">${post.salary}</span></p>
      <a class="details-btn" href="/details/${post._id}">Details</a>
    </div>`;