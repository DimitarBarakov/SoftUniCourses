import {showHomePage} from "./homePage";

let loginForm = document.getElementById('form-login').addEventListener("submit", onLogin)

async function onLogin(event){
    event.preventDefault();
    let formData = new FormData(event.target)
    let {email, password} = Object.fromEntries(formData.entries())
    await login(email,password)
    showHomePage();
}

async function login(email,password){
    const response = await fetch('http://localhost:3030/users/login',{
        method:'post',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({email,password})
    });
    const data = await response.json();
    sessionStorage.setItem('email', data.email)
    sessionStorage.setItem('accessToken', data.accessToken)

}


export function showLoginPage(){
    let homePageSection = document.getElementById('home-page');
    let addMovieSection = document.getElementById('add-movie');
    let editMovieSection = document.getElementById('edit-movie');
    let loginSection = document.getElementById('form-login');
    let registerSection = document.getElementById('form-sign-up');
    addMovieSection.style.display = 'none'
    editMovieSection.style.display = 'none'
    loginSection.style.display = 'block'
    homePageSection.style.display = 'none'
    registerSection.style.display = 'none'
}