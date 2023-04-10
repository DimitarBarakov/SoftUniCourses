document.getElementById('register-form').addEventListener("submit", register)

async function register(event){
    event.preventDefault();
    const formData = new FormData(event.target);
    const {email, password, rePass} = Object.fromEntries(formData)

    const response = await fetch('http://localhost:3030/users/register',{
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({email, password})
    })
    const data = await response.json();
    window.location = 'index.html'
}