import { get } from "../api/api.js";
import { html } from "../lib.js";
import { getUserData } from "../util";

const myPostsTemplate = (posts, postCard) => html`
<section id="dashboard-page">
    <h1 class="title">All Posts</h1>
    ${posts.length == 0?html`<h1 class="title no-posts-title">You have no posts yet!</h1>`
    :html`
    <div class="all-posts">
    ${posts.map(postCard)}
    </div>`}  
</section>`

export async function showMyPosts(ctx){
    const user = await getUserData();
    const posts = get(`/data/posts?where=_ownerId%3D%22${user.id}%22&sortBy=_createdOn%20desc`);
    ctx.render(myPostsTemplate(posts, postCard));
}

const postCard = (post) => html`
<div class="post">
    <h2 class="post-title">${post.title}</h2>
    <img class="post-image" src=${post.imageUrl} alt="Material Image">
     <div class="btn-wrapper">
        <a href="/dashboard/${post._id}" class="details-btn btn">Details</a>
    </div>
</div>`