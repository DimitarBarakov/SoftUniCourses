import { logout } from "../api/user.js";
import { html,render,page } from "../lib.js";
import { getUserData } from "../util.js";

const nav = document.querySelector('nav')

const navT = (user, onLogout) => html`
<div>
    <a href="/dashboard">Dashboard</a>
</div>
${
    user?html`
    <div class="user">
    <a href="/create">Add Album</a>
    <a @click = ${onLogout} href="javascript:void(0)">Logout</a>
  </div>
  </div>`:html`<div class="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
   </div>`
}`;


export async function showNav(){
    const user = getUserData();
    render(navT(user, onLogout),nav)

    async function onLogout(e){
        e.preventDefault();
        await logout();
        showNav();
        page.redirect('/dashboard')
    }
}