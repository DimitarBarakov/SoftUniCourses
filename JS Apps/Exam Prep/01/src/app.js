import {page, render, html} from './lib.js'
import { getUserData } from './util.js';
import { showCreate } from './views/createView.js';
import { showDashboard } from './views/dashboardView.js';
import { showDetails } from './views/detailsView.js';
import { showHome } from './views/homeView.js';
import { showLogin } from './views/loginView.js';
import { showRegister } from './views/registerView.js';

const main = document.getElementById('content')
updateNav();
page(decorateContext);
page('/', showHome)
page('/dashboard', showDashboard)
page('/dashboard/:id', showDetails)
page('/login', showLogin)
page('/register', showRegister)
page('/create', showCreate)

page.start();

function decorateContext(ctx,next){
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    next();
}
function renderMain(content){
    render(content, main)
}

function updateNav(){
    const navTemplate = (user)=>html`
    <li><a href="/">Home</a></li>
    <li><a href="/dashboard">Dashboard</a></li>
    ${user?html`<li><a href="/create">Create Postcard</a></li>
        <li><a href="javascript:void(0)">Logout</a></li>`
        :html`
        <li><a href="/login">Login</a></li>
        <li><a href="/register">Register</a></li>`}
`
    const ul = document.querySelector('ul');
    const user = getUserData();
    render(navTemplate(user),ul)
}