import { logout } from "../api/user.js";
import { html,render,page } from "../lib.js";
import { getUserData } from "../util.js";

const nav = document.querySelector('nav');

const navTemplate = (user, onLogout) => html`
<a href="/">Dashboard</a>

${
    user?html`
        <div id="user">
            <a href="/myPosts">My Posts</a>
            <a href="/create">Create Post</a>
            <a @click = ${onLogout} href="javascript:void(0)">Logout</a>
        </div>`:html`
        <div id="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>`
}`
export async function updateNav(){
    const user = getUserData();
    render(navTemplate(user, onLogout),nav)
}

async function onLogout(e){
    e.preventDefault();
    await logout()
    updateNav();
    page.redirect('/');
}