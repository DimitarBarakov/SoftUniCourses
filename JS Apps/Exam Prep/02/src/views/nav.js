import { logout } from "../api/user.js";
import { html,render } from "../lib.js";
import { getUserData } from "../util.js";
import {page} from "../lib.js";

const nav = document.querySelector("nav");

const navTemplate = (user, onLogout) => html`
<img src="./images/headphones.png">
<a href="/">Home</a>
<ul>
    <li><a href="/catalog">Catalog</a></li>
    <li><a href="#">Search</a></li>
    ${user?html`
    <li><a href="/create">Create Album</a></li>
    <li><a @click = ${onLogout} href="javascript:void(0)">Logout</a></li>`
    :html`
    <li><a href="/login">Login</a></li>
    <li><a href="/register">Register</a></li>`}
</ul>`

export function updateNav(ctx){
    const user = getUserData();
    render(navTemplate(user,onLogout), nav)


    async function onLogout(e){
        e.preventDefault();
        await logout();
        page.redirect('/')
        updateNav();
    }
}