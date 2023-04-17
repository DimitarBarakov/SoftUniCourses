import {page, render} from "./lib.js";
import { showCreate } from "./views/createView.js";
import { showDashboard } from "./views/dashboardView.js";
import { showDetails } from "./views/detailsView.js";
import { showEdit } from "./views/editView.js";
import { showLogin } from "./views/loginView.js";
import { updateNav } from "./views/navView.js";
import { showRegister } from "./views/registerView.js";
import { showHome } from "./views/showHome.js";

const main = document.querySelector('main')

page(decorateContext)
page('/', showHome)
page('/login', showLogin)
page('/register', showRegister)
page('/dashboard', showDashboard)
page('/details/:id', showDetails)
page("/addPair", showCreate)
page('/edit/:id', showEdit)

updateNav()
page.start()

function decorateContext(ctx, next){
    ctx.render = renderMain;
    next();
}

function renderMain(content){
    render(content, main);
}