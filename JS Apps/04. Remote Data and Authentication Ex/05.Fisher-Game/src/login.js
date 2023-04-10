let loginForm = document.getElementById('login-form')
loginForm.addEventListener("submit", login)

async function login(event){
    event.preventDefault();

    let formData = new FormData(event.target)
    let {email,password} = Object.fromEntries(formData)

    const response = await fetch('http://localhost:3030/users/login',{
        method: "post",
        headers: {
            'Content-Type': 'application.json'
        },
        body:JSON.stringify({email,password})
    });

    const data = await response.json()
    sessionStorage.setItem('accessToken', data.accessToken)
    window.location = "index.html"
}