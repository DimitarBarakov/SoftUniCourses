let homePageSection = document.getElementById('home-page');
let addMovieSection = document.getElementById('add-movie');
let editMovieSection = document.getElementById('edit-movie');
let loginSection = document.getElementById('form-login');
let registerSection = document.getElementById('form-sign-up');

export function showHomePage(){
    addMovieSection.style.display = 'none'
    editMovieSection.style.display = 'none'
    loginSection.style.display = 'none'
    registerSection.style.display = 'none'
    homePageSection.style.display = 'block'
}
