import { register } from "../api/user.js";
import { html } from "../lib.js";
import { showNav } from "./showNav.js";

const registerT = (onRegister) => html`
  <section id="register">
    <div class="form">
      <h2>Register</h2>
      <form @submit = ${onRegister} class="login-form">
        <input type="text" name="email" id="register-email" placeholder="email" />
        <input type="password" name="password" id="register-password" placeholder="password" />
        <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
        <button type="submit">register</button>
        <p class="message">Already registered? <a href="/login">Login</a></p>
      </form>
    </div>
  </section>`

export function showRegisterView(ctx){
    ctx.render(registerT(onRegister))

    async function onRegister(e){
        e.preventDefault();
        const formData = new FormData(e.target);
        const data = Object.fromEntries(formData);
        if(!data.email || !data.password || !data['re-password']){
            return alert("Wsichi poleta sa zadyljitelni!")
        }
        if(data.password !== data['re-password']){
            return alert("Razlichni paroli")
        }
        await register(data.email, data.password);
        showNav();
        ctx.page.redirect('/dashboard')
    }
}