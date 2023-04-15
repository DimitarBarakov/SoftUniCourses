import { page, render } from "./lib.js";
import { showCatalog } from "./views/catalogView.js";
import { showCreate } from "./views/createView.js";
import { showDetails } from "./views/detailsView.js";
import { showEdit } from "./views/editView.js";
import { showHome } from "./views/homeView.js";
import { showLogin } from "./views/loginView.js";
import { updateNav } from "./views/nav.js";
import { showRegister } from "./views/registerView.js";

const main = document.getElementById("main-content")

page(decorateContext)
page("/", showHome)
page("/home", showHome)
page("/catalog", showCatalog)
page("/catalog/:id", showDetails)
page("/login", showLogin)
page("/register", showRegister)
page("/create", showCreate)
page("/edit/:id", showEdit)

updateNav()
page.start();

function decorateContext(ctx, next){
    ctx.render = renderMain;
    next();
}

function renderMain(content){
    render(content, main);
}