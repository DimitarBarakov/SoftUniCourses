import { logout } from "../api/user.js";
import { html,render,page } from "../lib.js";
import { getUserData } from "../util.js";

const nav = document.querySelector('nav')

const navTemplate = (user, onLogout) => html`
<div>
  <a href="/dashboard">Dashboard</a>
  <a href="#">Search</a>
</div>
${
    user?html`
    <div class="user">
        <a href="/addPair">Add Pair</a>
        <a @click = ${onLogout} href="javascript:void(0)">Logout</a>
    </div>`:html`<div class="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>`
}`;


export async function updateNav(){
    const user = getUserData();
    render(navTemplate(user, onLogout),nav)

    async function onLogout(e){
        e.preventDefault();
        await logout();
        updateNav();
        page.redirect('/dashboard')
    }
}