import {showHomePage} from "./homePage.js";
document.getElementById('form-sign-up').addEventListener("submit", onRegister)

async function onRegister(event){
     event.preventDefault();
     let formData = new FormData(event.target)
     let {email, password, repeatPassword} = Object.fromEntries(formData.entries())
     if (!email || password.length < 6 || password !== repeatPassword){
         console.alert("Try Again")
         email.value = "";
         password.value = "";
         repeatPassword.value = "";
     }
     else{
         showHomePage();
         await register(email,password)
     }
}

async function register(email,password){
    const response = await fetch('http://localhost:3030/users/register',{
        method: 'post',
        headers:{
            "Content-Type": "application/json"
        },
        body:JSON.stringify({email,password})
    })
}

export function showRegisterPage(){
    let homePageSection = document.getElementById('home-page');
    let addMovieSection = document.getElementById('add-movie');
    let editMovieSection = document.getElementById('edit-movie');
    let loginSection = document.getElementById('form-login');
    let registerSection = document.getElementById('form-sign-up');
    addMovieSection.style.display = 'none'
    editMovieSection.style.display = 'none'
    loginSection.style.display = 'none'
    homePageSection.style.display = 'none'
    registerSection.style.display = 'block'
}