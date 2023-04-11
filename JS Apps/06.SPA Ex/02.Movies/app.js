import {showHomePage} from "./homePage.js"
import {showRegisterPage} from './register.js'
import {showLoginPage} from "./login.js";

let navList = document.getElementsByClassName('navbar-nav')[0];
let registerLink = navList.getElementsByTagName('li')[3];
let loginLink = navList.getElementsByTagName('li')[2];
registerLink.addEventListener('click', showRegisterPage)
loginLink.addEventListener('click', showLoginPage)
showHomePage();