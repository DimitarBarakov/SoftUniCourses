import {page, render} from "./lib.js"
import { showCreate } from "./views/createView.js";
import { showDetails } from "./views/detailsView.js";
import { showEdit } from "./views/editView.js";
import { showLogin } from "./views/loginView.js";
import { showMyPosts } from "./views/myPostsView.js";
import { updateNav } from "./views/navView.js";
import { showRegister } from "./views/registerView.js";
import { showDashboard } from "./views/showDashboard.js";

const main = document.getElementById("main-content");

page(decorateContext);
page("/", showDashboard)
page("/dashboard", showDashboard)
page('/dashboard/:id', showDetails)
page('/login', showLogin)
page("/register", showRegister)
page('/create', showCreate)
page("/edit/:id", showEdit)
page("/myPosts", showMyPosts)

updateNav();
page.start();

function decorateContext(ctx, next){
    ctx.render = renderMain;
    next();
}

function renderMain(content){
    render(content, main);
}