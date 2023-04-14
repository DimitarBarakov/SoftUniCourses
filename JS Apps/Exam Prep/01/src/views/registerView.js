import { register } from "../api/user.js";
import { html } from "../lib.js";

const registerTemplate = (onRegister) => html`
<section id="registerPage">
    <form @submit = ${onRegister} class="registerForm">
        <img src="./images/logo.png" alt="logo" />
        <h2>Register</h2>
        <div class="on-dark">
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
        </div>

        <div class="on-dark">
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" placeholder="********" value="">
        </div>

        <div class="on-dark">
            <label for="repeatPassword">Repeat Password:</label>
            <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
        </div>

        <button class="btn" type="submit">Register</button>

        <p class="field">
            <span>If you have profile click <a href="/login">here</a></span>
        </p>
    </form>
</section>
`

export function showRegister(ctx){
    ctx.render(registerTemplate(onRegister));
    async function onRegister(e){
        e.preventDefault();
        const formData = new FormData(e.target);
        const {email, password, repeatPassword} = Object.fromEntries(formData);
        if(!email || !password){
            return alert("All fields are required!!!")
        }
        if(password !== repeatPassword){
            return alert("Passwords dont match!!!")
        }
        await register(email, password);
        ctx.page.redirect('/')
        ctx.updateNav();
    }
}