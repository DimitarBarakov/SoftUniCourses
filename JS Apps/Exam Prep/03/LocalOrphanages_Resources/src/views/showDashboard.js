import { getAllPosts } from "../api/data.js";
import { html,render } from "../lib.js";

const dashboardTemplate = (posts, postCard) => html`
<section id="dashboard-page">
    <h1 class="title">All Posts</h1>
    ${posts.length == 0?html`<h1 class="title no-posts-title">No posts yet!</h1>`
    :html`
    <div class="all-posts">
    ${posts.map(postCard)}
    </div>`}  
</section>`

export async function showDashboard(ctx){
    const posts = await getAllPosts();
    ctx.render(dashboardTemplate(posts, postCard));
}

const postCard = (post) => html`
<div class="post">
            <h2 class="post-title">${post.title}</h2>
            <img class="post-image" src=${post.imageUrl} alt="Material Image">
            <div class="btn-wrapper">
                <a href="/dashboard/${post._id}" class="details-btn btn">Details</a>
            </div>
        </div>`