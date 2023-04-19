import {page, render} from "./lib.js";
import { showCreateView } from "./views/showCreate.js";
import { showDashboardView } from "./views/showDashboard.js";
import { showDetailsView } from "./views/showDetails.js";
import { showEditView } from "./views/showEdit.js";
import { showLoginView } from "./views/showLogin.js";
import { showNav } from "./views/showNav.js";
import { showRegisterView } from "./views/showRegister.js";
import { showHomeView } from "./views/showHome.js";

const main = document.querySelector('main')

page(decorateContext)
page('/',showHomeView)
page('/dashboard', showDashboardView)
page('/login', showLoginView)
page('/register', showRegisterView)
page('/create', showCreateView)
page('/details/:id', showDetailsView)
page('/edit/:id', showEditView)



showNav()
page.start()

function decorateContext(ctx, next){
    ctx.render = renderMain;
    next();
}

function renderMain(content){
    render(content, main);
}