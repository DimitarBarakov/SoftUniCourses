import page from "../node_modules/page/page.mjs";
import { catalogView } from "./views/catalog.js";
import { createView } from "./views/create.js";
import { loginView } from "./views/login.js";
import { myFurnitureView } from "./views/myFurniture.js";
import { registerView } from "./views/register.js";

console.log("Kur")

page("/",catalogView)
page("/catalog",catalogView)
page("/create",createView)
page("/dashboard",catalogView)
page("/details/:id",catalogView)
page("/edit/:id",catalogView)
page("/login",loginView)
page("/register",registerView)
page("/my-furniture",myFurnitureView)

page.start()